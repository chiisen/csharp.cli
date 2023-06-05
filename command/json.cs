using csharp.cli.common;
using csharp.cli.model;
using Newtonsoft.Json;
using System.Text;

namespace csharp.cli;

public partial class Program
{
    static BetArea? GetBetAreaJson()
    {
        string json = File.ReadAllText(@$"{AppDomain.CurrentDomain.BaseDirectory}resource\BetArea.json", Encoding.UTF8);
        if(json == null)
        {
            Console.WriteLine($"null json");
            return null;
        }
        BetArea data = Common.JsonDeserialize<BetArea>(json);
        if (data == null)
        {
            Console.WriteLine($"null data");
            return null;
        }
        return data;
    }
    /// <summary>
    /// 範例程式
    /// 命令列引數: json "C:\royal\github\RoyalTemporaryFile\MG\BetRecordHistory.json"
    /// 測試用只能指定特定 class 的 json 檔案
    /// </summary>
    public static void Json()
    {
        _ = App.Command("json", command =>
        {
            // 第二層 Help 的標題
            command.Description = "json 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var pathArgument = command.Argument("[path]", "指定需要輸出的文字路徑。");

            command.OnExecute(() =>
            {
                Console.WriteLine("測試用只能指定特定 class 的 json 檔案");

                var path = pathArgument.HasValue ? pathArgument.Value : null;
                if (path == null)
                {
                    Console.WriteLine($"null path");
                    return 1;
                }

                var jsonText = File.ReadAllText(path);
                if(jsonText == null)
                {
                    Console.WriteLine($"null jsonText");
                    return 1;
                }
                List<BetRecord> record = Common.JsonDeserialize<List<BetRecord>>(jsonText);
                if(record == null)
                {
                    Console.WriteLine($"null record");
                    return 1;
                }

                var value = record
                                  .Where(x => x.createdDateUTC >= new DateTime(2023, 5, 15, 0, 0, 0)
                                              && x.createdDateUTC < new DateTime(2023, 5, 16, 0, 0, 0))
                                  .OrderBy(x => x.createdDateUTC);

                Console.WriteLine($"json => value.Count(): {value.Count()}");

                string prefixKey = "dev";

                var betRecords = record
                                       .Where(x => x.PlayerId != null && x.PlayerId.ToLower()[..prefixKey.Length].Equals(prefixKey))
                                       .OrderBy(x => x.createdDateUTC);

                Console.WriteLine($"json => betRecords.Count(): {betRecords.Count()}");

                string json = JsonConvert.SerializeObject(value, Formatting.Indented);// 格式化後寫入
                var dir = Path.GetDirectoryName(path);

                var writePath = @$"{dir}\{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff")}-F.json";
                File.WriteAllText(writePath, json);

                string jsonLine = System.Text.Json.JsonSerializer.Serialize(value);// 寫成一行
                writePath = @$"{dir}\{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff")}-L.json";
                File.WriteAllText(writePath, jsonLine);

                Console.WriteLine($"json => path: {path}");
                return 0;
            });
        });
    }
}
