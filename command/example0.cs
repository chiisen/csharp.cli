using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example0
    /// </summary>
    public static void Example0()
    {
        _ = App.Command("example0", command =>
        {
            // 第二層 Help 的標題
            command.Description = "example0 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                Console.WriteLine($"example0", Color.Azure);
                return 0;
            });
        });
    }
}