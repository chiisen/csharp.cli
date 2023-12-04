using csharp.cli.helper;
using csharp.cli.model;
using csharp.cli.model.TableList;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /*
     // Redis 設定內容
    {
        "translationPath": "C:/royal/github/RoyalTemporaryFile/直接進桌/RD語系翻譯表.xlsx",
        "translationSheet": "籃版官網翻譯(新的)",
        "redisClubKey": "K8SDEV_AllClubTypeList",
        "redisTableKey": "K8SDEV_AllTableList",
        "redisConnectionString": "redis-cluster.h1-redis-dev:6379, password=h1devredis1688, abortConnect=false, connectRetry=5, connectTimeout=5000, syncTimeout=5000"
    }
    */



    /// <summary>
    /// EXCEL 轉檔
    /// 命令列引數: excel-convert "C:\royal\github\RoyalTemporaryFile\直接進桌\AllClubTypeList.xlsx" "sheet" "club"
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
                var excelFileSheet = excelSheet.HasValue ? excelSheet.Value : null;

                var sheet = OpenSheet(excelFilePath, excelFileSheet);
                if(sheet == null)
                {
                    Console.WriteLine($"[Null sheet] - {excelFilePath} - {excelFileSheet}", Color.Red);
                    return 0;
                }

                var modelStr = outModel.HasValue ? outModel.Value : null;
                //var modelNum = int.Parse(modelStr.ToString());

                
                
                // 讀取本地端 Redis 設定
                var setting = RedisHelper.GetValue<ExcelConvertSetting>("excel-convert");
                // 取得翻譯字典
                ExcelWorksheet? translation = null;
                Dictionary<string, string>? translationDictionary = null;

                if (setting != null && !string.IsNullOrEmpty(setting.translationPath))
                {
                    translation = OpenSheet(setting.translationPath, setting.translationSheet);
                    if (translation != null)
                    {
                        var translationList = ConvertList<TranslationList>(translation);
                        // translationDictionary = translationList.ToDictionary(x => x.key, x => x.value); // 沒重複可以直接使用

                        translationList.ForEach(x => {
                            translationDictionary = new Dictionary<string, string>();
                            if (translationDictionary.ContainsKey(x.key))
                            {
                                Console.WriteLine($"[翻譯代號 key 重複了] - {x.key} - {x.value}", Color.Red);
                            }
                            else
                            {
                                translationDictionary.Add(x.key, x.value);
                            }
                        });                        
                    }
                }

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
                                sql += "TRUNCATE TABLE [dbo].[T_AllClubTypeList]\n\n";

                                var count = 1;
                                sql += list.First().ConvertInsertSQL();
                                list.ForEach(x => {

                                    if (translationDictionary != null)
                                    {
                                        if (translationDictionary.ContainsKey(x.localizationCode) is not true)
                                        {
                                            Console.WriteLine($"[Club 翻譯代號 localizationCode 找不到] - {x.thirdPartyId} - {x.name} - {x.localizationCode}", Color.Red);
                                        }
                                    }

                                    sql += x.ConvertValuesSQL();
                                    if (count < list.Count)
                                    {
                                        sql += ",";
                                    }
                                    count++;
                                });

                                // 刪除指定　Redis 快取
                                if (setting != null && !string.IsNullOrEmpty(setting.redisConnectionString) && !string.IsNullOrEmpty(setting.redisClubKey))
                                {
                                    RedisHelper.OtherKeyDelete(setting.redisConnectionString, setting.redisClubKey);
                                    Console.WriteLine($"[Club 刪除 Redis Key] - {setting.redisClubKey}", Color.Red);
                                }
                            }
                        }
                        break;
                    case "table":
                        {
                            var list = ConvertList<PWAWebSiteAllTableListModel>(sheet);

                            // 轉欄位格式
                            var resp = new List<PWAWebSiteAllTableListResponse>();
                            list.ForEach(x => {
                                if (x.active)
                                {
                                    resp.Add(new PWAWebSiteAllTableListResponse(x));
                                }
                            });

                            // 轉 json
                            json = JsonConvert.SerializeObject(resp, Formatting.Indented);// 格式化後寫入

                            // 轉 sql
                            if (resp.Count > 0)
                            {
                                sql += "TRUNCATE TABLE [dbo].[T_AllTableList]\n\n";


                                var count = 1;
                                sql += resp.First().ConvertInsertSQL();
                                resp.ForEach(x => {

                                    if (translationDictionary != null)
                                    {
                                        if (translationDictionary.ContainsKey(x.localizationCode) is not true)
                                        {
                                            Console.WriteLine($"[Table 翻譯代號 localizationCode 找不到] - {x.thirdPartyId} - {x.name} - {x.localizationCode}", Color.Red);
                                        }
                                    }

                                    sql += x.ConvertValuesSQL();
                                    if (count < resp.Count)
                                    {
                                        sql += ",";
                                    }
                                    count++;
                                });

                                // 刪除指定　Redis 快取
                                if (setting != null && !string.IsNullOrEmpty(setting.redisConnectionString) && !string.IsNullOrEmpty(setting.redisTableKey))
                                {
                                    RedisHelper.OtherKeyDelete(setting.redisConnectionString, setting.redisTableKey);
                                    Console.WriteLine($"[Table 刪除 Redis Key] - {setting.redisTableKey}", Color.Red);
                                }
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
