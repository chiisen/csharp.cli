using csharp.cli.common;
using csharp.cli.helper;
using csharp.cli.model;
using Newtonsoft.Json;
using System.Diagnostics;
using static csharp.cli.common.Enum;
using Color = System.Drawing.Color;
using Console = Colorful.Console;

namespace csharp.cli;

/// <summary>
/// addGames 的 Redis 設定資訊
/// </summary>
public class AddGamesRedisInfo
{
    /// <summary>
    /// 廠商英文編號
    /// </summary>
    public string ThirdPartyId { get; set; }
    /// <summary>
    /// 新增遊戲的 csv 設定檔案
    /// </summary>
    public string CsvPath { get; set; }
    /// <summary>
    /// 翻譯代號
    /// </summary>
    public string LocalCode { get; set; }
    /// <summary>
    /// 原始的 Json 檔案路徑
    /// </summary>
    public string JsonPath { get; set; }
}

public partial class Program
{
    /// <summary>
    /// 新增遊戲(多數參數會由 Redis 上提供)
    /// 命令列引數: add-games "thirdPartyId 的英文代號"
    /// 指定要新增的遊戲清單，會產生對應的檔案
    /// </summary>
    /*
Redis 格式:
[
    {
        "ThirdPartyId": "JDB",
        "CsvPath": "C:/Users/sam/Downloads/JDB.csv",
        "LocalCode": "Game_JDB_",
        "JsonPath": "C:/royal/gitlab/APPAPI/adminapi_core5/AdminAPI_Core5/StaticFile/json/PWAWebSiteSlotGameJDB.json"
    }
]
    

    csv 格式：
    排序,遊戲代碼,遊戲名稱
    13,ue8mt39rhzpps,詛咒Deluxe
    14,uygm7axgh91qk,葉賢Deluxe

    */
    public static void addGames()
    {
        _ = App.Command("add-games", command =>
        {
            // 第二層 Help 的標題
            command.Description = "add-games 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var thirdPartyId = command.Argument("[ThirdPartyId]", "指定 ThirdPartyId");

            command.OnExecute(() =>
            {
                Console.WriteLine($"add-games", Color.Azure);

                var tpId = thirdPartyId.HasValue ? thirdPartyId.Value : null;
                if (tpId == null)
                {
                    Console.WriteLine($"沒有指定 json 的完整路徑與檔案名稱");
                    return 1;
                }

                // 讀取 Redis 的設定 (csharp.cli:add-games)

                var sw = Stopwatch.StartNew();

                const string redisKey = "add-games";
                var redisInfos = RedisHelper.GetValue<List<AddGamesRedisInfo>>(redisKey);

                sw.Stop();

                Console.WriteLine($"add-games - sw: {sw.ElapsedMilliseconds}", Color.Azure);

                if (redisInfos is null)
                {
                    Console.WriteLine($"Redis (csharp.cli:add-games) 設定為 null");
                    return 1;
                }

                // 取得 ThirdPartyId 對應的 Redis 設定
                var info = redisInfos.Where( x => x.ThirdPartyId.Trim().Equals(tpId)).Select( x => x).FirstOrDefault();
                if (info is null)
                {
                    Console.WriteLine($"Redis (csharp.cli:add-games) 找不到 {tpId} 的設定");
                    return 1;
                }

                // 讀取要新增遊戲的 CSV 設定檔案
                if (info.CsvPath is null)
                {
                    Console.WriteLine($"{tpId} 沒有 CsvPath 的設定");
                    return 1;
                }

                Console.WriteLine($"讀取 {tpId} 的 csv 設定檔案: {info.CsvPath}");

                var csvList = CsvHelper.GetCsv(info.CsvPath);
                if (csvList is null)
                {
                    Console.WriteLine($"{tpId} 讀取不到 CSV 內容");
                    return 1;
                }

                // 讀取原始的 json 檔案，新增遊戲是由原始加上新增的遊戲
                if (info.JsonPath is null)
                {
                    Console.WriteLine($"{tpId} 沒有 JSON 的設定");
                    return 1;
                }
                string? sourceJsonText = null;
                try
                {
                    sourceJsonText = File.ReadAllText(info.JsonPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e}", Color.Yellow);
                }
                if (sourceJsonText is null)
                {
                    Console.WriteLine($"{tpId} 讀取不到 JSON 的內容", Color.Red);
                    return 1;
                }

                // 轉換為對應的廠商格式
                switch (tpId)
                {
                    case "JDB":
                    {
                        var sourceJsonList = Common.JsonDeserialize<List<PWAWebSiteJDB>>(sourceJsonText);
                        if (sourceJsonList is null)
                        {
                            Console.WriteLine($"無法轉為 List");
                            return 1;
                        }

                        // 取的第一筆廠商資料做為新增遊戲的範本
                        var addGameTemplate = sourceJsonList.FirstOrDefault();
                        if (addGameTemplate is null)
                        {
                            Console.WriteLine($"無法取的一筆資料當範本");
                            return 1;
                        }

                        // 建立新增遊戲清單
                        var newGameList = new List<PWAWebSiteJDB>(sourceJsonList);
                        var count = 0;
                        foreach (var field in csvList)
                        {
                            var sort = field[(int)AddGamesCsvField.Sort].ToString();
                            var gameId = field[(int)AddGamesCsvField.GameId].ToString();
                            var gameName = field[(int)AddGamesCsvField.GameName].ToString();

                            var newGameItem = addGameTemplate.Clone();
                            newGameItem.id = gameId;
                            newGameItem.imageName = gameId;
                            newGameItem.name = gameName;
                            newGameItem.sort = int.Parse(sort);
                            newGameItem.localizationCode = $"{info.LocalCode}{gameId}";

                            // 判斷有沒有重複的遊戲代碼
                            var exist = newGameList.Where( x => x.id.Equals(gameId)).Select( x => x).FirstOrDefault();
                            if (exist is not null)
                            {
                                newGameList.Add(newGameItem);
                            }
                            else
                            {
                                Console.WriteLine($"重複的新增遊戲: [{count}] {gameId} {gameName}", Color.Red);
                            }

                            Console.WriteLine($"新增遊戲: [{count}] {gameId} {gameName}");
                            count++;
                        }

                        // 將新的遊戲清單寫入檔案
                        var newGameJson = JsonConvert.SerializeObject(newGameList, Formatting.Indented);// 格式化後寫入
                        try
                        {
                            var newGameJsonPath = @$"{System.Environment.CurrentDirectory}\{Path.GetFileNameWithoutExtension(info.JsonPath)}.newGames.json";

                            Console.WriteLine($"開始寫入 json 遊戲列表 {newGameJsonPath}");

                            File.WriteAllText(newGameJsonPath, newGameJson);

                            Console.WriteLine($"結束寫入 json 遊戲列表 {newGameJsonPath}");
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine(e);
                            throw;
                        }

                        break;
                    }
                    default:
                    {
                        Console.WriteLine($"無法處理 {tpId} 的 thirdPartyId 設定");
                        return 1;
                    }
                }

                return 0;
            });
        });
    }
}