using csharp.cli.model.TableList;

namespace csharp.cli.model.GameList
{
    /// <summary>
    /// 電子遊戲清單
    /// </summary>
    public class PWAWebSiteGameListSlotModel : ITableList
    {
        /// <summary>
        /// 遊戲id
        /// </summary>
        public string? gameId { get; set; }
        /// <summary>
        /// 遊戲名稱
        /// </summary>
        public string? gameName { get; set; }
        /// <summary>
        /// 遊戲類型
        /// </summary>
        public int gameType { get; set; }
        /// <summary>
        /// 館別id
        /// </summary>
        public int gameClubId { get; set; }
        /// <summary>
        /// 廠商編號
        /// </summary>
        public string? thirdPartyId { get; set; }
        /// <summary>
        /// 圖片路徑
        /// </summary>
        public string? imagePath { get; set; }
        /// <summary>
        /// 圖片名稱
        /// </summary>
        public string? imageName { get; set; }
        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// 對應翻譯編號
        /// </summary>
        public string? localizationCode { get; set; }
        /// <summary>
        /// 分類id清單
        /// </summary>
        public string? categoryIdList { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }

        public string ConvertInsertSQL()
        {
            return "";
        }

        public ITableList ConvertItem(int y, object value)
        {
            if (value == null)
            {
                return this;
            }

            switch (y)
            {
                case 1:
                    {
                        this.gameId = value.ToString();
                    }
                    break;
                case 2:
                    {
                        this.gameName = value.ToString();
                    }
                    break;                
                case 3:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.gameType = parsedValue;
                    }
                    break;
                case 4:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.gameClubId = parsedValue;
                    }
                    break;
                case 5:
                    this.thirdPartyId = value.ToString();
                    break;
                case 6:
                    this.imagePath = value.ToString();
                    break;
                case 7:
                    this.imageName = value.ToString();
                    break;
                case 8:
                    {
                        bool.TryParse(value.ToString(), out bool parsedValue);
                        this.active = parsedValue;
                    }
                    break;
                case 9:
                    this.localizationCode = value.ToString();
                    break;
                case 10:
                    {
                        this.categoryIdList = value.ToString();
                    }
                    break;
                case 11:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.sort = parsedValue;
                    }
                    break;
            }

            return this;
        }

        public string ConvertValuesSQL()
        {
            return "";
        }
    }
}

