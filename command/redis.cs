using System.Drawing;
using Console = Colorful.Console;
using StackExchange.Redis;
using Newtonsoft.Json;


namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: example0
    /// </summary>
    public static void Redis()
    {
        _ = App.Command("redis", command =>
        {
            // 第二層 Help 的標題
            command.Description = "redis 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                var connectionString = "127.0.0.1:6379, abortConnect=false, connectRetry=5, connectTimeout=5000, syncTimeout=5000";
                var options = ConfigurationOptions.Parse(connectionString);
                options.AllowAdmin = true;
                options.ReconnectRetryPolicy = new ExponentialRetry(3000);

                IConnectionMultiplexer _connectionMultiplexer = ConnectionMultiplexer.Connect(options);
                var redis = _connectionMultiplexer.GetDatabase(0);

                var cacheKey = "Summaries";
                var data = redis.StringGet(cacheKey);
                var ret = data.HasValue ? JsonConvert.DeserializeObject<string>(data) : default;

                Console.WriteLine($"{ret}", Color.Azure);
                return 0;
            });
        });
    }
}