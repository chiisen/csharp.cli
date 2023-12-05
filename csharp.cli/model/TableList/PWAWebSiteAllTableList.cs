namespace csharp.cli.model.TableList
{
    /// <summary>
    /// 遊戲桌列表
    /// </summary>
    public class PWAWebSiteAllTableListResponse
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
        /// <summary>
        /// 桌代號，不須填時，請填 " " 空字串，避免  判斷錯誤
        /// </summary>
        public string? deskDisplayName { get; set; }
        public string? imageName { get; set; }
        public string? imagePath { get; set; }
        public string? desk { get; set; }
        public string? serverId { get; set; }
        public int[]? categoryIdList { get; set; }
        /// <summary>
        /// 遊戲桌列表顯示排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 樣式
        /// </summary>
        public string? style { get; set; }
        public PWAWebSiteAllTableListResponse() { }
        public PWAWebSiteAllTableListResponse(PWAWebSiteAllTableListModel x)
        {
            this.id = x.id;
            this.gameType = x.gameType;
            this.thirdPartyId = x.thirdPartyId;
            this.clubType = x.clubType;
            this.name = x.name;
            this.active = x.active;
            this.localizationCode = x.localizationCode;
            if (!string.IsNullOrEmpty(x.deskDisplayName))
            {
                this.deskDisplayName = x.deskDisplayName;
            }
            else
            {
                this.deskDisplayName = "";
            }
            this.imageName = x.imageName;
            this.imagePath = x.imagePath;
            this.desk = x.desk;
            this.serverId = x.serverId;
            if (!string.IsNullOrEmpty(x.categoryIdList))
            {
                this.categoryIdList = x.categoryIdList.Split(',').Select(int.Parse).ToArray();
            }
            this.sort = x.sort;
            this.style = x.style;
        }
        public string ConvertInsertSQL()
        {
            return @"INSERT INTO[dbo].[T_AllTableList] (
         [id]
        ,[gameType]
        ,[thirdPartyId]
        ,[clubType]
        ,[name]
        ,[active]
        ,[localizationCode]
        ,[deskDisplayName]
        ,[imageName]
        ,[imagePath]
        ,[desk]
        ,[serverId]
        ,[categoryIdList]
        ,[sort]
        ,[style]
    )
VALUES";
        }
        public string ConvertValuesSQL()
        {
            int[] value = {};
            return @$"(
                {this.id},
                {this.gameType},
                '{this.thirdPartyId}',
                '{this.clubType}',
                '{this.name}',
                {(this.active.ToString().ToLower().Equals("true") ?  1 : 0)},
                '{this.localizationCode}',
                '{this.deskDisplayName}',
                '{this.imageName}',
                '{this.imagePath}',
                '{this.desk}',
                '{this.serverId}',
                '{(this.categoryIdList != null ? string.Join(", ", this.categoryIdList) : value)}',
                {this.sort},
                '{this.style}'
            )";
        }
    }
    /// <summary>
    /// 遊戲桌列表
    /// </summary>
    public class PWAWebSiteAllTableListModel : ITableList
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
        public string? deskDisplayName { get; set; } = "";
        public string? imageName { get; set; }
        public string? imagePath { get; set; }
        public string? desk { get; set; }
        public string? serverId { get; set; }
        public string? categoryIdList { get; set; }
        /// <summary>
        /// 遊戲桌列表顯示排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 樣式
        /// </summary>
        public string? style { get; set; }

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
                    this.deskDisplayName = value.ToString();
                    break;
                case 9:
                    this.imageName = value.ToString();
                    break;
                case 10:
                    this.imagePath = value.ToString();
                    break;
                case 11:
                    this.desk = value.ToString();
                    break;
                case 12:
                    this.serverId = value.ToString();
                    break;
                case 13:
                    this.categoryIdList = value.ToString();
                    break;
                case 14:
                    {
                        int.TryParse(value.ToString(), out int parsedValue);
                        this.sort = parsedValue;
                    }
                    break;
                case 15:
                    this.style = value.ToString();
                    break;
            }

            return this;
        }
        public string ConvertInsertSQL()
        {
            return "";// @see PWAWebSiteAllTableListResponse
        }

        public string ConvertValuesSQL()
        {
            return "";// @see PWAWebSiteAllTableListResponse
        }
    }
}
