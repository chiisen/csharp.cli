using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using McMaster.Extensions.CommandLineUtils;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: coverage 
    /// </summary>
    public static void Coverage()
    {
        _ = App.Command("coverage", command =>
        {
            // 第二層 Help 的標題
            command.Description = "coverage 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var wordsArgument = command.Argument("[words]", "指定需要輸出的文字。");

            // 輸入指令說明
            var repeatOption = command.Option("-r|--repeat-count", "指定輸出重複次數", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var words = wordsArgument.HasValue ? wordsArgument.Value : "world";

                var count = repeatOption.HasValue() ? repeatOption.Value() : "1";

                Console.WriteLine($"coverage => words: {words}, count: {count}");
                return 0;
            });
        });
    }
}