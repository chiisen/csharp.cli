using McMaster.Extensions.CommandLineUtils;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example "words" -r 10
    /// </summary>
    public static void version()
    {
        _ = _app.Command("version", command =>
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
