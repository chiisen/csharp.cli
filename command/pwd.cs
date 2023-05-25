using McMaster.Extensions.CommandLineUtils;
using System.Diagnostics;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: pwd
    /// </summary>
    public static void pwd()
    {
        _ = _app.Command("pwd", command =>
        {
            // 第二層 Help 的標題
            command.Description = "pwd 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                Console.WriteLine($"Launched from {Environment.CurrentDirectory}");
                Console.WriteLine($"Physical location {AppDomain.CurrentDomain.BaseDirectory}");
                Console.WriteLine($"AppContext.BaseDir {AppContext.BaseDirectory}");
                Console.WriteLine($"Runtime Call {Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)}");

                return 0;
            });
        });
    }
}
