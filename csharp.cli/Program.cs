// See https://aka.ms/new-console-template for more information

using McMaster.Extensions.CommandLineUtils;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.Caching;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    private static string? _currentPath = "";
    private static readonly CommandLineApplication App = new() { Name = "csharp.cli" };

    private static readonly ObjectCache MemoryCache = System.Runtime.Caching.MemoryCache.Default;
    private static readonly int SECONDS_EXPIRATION = 600;// 指定秒數後回收

    private static int Main(string[] args)
    {
        // 指定輸出為 UTF8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        #region 測試Serilog
        var sw = Stopwatch.StartNew();
        /*
         Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/cli.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();

        sw.Stop();

        Console.WriteLine($"測試Serilog - sw: {sw.ElapsedMilliseconds}", Color.Azure);
        */


        /*
        try
        {
            sw = Stopwatch.StartNew();

            // 這裡請放你原本主程式要寫的所有程式碼！
            var now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
            Log.Verbose($"Hello {now}");
            Log.Debug($"Hello {now}");
            Log.Information($"Hello {now}");
            Log.Warning($"Hello {now}");
            Log.Error($"Hello {now}");
            Log.Fatal($"Hello {now}");

            sw.Stop();

            Console.WriteLine($"測試 log - sw: {sw.ElapsedMilliseconds}", Color.Azure);
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
        */

        #endregion 測試Serilog


        Console.WriteLine($"^^^^^^^^^^^^^^^^", Color.Chartreuse);


        #region start-time
        /*
        sw = Stopwatch.StartNew();

        RedisHelper.SetValue<string>("start-time", DateTime.Now.ToString("yyyy-M-d hh:mm:ss"));

        sw.Stop();

        Console.WriteLine($"start-time - sw: {sw.ElapsedMilliseconds}", Color.Azure);
        */
        #endregion start-time




        #region 顯示執行路徑

        sw = Stopwatch.StartNew();

        var assem = Assembly.GetEntryAssembly();
        if (assem is not null)
        {
            _currentPath = Path.GetDirectoryName(assem.Location);
        }
        Console.WriteLine($"執行路徑: {_currentPath}", Color.Aqua);
        Console.WriteLine($"================", Color.Aqua);

        sw.Stop();

        Console.WriteLine($"顯示執行路徑 - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 顯示執行路徑

        #region 【Logger 輸入參數】

        sw = Stopwatch.StartNew();

        // ! Logger 輸入參數
        var argString = args.Aggregate("", (current, arg) => current + (arg + " "));
        Console.WriteLine($"輸入參數:csharp.cli {argString}");
        Console.WriteLine($"====================");

        sw.Stop();

        Console.WriteLine($"Logger 輸入參數 - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 【Logger 輸入參數】


        #region 【設定 Help】

        sw = Stopwatch.StartNew();

        // ! 設定 Help
        App.HelpOption("-?|-h|--help");
        App.OnExecute(() =>
        {
            App.ShowHelp();
            return 0;
        });

        sw.Stop();

        Console.WriteLine($"設定 Help - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 【設定 Help】


        #region 【註冊 Command】

        sw = Stopwatch.StartNew();

        // ! 註冊 Command
        TerminalGui();
        
        Example();

        Banner();

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

        ExcelConvert();

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

        addGames();

        autoSort();

        updateVersion();

        addCustomer();

        eventNews();

        ExcelToGameList();

        IChing();

        NLuaExample();

        sw.Stop();

        Console.WriteLine($"註冊 Command - sw: {sw.ElapsedMilliseconds}", Color.Azure);

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

        sw = Stopwatch.StartNew();

        // ! 取的 File Version
        var assembly = Assembly.GetExecutingAssembly();
        var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
        var fileVersion = "";
        if (fvi.FileVersion is not null)
        {
            fileVersion = fvi.FileVersion;
        }

        sw.Stop();

        Console.WriteLine($"取的 File Version - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 取的 File Version

        #region 取得 Assembly Version

        sw = Stopwatch.StartNew();

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

        sw.Stop();

        Console.WriteLine($"取得 Assembly Version - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 取得 Assembly Version


        Console.WriteLine($"================", Color.Blue);
        Console.WriteLine($"csharp.cli find-id -? 或 -help 可以查第二層說明", Color.Yellow);
        Console.WriteLine($"================", Color.Blue);
        Console.WriteLine($" AssemblyVersion: {assemblyVersion}\r\n FileVersion: {fileVersion}\r\n 回傳值為: {ret}");
        Console.WriteLine($"^^^^程式結束^^^^", Color.Green);
        //Console.WriteLine($"按任何鍵繼續....");
        //Console.ReadKey();

        #region end-time
        /*
        sw = Stopwatch.StartNew();

        RedisHelper.SetValue<string>("end-time", DateTime.Now.ToString("yyyy-M-d hh:mm:ss"));

        sw.Stop();

        Console.WriteLine($"end-time - sw: {sw.ElapsedMilliseconds}", Color.Azure);
        */
        #endregion end-time


        return 0;
    }
}