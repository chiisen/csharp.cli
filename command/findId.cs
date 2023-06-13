using csharp.cli.model;
using Dapper;
using DocumentFormat.OpenXml.Drawing;
using McMaster.Extensions.CommandLineUtils;
using Npgsql;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: findId
    /// </summary>
    public static void findId()
    {
        _ = App.Command("find-id", command =>
        {
            // 第二層 Help 的標題
            command.Description = "find id 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入指令說明
            var enameOption = command.Option("-e|--ename", "指定查詢暱稱", CommandOptionType.SingleValue);
            var idOption = command.Option("-i|--id", "指定查詢ID", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                const string connString = "Server=wallet-dev-postgresql.db-dev;Database=centerwallet;User Id=cwapi;Password='3Yw9*N|OKR2C';Pooling=true;Minimum Pool Size=5;Maximum Pool Size=150;";

                var ename = enameOption.HasValue() ? enameOption.Value() : null;
                var id = idOption.HasValue() ? idOption.Value() : null;
                if (ename is not null)
                {
                    const string strSql = @"SELECT club_id,
    club_ename,
    credit,
    lock_credit,
    currency,
    franchiser_id,
    last_platform
FROM public.t_wallet
WHERE club_ename = @ename;";
                    var par = new DynamicParameters(connString);
                    par.Add("@ename", ename);

                    using var conn = new NpgsqlConnection(connString);
                    var result = conn.Query<Wallet>(strSql, par).ToList();
                    var r = result.FirstOrDefault();
                    Console.WriteLine($"id: {r.Club_id}", Color.Green);

                    return 1;
                }
                else if (id is not null)
                {
                    const string strSql = @"SELECT club_id,
    club_ename,
    credit,
    lock_credit,
    currency,
    franchiser_id,
    last_platform
FROM public.t_wallet
WHERE club_id = @id;";
                    var par = new DynamicParameters(connString);
                    par.Add("@id", id);

                    using var conn = new NpgsqlConnection(connString);
                    var result = conn.Query<Wallet>(strSql, par).ToList();
                    var r = result.FirstOrDefault();
                    Console.WriteLine($"Ename: {r.Club_Ename}", Color.Green);
                }

                Console.WriteLine($"請輸入參數.", Color.Red);
                return 1;
            });
        });
    }
}