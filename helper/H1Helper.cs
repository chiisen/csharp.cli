using csharp.cli.model;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using Console = Colorful.Console;


namespace csharp.cli;

/// <summary>
/// H1 - MS-SQL
/// </summary>
public class H1Helper
{
    private const string _connString = "Data Source=daydb-svc.h1-db-uat;Initial Catalog=HKNetGame_HJ;User ID=Wallet;Password=rfv761!!$;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Pooling=true;Min Pool Size=10;Max Pool Size=150;";
    private static readonly SqlConnection _connection = new(_connString);
    private static readonly string _strSql = "SELECT * FROM HKNetGame_HJ.dbo.T_Club_Stake_Current WHERE Club_id = @id;";

    public static List<T_Club_Stake_Current> Query(string id)
    {
        // ! MS-SQL
        var parameters = new Dictionary<string, object>
        {
            { "@id", id }
        };
        try
        {
            return _connection.Query<T_Club_Stake_Current>(_strSql, new DynamicParameters(parameters), commandType: CommandType.Text).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"{_strSql}", Color.Yellow);

            Console.WriteLine($"{e}", Color.Red);
            throw;
        }
    }
}
