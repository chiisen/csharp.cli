using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: commit
    /// </summary>
    public static void commit()
    {
        _ = App.Command("commit", command =>
        {
            // 第二層 Help 的標題
            command.Description = "commit 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var messageArgument = command.Argument("[message]", "指定需要輸出的 commit message。");

            command.OnExecute(() =>
            {
                var message = messageArgument.HasValue ? messageArgument.Value : null;
                if (message == null)
                {
                    Console.WriteLine($"null message");
                    return 1;
                }


                string[] strCmdText = {
                    "git status",
                    "git add .",
                    $"git commit -m \"feat: {message}\"",
                    "git push",
                };

                var ps = new PowerShellHelper();

                foreach (var cmd in strCmdText)
                {
                    ps.Execute($"echo \">> {cmd}\"");
                    ps.Execute(cmd);
                    //ps.Execute("pause");
                }

                return 0;
            });
        });
    }
}