namespace csharp.cli.model
{
#pragma warning disable IDE1006 // 命名樣式
    public class BetArea
    {
        public int msgId { get; set; }
        public string? message { get; set; }
        public List<BetAreaData>? data { get; set; }
    }

    public class BetAreaData
    {
        public int gameId { get; set; }
        public string? gameName { get; set; }
        public string? betArea { get; set; }
        public string? context { get; set; }
        public string? lang { get; set; }
    }
#pragma warning restore IDE1006 // 命名樣式
}
