using Colorful;
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

                    var enamehMap = h1Result
                        .Where(x => x.Club_id is not null)
                        .GroupBy(x => x.Club_id)
                        .ToDictionary(x => x.Key ?? "default", x => x.ToList());

                    if (enamehMap is null)
                    {
                        Console.WriteLine($"null enamehMap.", Color.Red);
                        return 1;
                    }

                    h1Result.ForEach(h1 =>
                    {
                        const string h1Message = "<H1> Club_id: '{0}', TandemID: '{1}', ReportTime----: {2}";
                        var h1Colors = new Formatter[]
                        {
                            new (h1.Club_id, Color.Red),
                            new (h1.TandemID, Color.Blue),
                            new ($"{h1.ReportTime:yyyy-MM-dd_HH-mm-ss-fff}", Color.Yellow)
                        };
                        Console.WriteLineFormatted(h1Message, Color.White, h1Colors);

                        if (h1.TandemID is null)
                        {
                            Console.WriteLine($"null TandemID", Color.Yellow);
                            return;
                        }

                        var tId = h1.TandemID.ToString();
                        var w1Result = W1Helper.Query(tId);
                        if (w1Result.Count == 0)
                        {
                            Console.WriteLine($"w1Result not find(tId: '{tId}')", Color.Red);
                            Console.WriteLine($"w1Result SQL: '{W1Helper.GetSql()}'", Color.Yellow);
                            // ! 確認是否有連線
                            Console.WriteLine($"w1Result Version: '{W1Helper.Version()}'", Color.Green);
                            return;
                        }
                        var result = w1Result.ToList();
                        result.ForEach(w1 =>
                        {
                            if (w1.Club_id is null)
                            {
                                Console.WriteLine($"null y.Club_id", Color.Red);
                                return;
                            }
                            var ename = "【找不到】";
                            if (enamehMap.TryGetValue(w1.Club_id, out var value))
                            {
                                if (value is not null)
                                {
                                    ename = value.FirstOrDefault()?.Club_Ename ?? "【無值】";
                                }
                            }

                            w1.id ??= "【無值】";

                            const string w1Message = "<W1> Club_id: '{0}', id:       '{1}', reportdatetime: {2}, Club_Ename: '{3}', recordcount: {4}";
                            var w1Colors = new Formatter[]
                            {
                                new (w1.Club_id, Color.Red),
                                new (w1.id.Trim(), Color.Blue),
                                new ($"{w1.ReportDatetime:yyyy-MM-dd_HH-mm-ss-fff}", Color.Yellow),
                                new (ename, Color.Green),
                                new (w1.RecordCount, Color.Aquamarine)
                            };
                            Console.WriteLineFormatted(w1Message, Color.White, w1Colors);

                            Console.WriteLine("==================", Color.Blue);
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