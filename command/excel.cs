using csharp.cli.common;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System.Data;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// EXCEL 範例程式
    /// 命令列引數: excel
    /// </summary>
    public static void Excel()
    {
        _ = App.Command("excel", command =>
        {
            // 第二層 Help 的標題
            command.Description = "excel 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                #region Excel

                var persons = new List<UserDetails>()
                {
                    new UserDetails() {ID="1001", Name="ABCD", City ="City1", Country="USA"},
                    new UserDetails() {ID="1002", Name="PQRS", City ="City2", Country="INDIA"},
                    new UserDetails() {ID="1003", Name="XYZZ", City ="City3", Country="CHINA"},
                    new UserDetails() {ID="1004", Name="LMNO", City ="City4", Country="UK"},
                };

                // Lets converts our object data to Datatable for a simplified logic.
                // Datatable is most easy way to deal with complex datatypes for easy reading and formatting. 
                var table = Common.JsonDeserialize<DataTable>(JsonConvert.SerializeObject(persons));
                if (table == null)
                {
                    Console.WriteLine($"null table");
                    return 1;
                }

                using var document = SpreadsheetDocument.Create("TestNewData.xlsx", SpreadsheetDocumentType.Workbook);
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };

                sheets.Append(sheet);

                var headerRow = new Row();

                var columns = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    var cell = new Cell()
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(column.ColumnName)
                    };
                    headerRow.AppendChild(cell);
                }

                sheetData.AppendChild(headerRow);

                foreach (DataRow drowse in table.Rows)
                {
                    if (drowse == null)
                    {
                        continue;
                    }
                    var newRow = new Row();
                    foreach (var col in columns)
                    {
                        var cs = drowse[col];
                        var csStr = cs.ToString();
                        if (csStr == null)
                        {
                            continue;
                        }

                        var cell = new Cell()
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(csStr)
                        };
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }

                workbookPart.Workbook.Save();

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
