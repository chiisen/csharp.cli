using McMaster.Extensions.CommandLineUtils;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Data;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example "words" -r 10
    /// </summary>
    public static void mssql()
    {
        _ = App.Command("mssql", command =>
        {
            // 第二層 Help 的標題
            command.Description = "mssql 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                var connString =
                    "Data Source=daydb-svc.h1-db-dev;Initial Catalog=HKNetGame_HJ;User ID=Wallet;Password=rfv761!!$;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Pooling=true;Min Pool Size=10;Max Pool Size=150;";
                using var connection = new SqlConnection(connString);
                var strSql = @"SELECT
    DISTINCT Game_id,
    MaHao
FROM T_JTZD_ALL
WHERE (Game_id IN ('ShaiZi'))
ORDER BY MaHao ASC;";

                var result = connection.Query(strSql, commandType: CommandType.Text);
                result = result.Where(x => x.MaHao != "RCGStakeChargeOff").ToList();
                result.ToList().ForEach(x =>
                {
                    Console.WriteLine($"Game_id: {x.Game_id} MaHao: {x.MaHao}", Color.Aqua);
                });
                return 0;
            });
        });
    }
}