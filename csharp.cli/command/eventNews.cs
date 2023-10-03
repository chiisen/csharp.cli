
using OfficeOpenXml;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// Event News (工作自動化)
    /// 命令列引數: event-news "EXCEL完整路徑與檔案名稱" "sheet名稱"
    /// 目前只做到讀取 EXCEL 的資料，還沒轉為 SQL 語法
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
                if (string.IsNullOrEmpty(excelFilePath)) return 0;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;//指明非商业应用
                var package = new ExcelPackage(excelFilePath);//加载Excel工作簿

                var excelFileSheet = excelSheet.HasValue ? excelSheet.Value : null;
                var sheet1 = package.Workbook.Worksheets[excelFileSheet];//读取工作簿中名为"Sheet1"的工作表

                var x = 1;// 行(由上到下)
                var y = 1;// 列或叫欄位(由左到右)
                while (sheet1.Cells[x, y].Value != null)
                {
                    while (sheet1.Cells[x, y].Value != null)
                    {
                        Console.WriteLine($"x={x}, y={y}");
                        Console.WriteLine(sheet1.Cells[x, y].Value);
                        x += 1;
                    }

                    x = 1;// 從第一行開始
                    y += 1;// 換下一列
                }

                return 0;
            });
        });
    }
}