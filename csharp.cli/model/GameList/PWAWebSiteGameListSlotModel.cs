using csharp.cli.model.TableList;
using System.Drawing;

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
        /// 伺服器編號
        /// </summary>
        public string? serverId { get; set; }
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
        /// <summary>
        /// mType
        /// </summary>
        public int mType { get; set; }
        /// <summary>
        /// gType
        /// </summary>
        public int gType { get; set; }
        /// <summary>
        /// code
        /// </summary>
        public string? code { get; set; }

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
                        this.gameId = gameId.Replace("'", "''");// 如果 SQL 要在字串內出現 ' 的特殊符號，要再補上一個 ' 符號才能正常執行
                    }
                    break;
                case 2:
                    {
                        this.gameName = value.ToString();
                        this.gameName = gameName.Replace("'", "''");// 如果 SQL 要在字串內出現 ' 的特殊符號，要再補上一個 ' 符號才能正常執行
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
                    this.serverId = value.ToString();
                    break;
                case 7:
                    this.imagePath = value.ToString();
                    break;
                case 8:
                    this.imageName = value.ToString();
                    this.imageName = imageName.Replace("'", "''");// 如果 SQL 要在字串內出現 ' 的特殊符號，要再補上一個 ' 符號才能正常執行
                    break;
                case 9:
                    {
                        var open = false;
                        var activeStr = value.ToString().ToLower();
                        if (activeStr.Equals("true") || activeStr.Equals("1"))
                        {
                            open = true;
                        }
                        //bool.TryParse(value.ToString(), out bool parsedValue);
                        this.active = open;
                    }
                    break;
                case 10:
                    this.localizationCode = value.ToString();
                    break;
                case 11:
                    {
                        this.categoryIdList = value.ToString();
                    }
                    break;
                case 12:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.sort = parsedValue;
                    }
                    break;
                case 13:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.mType = parsedValue;
                    }
                    break;
                case 14:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.gType = parsedValue;
                    }
                    break;
                case 15:
                    {
                        this.code = value.ToString();
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

