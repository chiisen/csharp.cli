namespace csharp.cli.model.TableList
{
    internal class TranslationList : ITableList
    {
        public string? key { get; set; }
        public string? value { get; set; }
        ITableList ITableList.ConvertItem(int y, object value)
        {
            if (value == null)
            {
                return this;
            }

            switch (y)
            {
                case 1:
                    {
                        this.key = value.ToString();
                    }
                    break;
                case 3:
                    {
                        this.value = value.ToString();
                    }
                    break;
            }

            return this;
        }
        public string ConvertInsertSQL()
        {
            return "不需要輸出";
        }
        public string ConvertValuesSQL()
        {
            return "不需要輸出";
        }
    }
}
