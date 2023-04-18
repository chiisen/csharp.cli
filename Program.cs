// See https://aka.ms/new-console-template for more information
using McMaster.Extensions.CommandLineUtils;
using Polly;
using System;
using System.Globalization;
using System.Net;

public class Program
{
    static int Main(string[] args)
    {
        var app = new CommandLineApplication { Name = "csharp.cli.app" };
        app.HelpOption("-?|-h|--help");
        app.OnExecute(() =>
        {
            app.ShowHelp();
            return 0;
        });
        _ = app.Command("echo", command =>
        {
            command.Description = "輸出用戶輸入的文字。";
            command.HelpOption("-?|-h|-help");
            var wordsArgument = command.Argument("[words]", "指定需要輸出的文字。");
            var repeatOption = command.Option("-r|--repeat-count", "指定輸出重複次數", CommandOptionType.SingleValue);
            var upperOption = command.Option("--upper", "指定是否全部大寫", CommandOptionType.NoValue);
            command.OnExecute(() =>
            {
                var subject = wordsArgument.HasValue ? wordsArgument.Value : "world";
                if(upperOption.HasValue())
                {
                    subject = subject.ToUpper(CultureInfo.InvariantCulture);
                }
                var count = repeatOption.HasValue() ? repeatOption.Value() : "1";
                int repeat_count = int.Parse(count);
                for (int i = 0; i < repeat_count; ++i)
                {
                    Console.WriteLine(subject);
                }
                return 0;
            });
        });

        _ = app.Command("polly", command =>
        {
            command.Description = "重試測試。";
            command.HelpOption("-?|-h|-help");
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
            });
        });

        return app.Execute(args);
    }

    static HttpResponseMessage FailResponse()
    {
        HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.StatusCode = HttpStatusCode.BadGateway;
        return httpResponseMessage;
    }
}