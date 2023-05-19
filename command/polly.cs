using Polly;
using System.Net;

public partial class Program
{
    public static void polly()
    {
        _ = _app.Command("polly", command =>
        {
            // 第二層 Help 的標題
            command.Description = "重試測試。";

            command.OnExecute(() =>
            {
                Policy
                    // 1. 處理甚麼樣的例外
                    .Handle<HttpRequestException>()

                    //    或者返回條件(非必要)
                    .OrResult<HttpResponseMessage>(r => r.StatusCode != HttpStatusCode.OK)

                    // 2. 重試策略，包含重試次數
                    .Retry(3, (reponse, retryCount, context) =>
                    {
                        var result = reponse.Result;
                        if (result != null)
                        {
                            var errorMsg = result.Content
                                                 .ReadAsStringAsync()
                                                 .GetAwaiter()
                                                 .GetResult();
                            Console.WriteLine($"標準用法，發生錯誤：{errorMsg}，第 {retryCount} 次重試");
                        }
                        else
                        {
                            var exception = reponse.Exception;
                            Console.WriteLine($"標準用法，發生錯誤：{exception.Message}，第 {retryCount} 次重試");
                        }

                        Thread.Sleep(3000);
                    })

                    // 3. 執行內容
                    .Execute(FailResponse);

                Console.WriteLine("標準用法，完成");

                return 0;
            });
        });
    }

    static HttpResponseMessage FailResponse()
    {
        HttpResponseMessage httpResponseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.BadGateway
        };
        return httpResponseMessage;
    }
}
