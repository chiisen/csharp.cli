namespace csharp.cli.model
{
    /// <summary>
    /// 遊戲清單
    /// </summary>
    public interface PWAWebSite
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
        /// 圖片名稱
        /// </summary>
        public string? imageName { get; set; }
        /// <summary>
        /// 圖片路徑
        /// </summary>
        public string? imagePath { get; set; }
        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// 對應遊戲編號
        /// </summary>
        public string localizationCode { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// 顯示排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 分類列表
        /// 1 是全部
        /// 2 是老虎機
        /// 3 是捕魚機
        /// 4 是熱門
        /// 6 是其他
        /// </summary>
        public int[] categoryIdList { get; set; }
        /// <summary>
        /// mType
        /// </summary>
        public int mType { get; set; }
        /// <summary>
        /// gType (只有 JDB 使用)
        /// </summary>
        public int gType { get; set; }
        /// <summary>
        /// RCG 專用
        /// </summary>
        public bool supportWeb { get; set; }
        /// <summary>
        /// RCG 專用
        /// </summary>
        public bool supportMobile { get; set; }
        public string code { get; set; }
        public string @class { get; set; }
        /// <summary>
        /// RCG 專用 - 1:真人, 3:電子, 4:體育, 5:棋牌, 6:彩票, 7:動競, 8:電競RCG 專用
        /// </summary>
        public string gameType { get; set; }

        public PWAWebSite Clone();
        public string Replace(string values, PWAWebSite item);
    }
}