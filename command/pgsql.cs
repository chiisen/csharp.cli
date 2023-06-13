using csharp.cli.model;
using Dapper;
using Npgsql;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: pgsql 
    /// </summary>
    public static void pgsql()
    {
        _ = App.Command("pgsql", command =>
        {
            // 第二層 Help 的標題
            command.Description = "PostgreSQL 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                const string connString = "Server=wallet-dev-postgresql.db-dev;Database=centerwallet;User Id=cwapi;Password='3Yw9*N|OKR2C';Pooling=true;Minimum Pool Size=5;Maximum Pool Size=150;";
                var startTime = new DateTime(2023, 5, 16, 0, 0, 0);
                var endTime = new DateTime(2023, 5, 16, 23, 59, 59);

                const string strSql = @"SELECT *
		              FROM   t_mg_bet_record
		              WHERE gameendtimeutc >= @startTime 
		              AND gameendtimeutc <= @endTime";
                var par = new DynamicParameters(connString);
                par.Add("@startTime", startTime);
                par.Add("@endTime", endTime);

                using var conn = new NpgsqlConnection(connString);
                var result = conn.Query<BetRecord>(strSql, par).ToList();
                result = result.Where(x => x.GameCode != null && x.GameCode.Equals("SMG_10000Wishes")).ToList();
                result.ForEach(x =>
                {
                    Console.WriteLine($"{x.BetUID}", Color.Green);
                });

                return 0;
            });
        });
    }
}