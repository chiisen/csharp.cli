namespace csharp.cli.model
{
    /// <summary>
    /// ExcelConvert 功能的設定內容
    /// </summary>
    public class ExcelConvertSetting
    {
        public string? translationPath { get; set; }
        public string? translationSheet { get; set; }
        public string? redisConnectionString { get; set; }
        public string? redisClubKey { get; set; }
        public string? redisTableKey { get; set; }
        public string? serverIdPath { get; set; }
        public string? serverIdSheet { get; set; }
    }
}
