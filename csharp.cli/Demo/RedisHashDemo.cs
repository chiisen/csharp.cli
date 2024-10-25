using csharp.cli.helper;
using Spectre.Console;
using StackExchange.Redis;

namespace csharp.cli.Demo
{
    /// <summary>
    /// Redis Hash 範例
    /// </summary>
    public class RedisHashDemo
    {
        public static void Run()
        {
            AnsiConsole.MarkupLine($"[red]RedisHashDemo.[/]");

            // 假設要寫入的 Hash 鍵為 "user:1000"
            int clubId = 1000;

            for (int i = 0; i < 3; ++i)
            {
                string hashKey = $"userHash:{clubId + i}";
                // 要寫入的 HashEntry 資料
                var hashEntries = new HashEntry[]
                {
                        // 現在時間轉為 yyyy-mm-dd hh:mm:ss 格式
                        new("login", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        new("playGame", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                RedisHelper.HashSet(hashKey, hashEntries);

                // 確認寫入成功，讀取並輸出所有資料
                HashEntry[] storedEntries = RedisHelper.HashGetAll(hashKey);
                foreach (var entry in storedEntries)
                {
                    AnsiConsole.MarkupLine($"[green]{entry.Name}: {entry.Value}.[/]");
                }
            }
        }
    }
}
