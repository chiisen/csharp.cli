using Colorful;
using CsvHelper;
using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using System.Globalization;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 讀取 csv 的 AreaId 並且比對 betArea.json 的資料
    /// 命令列引數: csv "C:\royal\github\RoyalTemporaryFile\WM\csv\百家樂.csv" -b Bacc
    /// </summary>
    public static void Csv()
    {
        _ = App.Command("csv", command =>
        {
            // 第二層 Help 的標題
            command.Description = "讀取 csv。";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var pathArgument = command.Argument("[path]", "指定 csv 路徑與檔名。");

            // 輸入指令說明
            var betAreaOption = command.Option("-b|--bet-area", "指定輸出 BetArea", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var path = pathArgument.HasValue ? pathArgument.Value : null;
                if (path == null)
                {
                    Console.WriteLine($"null path");
                    return 1;
                }
                Console.WriteLine($"讀取csv: {path}");

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

                var betArea = betAreaOption.HasValue() ? betAreaOption.Value() : null;
                if (betArea == null)
                {
                    Console.WriteLine($"null BetArea");
                    return 1;
                }

                var list = CsvHelper.GetCsv(path);
                foreach (var d in list)
                {
                    var id = d[(int)common.Enum.BetArea.AreaId].ToString();
                    var name = d[(int)common.Enum.BetArea.AreaName].ToString();
                    name = name.Replace("\"", "");
                    var ids = data.data.Where(x => x.gameName is not null
                                           && x.gameName.ToLower().Equals(betArea.ToLower())
                                           && x.betArea == id).ToList();
                    foreach (var item in ids)
                    {
                        const string message = "{0} {1} {2}";
                        var colors = new Formatter[]
                        {
                            new (name, Color.Red),
                            new (item.betArea, Color.Blue),
                            new (item.context, Color.Yellow)
                        };
                        Console.WriteLineFormatted(message, Color.White, colors);
                    }
                }
                return 0;
            });
        });
    }
}
/// <summary>
/// CsvHelper
/// </summary>
public class CsvHelper
{
    public static List<Dictionary<int, string>> GetCsv(string? path)
    {
        var list = new List<Dictionary<int, string>>();
        if (path == null)
        {
            Console.WriteLine($"null path");
            return list;
        }

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<dynamic>();

        foreach (var r in records)
        {
            var map = new Dictionary<int, string>();

            var dics = (IDictionary<string, object>)r;
            var index = 1;
            foreach (var prop in dics)
            {
                map.Add(index, (string)prop.Value);
                //Console.WriteLine($"{prop.Key} {prop.Value}");
                index++;
            }
            if (map.Count > 0)
            {
                list.Add(map);
            }
        }

        return list;
    }
}
