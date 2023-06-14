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
    public static void H1BetCheck()
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
                    var h1Result = H1Helper.Query(id);
                    if (h1Result is null)
                    {
                        Console.WriteLine($"null h1Result.", Color.Red);
                        return 1;
                    }
                    if (h1Result.Count == 0)
                    {
                        Console.WriteLine($"h1Result not find(id: '{id}').", Color.Red);
                        Console.WriteLine($"h1Result SQL: '{H1Helper.GetSql()}'", Color.Yellow);
                        // ! 確認是否有連線
                        Console.WriteLine($"h1Result Version: '{H1Helper.Version()}'", Color.Green);
                        return 1;
                    }

#pragma warning disable CS8714 // 型別無法作為型別參數用於泛型型別或方法中。型別引數的可 Null 性與 'notnull' 限制式不符合。
                    var enamehMap = h1Result
                        .Where(x => x.Club_id is not null)
                        .GroupBy(x => x.Club_id)
                        .ToDictionary(x => x.Key, x => x.ToList());
#pragma warning restore CS8714 // 型別無法作為型別參數用於泛型型別或方法中。型別引數的可 Null 性與 'notnull' 限制式不符合。
                    if (enamehMap is null)
                    {
                        Console.WriteLine($"null enamehMap.", Color.Red);
                        return 1;
                    }

                    h1Result.ForEach(x =>
                    {
                        Console.WriteLine($"<H1> Club_id: '{x.Club_id}', TandemID: '{x.TandemID}', ReportTime----: {x.ReportTime:yyyy-MM-dd_HH-mm-ss-fff}", Color.Aqua);

                        if (x.TandemID is null)
                        {
                            Console.WriteLine($"null TandemID", Color.Yellow);
                            return;
                        }

                        var tId = x.TandemID.ToString();
                        var w1Result = W1Helper.Query(tId);
                        if (w1Result.Count == 0)
                        {
                            Console.WriteLine($"w1Result not find(tId: '{tId}')", Color.Red);
                            Console.WriteLine($"w1Result SQL: '{W1Helper.GetSql()}'", Color.Yellow);
                            // ! 確認是否有連線
                            Console.WriteLine($"w1Result Version: '{W1Helper.Version()}'", Color.Green);
                            return;
                        }
                        var r = w1Result.ToList();
                        r.ForEach(y =>
                        {
                            if (y.Club_id is null)
                            {
                                Console.WriteLine($"null y.Club_id", Color.Red);
                                return;
                            }
                            var ename = "【找不到】";
                            if (enamehMap.TryGetValue(y.Club_id, out var value))
                            {
                                if (value is not null)
                                {
                                    ename = value.FirstOrDefault()?.Club_Ename ?? "【無值】";
                                }
                            }

                            y.id ??= "【無值】";
                            Console.WriteLine($"<W1> Club_id: '{y.Club_id}', id:       '{y.id.Trim()}', reportdatetime: {y.ReportDatetime:yyyy-MM-dd_HH-mm-ss-fff}, Club_Ename: '{ename}', recordcount: {y.RecordCount}", Color.Chartreuse);
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