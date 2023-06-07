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
    /// 讀取 .bet-area 設定檔案，列出 bet-area 的結果
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
                    Console.WriteLine("==============================");
                    Console.WriteLine($"> {ba.gameName} {ba.gameDesc}");
                    Console.WriteLine("==============================");

                    var listWm = CsvHelper.GetCsv(ba.pathWM);
                    var list = CsvHelper.GetCsv(ba.path);
                    var iLen = list.Max(x => x[(int)common.Enum.BetArea.AreaId].Length);
                    var nLen = list.Max(x => x[(int)common.Enum.BetArea.AreaName].Length);

                    BetAreaAllHelper.Head(nLen, iLen);

                    Console.WriteLine("==============================");

                    var dict = new Dictionary<string, string>();
                    foreach (var d in list)
                    {
                        var areaId = d[(int)common.Enum.BetArea.AreaId].ToString();
                        if (Common.IsNumeric(areaId) == false)
                        {
                            //Console.WriteLine($"areaId: {areaId} 不是數值，所以略過處理");
                            continue;
                        }

                        var aId = $"{Convert.ToInt16(areaId):00000}";
                        var areaName = d[(int)common.Enum.BetArea.AreaName].ToString();

                        //跳過重複
                        if (dict.ContainsKey(areaName) == true)
                        {
                            Console.WriteLine($"areaName: {areaName} 重複處理，所以略過處理");
                            continue;
                        }

                        dict.Add(areaName, aId);

                        // TODO: 去掉有引號的字串
                        areaName = areaName.Replace("\"", "");

                        var ids = data.data.Where(x => x.gameName is not null
                                                    && ba.gameName is not null
                                                    && x.gameName.ToLower().Equals(ba.gameName.ToLower())
                                                    && x.betArea == aId).ToList();
                        if (ids.Count == 0)
                        {
                            continue;
                        }

                        var cLen = ids.Where(x => x.context is not null).Max(x => x.context.Length);

                        foreach (var item in ids)
                        {
                            var context = item.context;
                            if (context == null)
                            {
                                continue;
                            }
                            context = context.Replace(" ", ""); // 去掉空白

                            context = Common.ReplaceChineseNumerals(context);

                            var betArea = item.betArea;
                            if(betArea == null)
                            {
                                continue;
                            }

                            var first = listWm.Where(x => Common.ReplaceChineseNumerals(x[(int)common.Enum.BetArea.AreaName]).Equals(context))
                                              .Select(x => x).FirstOrDefault();
                            if (first is not null)
                            {
                                BetAreaAllHelper.Message("{0} {1} {2} {3}", areaName, betArea, context, first[1], nLen, iLen, cLen);
                            }
                            else
                            {
                                BetAreaAllHelper.ErrorMessage("{0} {1} {2} {3}", areaName, betArea, context, nLen, iLen, cLen);
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
    private const int AreaNameLens = 55;
    private const int BetAreaLens = 10;
    private const int ContextLens = 30;
    private const int WmCodeLens = 25;
    /// <summary>
    /// 列印彩色標題
    /// </summary>
    public static void Head(int nLens, int iLen)
    {
        const string head = "{0} {1} {2} {3}";

        var colors = new Formatter[]
        {
            new ("\"areaName\"".PadRight(nLens), Color.Green),
            new ("\"BetArea\"".PadRight(iLen), Color.Blue),
            new ("\"context\"".PadRight(ContextLens), Color.Yellow),
            new ("\"WM code\"".PadRight(WmCodeLens), Color.White)
        };
        Console.WriteLineFormatted(head, Color.White, colors);
    }

    /// <summary>
    /// 列印欄位資訊
    /// </summary>
    /// <param name="areaName"></param>
    /// <param name="betArea"></param>
    /// <param name="context"></param>
    public static void Message(string message, string areaName, string betArea, string context, string wmCode, int nLens, int iLen, int cLen)
    {
        var colors = new Formatter[]
        {
            new(areaName.PadRight(nLens), Color.Green),
            new(betArea.PadRight(iLen), Color.Blue),
            new(context.PadRight(cLen), Color.Yellow),
            new(wmCode.PadRight(WmCodeLens), Color.White)
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
    public static void ErrorMessage(string message, string areaName, string betArea, string context, int nLens, int iLen, int cLen)
    {
        var colors = new Formatter[]
        {
            new(areaName.PadRight(AreaNameLens), Color.Green),
            new(betArea.PadRight(BetAreaLens), Color.Blue),
            new(context.PadRight(ContextLens), Color.Yellow),
            new("沒有對應的代碼".PadRight(25), Color.Red)
        };
        Console.WriteLineFormatted(message, Color.White, colors);
    }
}
