using csharp.cli.model.TableList;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public class ExcelHelper
{
    /// <summary>
    /// 開啟 Sheet 工作列
    /// </summary>
    /// <param name="excelFilePath"></param>
    /// <param name="excelFileSheet"></param>
    /// <returns></returns>
    public static ExcelWorksheet? OpenSheet(string? excelFilePath, string? excelFileSheet)
    {
        if (string.IsNullOrEmpty(excelFilePath))
        {
            return null;
        }
        if (!File.Exists(excelFilePath))
        {
            Console.WriteLine($"檔案不存在 - {excelFilePath}", Color.Red);
            return null;
        }

        Console.WriteLine($"開啟 Excel - {excelFilePath}", Color.Yellow);

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;//指明非商业应用
        var package = new ExcelPackage(excelFilePath);//加载Excel工作簿

        if (string.IsNullOrEmpty(excelFileSheet))
        {
            return null;
        }
        var sheet = package.Workbook.Worksheets[excelFileSheet];//读取工作簿中名为"Sheet1"的工作表
        return sheet;
    }

    /// <summary>
    /// Excel 轉為 json string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sheet"></param>
    /// <returns></returns>
    public static string ConvertString<T>(ExcelWorksheet sheet) where T : ITableList, new()
    {
        var list = new List<T>();

        var x = 2;// 行(由上到下，第一列是欄位名稱，所以由2開始)
        var y = 1;// 列或叫欄位(由左到右)
        while (sheet.Cells[x, y].Value != null)
        {
            var item = new T();

            while (sheet.Cells[x, y].Value != null)
            {
                // 填資料
                item = (T)item.ConvertItem(y, sheet.Cells[x, y].Value);

                y += 1;
            }

            list.Add(item);

            y = 1;// 從第一行開始
            x += 1;// 換下一列
        }

        return JsonConvert.SerializeObject(list, Formatting.Indented);// 格式化後寫入
    }

    /// <summary>
    /// Excel 轉為 List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sheet"></param>
    /// <returns></returns>
    public static List<T> ConvertList<T>(ExcelWorksheet sheet) where T : ITableList, new()
    {
        var list = new List<T>();

        var x = 2;// 行(由上到下，第一列是欄位名稱，所以由2開始)
        var y = 1;// 列或叫欄位(由左到右)
        while (sheet.Cells[x, y].Value != null)
        {
            var item = new T();

            while (sheet.Cells[x, y].Value != null)
            {
                // 填資料
                item = (T)item.ConvertItem(y, sheet.Cells[x, y].Value);

                y += 1;
            }

            list.Add(item);

            y = 1;// 從第一行開始
            x += 1;// 換下一列
        }

        return list;
    }
}

