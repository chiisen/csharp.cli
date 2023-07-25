using Newtonsoft.Json;
using StackExchange.Redis;

namespace csharp.cli.helper
{
    public class RedisHelper
    {
        public static T GetValue<T>(string cacheKey)
        {
            const string connectionString = "127.0.0.1:6379, abortConnect=false, connectRetry=5, connectTimeout=5000, syncTimeout=5000";
            var options = ConfigurationOptions.Parse(connectionString);
            options.AllowAdmin = true;
            options.ReconnectRetryPolicy = new ExponentialRetry(3000);

            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(options);
            var redis = connectionMultiplexer.GetDatabase(0);

            var data = redis.StringGet(cacheKey);
            if (data == RedisValue.EmptyString)
            {
                Console.WriteLine($"empty data");
                return default!;
            }

            var info = data.HasValue ? JsonConvert.DeserializeObject<T>(data!) : default;
            return info!;
        }
    }
}
