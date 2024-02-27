using System.Text.Json.Serialization;

namespace csharp.cli.model.GameList
{
    /// <summary>
    /// 電子遊戲清單
    /// </summary>
    public class PWAWebSiteGameListSlotResponse
    {
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
        /// 排序
        /// </summary>
        public int sort { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 遊戲類型
        /// </summary>
        [JsonIgnore]
        public int gameType { get; set; }

        /// <summary>
        /// 廠商英文代號
        /// </summary>
        [JsonIgnore]
        public string? thirdPartyId { get; set; }

        /// <summary>
        /// ServerId
        /// </summary>
        public string? serverId { get; set; }

        /// <summary>
        /// mType
        /// </summary>
        public int mType { get; set; }

        /// <summary>
        /// JDB專用欄位
        /// </summary>
        public int gType { get; set; }

        /// <summary>
        /// code
        /// </summary>
        public string? code { get; set; }

        /// <summary>
        /// 公開建構式
        /// </summary>
        public PWAWebSiteGameListSlotResponse()
        {
            categoryIdList = Array.Empty<int>();
        }

        /// <summary>
        /// PWAWebSiteGameListSlotModel 轉 PWAWebSiteGameListSlotResponse
        /// </summary>
        /// <param name="x">原始 PWAWebSiteGameListSlotModel 型別資料</param>
        public PWAWebSiteGameListSlotResponse(PWAWebSiteGameListSlotModel x)
        {
            if (x == null)
            {
                return;
            }
            this.id = x.gameId;
            this.clubId = x.gameClubId;
            this.thirdPartyId = x.thirdPartyId;
            this.serverId = x.serverId;
            this.name = x.gameName;
            this.gameType = x.gameType;
            this.imagePath = x.imagePath;
            this.imageName = x.imageName;
            this.active = x.active;
            this.localizationCode = x.localizationCode;
            if (!string.IsNullOrEmpty(x.categoryIdList))
            {
                this.categoryIdList = x.categoryIdList.Split(',').Select(int.Parse).ToArray();
            }
            else
            {
                this.categoryIdList = null;
            }
            this.sort = x.sort;
            this.mType = x.mType;
            this.gType = x.gType;
            this.code = x.code;
        }

        /// <summary>
        /// 將物件轉換為 INSERT SQL 語句。
        /// </summary>
        /// <returns>INSERT SQL 語句。</returns>
        public string ConvertInsertSQL()
        {
            return @"
INSERT INTO [dbo].[T_WebSite_Game_MappingInfo] (
        [gameId]
        ,[gameName]
        ,[gameType]
        ,[gameClubId]
        ,[thirdPartyId]
        ,[serverId]
        ,[imagePath]
        ,[imageName]
        ,[active]
        ,[localizationCode]
        ,[categoryIdList]
        ,[sort]
        ,[mType]
        ,[gType]
        ,[code]
    )
VALUES";
        }

        /// <summary>
        /// 將物件轉換為 INSERT SQL 語句的 VALUES 部分。
        /// </summary>
        /// <returns>INSERT SQL 語句的 VALUES 部分。</returns>
        public string ConvertValuesSQL()
        {
            int[] value = { };
            return @$"(
        '{this.id}',
        '{this.name}',
        {this.gameType},
        {this.clubId},
        '{this.thirdPartyId}',
        '{this.serverId}',
        '{this.imagePath}',
        '{this.imageName}',
        {(this.active.ToString().ToLower().Equals("true") ? 1 : 0)},
        '{this.localizationCode}',
        '{(this.categoryIdList != null ? string.Join(", ", this.categoryIdList) : value)}',
        {this.sort},
        {this.mType},
        {this.gType},
        '{this.code}'
     )";
        }
    }
}

