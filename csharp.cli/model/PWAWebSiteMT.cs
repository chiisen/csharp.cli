﻿using System.Text.Json.Serialization;

namespace csharp.cli.model
{
    /// <summary>
    /// MT 遊戲清單
    /// </summary>
    public class PWAWebSiteMT : PWAWebSite
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
        /// mType
        /// </summary>
        public int mType { get; set; }
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
        /// 同 id 欄位
        /// </summary>
        public string GameCode 
        {
            get
            {
                return id;
            }
        }
        /// <summary>
        /// 顯示排序
        /// </summary>
        public int sort { get; set; } // 沒 sort 欄位
        /// <summary>
        /// gType(未使用)
        /// </summary>
        [JsonIgnore] 
        public int gType { get; set; }
        public PWAWebSite Clone()
        {
            return (PWAWebSiteMT)this.MemberwiseClone();
        }
    }
}