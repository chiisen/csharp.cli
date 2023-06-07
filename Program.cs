// See https://aka.ms/new-console-template for more information
using McMaster.Extensions.CommandLineUtils;
using System.Reflection;
using System.Runtime.Caching;

namespace csharp.cli;

public partial class Program
{
    private static string? _currentPath = "";
    private static readonly CommandLineApplication App = new() { Name = "csharp.cli" };

    private static readonly ObjectCache Cache = MemoryCache.Default;
    private static readonly int SECONDS_EXPIRATION = 600;// 指定秒數後回收

    static int Main(string[] args)
    {
        Console.WriteLine($"================");

        #region 顯示執行路徑
        var assem = Assembly.GetEntryAssembly();
        if(assem is not null)
        {
            _currentPath = Path.GetDirectoryName(assem.Location);
        }        
        Console.WriteLine($"執行路徑: {_currentPath}");
        #endregion 顯示執行路徑

        #region 【Logger 輸入參數】

        // ! Logger 輸入參數
        string argString = "";
        foreach (var arg in args)
        {
            argString += arg + " ";

        }
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

        cache();

        Json();

        Pwd();

        Environment();

        Ps();

        Excel();

        MultiThread();

        BetAreaAll();
        #endregion 【註冊 Command】

        int ret = -1;
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
            if(ver is not null)
            {
                assemblyVersion = ver.ToString();
            }
        }
        
        #endregion 取得 Assembly Version

        Console.WriteLine($"================");
        Console.WriteLine($" AssemblyVersion: {assemblyVersion}\r\n FileVersion: {fileVersion}\r\n 回傳值為: {ret}");
        Console.WriteLine($"====程式結束====");
        //Console.WriteLine($"按任何鍵繼續....");
        //Console.ReadKey();

        return 0;
    }
}