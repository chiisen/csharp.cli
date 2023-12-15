using System.Text.Json.Serialization;

namespace csharp.cli.model
{
    /// <summary>
    /// AE 遊戲清單
    /// </summary>
    public class PWAWebSiteAE : PWAWebSite
    {
        /// <summary>
        /// ServerId
        /// </summary>
        public string? serverId { get; set; }
        /// <summary>
        /// 遊戲id
        /// </summary>
        public string? id { get; set; }
        /// <summary>
        /// 館別id
        /// </summary>
        public int clubId { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// mType
        /// </summary>
        public int mType { get; set; }
        /// <summary>
        /// 圖片路徑
        /// </summary>
        public string? imagePath { get; set; }
        /// <summary>
        /// 圖片名稱
        /// </summary>
        public string? imageName { get; set; }
        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// 對應遊戲編號
        /// </summary>
        public string? localizationCode { get; set; }
        /// <summary>
        /// 分類id清單
        /// </summary>
        public int[]? categoryIdList { get; set; }
        /// <summary>
        /// 顯示排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// gType(未使用)
        /// </summary>
        [JsonIgnore]
        public int gType { get; set; }
        /// <summary>
        /// RCG 專用
        /// </summary>
        [JsonIgnore] 
        public bool supportWeb { get; set; }
        /// <summary>
        /// RCG 專用
        /// </summary>
        [JsonIgnore] 
        public bool supportMobile { get; set; }
        [JsonIgnore] 
        public string? code { get; set; }
        [JsonIgnore] 
        public string? @class { get; set; }
        /// <summary>
        /// RCG 專用 - 1:真人, 3:電子, 4:體育, 5:棋牌, 6:彩票, 7:動競, 8:電競RCG 專用
        /// </summary>
        [JsonIgnore] 
        public string? gameType { get; set; }
        public PWAWebSite Clone()
        {
            return (PWAWebSiteAE)this.MemberwiseClone();
        }
        public string Replace(string values, PWAWebSite item)
        {
            // JSON 樣板
            /*
             {
                "serverId": "1009200000",
                "imageName": "25",
                "id": "25",
                "name": "一本万利",
                "clubId": 16,
                "imagePath": "Ameba",
                "active": true,
                "mType": 0,
                "localizationCode": "Game_AE_25",
                "categoryIdList": [
                  1,
                  2,
                  4
                ],
                "sort": 3
              },
             */
            // 查 "PWAWebSiteClub2" AE 是 3 - 1:真人, 3:電子, 4:體育, 5:棋牌, 6:彩票, 7:動競, 8:電競
            values = values.Replace("@serverId", item.serverId);
            values = values.Replace("@gameId", item.id?.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
            values = values.Replace("@gameClubId", item.clubId.ToString());
            values = values.Replace("@gameName", item.name?.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
            values = values.Replace("@mType", item.mType.ToString());
            values = values.Replace("@imagePath", item.imagePath?.Replace("'", "''")); // MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
            values = values.Replace("@imageName", item.imageName?.Replace("'", "''")); // MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
            values = values.Replace("@active", (item.active ? "1" : "0"));
            values = values.Replace("@localizationCode", item.localizationCode?.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
            if (item.categoryIdList != null)
                values = values.Replace("@categoryIdList", string.Join(",", item.categoryIdList));
            values = values.Replace("@sort", item.sort.ToString());

            return values;
        }
    }
}