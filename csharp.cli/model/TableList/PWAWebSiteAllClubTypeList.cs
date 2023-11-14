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
        public string thirdPartyId { get; set; }
        public string clubType { get; set; }
        public string name { get; set; }
        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// 語系對應代碼
        /// </summary>
        public string localizationCode { get; set; }
        public string imageName { get; set; }
        public string imagePath { get; set; }
        /// <summary>
        /// 遊戲桌列表顯示排序
        /// </summary>
        public int sort { get; set; }

        ITableList ITableList.ConvertItem(int y, object value)
        {
            switch (y)
            {
                case 1:
                    this.id = int.Parse(value.ToString());
                    break;
                case 2:
                    this.gameType = int.Parse(value.ToString());
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
                    this.active = bool.Parse(value.ToString());
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
                    this.sort = int.Parse(value.ToString());
                    break;
            }
            return this;
        }

        public string ConvertInsertSQL()
        {
            return @"INSERT INTO [dbo].[T_AllClubTypeList] (
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
