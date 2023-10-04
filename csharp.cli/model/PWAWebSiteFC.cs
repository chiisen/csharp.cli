namespace csharp.cli.model
{
    /// <summary>
    /// JDB 遊戲清單
    /// </summary>
    public class PWAWebSiteFC : PWAWebSite
    {
        /// <summary>
        /// ServerId
        /// </summary>
        public string serverId { get; set; }
        /// <summary>
        /// mType
        /// </summary>
        public int mType { get; set; }
        /// <summary>
        /// 遊戲id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 館別id
        /// </summary>
        public int clubId { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 圖片路徑
        /// </summary>
        public string imagePath { get; set; }
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
        /// 分類id清單
        /// </summary>
        public int[] categoryIdList { get; set; }
        /// <summary>
        /// 顯示排序
        /// </summary>
        public int sort { get; set; }
        public PWAWebSite Clone()
        {
            return (PWAWebSiteFC)this.MemberwiseClone();
        }
    }
}