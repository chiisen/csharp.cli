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
        /// AddGames
        /// </summary>
        public enum AddGames
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
