using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System.Data;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example "words" -r 10
    /// </summary>
    public static void excel()
    {
        _ = _app.Command("excel", command =>
        {
            // 第二層 Help 的標題
            command.Description = "excel 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var wordsArgument = command.Argument("[words]", "指定需要輸出的文字。");

            // 輸入指令說明
            var repeatOption = command.Option("-r|--repeat-count", "指定輸出重複次數", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var words = wordsArgument.HasValue ? wordsArgument.Value : "world";

                var count = repeatOption.HasValue() ? repeatOption.Value() : "1";

                Console.WriteLine($"example => words: {words}, count: {count}");


                #region Excel

                List<UserDetails> persons = new()
           {
               new UserDetails() {ID="1001", Name="ABCD", City ="City1", Country="USA"},
               new UserDetails() {ID="1002", Name="PQRS", City ="City2", Country="INDIA"},
               new UserDetails() {ID="1003", Name="XYZZ", City ="City3", Country="CHINA"},
               new UserDetails() {ID="1004", Name="LMNO", City ="City4", Country="UK"},
          };

                // Lets converts our object data to Datatable for a simplified logic.
                // Datatable is most easy way to deal with complex datatypes for easy reading and formatting. 
                DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(persons), (typeof(DataTable)));

                using (SpreadsheetDocument document = SpreadsheetDocument.Create("TestNewData.xlsx", SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new SheetData();
                    worksheetPart.Worksheet = new Worksheet(sheetData);

                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };

                    sheets.Append(sheet);

                    Row headerRow = new();

                    List<String> columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        Cell cell = new()
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(column.ColumnName)
                        };
                        headerRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        Row newRow = new();
                        foreach (String col in columns)
                        {
                            Cell cell = new()
                            {
                                DataType = CellValues.String,
                                CellValue = new CellValue(dsrow[col].ToString())
                            };
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }

                    workbookPart.Workbook.Save();
                }

                #endregion Excel


                return 0;
            });
        });
    }

    public class UserDetails
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
