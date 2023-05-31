using Colorful;
using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Console = Colorful.Console;

public partial class Program
{
    /// <summary>
    /// 讀取 csv。
    /// 命令列引數: csv csvFile.csv -b Bacc
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
                var betArea = betAreaOption.HasValue() ? betAreaOption.Value() : null;
                BetArea? data = null;
                if (betArea != null)
                {
                    data = GetBetAreaJson();
                    if (data == null)
                    {
                        Console.WriteLine($"null json");
                        return 1;
                    }
                    // 只留下 lang 為 zh-TW
                    data.data = data.data.Where(x => x.lang == "zh-TW").ToList();
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
        if(path == null)
        {
            Console.WriteLine($"null path");
            return list;
        }

        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                bool isReplace = false;

                Regex regex = new("\"(.*)\"");
                var v = regex.Match(line);
                string sourceStr = "";
                string replaceStr = "";
                if (v.Groups.Count > 1)
                {
                    // 把兩個 " 之間的逗號，換成中文逗號，避免被當成 csv 分隔符號
                    sourceStr = v.Groups[0].ToString();
                    replaceStr = sourceStr.Replace(",", "，");
                    line = line.Replace(sourceStr, replaceStr);

                    isReplace = true;
                }

                var values = line.Split(',');

                if (isReplace)
                {
                    values.Where(x => x.Equals(replaceStr)).ToList().ForEach(x =>
                    {
                        // 把兩個 " 之間的中文逗號，還原為逗點
                        var index = Array.IndexOf(values, x);
                        values[index] = x.Replace(replaceStr, sourceStr);
                    });
                }
                
                Dictionary<int, string> result = values.Select((s, index) => new { s, index }).ToDictionary(x => x.index + 1, x => x.s);
                list.Add(result);
            }
        }
        return list;
    }
}
