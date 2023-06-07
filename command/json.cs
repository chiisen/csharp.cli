using csharp.cli.common;
using csharp.cli.model;
using Newtonsoft.Json;
using System.Text;

namespace csharp.cli;

public partial class Program
{
    public static BetArea? GetBetAreaJson()
    {
        var json = File.ReadAllText(@$"{AppDomain.CurrentDomain.BaseDirectory}resource\BetArea.json", Encoding.UTF8);
        var data = Common.JsonDeserialize<BetArea>(json);
        return data;
    }
    /// <summary>
    /// 讀取 json 範例程式
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
                var record = Common.JsonDeserialize<List<BetRecord>>(jsonText);

                var value = record
                                  .Where(x => x.createdDateUTC >= new DateTime(2023, 5, 15, 0, 0, 0)
                                              && x.createdDateUTC < new DateTime(2023, 5, 16, 0, 0, 0))
                                  .OrderBy(x => x.createdDateUTC);

                Console.WriteLine($"json => value.Count(): {value.Count()}");

                const string prefixKey = "dev";

                var betRecords = record
                                       .Where(x => x.PlayerId is not null && x.PlayerId.ToLower()[..prefixKey.Length].Equals(prefixKey))
                                       .OrderBy(x => x.createdDateUTC);

                Console.WriteLine($"json => betRecords.Count(): {betRecords.Count()}");

                var json = JsonConvert.SerializeObject(value, Formatting.Indented);// 格式化後寫入
                var dir = Path.GetDirectoryName(path);

                var writePath = @$"{dir}\{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}-F.json";
                File.WriteAllText(writePath, json);
                Console.WriteLine($"寫入 json 檔案: {writePath}");

                var jsonLine = System.Text.Json.JsonSerializer.Serialize(value);// 寫成一行
                writePath = @$"{dir}\{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}-L.json";
                File.WriteAllText(writePath, jsonLine);
                Console.WriteLine($"寫入 json 檔案: {writePath}");
                return 0;
            });
        });
    }
}
