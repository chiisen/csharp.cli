using csharp.cli.model.TableList;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Services.Description;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// EXCEL 轉檔
    /// 命令列引數: excel-convert "words" -r 10
    /// </summary>
    public static void ExcelConvert()
    {
        _ = App.Command("excel-convert", command =>
        {
            // 第二層 Help 的標題
            command.Description = "ExcelConvert 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var excelPath = command.Argument("[Excel_Path]", "指定 Excel 的檔案路徑");

            // 輸入參數說明
            var excelSheet = command.Argument("[Excel_Sheet]", "指定 Excel 的工作表");

            // 輸入參數說明
            var outModel = command.Argument("[Out_Model]", "指定的輸出模型");

            command.OnExecute(() =>
            {
                var excelFilePath = excelPath.HasValue ? excelPath.Value : null;
                if (string.IsNullOrEmpty(excelFilePath)) return 0;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;//指明非商业应用
                var package = new ExcelPackage(excelFilePath);//加载Excel工作簿

                var excelFileSheet = excelSheet.HasValue ? excelSheet.Value : null;
                var sheet = package.Workbook.Worksheets[excelFileSheet];//读取工作簿中名为"Sheet1"的工作表

                var modelStr = outModel.HasValue ? outModel.Value : null;
                //var modelNum = int.Parse(modelStr.ToString());

                var targetJson = $"{excelFilePath}.json";
                var targetSQL = $"{excelFilePath}.sql";
                string json = "";
                string sql = "";
                switch (modelStr)
                {
                    case "club":
                        {
                            var list = ConvertList<PWAWebSiteAllClubTypeListResponse>(sheet);
                            // 轉 json
                            json = JsonConvert.SerializeObject(list, Formatting.Indented);// 格式化後寫入

                            // 轉 sql
                            if(list.Count > 0)
                            {
                                var count = 1;
                                sql += list.First().ConvertInsertSQL();
                                list.ForEach(x => {
                                    sql += x.ConvertValuesSQL();
                                    if (count < list.Count)
                                    {
                                        sql += ",";
                                    }
                                    count++;
                                });
                            }
                        }
                        break;
                    case "table":
                        {
                            var list = ConvertList<PWAWebSiteAllTableListModel>(sheet);

                            // 轉欄位格式
                            var resp = new List<PWAWebSiteAllTableListResponse>();
                            list.ForEach(x => resp.Add(new PWAWebSiteAllTableListResponse(x)));

                            // 轉 json
                            json = JsonConvert.SerializeObject(resp, Formatting.Indented);// 格式化後寫入

                            // 轉 sql
                            if (resp.Count > 0)
                            {
                                var count = 1;
                                sql += resp.First().ConvertInsertSQL();
                                resp.ForEach(x => {
                                    sql += x.ConvertValuesSQL();
                                    if (count < resp.Count)
                                    {
                                        sql += ",";
                                    }
                                    count++;
                                });
                            }
                        }
                        break;
                }
                File.WriteAllText(targetJson, json);
                File.WriteAllText(targetSQL, sql);
                return 0;
            });
        });
    }
    /// <summary>
    /// Excel 轉為 json string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sheet"></param>
    /// <returns></returns>
    public static string ConvertString<T>(ExcelWorksheet sheet) where T : ITableList, new ()
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
