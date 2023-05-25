using McMaster.Extensions.CommandLineUtils;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: environment
    /// </summary>
    public static void environment()
    {
        _ = _app.Command("environment", command =>
        {
            // 第二層 Help 的標題
            command.Description = "environment 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                // ! 取得環境變數
                string envVar = Environment.GetEnvironmentVariable("path");
                if (envVar != null)
                {
                    Console.WriteLine(envVar);
                }

                return 0;
            });
        });
    }
}

