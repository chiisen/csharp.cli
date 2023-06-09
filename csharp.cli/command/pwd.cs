﻿using System.Diagnostics;

namespace csharp.cli;
public partial class Program
{
    /// <summary>
    /// 顯示常用路徑
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
                Console.WriteLine(processModule is not null
                    ? $"Runtime Call {Path.GetDirectoryName(processModule.FileName)}"
                    : "null processModule");

                return 0;
            });
        });
    }
}
