using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: h1BetCheck
    /// </summary>
    public static void h1BetCheck()
    {
        _ = App.Command("h1-bet-check", command =>
        {
            // 第二層 Help 的標題
            command.Description = "h1 Bet Check 說明";
            command.HelpOption("-?|-h|-help");

            var idOption = command.Option("-i|--id", "指定查詢ID", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var id = idOption.HasValue() ? idOption.Value() : null;
                if (id is not null)
                {
                    // ! MS-SQL
                    var result = H1Helper.Query(id);
                    if (result.Count == 0)
                    {
                        Console.WriteLine($"result not find.", Color.Red);
                        return 1;
                    }

                    //var enamehMap = result
                    //    .Where( x => x.Club_id is not null)
                    //    .GroupBy(x => x.Club_id)
                    //    .ToDictionary(x => x.Key, x => x.ToList());

                    result.ForEach(x =>
                    {
                        Console.WriteLine($"Club_id: '{x.Club_id}', TandemID: '{x.TandemID}', ReportTime: {x.ReportTime}", Color.Aqua);

                        if (x.TandemID is null)
                        {
                            Console.WriteLine($"null TandemID", Color.Yellow);
                            return;
                        }

                        var tId = x.TandemID.ToString();
                        var result2 = W1Helper.Query(tId);
                        if (result2.Count == 0)
                        {
                            Console.WriteLine($"result2 not find(tId: '{tId}').", Color.Red);
                            return;
                        }
                        var r = result2.ToList();
                        r.ForEach(y =>
                        {
                            //var ename = enamehMap.ContainsKey(y.Club_id)
                            //    ? enamehMap.FirstOrDefault().Club_Cname
                            //    : "";
                            Console.WriteLine($"id: '{y.id}', game_id: {y.Game_id}, Club_id: {y.Club_id}, Club_Ename: , reportdatetime: {y.ReportDatetime}, recordcount: {y.RecordCount}", Color.Green);
                        });
                    });

                    return 0;
                }

                Console.WriteLine($"請輸入查詢參數.", Color.Red);
                return 1;
            });
        });
    }
}