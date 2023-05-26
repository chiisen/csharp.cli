using Colorful;
using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
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
                }

                List<Dictionary<int, string>> list = GetCsv(path);
                foreach (var d in list)
                {
                    var id = d[2].ToString();
                    var name = d[3].ToString();
                    var ids = data.data.Where(x => x.gameName.ToLower() == betArea.ToLower() && x.betArea == id);
                    foreach (var item in ids)
                    {
                        if (item.lang == "zh-TW")
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
                var values = line.Split(',');
                Dictionary<int, string> result = values.Select((s, index) => new { s, index }).ToDictionary(x => x.index + 1, x => x.s);
                list.Add(result);
            }
        }
        return list;
    }
}
