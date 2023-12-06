using csharp.cli.helper;
using csharp.cli.model;
using csharp.cli.model.TableList;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Linq;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /*
     // Redis 設定內容
    {
        "translationPath": "C:/royal/github/RoyalTemporaryFile/直接進桌/RD語系翻譯表.xlsx",
        "translationSheet": "總表(需要新的翻譯請在這邊填寫),籃版官網翻譯(新的)",
        "redisClubKey": "K8SDEV_AllClubTypeList",
        "redisTableKey": "K8SDEV_AllTableList",
        "redisConnectionString": "redis-cluster.h1-redis-dev:6379, password=h1devredis1688, abortConnect=false, connectRetry=5, connectTimeout=5000, syncTimeout=5000",
        "serverIdPath": "C:/royal/github/RoyalTemporaryFile/直接進桌/RG真人ServerId.xlsx",
        "serverIdSheet": "Server"
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
                Console.WriteLine($"執行模式:{modelStr}", Color.Green);


                // 讀取本地端 Redis 設定
                var setting = RedisHelper.GetValue<ExcelConvertSetting>("excel-convert");
                // 取得翻譯字典
                Dictionary<string, string>? translationDictionary = null;

                Dictionary<string, string>? serverIdDictionary = null;

                string trans = "";
                string serv = "";

                if (setting != null && !string.IsNullOrEmpty(setting.translationPath) && setting.translationSheet != null)
                {
                    var sheets = setting.translationSheet.Split(',').ToList();
                    sheets.ForEach(s => 
                    {
                        ExcelWorksheet? translationExcel = OpenSheet(setting.translationPath, s);
                        if (translationExcel != null)
                        {
                            var translationList = ConvertList<TranslationList>(translationExcel);
                            // translationDictionary = translationList.ToDictionary(x => x.key, x => x.value); // 沒重複可以直接使用
                            if (translationList.Count > 0)
                            {
                                Console.WriteLine($"讀取翻譯 {s} - {translationList.Count} 筆", Color.Green);

                                if (translationDictionary == null)
                                {
                                    translationDictionary = new Dictionary<string, string>();
                                }
                                translationList.ForEach(x =>
                                {
                                    if (x.key is not null && translationDictionary.ContainsKey(x.key) is not true)
                                    {
                                        if (x.value is not null)
                                        {
                                            translationDictionary.Add(x.key, x.value);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"[翻譯代號 key 重複了] - Sheet:{s} - Key:{x.key} - Value:{x.value}", Color.Red);
                                    }
                                });

                                // 轉 json
                                trans = JsonConvert.SerializeObject(translationDictionary, Formatting.Indented);// 格式化後寫入
                            }
                        }
                    });

                    if (translationDictionary != null)
                    {
                        Console.WriteLine($"讀取翻譯多個 Sheet 共 {translationDictionary.Count} 筆", Color.Green);
                    }

                    ExcelWorksheet? serverIdExcel = OpenSheet(setting.serverIdPath, setting.serverIdSheet);
                    if (serverIdExcel != null)
                    {
                        var serverIdList = ConvertList<ServerIdList>(serverIdExcel);

                        if (serverIdList.Count > 0)
                        {
                            Console.WriteLine($"讀取 ServerId {serverIdList.Count} 筆", Color.Green);

                            serverIdDictionary = new Dictionary<string, string>();
                            serverIdList.ForEach(x =>
                            {
                                if (x.key is not null && serverIdDictionary.ContainsKey(x.key) is not true)
                                {
                                    if (x.value is not null)
                                    {
                                        serverIdDictionary.Add(x.key, x.value);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"[ServerId 的 key 重複了] - Sheet:{setting.serverIdSheet} - Key:{x.key} - Value:{x.value}", Color.Red);
                                }
                            });

                            // 轉 json
                            serv = JsonConvert.SerializeObject(serverIdDictionary, Formatting.Indented);// 格式化後寫入
                        }
                    }
                }

                var translationJson = $"{excelFilePath}_translation.json";
                var serverIdJson = $"{excelFilePath}_serverId.json";
                var targetJson = $"{excelFilePath}.json";
                var targetSQL = $"{excelFilePath}.sql";
                string json = "";
                string sql = "";
                
                switch (modelStr)
                {
                    case "club":
                        {
                            var list = ConvertList<PWAWebSiteAllClubTypeListResponse>(sheet);

                            // 排除未開啟的桌資料
                            list = list.Where(x => x.active == true).ToList();

                            // 轉 json
                            json = JsonConvert.SerializeObject(list, Formatting.Indented);// 格式化後寫入

                            // 轉 sql
                            if(list.Count > 0)
                            {
                                sql += "TRUNCATE TABLE [dbo].[T_AllClubTypeList]\n\n";

                                var count = 1;
                                sql += list.First().ConvertInsertSQL();
                                list.ForEach(x => {

                                    if (translationDictionary is not null)
                                    {
                                        if(x.localizationCode is not null)
                                        {
                                            if (translationDictionary.ContainsKey(x.localizationCode) is not true)
                                            {
                                                Console.WriteLine($"[Club 翻譯代號 localizationCode 找不到] - thirdPartyId:{x.thirdPartyId} - name:{x.name} - localizationCode:{x.localizationCode}", Color.Red);
                                            }
                                            else
                                            {
                                                var dict = translationDictionary[x.localizationCode];
                                                if (dict != x.name)
                                                {
                                                    if(x.name != null && x.name.Contains(dict))
                                                    {
                                                        Console.WriteLine($"[Club 翻譯代號 localizationCode 與 name 部分相似] - thirdPartyId:{x.thirdPartyId} - name:{x.name} - localizationCode:{x.localizationCode} - dict:{dict}", Color.Yellow);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"[Club 翻譯代號 localizationCode 與 name 不一致] - thirdPartyId:{x.thirdPartyId} - name:{x.name} - localizationCode:{x.localizationCode} - dict:{dict}", Color.Red);
                                                    }                                                    
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"[Club 翻譯代號 localizationCode 為 null] - thirdPartyId:{x.thirdPartyId} - name:{x.name}", Color.Red);
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
                                // 排除未開啟的桌資料
                                if (x.active == true)
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

                                    if (translationDictionary is not null)
                                    {
                                        if (x.localizationCode is not null)
                                        {
                                            if (translationDictionary.ContainsKey(x.localizationCode) is not true)
                                            {
                                                Console.WriteLine($"[Table 翻譯代號 localizationCode 找不到] - thirdPartyId:{x.thirdPartyId} - name:{x.name} - localizationCode:{x.localizationCode}", Color.Red);
                                            }
                                            else
                                            {
                                                var dict = translationDictionary[x.localizationCode];
                                                if (dict != x.name)
                                                {
                                                    if (x.name != null && x.name.Contains(dict) && x.deskDisplayName != null)
                                                    {
                                                        //桌名稱是組出來的，所以必須移除代號再比較
                                                        var newName = x.name.Replace(x.deskDisplayName, "");
                                                        if(newName != dict)
                                                        {
                                                            Console.WriteLine($"[Table 翻譯代號 localizationCode 與 name 部分相似] - thirdPartyId:{x.thirdPartyId} - name:{x.name} - localizationCode:{x.localizationCode} - dict:{dict}", Color.Yellow);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"[Table 翻譯代號 localizationCode 與 name 不一致] - thirdPartyId:{x.thirdPartyId} - name:{x.name} - localizationCode:{x.localizationCode} - dict:{dict}", Color.Red);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine($"[Table 翻譯代號 localizationCode 為 null] - thirdPartyId:{x.thirdPartyId} - name:{x.name}", Color.Red);
                                        }                                            
                                    }

                                    if(serverIdDictionary is not null)
                                    {
                                        if (x.serverId is not null && x.thirdPartyId is not null && x.thirdPartyId == "RCG")
                                        {
                                            if(x.desk is not null)
                                            {
                                                if(serverIdDictionary.ContainsKey(x.desk) is true)
                                                {
                                                    var servId = serverIdDictionary[x.desk];
                                                    if (x.serverId != servId)
                                                    {
                                                        Console.WriteLine($"[Table 的 serverId 可能填錯了] - thirdPartyId:{x.thirdPartyId} - name:{x.name} - desk:{x.desk} - serverId:{x.serverId} 正確為: {servId}", Color.Red);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"[Table 桌號 desk 不存在 ServerId 檔案中] - thirdPartyId:{x.thirdPartyId} - name:{x.name} - desk:{x.desk}", Color.Red);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"[Table 桌號 desk 為 null] - thirdPartyId:{x.thirdPartyId} - name:{x.name}", Color.Red);
                                            }
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

                File.WriteAllText(translationJson, trans);
                File.WriteAllText(serverIdJson, serv);                

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
