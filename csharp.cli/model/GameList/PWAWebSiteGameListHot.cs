using System.Text.Json.Serialization;

namespace csharp.cli.model.GameList
{
    /// <summary>
    /// 熱門遊戲清單
    /// </summary>
    public class PWAWebSiteGameListHotResponse
    {
        /// <summary>
        /// 遊戲id
        /// </summary>
        public string? gameId { get; set; }
        /// <summary>
        /// 廠商英文代號
        /// </summary>
        public string? thirdPartyId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 遊戲類型
        /// </summary>
        public int gameType { get; set; }
        public PWAWebSiteGameListHotResponse() { }
        public PWAWebSiteGameListHotResponse(PWAWebSiteGameListHotModel x)
        {
            if (x == null)
            {
                return;
            }
            this.gameId = x.gameId;
            this.thirdPartyId = x.thirdPartyId;
            this.sort = x.sort;
            this.gameType = x.gameType;
        }

        public string ConvertInsertSQL()
        {
            return @"
INSERT INTO [dbo].[T_WebSite_Popular_Game] (
        [gameId]
        ,[thirdPartyId]
        ,[sort]
        ,[gameType]
    )
VALUES";
        }

        public string ConvertValuesSQL()
        {
            int[] value = { };
            return @$"(
        '{this.gameId}',
        '{this.thirdPartyId}',
        {this.sort},
        {this.gameType}
    )";
        }
    }
}

