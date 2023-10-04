namespace csharp.cli.model
{
    /// <summary>
    /// 遊戲清單
    /// </summary>
    public interface PWAWebSite
    {
        /// <summary>
        /// 遊戲id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 圖片名稱
        /// </summary>
        public string imageName { get; set; }
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
        public string name { get; set; }
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

        public PWAWebSite Clone();
    }
}