using csharp.cli.Demo;
using csharp.cli.helper;
using Newtonsoft.Json;
using Spectre.Console;
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
                var isUpdate = RedisHelper.CheckAndUpdateKeyAsync("test", "2");
                AnsiConsole.MarkupLine($"[green]是否更新 {isUpdate.ToString()}.[/]");

                RedisHashDemo.Run();
                RedisListDemo.Run();

                var data = RedisHelper.GetValue<string>("Summaries");
                if (string.IsNullOrEmpty(data))
                {
                    AnsiConsole.MarkupLine($"[red]empty data.[/]");
                    return 1;
                }
                var ret = JsonConvert.DeserializeObject<string>(data!);
                AnsiConsole.MarkupLine($"[green]n = {ret}.[/]");

                return 0;
            });
        });
    }
}


