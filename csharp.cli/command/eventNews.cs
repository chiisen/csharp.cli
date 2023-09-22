using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing;
using Console = Colorful.Console;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.EMMA;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// Event News (工作自動化)
    /// 命令列引數: event-news "C:\Users\sam\Downloads\H1活動消息.xlsx" "品牌活動"
    /// </summary>
    public static void eventNews()
    {
        _ = App.Command("event-news", command =>
        {
            // 第二層 Help 的標題
            command.Description = "Event News (工作自動化)";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var excelPath = command.Argument("[Excel_Path]", "指定的 Excel 檔案路徑");

            // 輸入參數說明
            var excelSheet = command.Argument("[Excel_Sheet]", "指定的 Excel 的工作表");

            command.OnExecute(() =>
            {
                var excelFilePath = excelPath.HasValue ? excelPath.Value : null;
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(excelFilePath, false))
                    {
                        var excelFileSheet = excelSheet.HasValue ? excelSheet.Value : null;
                        if (!string.IsNullOrEmpty(excelFileSheet))
                        {
                            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                            foreach (Row row in sheetData.Elements<Row>())
                            {
                                foreach (Cell cell in row.Elements<Cell>())
                                {
                                    string cellValue = cell.InnerText;
                                    Console.WriteLine(cellValue);
                                }
                            }
                        }
                    }
                }
                return 0;
            });
        });
    }
}