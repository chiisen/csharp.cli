using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System.Linq;

public partial class Program
{
    /// <summary>
    /// 讀取 csv。
    /// 命令列引數: csv csvFile.csv
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
            BetArea json = null;
            if (betArea != null)
            {
                json = JsonConvert.DeserializeObject<BetArea>(betAreaJson);
                if (json == null)
                {
                    Console.WriteLine($"null json");
                    return 1;
                }
            }
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                        var line = reader.ReadLine();
                        if (betArea != null)
                        {
                            var values = line.Split(',');
                            Dictionary<int, string> result = values.Select((s, index) => new { s, index }).ToDictionary(x => x.index + 1, x => x.s);

                            var id = result[2].ToString();
                            var name = result[3].ToString();
                            var ids = json.data.Where(x => x.gameName.ToLower() == betArea.ToLower() && x.betArea == id);
                            foreach (var item in ids)
                            {
                                Console.WriteLine($"{name} {item.betArea} {item.context} {item.lang}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{line}");
                        }
                }
            }
            return 0;            
            });
        });
    }
}
