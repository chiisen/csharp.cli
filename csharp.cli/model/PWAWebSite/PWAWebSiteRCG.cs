using System.Text.Json.Serialization;

namespace csharp.cli.model
{
    /// <summary>
    /// RCG 遊戲清單
    /// </summary>
    public class PWAWebSiteRCG : PWAWebSite
    {
        /// <summary>
        /// ServerId
        /// </summary>
        [JsonIgnore] 
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
        public string? gameType { get; set; }
        public PWAWebSite Clone()
        {
            return (PWAWebSiteRCG)this.MemberwiseClone();
        }
        public string Replace(string values, PWAWebSite item)
        {
            // JSON 樣板
            /*
             {
                "id": 1,
                "gameType": 1,
                "thirdPartyId": "Royal",
                "code": "baccarat",
                "name": "百家樂", // 經典百家 => 百家樂
                "class": "royalLive",
                "active": true,
                "supportWeb": true,
                "supportMobile": false,
                "localizationCode": "G_Name_Bacc",
                "videoMode": "big"
              },
             */
            // 查 "PWAWebSiteClub2" RCG 是 1 - 1:真人, 3:電子, 4:體育, 5:棋牌, 6:彩票, 7:動競, 8:電競
            values = values.Replace("@gameId", item.id?.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
            // thirdPartyId 不存入資料庫
            values = values.Replace("@code", item.code);
            values = values.Replace("@gameName", item.name?.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了
            values = values.Replace("@class", item.@class);
            values = values.Replace("@active", (item.active ? "1" : "0"));
            values = values.Replace("@supportWeb", (item.supportWeb ? "1" : "0"));
            values = values.Replace("@supportMobile", (item.supportMobile ? "1" : "0"));
            values = values.Replace("@localizationCode", item.localizationCode?.Replace("'", "''"));// MS-SQL 遇到單引號要改成兩個單引號就能正常執行了

            return values;
        }
    }
}