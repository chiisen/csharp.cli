using csharp.cli.model;
using Newtonsoft.Json;
using System.Drawing;
using static csharp.cli.common.Enum;

namespace csharp.cli.common
{
    public class AddGamesProcess
    {
        public int Process<T>(AddGamesRedisInfo info, List<Dictionary<int, string>> csvList, string sourceJsonText) where T : PWAWebSite
        {
            var sourceJsonList = Common.JsonDeserialize<List<T>>(sourceJsonText);
            if (sourceJsonList is null)
            {
                Console.WriteLine($"無法轉為 List");
                return 1;
            }

            // 取的第一筆廠商資料做為新增遊戲的範本
            var addGameTemplate = sourceJsonList.Where(x => x.active == true).Select(x => x).FirstOrDefault();
            if (addGameTemplate is null)
            {
                Console.WriteLine($"無法取的一筆資料當範本");
                return 1;
            }

            // 建立新增遊戲清單
            var newGameList = new List<T>(sourceJsonList);
            var count = 0;
            foreach (var field in csvList)
            {
                var sort = field[(int)AddGamesCsvField.Sort].ToString();
                var gameId = field[(int)AddGamesCsvField.GameId].ToString();
                var gameName = field[(int)AddGamesCsvField.GameName].ToString();

                var newGameItem = (T)addGameTemplate.Clone();
                newGameItem.id = gameId;
                newGameItem.imageName = gameId;
                newGameItem.name = gameName;
                newGameItem.sort = int.Parse(sort);
                newGameItem.localizationCode = $"{info.LocalCode}{gameId}";
                newGameItem.categoryIdList = Array.Empty<int>();

                // 判斷有沒有重複的遊戲代碼
                var exist = newGameList.Where(x => x.id.Equals(gameId) && x.active == true).Select(x => x).FirstOrDefault();
                if (exist is not null)
                {
                    Console.WriteLine($"重複的新增遊戲: [{count}] {gameId} {gameName}", Color.Red);
                }

                newGameList.Add((T)newGameItem);

                Console.WriteLine($"新增遊戲: [{count}] {gameId} {gameName}");
                count++;
            }

            // 將新的遊戲清單寫入檔案
            var newGameJson = JsonConvert.SerializeObject(newGameList, Formatting.Indented);// 格式化後寫入
            try
            {
                var newGameJsonPath = @$"{Environment.CurrentDirectory}\{Path.GetFileNameWithoutExtension(info.JsonPath)}.newGames.json";

                Console.WriteLine($"開始寫入 json 遊戲列表 {newGameJsonPath}");

                File.WriteAllText(newGameJsonPath, newGameJson);

                Console.WriteLine($"結束寫入 json 遊戲列表 {newGameJsonPath}");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }

            return 0;
        }
    }
}
