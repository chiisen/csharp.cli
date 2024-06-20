using csharp.cli.common;
using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example "words" -r 10
    /// </summary>
    public static void Banner()
    {
        _ = App.Command("banner", command =>
        {
            // 第二層 Help 的標題
            command.Description = "banner 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var jsonlPath = command.Argument("[Json_Path]", "指定的 Json 檔案路徑");
            // 輸入參數說明
            var selectImage = command.Argument("[Select_Image]", "指定圖片");

            // 輸入參數說明
            var replace = command.Argument("[Replace]", "指定的取代內容");

            command.OnExecute(() =>
            {
                var path = jsonlPath.HasValue ? jsonlPath.Value : null;
                if (path == null)
                {
                    Console.WriteLine($"null path");
                    return 1;
                }

                var jsonText = File.ReadAllText(path);
                var record = Common.JsonDeserialize<List<Banner>>(jsonText);

                var image = selectImage.HasValue ? selectImage.Value : null;
                if (image == null)
                {
                    Console.WriteLine($"null image");
                    return 1;
                }

                var newStr = replace.HasValue ? replace.Value : null;
                if (newStr == null)
                {
                    Console.WriteLine($"null newStr");
                    return 1;
                }

                record.ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(x.banner_src) && x.banner_src.Contains(image))
                    {
                        x.banner_url = newStr;
                    }
                });

                var json = JsonConvert.SerializeObject(record, Formatting.Indented);// 格式化後寫入
                var writePath = $"{path}.bak";
                File.WriteAllText(writePath, json, new System.Text.UTF8Encoding(true));

                return 0;
            });
        });
    }
}
