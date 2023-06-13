using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: h1BetCheck
    /// </summary>
    public static void h1BetCheck()
    {
        _ = App.Command("h1-bet-check", command =>
        {
            // 第二層 Help 的標題
            command.Description = "h1 Bet Check 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {


                return 0;
            });
        });
    }
}