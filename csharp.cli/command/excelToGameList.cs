﻿using csharp.cli.model.GameList;
using Newtonsoft.Json;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// EXCEL 轉成遊戲列表的 json 格式與 SQL INSERT 指令
    /// 命令列引數: excel-to-gamelist "C:/royal/github/RoyalTemporaryFile/GEMINI/Game List 遊戲清單.xlsx" "Game List 遊戲清單" "slot"
    /// 命令列引數: excel-to-gamelist "C:\royal\github\RoyalTemporaryFile\進線2遊戲列表\進線2遊戲列表.xlsx" "JDB" "slot"
    /// 命令列引數: excel-to-gamelist "C:/royal/github/RoyalTemporaryFile/手機熱門遊戲/Mobile_Popular_Games_3.xlsx" "sheet" "hot"
    /// </summary>
    public static void ExcelToGameList()
    {
        _ = App.Command("excel-to-gamelist", command =>
        {
            // 第二層 Help 的標題
            command.Description = "Excel To GameList 說明";
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

                var sheet = ExcelHelper.OpenSheet(excelFilePath, excelFileSheet);
                if (sheet == null)
                {
                    Console.WriteLine($"[Null sheet] - {excelFilePath} - {excelFileSheet}", Color.Red);
                    return 0;
                }

                var modelStr = outModel.HasValue ? outModel.Value : null;
                //var modelNum = int.Parse(modelStr.ToString());
                Console.WriteLine($"執行模式:{modelStr}", Color.Green);

                var targetJson = $"{excelFilePath}.json";
                var targetSQL = $"{excelFilePath}.sql";
                string json = "";
                string sql = "";

                switch (modelStr)
                {
                    case "slot":
                        {
                            var list = ConvertList<PWAWebSiteGameListSlotModel>(sheet);

                            var gameList = new List<PWAWebSiteGameListSlotResponse>();
                            list.ForEach(x => {
                                gameList.Add(new PWAWebSiteGameListSlotResponse(x));
                            });

                            // 轉 json
                            json = JsonConvert.SerializeObject(gameList, Formatting.Indented);// 格式化後寫入

                            // 轉 sql
                            if (gameList.Count > 0)
                            {
                                sql += $"DELETE [HKNetGame_HJ].[dbo].[T_WebSite_Game_MappingInfo] WHERE [thirdPartyId] = '{gameList[0].thirdPartyId}'\n\n";

                                var count = 1;
                                sql += gameList.First().ConvertInsertSQL();
                                gameList.ForEach(x =>
                                {
                                    sql += x.ConvertValuesSQL();
                                    if (count < gameList.Count)
                                    {
                                        sql += ",";
                                    }
                                    count++;
                                });
                                Console.WriteLine($"slot: 產生 {count} 筆資料", Color.Green);
                            }
                            break;
                        }
                    case "hot":
                        {
                                var list = ConvertList<PWAWebSiteGameListHotModel>(sheet);

                                var gameList = new List<PWAWebSiteGameListHotResponse>();
                                list.ForEach(x => {
                                    gameList.Add(new PWAWebSiteGameListHotResponse(x));
                                });

                                // 轉 json
                                json = JsonConvert.SerializeObject(gameList, Formatting.Indented);// 格式化後寫入

                                // 轉 sql
                                if (gameList.Count > 0)
                                {
                                    sql += $"DELETE [HKNetGame_HJ].[dbo].[T_WebSite_Popular_Game] WHERE [gameType] = {gameList[0].gameType}\n\n";

                                    var count = 1;
                                    sql += gameList.First().ConvertInsertSQL();
                                    gameList.ForEach(x =>
                                    {
                                        sql += x.ConvertValuesSQL();
                                        if (count < gameList.Count)
                                        {
                                            sql += ",";
                                        }
                                        count++;
                                    });
                                Console.WriteLine($"hot: 產生 {count} 筆資料", Color.Green);
                            }
                                break;
                        }
                }

                File.WriteAllText(targetJson, json, new System.Text.UTF8Encoding(true));
                File.WriteAllText(targetSQL, sql, new System.Text.UTF8Encoding(true));
                return 0;
            });
        });
    }
}
