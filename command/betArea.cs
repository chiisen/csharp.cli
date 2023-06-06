using Colorful;
using csharp.cli.common;
using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using System.Globalization;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 查詢 BetArea
    /// - c: 查詢翻譯內容
    /// 命令列引數: bet-area Bacc -c 閒
    /// - i: 查詢 AreaId
    /// 命令列引數: bet-area Bacc -i 1
    /// - a: csv 指定檔案路徑，列出全部的翻譯內容
    /// 命令列引數: bet-area Bacc -a C:\royal\github\RoyalTemporaryFile\WM\csv\百家樂.csv
    /// </summary>
    public static void BetArea()
    {
        _ = App.Command("bet-area", command =>
        {
            // 第二層 Help 的標題
            command.Description = "查詢 BetArea";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var gameNameArgument = command.Argument("[gameName]", "指定需要輸出的遊戲。");

            // 輸入指令說明
            var idOption = command.Option("-i|--id", "指定輸出 BetArea", CommandOptionType.SingleValue);
            var contextOption = command.Option("-c|--context", "指定輸出 BetArea", CommandOptionType.SingleValue);
            var AreaNameOption = command.Option("-a|--area-name", "指定輸出 Area Name 的 csv 路徑", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var data = GetBetAreaJson();
                if (data == null)
                {
                    Console.WriteLine($"null data");
                    return 1;
                }
                if (data.data == null)
                {
                    Console.WriteLine($"null data.data");
                    return 1;
                }

                // 只留下 lang 為 zh-TW
                data.data = data.data.Where(x => x.lang == "zh-TW").ToList();

                var gameName = gameNameArgument.HasValue ? gameNameArgument.Value : null;
                if (gameName == null)
                {
                    Console.WriteLine($"null gameName");
                    return 1;
                }

                gameName = gameName.ToLower(CultureInfo.InvariantCulture);

                var id = idOption.HasValue() ? idOption.Value() : null;
                if (id != null)
                {
                    id = string.Format("{0:00000}", Convert.ToInt16(id));
                    var ids = data.data.Where(x => x.gameName != null 
                                           && x.gameName.ToLower() == gameName 
                                           && x.betArea == id.ToString()).ToList();
                    foreach (var item in ids)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                var context = contextOption.HasValue() ? contextOption.Value() : null;
                if (context != null)
                {
                    var contexts = data.data.Where(x => x.gameName != null 
                                                && x.gameName.ToLower() == gameName 
                                                && x.context == context);
                    foreach (var item in contexts)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                var areaNamePath = AreaNameOption.HasValue() ? AreaNameOption.Value() : null;
                if (areaNamePath != null)
                {
                    using (var reader = new StreamReader(areaNamePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if(line == null)
                            {
                                continue;
                            }
                            var values = line.Split(',');
                            var result = values.Select((s, index) => new { s, index }).ToDictionary(x => x.index + 1, x => x.s);

                            var areaId = result[2].ToString();
                            if (Common.IsNumeric(areaId) == false)
                            {
                                continue;
                            }
                            var aId = string.Format("{0:00000}", Convert.ToInt16(areaId));
                            var areaName = result[3].ToString();

                            var ids = data.data.Where(x => x.gameName != null 
                                                   && x.gameName.ToLower() == gameName 
                                                   && x.betArea == aId).ToList();
                            foreach (var item in ids)
                            {
                                if (item == null)
                                {
                                    Console.WriteLine($"null item");
                                    continue;
                                }
                                BetAreaHelper.Message(areaName, item.betArea, item.context);
                            }
                        }
                    }
                }
                return 0;
            });
        });
    }
}

/// <summary>
/// BetAreaHelper
/// </summary>
public class BetAreaHelper
{
    public static void Message(string? areaName, string? betArea, string? context)
    {
        bool isNull = false;
        if(areaName == null)
        {
            Console.WriteLine($"null areaName");
            isNull = true;
        }
        if (betArea == null)
        {
            Console.WriteLine($"null betArea");
            isNull = true;
        }
        if (context == null)
        {
            Console.WriteLine($"null context");
            isNull = true;
        }
        if(isNull == true)
        {
            return;
        }
        var message = "{0} {1} {2}";
        var colors = new Formatter[]
        {
            new (areaName, Color.Red),
            new (betArea, Color.Blue),
            new (context, Color.Yellow)
        };
        Console.WriteLineFormatted(message, Color.White, colors);
    }
}
