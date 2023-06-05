using System.Diagnostics;

namespace csharp.cli;
public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: pwd
    /// </summary>
    public static void Pwd()
    {
        _ = App.Command("pwd", command =>
        {
            // 第二層 Help 的標題
            command.Description = "pwd 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                Console.WriteLine($"Launched from {System.Environment.CurrentDirectory}");
                Console.WriteLine($"Physical location {AppDomain.CurrentDomain.BaseDirectory}");
                Console.WriteLine($"AppContext.BaseDir {AppContext.BaseDirectory}");
                var processModule = Process.GetCurrentProcess().MainModule;
                if (processModule != null)
                {
                    Console.WriteLine($"Runtime Call {Path.GetDirectoryName(processModule.FileName)}");
                }
                else
                {
                    Console.WriteLine("null processModule");
                }

                return 0;
            });
        });
    }
}
