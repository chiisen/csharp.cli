using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: json "words" -r 10
    /// </summary>
    public static void json()
    {
        _ = _app.Command("json", command =>
        {
            // 第二層 Help 的標題
            command.Description = "json 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var pathArgument = command.Argument("[path]", "指定需要輸出的文字路徑。");

            command.OnExecute(() =>
            {
                var path = pathArgument.HasValue ? pathArgument.Value : null;
                if (path == null)
                {
                    Console.WriteLine($"null path");
                    return 1;
                }
                
                var jsonText = File.ReadAllText(path);
                List<BetRecord> record = JsonConvert.DeserializeObject<List<BetRecord>>(jsonText);

                var value = record
                                  .Where(x => x.createdDateUTC >= new DateTime(2023, 5, 15, 0, 0, 0)
                                              && x.createdDateUTC < new DateTime(2023, 5, 16, 0, 0, 0))
                                  .OrderBy(x => x.createdDateUTC);

                Console.WriteLine($"json => value.Count(): {value.Count()}");

                string prefixKey = "dev";

                var betRecords = record
                                       .Where(x => x.PlayerId.ToLower().Substring(0, prefixKey.Length).Equals(prefixKey))
                                       .OrderBy(x => x.createdDateUTC);

                Console.WriteLine($"json => betRecords.Count(): {betRecords.Count()}");

                string json = System.Text.Json.JsonSerializer.Serialize(value);
                File.WriteAllText(@"C:\royal\20230515T150000.json", json);

                Console.WriteLine($"json => path: {path}");
                return 0;
            });
        });
    }
}
