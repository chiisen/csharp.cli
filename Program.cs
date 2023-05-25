// See https://aka.ms/new-console-template for more information
using McMaster.Extensions.CommandLineUtils;
using System.Reflection;
using System.Runtime.Caching;

public partial class Program
{
    private static string currentPath;
    private static CommandLineApplication _app = new() { Name = "csharp.cli" };

    private static ObjectCache Cache = MemoryCache.Default;
    private static readonly int SECONDS_EXPIRATION = 600;// 指定秒數後回收

    static int Main(string[] args)
    {
        #region 顯示執行路徑
        currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        Console.WriteLine($"執行路徑: {currentPath}");
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
        _app.HelpOption("-?|-h|--help");
        _app.OnExecute(() =>
        {
            _app.ShowHelp();
            return 0;
        });

        #endregion 【設定 Help】


        #region 【註冊 Command】

        // ! 註冊 Command
        example();

        echo();

        polly();

        betArea();

        csv();

        version();

        cache();

        json();
        #endregion 【註冊 Command】

        int ret = -1;
        try
        {
            ret = _app.Execute(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"發生錯誤:{ex.Message}");
        }

        #region 取的 File Version
        // ! 取的 File Version
        Assembly assembly = Assembly.GetExecutingAssembly();
        System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
        string fileVersion = fvi.FileVersion;
        #endregion 取的 File Version

        #region 取得 Assembly Version
        // ! 取得 Assembly Version
        string AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        #endregion 取得 Assembly Version

        Console.WriteLine($" AssemblyVersion: {AssemblyVersion}\r\n FileVersion: {fileVersion}\r\n 回傳值為: {ret}");
        Console.WriteLine($"按任何鍵繼續....");
        Console.ReadKey();

        return 0;
    }
}