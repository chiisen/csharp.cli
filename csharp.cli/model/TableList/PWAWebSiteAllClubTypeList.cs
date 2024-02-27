namespace csharp.cli.model.TableList
{
    /// <summary>
    /// 遊戲類型
    /// </summary>
    public class PWAWebSiteAllClubTypeListResponse : ITableList
    {
        /// <summary>
        /// 主要編號
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 遊戲分類
        /// </summary>
        public int gameType { get; set; }
        public string? thirdPartyId { get; set; }
        public string? clubType { get; set; }
        public string? name { get; set; }
        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// 語系對應代碼
        /// </summary>
        public string? localizationCode { get; set; }
        public string? imageName { get; set; }
        public string? imagePath { get; set; }
        /// <summary>
        /// 遊戲桌列表顯示排序
        /// </summary>
        public int sort { get; set; }

        ITableList ITableList.ConvertItem(int y, object value)
        {
            if(value == null)
            {
                return this;
            }

            switch (y)
            {
                case 1:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.id = parsedValue;
                    }
                    break;
                case 2:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.gameType = parsedValue;
                    }
                    break;
                case 3:
                    this.thirdPartyId = value.ToString();
                    break;
                case 4:
                    this.clubType = value.ToString();
                    break;
                case 5:
                    this.name = value.ToString();
                    break;
                case 6:
                    {
                        bool.TryParse(value.ToString(), out bool parsedValue);
                        this.active = parsedValue;
                    }
                    break;
                case 7:
                    this.localizationCode = value.ToString();
                    break;
                case 8:
                    this.imageName = value.ToString();
                    break;
                case 9:
                    this.imagePath = value.ToString();
                    break;
                case 10:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.sort = parsedValue;
                    }
                    break;
            }

            return this;
        }

        public string ConvertInsertSQL()
        {
            return @"INSERT INTO [dbo].[T_WebSite_GameType] (
        [id],
        [gameType],
        [thirdPartyId],
        [clubType],
        [name],
        [active],
        [localizationCode],
        [imageName],
        [imagePath],
        [sort]
    )
VALUES";
        }
        public string ConvertValuesSQL()
        {
            return @$"(
        {this.id},
        {this.gameType},
        '{this.thirdPartyId}',
        '{this.clubType}',
        '{this.name}',
        {(this.active.ToString().ToLower().Equals("true") ? 1 : 0)},
        '{this.localizationCode}',
        '{this.imageName}',
        '{this.imagePath}',
         {this.sort}
)";
        }
    }    
}
