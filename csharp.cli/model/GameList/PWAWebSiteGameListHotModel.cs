using csharp.cli.model.TableList;

namespace csharp.cli.model.GameList
{
    /// <summary>
    /// 熱門遊戲清單
    /// </summary>
    public class PWAWebSiteGameListHotModel : ITableList
    {
        /// <summary>
        /// 遊戲id
        /// </summary>
        public string? gameId { get; set; }
        /// <summary>
        /// 廠商英文代號
        /// </summary>
        public string? thirdPartyId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 遊戲類型
        /// </summary>
        public int gameType { get; set; }

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
                        this.thirdPartyId = value.ToString();
                        if(this.thirdPartyId == "RSG")
                        {
                            throw new Exception("thirdPartyId 不能為 RSG，必須改成 Royal");
                        }
                    }
                    break;                
                case 3:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.sort = parsedValue;
                    }
                    break;
                case 4:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.gameType = parsedValue;
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

