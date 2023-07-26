using csharp.cli.common;
using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Drawing;
using static csharp.cli.model.WMDataReportResponse;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 自動排序
    /// 命令列引數: auto-sort "C:/royal/gitlab/adminapi_core5_ACCS-108/AdminAPI_Core5/StaticFile/json/PWAWebSiteSlotGameAE.json"
    /// -s 1 有值，則自動排序
    /// </summary>
    public static void autoSort()
    {
        _ = App.Command("auto-sort", command =>
        {
            // 第二層 Help 的標題
            command.Description = "auto-sort 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var path = command.Argument("[jsonPaths]", "指定檔案路徑。");

            // 輸入指令說明
            var autoSortOption = command.Option("-s|--sort", "是否自動排序", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                Console.WriteLine($"auto-sort", Color.Azure);

                var jsonPath = path.HasValue ? path.Value : null;
                if (jsonPath == null)
                {
                    Console.WriteLine($"null jsonPath");
                    return 1;
                }

                string? jsonText = null;
                try
                {
                    jsonText = File.ReadAllText(jsonPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e}", Color.Yellow);
                }
                if (jsonText is null)
                {
                    Console.WriteLine($"null jsonText", Color.Red);
                    return 1;
                }

                var record = Common.JsonDeserialize<List<PWAWebSiteTableGame4>>(jsonText);
                if (record is null)
                {
                    Console.WriteLine($"null record");
                    return 1;
                }

                // TODO: 自動排序，可選參考 csv 設定檔案，調整排序順序，代補全
                var autoSort = autoSortOption.HasValue() ? autoSortOption.Value() : null;
                if (autoSort is not null)
                {
                    var count = 0;
                    record.ForEach(x =>
                    {
                        count += 1;
                        x.sort = count;
                    });
                }

                var json = JsonConvert.SerializeObject(record, Formatting.Indented);// 格式化後寫入
                try
                {
                    File.WriteAllText(jsonPath, json);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                    throw;
                }

                return 0;
            });
        });
    }
}