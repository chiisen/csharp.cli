using csharp.cli.helper;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

/// <summary>
/// addCustomer 的 Redis 設定資訊
/// </summary>
public class addCustomerRedisInfo
{
    public string? action { get; set; }
    public string? source { get; set; }
    public string? destination { get; set; }
    public string? fileName { get; set; }
    public List<string>? content { get; set; }
}

public partial class Program
{
    /// <summary>
    /// 利用 Redis 上的 Json 設定腳本，自動修改或新增目標路徑的內容
    /// Redis 為本地端，並非遠端，所以不用擔心安全性問題，連線字串為: 127.0.0.1@6379
    /// Redis 的 Windows 版本下載網址: https://github.com/MicrosoftArchive/redis/releases
    /// Redos 的 Client 端下載網址: https://github.com/qishibo/AnotherRedisDesktopManager
    /// Redis 的 Client 端也可以用 choco install another-redis-desktop-manager 安裝
    /// 或是用winget install qishibo.AnotherRedisDesktopManager 安裝
    /// Redis 的唯一 key 為 `csharp.cli:add-customer`
    /// 腳本參考: https://hackmd.io/@chiisen/B1Drd6djn
    /// 目前只有 COPY 新增檔案、INSERT 新增程式碼
    /// 腳本中的 ##CUSTOMER## 為全大寫，例如: PME
    /// 腳本中的 ##CUSTOMER1## 為第一個字大寫，例如: Pme
    /// 腳本中的 ##CUSTOMER2## 為全小寫，例如: pme
    /// 命令列引數: add-customer GEMINI
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

                const string redisKey = "add-customer";
                var list = RedisHelper.GetValue<List<addCustomerRedisInfo>>(redisKey);
                if (list is null)
                {
                    Console.WriteLine($"null list ({RedisHelper.GetProjectName()}:{redisKey})");
                    return 1;
                }

                // 全大寫 ##CUSTOMER##
                customerCode = customerCode.ToUpper();

                // 第一個字大寫 ##CUSTOMER1##
                var c1Code = customerCode.ToLower();
                c1Code = c1Code[..1].ToUpper() + c1Code[1..];

                // 全小寫 ##CUSTOMER2##
                var c2Code = customerCode.ToLower();

                foreach (var info in list)
                {
                    switch (info.action)
                    {
                        case "COPY":
                            {
                                var fileName = info.fileName?.Replace("##CUSTOMER##", customerCode);

                                fileName = fileName?.Replace("##CUSTOMER1##", c1Code);

                                fileName = fileName?.Replace("##CUSTOMER2##", c2Code);

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

                                /*
                                    const string pattern = @"(\r)+";
                                    const string replacement = "\r\n";
                                    newText = Regex.Replace(newText, pattern, replacement);

                                    newText = newText.Replace("\r", "\r\n");// 調整為 CRLF
                                    */
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

                                var oneline = string.Join("\r\n", contentList);
                                oneline += "\r\n";
                                oneline += info.source;

                                if (info.source != null)
                                {
                                    newText = newText.Replace(info.source, oneline);
                                }

                                /*
                                    const string pattern = @"(\r)+";
                                    const string replacement = "\r\n";
                                    newText = Regex.Replace(newText, pattern, replacement);

                                    newText = newText.Replace("\r", "\r\n");// 調整為 CRLF
                                    */

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