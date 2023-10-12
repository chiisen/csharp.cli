using csharp.cli.model;
using Newtonsoft.Json;
using System.Drawing;
using static csharp.cli.common.Enum;

namespace csharp.cli.common
{
    public class AddGamesProcess
    {
        public int Process<T>(string tpId, AddGamesRedisInfo info, List<Dictionary<int, string>> csvList, string sourceJsonText) where T : PWAWebSite
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
                Console.WriteLine(e);
                throw;
            }

            

            try
            {
                var newGameSqlPath = @$"{Environment.CurrentDirectory}\{Path.GetFileNameWithoutExtension(info.JsonPath)}.newGames.sql";

                Console.WriteLine($"開始寫入 sql 遊戲列表 {newGameSqlPath}");

                var valueList = new List<string>();

                var insert = @$"INSERT INTO[dbo].[T_Game_MappingInfo] (
                [serverId],
                [gameId],
                [gameClubId],
                [gameName],
                [imagePath],
                [imageName],
                [active],
                [localizationCode],
                [categoryIdList],
                [sort],
                [gameType],
                [thirdPartyId],
                [mType],
                [gType]
                )
                VALUES";

                var values = @$"(
                 '@serverId',
                 '@gameId',
                 @gameClubId,
                 '@gameName',
                 '@imagePath',
                 '@imageName',
                 @active,
                 '@localizationCode',
                 '@categoryIdList',
                 @sort,
                 @gameType,
                 '@thirdPartyId',
                 @mType,
                 @gType
                )";

                var first = true;
                for (var i = 0; i < gameList.Count; i++)
                {
                    var oneItemValues = "";
                    if (first)
                    {
                        oneItemValues = insert + values;
                        first = false;
                    }
                    else
                    {
                        oneItemValues = values;
                    }
                    
                    oneItemValues = oneItemValues.Replace("@serverId", newGameList[i].serverId);
                    oneItemValues = oneItemValues.Replace("@gameId", newGameList[i].id.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
                    oneItemValues = oneItemValues.Replace("@gameClubId", newGameList[i].clubId.ToString());
                    oneItemValues = oneItemValues.Replace("@gameName", newGameList[i].name.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
                    oneItemValues = oneItemValues.Replace("@imagePath", newGameList[i].imagePath.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
                    oneItemValues = oneItemValues.Replace("@imageName", newGameList[i].imageName.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
                    oneItemValues = oneItemValues.Replace("@active", (newGameList[i].active ? "1": "0"));
                    oneItemValues = oneItemValues.Replace("@localizationCode", newGameList[i].localizationCode.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
                    oneItemValues = oneItemValues.Replace("@categoryIdList", string.Join(",", newGameList[i].categoryIdList));
                    oneItemValues = oneItemValues.Replace("@sort", newGameList[i].sort.ToString());

                    // 給預設值
                    oneItemValues = oneItemValues.Replace("@gameType", "0");
                    oneItemValues = oneItemValues.Replace("@thirdPartyId", tpId);

                    // 取值，但是通常是 2 選 1 (只有 JDB 用 gType)
                    oneItemValues = oneItemValues.Replace("@mType", newGameList[i].mType.ToString());
                    oneItemValues = oneItemValues.Replace("@gType", newGameList[i].gType.ToString());

                    valueList.Add(oneItemValues);
                }

                File.WriteAllText(newGameSqlPath, string.Join(",", valueList) + ";");

                Console.WriteLine($"結束寫入 sql 遊戲列表 {newGameSqlPath}");
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
