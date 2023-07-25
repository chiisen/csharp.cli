﻿using csharp.cli.common;
using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Reflection.Metadata;
using Color = System.Drawing.Color;
using Console = Colorful.Console;

namespace csharp.cli;

/// <summary>
/// addGames 的 Redis 設定資訊
/// </summary>
public class addGamesRedisInfo
{
    public string csvPath { get; set; }
    public string localCode { get; set; }
}

public partial class Program
{
    /// <summary>
    /// 新增遊戲(參數太多，需要配合 Redis)
    /// 命令列引數: add-games "C:/royal/gitlab/adminapi_core5/AdminAPI_Core5/StaticFile/json/PWAWebSiteSlotGameJOKER.json"
    /// </summary>
    /*
    Redis 範例:
    {
        "csvPath": "C:/Users/sam/Downloads/JOKER.csv",
        "localCode": "Game_JOKER_"
    }
    */
    public static void addGames()
    {
        _ = App.Command("add-games", command =>
        {
            // 第二層 Help 的標題
            command.Description = "add-games 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var path = command.Argument("[jsonPaths]", "指定檔案路徑。");

            command.OnExecute(() =>
            {
                Console.WriteLine($"add-games", Color.Azure);

                var jsonPath = path.HasValue ? path.Value : null;
                if (jsonPath == null)
                {
                    Console.WriteLine($"null jsonPath");
                    return 1;
                }

                string? jsonText = null;
                try
                {
                    jsonText = File.ReadAllText(jsonPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e}", Color.Yellow);
                }
                if (jsonText is null)
                {
                    Console.WriteLine($"null jsonText", Color.Red);
                    return 1;
                }

                var record = Common.JsonDeserialize<List<PWAWebSiteTableGame>>(jsonText);
                if (record is null)
                {
                    Console.WriteLine($"null record");
                    return 1;
                }

                // TODO: 新增遊戲需要參考 csv 設定檔案，代補全
                var gameList = new List<PWAWebSiteTableGame>();
                var addGame = record.FirstOrDefault();
                if (addGame != null)
                {
                    const string connectionString = "127.0.0.1:6379, abortConnect=false, connectRetry=5, connectTimeout=5000, syncTimeout=5000";
                    var options = ConfigurationOptions.Parse(connectionString);
                    options.AllowAdmin = true;
                    options.ReconnectRetryPolicy = new ExponentialRetry(3000);

                    IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(options);
                    var redis = connectionMultiplexer.GetDatabase(0);

                    const string cacheKey = "add-games";
                    var data = redis.StringGet(cacheKey);
                    if (data == RedisValue.EmptyString)
                    {
                        Console.WriteLine($"empty data", Color.Red);
                        return 1;
                    }

                    var info = data.HasValue ? JsonConvert.DeserializeObject<addGamesRedisInfo>(data!) : default;
                    if (info.csvPath is null)
                    {
                        Console.WriteLine($"null info.csvPath");
                        return 1;
                    }
                    Console.WriteLine($"讀取 csv 設定檔案: {info.csvPath}");
                    
                    var list = CsvHelper.GetCsv(info.csvPath);
                    var count = 0;
                    foreach (var d in list)
                    {
                        var sort = d[(int)common.Enum.AddGames.Sort].ToString();
                        var gameId = d[(int)common.Enum.AddGames.GameId].ToString();
                        var gameName = d[(int)common.Enum.AddGames.GameName].ToString();

                        var newGame = addGame.Clone();
                        newGame.id = gameId;
                        newGame.imageName = gameId;
                        newGame.name = gameName;
                        newGame.sort = int.Parse(sort);
                        newGame.localizationCode = $"{info.localCode}{gameId}";

                        gameList.Add(newGame);

                        Console.WriteLine($"addgame: [{count}] {gameId} {gameName}");
                        count++;
                    }
                }

                var json = JsonConvert.SerializeObject(gameList, Formatting.Indented);// 格式化後寫入
                try
                {
                    File.WriteAllText(jsonPath + ".newGames", json);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                    throw;
                }

                return 0;
            });
        });
    }
}