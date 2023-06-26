using csharp.cli.model;
using Dapper;
using Npgsql;
using System.Data;
using System.Drawing;
using Console = Colorful.Console;


namespace csharp.cli;


/// <summary>
/// W1 - PostGresql
/// </summary>
public class W1Helper
{
    private const string _connString = "Server=wallet-uat-postgresql.db-uat;Database=centerwallet;User Id=cwapi;Password='3Yw9*N|OKR2C';Pooling=true;Minimum Pool Size=5;Maximum Pool Size=150;";
    private static readonly NpgsqlConnection _connection = new(_connString);
    private static readonly string _strSql = @"SELECT 
    CAST(id AS char(40)),
    club_id,
	game_id,
	game_type,
	bet_type,
	bet_amount,
	turnover,
	win,
	netwin,
	reportdatetime,
	currency,
	franchiser_id,
	recordcount,
	updatedatetime,
	jackpotwin
FROM public.t_bet_record_summary WHERE text(id) = @t_id;";

    public static string GetSql()
    {
        return _strSql;
    }
    public static string? Version()
    {
        // ! PostGresql
        var parameters = new DynamicParameters();
        return _connection.Query<string>("SELECT version();", parameters).FirstOrDefault();
    }
    public static List<BetRecordSummary> Query(string? tId)
    {
        // ! PostGresql
        var parameters = new DynamicParameters();
        parameters.Add("@t_id", tId);
        try
        {
            return _connection.Query<BetRecordSummary>(_strSql, parameters).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"{_strSql}", Color.Yellow);

            Console.WriteLine($"{e}", Color.Red);

            Console.WriteLine($"tId: {tId}", Color.Green);
            throw;
        }
    }
}

