using System.Text.Json.Serialization;

namespace csharp.cli.model
{
    /// <summary>
    /// JDB 遊戲清單
    /// </summary>
    public class PWAWebSiteJDB : PWAWebSite
    {
        /// <summary>
        /// ServerId
        /// </summary>
        public string serverId { get; set; }
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
        /// gType (只有 JDB 使用)
        /// </summary>
        public int gType { get; set; }
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
        /// <summary>
        /// mType(未使用)
        /// </summary>
        [JsonIgnore]
        public int mType { get; set; }
        public PWAWebSite Clone()
        {
            return (PWAWebSiteJDB)this.MemberwiseClone();
        }
    }
}