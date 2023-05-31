using Colorful;
using csharp.cli.model;
using CsvHelper;
using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using System.Globalization;
using Console = Colorful.Console;

public partial class Program
{
    /// <summary>
    /// 讀取 csv。
    /// 命令列引數: csv ".\WM\csv\csvFile.csv" -b Bacc
    /// </summary>
    public static void csv()
    {
        _ = _app.Command("csv", command =>
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
                
                BetArea? data = GetBetAreaJson();
                if (data == null)
                {
                    Console.WriteLine($"null json");
                    return 1;
                }
                else
                {
                    // 只留下 lang 為 zh-TW
                    data.data = data.data.Where(x => x.lang == "zh-TW").ToList();
                }

                var betArea = betAreaOption.HasValue() ? betAreaOption.Value() : null;
                if (betArea == null)
                {
                    Console.WriteLine($"null betArea");
                    return 1;
                }

                List<Dictionary<int, string>> list = GetCsv(path);
                foreach (var d in list)
                {
                    var id = d[2].ToString();
                    var name = d[3].ToString();
                    name = name.Replace("\"", "");
                    var ids = data.data.Where(x => x.gameName.ToLower() == betArea.ToLower() 
                                           && x.betArea == id).ToList();
                    foreach (var item in ids)
                    {
                        string message = "{0} {1} {2}";
                        Formatter[] colors = new Formatter[]
                        {
                            new Formatter(name, Color.Red),
                            new Formatter(item.betArea, Color.Blue),
                            new Formatter(item.context, Color.Yellow)
                        };
                        Console.WriteLineFormatted(message, Color.White, colors);
                    }
                }
                return 0;
            });
        });
    }

    public static List<Dictionary<int, string>> GetCsv(string path)
    {
        List<Dictionary<int, string>> list = new();
        if (path == null)
        {
            Console.WriteLine($"null path");
            return list;
        }

        using (var reader = new StreamReader(path))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
                
                foreach (var rec in records)
                {
                    var dic = new Dictionary<int, string>();

                    var dics = (IDictionary<string, object>)rec;
                    int index = 1;
                    foreach (var prop in dics)
                    {
                        dic.Add(index, prop.Value as string);
                        //Console.WriteLine($"{prop.Key} {prop.Value}");
                        index++;
                    }
                    if (dic.Count > 0)
                    {
                        list.Add(dic);
                    }
                }
            }
        }

        return list;
    }
}
