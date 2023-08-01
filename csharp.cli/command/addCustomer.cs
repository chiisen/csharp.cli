using System.Drawing;
using System.Text;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: add-customer
    /// </summary>
    public static void addCustomer()
    {
        _ = App.Command("add-customer", command =>
        {
            // 第二層 Help 的標題
            command.Description = "add-customer 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var code = command.Argument("[customerCode]", "客戶英文代碼。");

            command.OnExecute(() =>
            {
                Console.WriteLine($"add-customer", Color.Azure);
                var customerCode = code.HasValue ? code.Value : null;
                if (customerCode == null)
                {
                    Console.WriteLine($"null customerCode");
                    return 1;
                }
                var sourceFolder = @$"{AppDomain.CurrentDomain.BaseDirectory}";
                var destinationFolder = @$"{System.Environment.CurrentDirectory}\";
                var sourceFile = @$"{sourceFolder}resource\AdminAPI_Core5\Controllers\Game\Game##CUSTOMER1##ApiController.cs";
                var destinationFile = @$"{destinationFolder}AdminAPI_Core5\Controllers\Game\Game{code}ApiController.cs";

                // To overwrite the destination file if it already exists.
                File.Copy(sourceFile, destinationFile, true);
                return 0;
            });
        });
    }
}