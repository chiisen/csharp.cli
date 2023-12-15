namespace csharp.cli.common
{
    public class Enum
    {
        /// <summary>
        /// BetArea
        /// </summary>
        public enum BetArea
        {
            OddsModel = 1,
            AreaId = 2,
            AreaName = 3,
            Odds = 4
        }
        /// <summary>
        /// 新增遊戲的 CSV 欄位設定
        /// </summary>
        public enum AddGamesCsvField
        {
            Sort = 1,
            GameId = 2,
            GameName = 3,
            Love = 4, // 熱門
            Fish = 3, // 捕魚
            Other = 6, // 其他
        }
    }
}
