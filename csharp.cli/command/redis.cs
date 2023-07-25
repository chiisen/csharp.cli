using csharp.cli.helper;
using Newtonsoft.Json;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example0
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
                var data = RedisHelper.GetValue<string>("Summaries");
                if (data == string.Empty)
                {
                    Console.WriteLine($"empty data", Color.Red);
                    return 1;
                }
                var ret = JsonConvert.DeserializeObject<string>(data!);

                Console.WriteLine($"{ret}", Color.Azure);
                return 0;
            });
        });
    }
}