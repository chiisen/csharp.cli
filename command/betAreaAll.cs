using Colorful;
using csharp.cli.common;
using csharp.cli.model;
using Newtonsoft.Json;
using System.Drawing;
using System.Text;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: bet-area-all
    /// 目錄內需要有一個 .bet-area 設定檔案
    /// </summary>
    public static void BetAreaAll()
    {
        _ = App.Command("bet-area-all", command =>
        {
            // 第二層 Help 的標題
            command.Description = "查詢 BetArea";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                Console.WriteLine($"> 目錄內需要有一個 .bet-area 設定檔案");

                var settingPath = @$"{System.Environment.CurrentDirectory}\.bet-area";
                if (File.Exists(settingPath) == false)
                {
                    Console.WriteLine($"> 無法讀取到 .bet-area 設定檔案");
                    return 1;
                }

                Console.WriteLine($"> 讀取到 .bet-area 設定檔案");

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

                var settingsText = File.ReadAllText(settingPath, Encoding.UTF8);
                var settings = JsonConvert.DeserializeObject<List<BetAreaSetting>>(settingsText);
                if(settings == null)
                {
                    Console.WriteLine("null settings");
                    return 1;
                }
                foreach (var ba in settings)
                {
                    if(ba == null)
                    {
                        continue;
                    }
                    Console.WriteLine($"> {ba.gameName} {ba.gameDesc}");
                    Console.WriteLine("==============================");

                    BetAreaAllHelper.Head();

                    Console.WriteLine("==============================");

                    var writePath = @$"{System.Environment.CurrentDirectory}\{ba.gameName}.txt";

                    var listWM = CsvHelper.GetCsv(ba.pathWM);
                    var list = CsvHelper.GetCsv(ba.path);
                    var dict = new Dictionary<string, string>();
                    foreach (var d in list)
                    {
                        var areaId = d[2].ToString();
                        if (Common.IsNumeric(areaId) == false)
                        {
                            //Console.WriteLine($"areaId: {areaId} 不是數值，所以略過處理");
                            continue;
                        }

                        var aId = string.Format("{0:00000}", Convert.ToInt16(areaId));
                        var areaName = d[3].ToString();

                        //跳過重複
                        if (dict.ContainsKey(areaName) == true)
                        {
                            Console.WriteLine($"areaName: {areaName} 重複處理，所以略過處理");
                            continue;
                        }

                        dict.Add(areaName, aId);

                        // TODO: 去掉有引號的字串
                        areaName = areaName.Replace("\"", "");

                        var ids = data.data.Where(x => x.gameName != null
                                                        && ba.gameName != null
                                                        && x.gameName.ToLower() == ba.gameName.ToLower()
                                                        && x.betArea == aId).ToList();
                        foreach (var item in ids)
                        {
                            if(item == null)
                            {
                                continue;
                            }

                            var context = item.context;
                            if (context == null)
                            {
                                continue;
                            }
                            context = context.Replace(" ", ""); // 去掉空白

                            context = Common.ReplaceChineseNumerals(context);
                            if (context == null)
                            {
                                continue;
                            }

                            var betArea = item.betArea;
                            if(betArea == null)
                            {
                                continue;
                            }

                            var first = listWM.Where(x => Common.ReplaceChineseNumerals(x[3]).Equals(context))
                                              .Select(x => x).FirstOrDefault();
                            if (first != null)
                            {
                                BetAreaAllHelper.Message("{0} {1} {2}" + $" {first[1]}", areaName, betArea, context);
                            }
                            else
                            {
                                BetAreaAllHelper.ErrorMessage("{0} {1} {2} {3}", areaName, betArea, context);
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
/// BetAreaAllHelper
/// </summary>
public class BetAreaAllHelper
{
    /// <summary>
    /// 列印彩色標題
    /// </summary>
    public static void Head()
    {
        var head = "{0} {1} {2} {3}";

        var colors = new Formatter[]
        {
            new ("\"areaName\"", Color.Green),
            new ("\"BetArea\"", Color.Blue),
            new ("\"context\"", Color.Yellow),
            new ("\"WM code\"", Color.White)
        };
        Console.WriteLineFormatted(head, Color.White, colors);
    }

    /// <summary>
    /// 列印欄位資訊
    /// </summary>
    /// <param name="areaName"></param>
    /// <param name="betArea"></param>
    /// <param name="context"></param>
    public static void Message(string message, string areaName, string betArea, string context)
    {
        var colors = new Formatter[]
        {
            new(areaName, Color.Green),
            new(betArea, Color.Blue),
            new(context, Color.Yellow)
        };
        Console.WriteLineFormatted(message, Color.White, colors);
    }

    /// <summary>
    /// 列印欄位資訊包含錯誤訊息
    /// </summary>
    /// <param name="message"></param>
    /// <param name="areaName"></param>
    /// <param name="betArea"></param>
    /// <param name="context"></param>
    public static void ErrorMessage(string message, string areaName, string betArea, string context)
    {
        var colors = new Formatter[]
        {
            new(areaName, Color.Green),
            new(betArea, Color.Blue),
            new(context, Color.Yellow),
            new(" 沒有對應的代碼", Color.Red)
        };
        Console.WriteLineFormatted(message, Color.White, colors);
    }
}
