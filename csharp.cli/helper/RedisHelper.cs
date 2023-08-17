using Newtonsoft.Json;
using StackExchange.Redis;
using System.Reflection;

namespace csharp.cli.helper
{
    public class RedisHelper
    {
        protected static IDatabase? Redis { get; set; }
        public static bool IsInitialized { get; private set; }

        private static void LazyInitializer(int db = 0)
        {
            if (IsInitialized is true)
            {
                return;
            }

            const string connectionString = "127.0.0.1:6379, abortConnect=false, connectRetry=5, connectTimeout=5000, syncTimeout=5000";
            var options = ConfigurationOptions.Parse(connectionString);
            options.AllowAdmin = true;
            options.ReconnectRetryPolicy = new ExponentialRetry(3000);

            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(options);
            Redis = connectionMultiplexer.GetDatabase(db);

            IsInitialized = true;
        }

        public static string GetProjectName()
        {
            // 取得目前執行的 assembly
            var asm = Assembly.GetExecutingAssembly();

            // 取得 assembly 的名稱
            var assemblyName = asm.GetName().Name;

            return assemblyName;
        }

        /// <summary>
        /// 用 key 取得 value，目前 Redis 的 Key 值會加上專案的名稱，例如: csharp.cli:add-customer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static T GetValue<T>(string cacheKey, int db = 0)
        {
            LazyInitializer(db);

            var assemblyName = GetProjectName();

            var data = Redis!.StringGet($"{assemblyName}:{cacheKey}");
            if (data == RedisValue.EmptyString)
            {
                Console.WriteLine($"empty data");
                return default!;
            }

            var info = data.HasValue ? JsonConvert.DeserializeObject<T>(data!) : default;
            return info!;
        }

        /// <summary>
        /// 用 key 設定 value，目前 Redis 的 Key 值會加上專案的名稱，例如: csharp.cli:add-customer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        /// <param name="db"></param>
        public static void SetValue<T>(string cacheKey, T value, int db = 0)
        {
            LazyInitializer(db);

            var assemblyName = GetProjectName();

            var key = $"{assemblyName}:{cacheKey}";

            if (value?.GetType() == typeof(string))
            {
                Redis!.StringSet($"{key}", value.ToString());
                return;
            }
            var data = JsonConvert.SerializeObject(value);

            Redis!.StringSet($"{key}", data);
        }
    }
}
