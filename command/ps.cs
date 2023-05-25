using McMaster.Extensions.CommandLineUtils;
using System.Diagnostics;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: pwd
    /// </summary>
    public static void ps()
    {
        _ = _app.Command("ps", command =>
        {
            // 第二層 Help 的標題
            command.Description = "pwd 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                // ! powershell 下 Get-ChildItem Env: 可以列出環境變數
                PowerShellHelper ps = new();
                ps.Execute("Get-ChildItem Env:");

                return 0;
            });
        });
    }
}
