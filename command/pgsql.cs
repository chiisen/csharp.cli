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
                const string gameCode = "SMG_10000Wishes";
                const string connString = "Server=wallet-dev-postgresql.db-dev;Database=centerwallet;User Id=cwapi;Password='3Yw9*N|OKR2C';Pooling=true;Minimum Pool Size=5;Maximum Pool Size=150;";
                var startTime = new DateTime(2023, 5, 16, 0, 0, 0);
                var endTime = new DateTime(2023, 5, 16, 23, 59, 59);

                const string strSql = @"SELECT *
		              FROM   t_mg_bet_record
		              WHERE gameendtimeutc >= @startTime 
		              AND gameendtimeutc <= @endTime";
                var parameters = new DynamicParameters();
                parameters.Add("@startTime", startTime);
                parameters.Add("@endTime", endTime);

                using var connection = new NpgsqlConnection(connString);
                var result = connection.Query<BetRecord>(strSql, parameters).ToList();
                result = result.Where(x => x.GameCode is gameCode).ToList();
                result.ForEach(x =>
                {
                    Console.WriteLine($"BetUID: {x.BetUID}, GameCode: {x.GameCode}, gameStartTimeUTC: {x.gameStartTimeUTC}", Color.Green);
                });

                return 0;
            });
        });
    }
}