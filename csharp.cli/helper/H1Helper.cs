using csharp.cli.model;
using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
    private static readonly string _strSql = @"SELECT 
ReportStamp,
    Club_id,
    Game_id,
    JiTai_id,
    Stake_id,
    ZhuDan_Type,
    Stake_Score,
    Account_Score,
    [Datetime],
    Active,
    Id,
    YouXiaoYaFen,
    Club_TuiSui,
    JXS_TuiSui,
    JXS_ChengShu,
    ZDL_TuiSui,
    ZDL_ChengShu,
    GD_TuiSui,
    GD_ChengShu,
    DGD_TuiSui,
    DGD_ChengShu,
    FuDong_PeiLv,
    Ip,
    ReportTime,
    Desk_id,
    No_Run,
    No_Active,
    JiTai_No,
    StakeType,
    MaHao,
    PeiLv,
    Club_JS_Flag,
    JXS_JS_Flag,
    ZDL_JS_Flag,
    GD_JS_Flag,
    DGD_JS_Flag,
    HuiLv_Type,
    HuiLv_Value,
    Franchiser_id,
    Franchiser_Ename,
    Franchiser_Cname,
    Club_Ename,
    Club_Cname,
    Now_XinYong,
    ShengDian,
    YaMa,
    ShengDian_Flag,
    ZuBie,
    Server_id,
    ZJ_TuiSui,
    ZJ_ChengShu,
    StartSeqNoFlag,
    EndSeqNoFlag,
    Jackpot_Score,
    JackpotPool_Value,
    TableFee,
    Commission,
    CalType,
    RCGRecord,
    TandemID 
FROM HKNetGame_HJ.dbo.T_Club_Stake_Current WHERE Club_id = @id;";
    public static string GetSql()
    {
        return _strSql;
    }

    public static string? Version()
    {
        // ! MS-SQL
        var parameters = new Dictionary<string, object>();
        return _connection.Query<string>("SELECT @@version;", new DynamicParameters(parameters), commandType: CommandType.Text).FirstOrDefault();
    }
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
            Console.WriteLine($"{_strSql}", System.Drawing.Color.Yellow);

            Console.WriteLine($"{e}", System.Drawing.Color.Red);

            Console.WriteLine($"id: {id}", System.Drawing.Color.Green);
            throw;
        }
    }
}
