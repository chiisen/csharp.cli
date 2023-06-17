using csharp.cli.model;
using Dapper;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Transactions;
using Color = System.Drawing.Color;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example0
    /// </summary>
    public static void BigInsert()
    {
        _ = App.Command("big-insert", command =>
        {
            // 第二層 Help 的標題
            command.Description = "big-insert 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                //BigInsertHelper.SqlBulkCopyUpdate();

                BigInsertHelper.SqlBulkCopyInsert();
                //BigInsertHelper.DapperInsert();

                return 0;
            });
        });
    }

    public class BigInsertHelper
    {
        private static int _objCount = 300000;
        private static SqlConnection _conn = new(
            new SqlConnectionStringBuilder()
            {
                DataSource = "localhost",
                InitialCatalog = "big",
                UserID = "sa",
                Password = "Pass@word"
            }.ConnectionString
        );

        public static void DeleteAll()
        {
            var sw = Stopwatch.StartNew();

            //  Delete all from the destination table.
            var commandDelete = new SqlCommand
            {
                Connection = new SqlConnection(_conn.ConnectionString),
                CommandText = "DELETE FROM big.dbo.BigInsertTable"
            };
            commandDelete.Connection.Open();
            commandDelete.ExecuteNonQuery();

            sw.Stop();
            Console.WriteLine($"DELETE - sw: {sw.ElapsedMilliseconds}", Color.Azure);
        }
        public static void SqlBulkCopyInsert()
        {
            //DeleteAll();

            var dt = new DataTable();
            dt.Columns.Add("BId", typeof(int));
            dt.Columns.Add("BName", typeof(string));

            for (var i = 0; i < _objCount; i++)
            {
                var row = dt.NewRow();
                row["BId"] = i;
                row["BName"] = "BigInsert" + i;

                dt.Rows.Add(row);
            }

            var sw = Stopwatch.StartNew();

            using var scope = new TransactionScope();
            using var sql = new SqlConnection(_conn.ConnectionString);
            sql.Open();
            using var sqlBulkCopy = new SqlBulkCopy(sql);

            // BatchSize：一次批次寫入多少筆資料
            sqlBulkCopy.BatchSize = 1000;

            // NotifyAfter：在寫入多少筆資料後呼叫 SqlRowsCopied 事件
            sqlBulkCopy.NotifyAfter = 100;
            sqlBulkCopy.SqlRowsCopied +=
                (o, args) =>
                {
                    Console.WriteLine($"寫入: {args.RowsCopied}", Color.Yellow);
                };

            // BulkCopyTimeout：逾時秒數
            sqlBulkCopy.BulkCopyTimeout = 60;

            // ColumnMappings：如果我們資料來源的 DataTable 的 ColumnName 跟要寫入的資料表的 ColumnName 是不一樣的，或是只寫入部分的欄位，就要在 ColumnMappings 新增額外的對應。
            sqlBulkCopy.ColumnMappings.Add("BId", "BId");
            sqlBulkCopy.ColumnMappings.Add("BName", "BName");

            // DestinationTableName：要寫入的資料表名稱
            sqlBulkCopy.DestinationTableName = "dbo.BigInsertTable";

            // WriteToServer()：寫入資料的方法

            try
            {
                sqlBulkCopy.WriteToServer(dt);
                scope.Complete();// ! 沒有執行 Complete() 資料寫入會全部取消
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}", Color.Red);
                throw;
            }
            sw.Stop();
            Console.WriteLine($"SqlBulkCopyInsert - sw: {sw.ElapsedMilliseconds}", Color.Azure);
        }

        public static void SqlBulkCopyUpdate()
        {
            var list = new List<BigInsertTable>();
            for (var i = 0; i < _objCount; i++)
            {
                list.Add(new BigInsertTable()
                {
                    BId = i,
                    BName = "BigInsert&Update" + i
                });
            }

            const string crateTemplateSql = @"
	BId int NULL,
	BName varchar(100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL";

            // 本地認證評估更新SQL 這裡採用的merge語言更新語句 你也可以使用 sql update 語句
            const string updateSql = @"Merge into BigInsertTable AS T 
Using #TmpTable AS S 
ON T.BId = S.BId
WHEN MATCHED 
THEN UPDATE SET T.[BId]=S.[BId],T.[BName]=S.[BName];";

            var dataTable = ConvertToDataTable(list);
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            using var conn = new SqlConnection(_conn.ConnectionString);
            using var command = new SqlCommand("", conn);
            try
            {
                var sw = Stopwatch.StartNew();

                conn.Open();
                //數據庫並創建一個臨時表來保存數據表的數據
                command.CommandText = $"  CREATE TABLE #TmpTable ({crateTemplateSql})";
                command.ExecuteNonQuery();

                sw.Stop();

                Console.WriteLine($"CREATE TABLE #TmpTable - sw: {sw.ElapsedMilliseconds}", Color.Azure);


                sw = Stopwatch.StartNew();
                //使用SqlBulkCopy 加載數據到臨時表中
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    foreach (DataColumn dcPrepped in dataTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(dcPrepped.ColumnName, dcPrepped.ColumnName);
                    }

                    bulkCopy.BulkCopyTimeout = 660;
                    bulkCopy.DestinationTableName = "#TmpTable";
                    bulkCopy.WriteToServer(dataTable);
                    bulkCopy.Close();
                }

                // 執行Command命令 使用臨時表的數據去更新目標表中的數據  然後刪除臨時表
                command.CommandTimeout = 300;
                command.CommandText = updateSql;
                command.ExecuteNonQuery();

                sw.Stop();

                Console.WriteLine($"SqlBulkCopyUpdate - sw: {sw.ElapsedMilliseconds}", Color.Azure);
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                var row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static void DapperInsert()
        {
            var objs = Enumerable.Range(0, _objCount).Select(x => new BigInsertTable { BId = x, BName = "Big" + x }).ToArray();

            var sw = Stopwatch.StartNew();
            using var scope = new TransactionScope();
            using var sql = new SqlConnection(_conn.ConnectionString);
            var sb = new StringBuilder();
            sb.AppendLine(@"INSERT INTO [dbo].[BigInsertTable]");
            sb.AppendLine(@"([BId],");
            sb.AppendLine(@" [BName])");
            sb.AppendLine(@"VALUES");
            sb.AppendLine(@"(@BId,");
            sb.AppendLine(@" @BName)");

            Console.WriteLine($"SQL: {sb}", Color.Yellow);
            sql.Execute(sb.ToString(), objs);

            scope.Complete();// ! 沒有執行 Complete() 資料寫入會全部取消
            sw.Stop();
            Console.WriteLine($"DapperInsert - sw: {sw.ElapsedMilliseconds}", Color.Azure);
        }
    }
}