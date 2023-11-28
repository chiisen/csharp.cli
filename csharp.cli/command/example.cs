using McMaster.Extensions.CommandLineUtils;
using Terminal.Gui;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example "words" -r 10
    /// </summary>
    public static void Example()
    {
        _ = App.Command("example", command =>
        {
            // 第二層 Help 的標題
            command.Description = "example 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var wordsArgument = command.Argument("[words]", "指定需要輸出的文字。");

            // 輸入指令說明
            var repeatOption = command.Option("-r|--repeat-count", "指定輸出重複次數", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var words = wordsArgument.HasValue ? wordsArgument.Value : "world";

                var count = repeatOption.HasValue() ? repeatOption.Value() : "1";

                Console.WriteLine($"example => words: {words}, count: {count}", System.Drawing.Color.Azure);


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

                Console.WriteLine($"n = {message}", System.Drawing.Color.Red);

                return 0;
            });
        });
    }
}
