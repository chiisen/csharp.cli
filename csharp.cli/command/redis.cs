using csharp.cli.helper;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: redis
    /// </summary>
    public static void Redis()
    {
        _ = App.Command("redis", command =>
        {
            // 第二層 Help 的標題
            command.Description = "redis 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                // 假設要寫入的 Hash 鍵為 "user:1000"
                int clubId = 1000;

                for (int i = 0; i < 3; ++i)
                {
                    string hashKey = $"AlertAccount:{clubId + i}";
                    // 要寫入的 HashEntry 資料
                    var hashEntries = new HashEntry[]
                    {
                        // 現在時間轉為 yyyy-mm-dd hh:mm:ss 格式
                        new HashEntry("login", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        new HashEntry("playGame", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    RedisHelper.HashSet(hashKey, hashEntries);

                    // 確認寫入成功，讀取並輸出所有資料
                    HashEntry[] storedEntries = RedisHelper.HashGetAll(hashKey);
                    foreach (var entry in storedEntries)
                    {
                        Console.WriteLine($"{entry.Name}: {entry.Value}");
                    }
                }

                /*
                var data = RedisHelper.GetValue<string>("Summaries");
                if (string.IsNullOrEmpty(data))
                {
                    Console.WriteLine($"empty data", Color.Red);
                    return 1;
                }
                var ret = JsonConvert.DeserializeObject<string>(data!);
                Console.WriteLine($"{ret}", Color.Azure);
                */

                return 0;
            });
        });
    }
}
