using Colorful;
using csharp.cli.common;
using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Linq;
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
            var writeOption = command.Option("-w|--write", "指定輸出 Area Name 的 txt 路徑", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                string settingPath = @$"{Environment.CurrentDirectory}\.bet-area";
                if (File.Exists(settingPath))
                {
                    Console.WriteLine($"> 讀取到 .bet-area 設定檔案");

                    BetArea jsonData = GetBetAreaJson();
                    if (jsonData == null)
                    {
                        Console.WriteLine($"null jsonData");
                        return 1;
                    }

                    string settingsText = File.ReadAllText(settingPath, Encoding.UTF8);
                    List<BetAreaSetting> settings = JsonConvert.DeserializeObject<List<BetAreaSetting>>(settingsText);
                    foreach (var ba in settings)
                    {
                        Console.WriteLine($"> {ba.gameName} {ba.gameDesc}");
                        Console.WriteLine("==============================");

                        string head = "{0} {1} {2} {3}";
                        Formatter[] headColors = new Formatter[]
                        {
                            new Formatter("\"areaName\"", Color.Red),
                            new Formatter("\"betArea\"", Color.Blue),
                            new Formatter("\"context\"", Color.Yellow),
                            new Formatter("\"WM code\"", Color.White)
                        };
                        Console.WriteLineFormatted(head, Color.White, headColors);
                        Console.WriteLine("==============================");

                        string writePath = @$"{Environment.CurrentDirectory}\{ba.gameName}.txt";

                        List<string> codes = new();

                        List<Dictionary<int, string>> listWM = GetCsv(ba.pathWM);
                        List<Dictionary<int, string>> list = GetCsv(ba.path);
                        foreach (var d in list)
                        {
                            var areaId = d[2].ToString();
                            if (Common.IsNumeric(areaId) == false)
                            {
                                continue;
                            }
                            var aId = string.Format("{0:00000}", Convert.ToInt16(areaId));
                            var areaName = d[3].ToString();
                            areaName = areaName.Replace("\"", "");
                            if (Common.IsLetter(areaName) == false)
                            {
                                areaName = $"'{areaName}'";
                            }

                            var ids = jsonData.data.Where(x => x.gameName.ToLower() == ba.gameName.ToLower() && x.betArea == aId);
                            foreach (var item in ids)
                            {
                                if (item.lang == "zh-TW")
                                {
                                    var cont = item.context;
                                    cont = cont.Replace(" ", "");// 去掉空白

                                    cont = Common.ReplaceChineseNumerals(cont);

                                    string message = "{0} {1} {2}";
                                    Formatter[] messageColors = new Formatter[]
                                    {
                                        new Formatter(areaName, Color.Red),
                                        new Formatter(item.betArea, Color.Blue),
                                        new Formatter(cont, Color.Yellow)
                                    };

                                    var first = listWM.Where(x => x[3].Equals(cont)).Select(x => x).FirstOrDefault();
                                    if(first != null)
                                    {
                                        Console.WriteLineFormatted(message + $" {first[1]}", Color.White, messageColors);

                                        codes.Add($"{{(101, \"{first[1]}\"),\"{areaName}\"}},// {cont}");
                                    }
                                    else
                                    {
                                        Console.WriteLineFormatted(message, Color.White, messageColors);
                                    }
                                }
                            }
                        }

                        string writeOptionString = writeOption.HasValue() ? writeOption.Value() : null;
                        if (writeOptionString != null)
                        {
                            using (StreamWriter writer = new(writePath))
                            {
                                codes.ForEach( x =>
                                {
                                    writer.WriteLine(x);
                                });
                            }                            
                        }                        
                    }
                    return 0;
                }

                BetArea data = GetBetAreaJson();
                if (data == null)
                {
                    Console.WriteLine($"null data");
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
                    var ids = data.data.Where(x => x.gameName.ToLower() == gameName && x.betArea == id.ToString());
                    foreach (var item in ids)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                string context = contextOption.HasValue() ? contextOption.Value() : null;
                if (context != null)
                {
                    var contexts = data.data.Where(x => x.gameName.ToLower() == gameName && x.context == context);
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
                            if (Common.IsNumeric(areaId) == false)
                            {
                                continue;
                            }
                            var aId = string.Format("{0:00000}", Convert.ToInt16(areaId));
                            var areaName = result[3].ToString();

                            var ids = data.data.Where(x => x.gameName.ToLower() == gameName && x.betArea == aId);
                            foreach (var item in ids)
                            {
                                if (item.lang == "zh-TW")
                                {
                                    string message = "{0} {1} {2}";
                                    Formatter[] colors = new Formatter[]
                                    {
                                        new Formatter(areaName, Color.Red),
                                        new Formatter(item.betArea, Color.Blue),
                                        new Formatter(item.context, Color.Yellow)
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
