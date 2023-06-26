namespace csharp.cli.model
{
    public class BetRecordSummary
    {
        /// <summary>
        /// guid
        /// </summary>
        public string? id { get; set; }
        /// <summary>
        /// club id
        /// </summary>        
        public string? Club_id { get; set; }
        public string? Franchiser_id { get; set; }
        public string? Game_id { get; set; }
        public int Game_type { get; set; }
        public int Bet_type { get; set; }
        /// <summary>
        /// 投注金額
        /// </summary>
        public decimal? Bet_amount { get; set; }
        /// <summary>
        /// 有效投注
        /// </summary>
        public decimal? Turnover { get; set; }
        /// <summary>
        /// 當局贏分
        /// </summary>
        public decimal? Win { get; set; }
        /// <summary>
        /// 當局淨贏分
        /// </summary>
        public decimal? Netwin { get; set; }
        /// <summary>
        /// 當局彩金贏分
        /// </summary>
        public decimal? JackpotWin { get; set; }

        public DateTime? ReportDatetime { get; set; }
        public string? Currency { get; set; }
        public int RecordCount { get; set; }
    }
}