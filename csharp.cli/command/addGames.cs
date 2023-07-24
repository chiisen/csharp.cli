using csharp.cli.common;
using csharp.cli.model;
using Newtonsoft.Json;
using Color = System.Drawing.Color;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 新增遊戲
    /// 命令列引數: add-games "C:/royal/adminapi_core5/AdminAPI_Core5/StaticFile/json/PWAWebSiteSlotGameMG.json"
    /// </summary>
    public static void addGames()
    {
        _ = App.Command("add-games", command =>
        {
            // 第二層 Help 的標題
            command.Description = "add-games 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var path = command.Argument("[jsonPaths]", "指定檔案路徑。");

            command.OnExecute(() =>
            {
                Console.WriteLine($"add-games", Color.Azure);

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

                var record = Common.JsonDeserialize<List<PWAWebSiteTableGame>>(jsonText);
                if (record is null)
                {
                    Console.WriteLine($"null record");
                    return 1;
                }

                // TODO: 新增遊戲需要參考 csv 設定檔案，代補全
                var addGame = record.FirstOrDefault();
                if (addGame != null)
                {
                    addGame.imageName = "test";
                    addGame.id = "test";

                    record.Add(addGame);
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