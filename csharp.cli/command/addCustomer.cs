using csharp.cli.helper;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

/// <summary>
/// addCustomer 的 Redis 設定資訊
/// </summary>
public class addCustomerRedisInfo
{
    public string action { get; set; }
    public string source { get; set; }
    public string destination { get; set; }
    public string fileName { get; set; }
    public List<string>? content { get; set; }
}

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

                var list = RedisHelper.GetValue<List<addCustomerRedisInfo>>("add-customer");
                if (list is null)
                {
                    Console.WriteLine($"null list");
                    return 1;
                }

                // 全大寫
                customerCode = customerCode.ToUpper();

                // 第一個字大寫
                var c1Code = customerCode.ToLower();
                c1Code = c1Code[..1].ToUpper() + c1Code[1..];

                // 全小寫
                var c2Code = customerCode.ToLower();

                foreach (var info in list)
                {
                    switch (info.action)
                    {
                        case "COPY":
                        {
                            var fileName = info.fileName.Replace("##CUSTOMER##", customerCode);

                            fileName = fileName.Replace("##CUSTOMER1##", c1Code);

                            fileName = fileName.Replace("##CUSTOMER2##", c2Code);

                            var sourceFile = @$"{sourceFolder}{info.source}{info.fileName}";
                            if (File.Exists(sourceFile) is false)
                            {
                                Console.WriteLine($"檔案不存在: {sourceFile}");
                                return 1;
                            }

                            var destinationFile = @$"{destinationFolder}{info.destination}{fileName}";

                            var path = @$"{destinationFolder}{info.destination}";
                            Directory.CreateDirectory(path);

                            // To overwrite the destination file if it already exists.
                            File.Copy(sourceFile, destinationFile, true);

                            Console.WriteLine($"新增客戶-檔案: {destinationFile}");

                            var newText = File.ReadAllText(destinationFile);
                            newText = newText.Replace("##CUSTOMER##", customerCode);
                            newText = newText.Replace("##CUSTOMER1##", c1Code);
                            newText = newText.Replace("##CUSTOMER2##", c2Code);

                            File.WriteAllText(destinationFile, newText);

                            break;
                        }
                        case "INSERT":
                        {
                            var destinationFile = @$"{destinationFolder}{info.destination}{info.fileName}";
                            if (File.Exists(destinationFile) is false)
                            {
                                Console.WriteLine($"檔案不存在: {destinationFile}");
                                return 1;
                            }
                            var newText = File.ReadAllText(destinationFile);
                            var contentList = new List<string>();
                            info.content?.ForEach(x =>
                            {
                                var y = x.Replace("##CUSTOMER##", customerCode);
                                y = y.Replace("##CUSTOMER1##", c1Code);
                                y = y.Replace("##CUSTOMER2##", c2Code);
                                contentList.Add(y);

                                Console.WriteLine($"新增客戶-程式碼: {y}");
                            });

                            var oneline = string.Join("\r", contentList);
                            oneline += "\r";
                            oneline += info.source;
                            newText = newText.Replace(info.source, oneline);

                            File.WriteAllText(destinationFile, newText);
                            break;
                        }
                    }
                }
                
                return 0;
            });
        });
    }
}