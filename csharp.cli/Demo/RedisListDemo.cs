using csharp.cli.helper;
using Spectre.Console;

namespace csharp.cli.Demo
{
    /// <summary>
    /// Redis List 範例
    /// </summary>
    public class RedisListDemo
    {
        public static void Run()
        {
            AnsiConsole.MarkupLine($"[red]RedisListDemo.[/]");

            // 假設要寫入的 List 鍵為 "user:messages"
            string listKey = "userList:messages";

            // 要寫入的 List 資料
            var messages = new string[]
            {
                "Hello, World!",
                "Welcome to Redis",
                "This is a list example"
            };

            // 將資料推入列表
            foreach (var message in messages)
            {
                RedisHelper.ListRightPush(listKey, message);
            }

            // 確認寫入成功，讀取並輸出所有資料
            long listLength = RedisHelper.ListLength(listKey);
            for (long i = 0; i < listLength; i++)
            {
                string? message = RedisHelper.ListGetByIndex(listKey, i);
                AnsiConsole.MarkupLine($"[green]Message {i + 1}: {message}.[/]");
            }
        }
    }
}
