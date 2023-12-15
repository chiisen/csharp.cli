using csharp.cli.common;
using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: coverage 
    /// </summary>
    public static void Coverage()
    {
        _ = App.Command("coverage", command =>
        {
            // 第二層 Help 的標題
            command.Description = "coverage 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var jsonPathArgument = command.Argument("[words]", "指定 Json 格式的注單資料。");

            // 輸入指令說明
            var gidOption = command.Option("-g|--gid", "指定 gid", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var jsonPath = jsonPathArgument.HasValue ? jsonPathArgument.Value : null;
                if (jsonPath is null)
                {
                    Console.WriteLine($"null jsonPath");
                    return 1;
                }

                string? jsonText = null;
                try
                {
                    jsonText = File.ReadAllText(jsonPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e}", Color.Yellow);
                }
                if (jsonText is null)
                {
                    Console.WriteLine($"null jsonText", Color.Red);
                    return 1;
                }
                var record = Common.JsonDeserialize<List<WMDataReportResponse.Result>>(jsonText);
                if (record is null)
                {
                    Console.WriteLine($"null record");
                    return 1;
                }
                var gid = gidOption.HasValue() ? gidOption.Value() : null;
                if (gid is null)
                {
                    Console.WriteLine($"null gid");
                    return 1;
                }

                var id = int.Parse(gid);

                var r = record.Where(x => WmConvertHelper.BetCodeToRcg(x).Equals("") && x.gid == id)
                                                 .GroupBy(n => n.betCode)
                                                 .SelectMany(group => string.IsNullOrEmpty(group.Key)
                                                                                           ? group as IEnumerable<WMDataReportResponse.Result>
                                                                                           : new[] { group.First() })
                                                .Select(x => new { x.gid, x.betCode, x.betResult, x.commission })
                                                .OrderBy(n => n.betCode)
                                                .ToList();

                r = r.OrderByDescending(x => x.betCode).ToList();

                r.ForEach(x =>
                {
                    Console.WriteLine($"{x.betCode}", Color.Yellow);
                });

                return 0;
            });
        });
    }
}