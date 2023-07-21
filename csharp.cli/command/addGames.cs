using csharp.cli.common;
using csharp.cli.model;
using Newtonsoft.Json;
using Color = System.Drawing.Color;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: addGames
    /// </summary>
    public static void addGames()
    {
        _ = App.Command("add-games", command =>
        {
            // 第二層 Help 的標題
            command.Description = "addGames 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                Console.WriteLine($"addGames", Color.Azure);

                const string env = "DEV";
                const string jsonPath = $"C:/royal/gitlab/adminapi_core5/AdminAPI_Core5/StaticFile/json/PWAWebSiteDataVersion.K8S{env}.json";
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

                var record = Common.JsonDeserialize<List<PWAWebSiteDataVersion>>(jsonText);
                if (record is null)
                {
                    Console.WriteLine($"null record");
                    return 1;
                }

                const string code = "PWAWebSiteCategory";

                record.ForEach(x =>
                {
                    // 修改指定的 code
                    if (x.code.Equals(code))
                    {
                        var nowTime = DateTime.Now.ToString("yyyyMMddHH") + "0000";
                        Console.WriteLine($"{x.version}", Color.Yellow);
                        if (x.version.Equals(nowTime) is false)
                        {
                            x.version = nowTime;
                            Console.WriteLine($"{nowTime}", Color.Blue);
                        }
                        else
                        {
                            var offsetString = x.version[10..];
                            var number = int.Parse(offsetString);
                            number += 1;
                            var number4digits = number.ToString("00##");

                            var nextNumber = DateTime.Now.ToString("yyyyMMddHH") + number4digits;
                            x.version = nextNumber;
                            Console.WriteLine($"{nextNumber}", Color.Blue);
                        }
                    }
                });


                var json = JsonConvert.SerializeObject(record, Formatting.Indented);// 格式化後寫入

                // 取得註解
                var sourceSplit = jsonText.Split("\n");
                var targetSplit = json.Split("\n");

                for (var i = 0; i < targetSplit.Length; ++i)// source 會手動編輯，所以資料可能會比較多，故用 targetSplit.Length
                {
                    var target = targetSplit[i];
                    var source = sourceSplit[i];
                    if (target.Equals(source) is false)
                    {
                        Console.WriteLine($"{target}", Color.DarkRed);
                        Console.WriteLine($"{source}", Color.Red);

                        var ret = Common.GetTheCommentAfterTheString(source, target);
                        Console.WriteLine($"{ret.diff}", Color.MediumVioletRed);
                        targetSplit[i] = ret.replace;
                    }
                }

                var result = string.Join("", targetSplit.ToArray());


                try
                {
                    File.WriteAllText(jsonPath, result);
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