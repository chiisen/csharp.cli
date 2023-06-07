using csharp.cli.common;
using McMaster.Extensions.CommandLineUtils;
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
    /// - g: 指定 bet-area.json 檔案，列出全部的翻譯內容
    /// 命令列引數: bet-area Bacc -a 1
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
            var areaNameOption = command.Option("-a|--area-name", "指定輸出 Area Name 的 csv 路徑", CommandOptionType.SingleValue);
            var gameAreaOption = command.Option("-g|--game", "指定輸出遊戲的 bet-area.json 內容", CommandOptionType.SingleValue);

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

                var gameArea = gameAreaOption.HasValue() ? gameAreaOption.Value() : null;
                if (gameArea is not null)
                {
                    var ids = data.data.Where(x => x.gameName is not null
                                           && x.gameName.ToLower().Equals(gameName)).ToList();
                    foreach (var item in ids)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                var id = idOption.HasValue() ? idOption.Value() : null;
                if (id is not null)
                {
                    id = $"{Convert.ToInt16(id):00000}";
                    var ids = data.data.Where(x => x.gameName is not null
                                                   && x.gameName.ToLower().Equals(gameName)
                                                   && x.betArea == id).ToList();
                    foreach (var item in ids)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                var context = contextOption.HasValue() ? contextOption.Value() : null;
                if (context is not null)
                {
                    var contexts = data.data.Where(x => x.gameName is not null
                                                && x.gameName.ToLower().Equals(gameName)
                                                && x.context == context);
                    foreach (var item in contexts)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                var areaNamePath = areaNameOption.HasValue() ? areaNameOption.Value() : null;
                if (areaNamePath is null) return 0;

                using var reader = new StreamReader(areaNamePath);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        continue;
                    }
                    var values = line.Split(',');
                    var result = values.Select((s, index) => new { s, index }).ToDictionary(x => x.index + 1, x => x.s);

                    var areaId = result[(int)common.Enum.BetArea.AreaId];
                    if (Common.IsNumeric(areaId) == false)
                    {
                        continue;
                    }
                    var aId = $"{Convert.ToInt16(areaId):00000}";
                    var areaName = result[(int)common.Enum.BetArea.AreaName];

                    var ids = data.data.Where(x =>
                    {
                        if (x is null) return false;
                        return x.gameName is not null
                               && x.gameName.ToLower().Equals(gameName)
                               && x.betArea is not null
                               && x.betArea.Equals(aId);
                    }).ToList();
                    foreach (var item in ids)
                    {
                        BetAreaHelper.Message(areaName, item.betArea, item.context);
                    }
                }

                return 0;
            });
        });
    }
}


