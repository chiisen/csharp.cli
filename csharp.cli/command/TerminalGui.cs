using Terminal.Gui;
using Console = Colorful.Console;
using Spectre.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// Terminal.Gui 範例程式
    /// 命令列引數: terminal-gui
    /// </summary>
    public static void TerminalGui()
    {
        _ = App.Command("terminal-gui", command =>
        {
            // 第二層 Help 的標題
            command.Description = "terminal-gui 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                // Terminal.Gui 範例
                Application.Init();

                var n = MessageBox.Query(50, 7,
                    "Question", "你喜歡介面操作嗎?", "Yes", "No");

                Application.Shutdown();

                var message = "";
                switch(n)
                {
                    case 0:
                        message = $"Yes({n})";
                        break;
                    case 1:
                        message = $"No({n})";
                        break;
                    default:
                        message = $"default({n})";
                        break;
                }                

                AnsiConsole.MarkupLine($"[red]n = {message}.[/]");

                return 0;
            });
        });
    }
}
