// See https://aka.ms/new-console-template for more information

using System.Drawing;
using McMaster.Extensions.CommandLineUtils;
using System.Reflection;
using System.Runtime.Caching;
using Console = Colorful.Console;
using Serilog;

namespace csharp.cli;

public partial class Program
{
    private static string? _currentPath = "";
    private static readonly CommandLineApplication App = new() { Name = "csharp.cli" };

    private static readonly ObjectCache MemoryCache = System.Runtime.Caching.MemoryCache.Default;
    private static readonly int SECONDS_EXPIRATION = 600;// 指定秒數後回收

    private static int Main(string[] args)
    {
        #region 測試Serilog

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/cli.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();
        
        try
        {
            // 這裡請放你原本主程式要寫的所有程式碼！
            var now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
            Log.Verbose($"Hello {now}");
            Log.Debug($"Hello {now}");
            Log.Information($"Hello {now}");
            Log.Warning($"Hello {now}");
            Log.Error($"Hello {now}");
            Log.Fatal($"Hello {now}");
        }
        catch (Exception ex)
        {
            // 紀錄你的應用程式中未被捕捉的例外 (Unhandled Exception)
            Log.Error(ex, "Something went wrong");
        }
        finally
        {
            Log.CloseAndFlush(); // 非常重要的一段！
        }

        #endregion 測試Serilog

        Console.WriteLine($"^^^^^^^^^^^^^^^^", Color.Chartreuse);

        #region 顯示執行路徑
        var assem = Assembly.GetEntryAssembly();
        if (assem is not null)
        {
            _currentPath = Path.GetDirectoryName(assem.Location);
        }
        Console.WriteLine($"執行路徑: {_currentPath}", Color.Aqua);
        Console.WriteLine($"================", Color.Aqua);
        #endregion 顯示執行路徑

        #region 【Logger 輸入參數】

        // ! Logger 輸入參數
        var argString = args.Aggregate("", (current, arg) => current + (arg + " "));
        Console.WriteLine($"輸入參數:csharp.cli {argString}");
        Console.WriteLine($"====================");

        #endregion 【Logger 輸入參數】


        #region 【設定 Help】

        // ! 設定 Help
        App.HelpOption("-?|-h|--help");
        App.OnExecute(() =>
        {
            App.ShowHelp();
            return 0;
        });

        #endregion 【設定 Help】


        #region 【註冊 Command】

        // ! 註冊 Command
        Example();

        Echo();

        Polly();

        BetArea();

        Csv();

        Version();

        Cache();

        Json();

        Pwd();

        Environment();

        Ps();

        Excel();

        MultiThread();

        BetAreaAll();

        Coverage();

        pgsql();

        mssql();

        H1BetCheck();

        Example0();

        findId();

        commit();

        Redis();

        BigInsert();

        Plinq();
        #endregion 【註冊 Command】

        var ret = -1;
        try
        {
            ret = App.Execute(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"發生錯誤:{ex.Message}");
        }

        #region 取的 File Version
        // ! 取的 File Version
        var assembly = Assembly.GetExecutingAssembly();
        var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
        var fileVersion = "";
        if (fvi.FileVersion is not null)
        {
            fileVersion = fvi.FileVersion;
        }

        #endregion 取的 File Version

        #region 取得 Assembly Version
        // ! 取得 Assembly Version
        var assemblyVersion = "";
        var execAssem = Assembly.GetExecutingAssembly();
        if (execAssem?.GetName() is not null)
        {
            var ver = execAssem.GetName().Version;
            if (ver is not null)
            {
                assemblyVersion = ver.ToString();
            }
        }

        #endregion 取得 Assembly Version

        Console.WriteLine($"================", Color.Blue);
        Console.WriteLine($"csharp.cli find-id -? 或 -help 可以查第二層說明", Color.Yellow);
        Console.WriteLine($"================", Color.Blue);
        Console.WriteLine($" AssemblyVersion: {assemblyVersion}\r\n FileVersion: {fileVersion}\r\n 回傳值為: {ret}");
        Console.WriteLine($"^^^^程式結束^^^^", Color.Green);
        //Console.WriteLine($"按任何鍵繼續....");
        //Console.ReadKey();

        return 0;
    }
}