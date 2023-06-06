namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// PowerShell 範例程式
    /// 命令列引數: ps
    /// </summary>
    public static void Ps()
    {
        _ = App.Command("ps", command =>
        {
            // 第二層 Help 的標題
            command.Description = "power shell 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                // ! powershell 下 Get-ChildItem Env: 可以列出環境變數
                var ps = new PowerShellHelper();
                ps.Execute("Get-ChildItem Env:");

                return 0;
            });
        });
    }
}
