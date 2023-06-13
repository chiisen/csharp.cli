using csharp.cli.model;
using Dapper;
using Npgsql;
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
    private static readonly string _strSql = "SELECT * FROM public.t_bet_record_summary WHERE \"id\"::text = '@t_id';";
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
            throw;
        }
    }
}

