namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: version
    /// </summary>
    public static void Version()
    {
        _ = App.Command("version", command =>
        {
            // 第二層 Help 的標題
            command.Description = "目前安裝的版本號。";

            command.OnExecute(() =>
            {
                string strCmdText;
                strCmdText = "/C dotnet tool list -g";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                return 0;
            });
        });
    }
}
