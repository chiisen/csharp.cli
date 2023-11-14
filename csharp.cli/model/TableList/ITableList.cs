namespace csharp.cli.model.TableList
{
    public interface ITableList
    {
        ITableList ConvertItem(int y, object value);
        string ConvertInsertSQL();
        string ConvertValuesSQL();
    }
}
