namespace csharp.cli.model
{
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
}
