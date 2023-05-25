using Colorful;
using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System.Drawing;
using System.Globalization;
using Console = Colorful.Console;

public partial class Program
{
    /// <summary>
    /// 查詢 betArea
    /// 命令列引數: bet-area Bacc -c "閒"
    /// </summary>
    public static void betArea()
    {
        _ = _app.Command("bet-area", command =>
        {
            // 第二層 Help 的標題
            command.Description = "查詢 betArea";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var gameNameArgument = command.Argument("[gameName]", "指定需要輸出的遊戲。");

            // 輸入指令說明
            var idOption = command.Option("-i|--id", "指定輸出 betArea", CommandOptionType.SingleValue);
            var contextOption = command.Option("-c|--context", "指定輸出 betArea", CommandOptionType.SingleValue);
            var AreaNameOption = command.Option("-a|--area-name", "指定輸出 Area Name 的 csv 路徑", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                BetArea json = JsonConvert.DeserializeObject<BetArea>(BetAreaJson.Value);
                if (json == null)
                {
                    Console.WriteLine($"null json");
                    return 1;
                }

                var gameName = gameNameArgument.HasValue ? gameNameArgument.Value : null;
                if (gameName == null)
                {
                    Console.WriteLine($"null gameName");
                    return 1;
                }

                gameName = gameName.ToLower(CultureInfo.InvariantCulture);

                string id = idOption.HasValue() ? idOption.Value() : null;
                if (id != null)
                {
                    id = string.Format("{0:00000}", Convert.ToInt16(id));
                    var ids = json.data.Where(x => x.gameName.ToLower() == gameName && x.betArea == id.ToString());
                    foreach (var item in ids)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                string context = contextOption.HasValue() ? contextOption.Value() : null;
                if (context != null)
                {
                    var contexts = json.data.Where(x => x.gameName.ToLower() == gameName && x.context == context);
                    foreach (var item in contexts)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                string areaNamePath = AreaNameOption.HasValue() ? AreaNameOption.Value() : null;
                if (areaNamePath != null)
                {
                    using (var reader = new StreamReader(areaNamePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            Dictionary<int, string> result = values.Select((s, index) => new { s, index }).ToDictionary(x => x.index + 1, x => x.s);

                            var areaId = result[2].ToString();
                            var isNumeric = int.TryParse(areaId, out int n);
                            if(isNumeric == false)
                            {
                                continue;
                            }
                            var aId = string.Format("{0:00000}", Convert.ToInt16(areaId));
                            var areaName = result[3].ToString();

                            var ids = json.data.Where(x => x.gameName.ToLower() == gameName && x.betArea == aId);
                            foreach (var item in ids)
                            {
                                if (item.lang == "zh-TW")
                                {
                                    string message = "{0} {1} {2} {3}";
                                    Formatter[] colors = new Formatter[]
                                    {
                                        new Formatter(areaName, Color.Red),
                                        new Formatter(item.betArea, Color.Blue),
                                        new Formatter(item.context, Color.Yellow),
                                        new Formatter(item.lang, Color.Pink),
                                    };
                                    Console.WriteLineFormatted(message, Color.White, colors);
                                }
                            }
                        }
                    }
                }

                return 0;
            });
        });
    }
}
