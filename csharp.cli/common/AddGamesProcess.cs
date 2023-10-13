using csharp.cli.model;
using Newtonsoft.Json;
using System.Drawing;
using static csharp.cli.common.Enum;

namespace csharp.cli.common
{
    /// <summary>
    /// 新增遊戲列表的處理物件
    /// </summary>
    public class AddGamesProcess
    {
        public int Process<T>(string tpId, AddGamesRedisInfo info, List<Dictionary<int, string>> csvList, string sourceJsonText) where T : PWAWebSite, new()
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
            var gameList = new List<T>(sourceJsonList);// TODO: 這個變數只處理舊有的遊戲清單，不包含新增的遊戲清單
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
                Console.WriteLine(e);
                throw;
            }

            

            try
            {
                var newGameSqlPath = @$"{Environment.CurrentDirectory}\{Path.GetFileNameWithoutExtension(info.JsonPath)}.newGames.sql";

                Console.WriteLine($"開始寫入 sql 遊戲列表【不包含新增遊戲】 {newGameSqlPath}");

                var valueList = new List<string>();

                var destinationFolder = @$"{Environment.CurrentDirectory}\";
                var destinationInsertFile = @$"{destinationFolder}\resource\PWAWebSite\{tpId}\INSERT_{tpId}.sql";
                var insertText = File.ReadAllText(destinationInsertFile);
                var destinationValuesFile = @$"{destinationFolder}\resource\PWAWebSite\{tpId}\VALUES_{tpId}.sql";
                var valuesText = File.ReadAllText(destinationValuesFile);

                var first = true;
                for (var i = 0; i < gameList.Count; i++)
                {
                    var oneItemValues = "";
                    if (first)
                    {
                        oneItemValues = insertText + valuesText;
                        first = false;
                    }
                    else
                    {
                        oneItemValues = valuesText;
                    }

                    var replace = new T();
                    oneItemValues = replace.Replace(oneItemValues, newGameList[i]);

                    valueList.Add(oneItemValues);
                }

                File.WriteAllText(newGameSqlPath, string.Join(",", valueList) + ";");

                Console.WriteLine($"結束寫入 sql 遊戲列表【不包含新增遊戲】共{gameList.Count}筆 {newGameSqlPath}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 0;
        }
    }
}
