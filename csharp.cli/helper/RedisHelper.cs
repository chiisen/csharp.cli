﻿using Colorful;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Reflection;
using Terminal.Gui;

namespace csharp.cli.helper
{
    public class RedisHelper
    {
        protected static IDatabase? Redis { get; set; }
        protected static IDatabase? OtherRedis { get; set; }
        protected static IServer[]? Servers { get; set; }
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
            Servers = connectionMultiplexer.GetServers();
            Redis = connectionMultiplexer.GetDatabase(db);

            IsInitialized = true;
        }

        public static string GetProjectName()
        {
            // 取得目前執行的 assembly
            var asm = Assembly.GetExecutingAssembly();

            // 取得 assembly 的名稱
            return asm?.GetName()?.Name ?? string.Empty;
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
                System.Console.WriteLine($"empty data");
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

        /// <summary>
        /// 刪除本地 Redis 的 Key，目前 Redis 的 Key 值會加上專案的名稱，例如: csharp.cli:add-customer
        /// </summary>
        /// <param name="connectionString">Redis連線字串</param>
        /// <param name="cacheKey"></param>
        /// <param name="db"></param>
        public static void KeyDelete(string cacheKey, int db = 0)
        {
            var assemblyName = GetProjectName();

            var key = $"{assemblyName}:{cacheKey}";

            OtherRedis!.KeyDelete(key);
        }

        /// <summary>
        /// 刪除指定 Redis 的 Key(不一定是本地，所以需要連線字串)
        /// </summary>
        /// <param name="connectionString">Redis連線字串</param>
        /// <param name="cacheKey"></param>
        /// <param name="db"></param>
        public static void OtherKeyDelete(string connectionString, string cacheKey, int db = 0)
        {
            var options = ConfigurationOptions.Parse(connectionString);
            options.AllowAdmin = true;
            options.ReconnectRetryPolicy = new ExponentialRetry(3000);

            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(options);
            OtherRedis = connectionMultiplexer.GetDatabase(db);
            OtherRedis!.KeyDelete(cacheKey);
        }

        /// <summary>
        /// 指定 Redis 的 key 取得 value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static T GetOtherValue<T>(string connectionString, string cacheKey, int db = 0)
        {
            var options = ConfigurationOptions.Parse(connectionString);
            options.AllowAdmin = true;
            options.ReconnectRetryPolicy = new ExponentialRetry(3000);

            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(options);
            OtherRedis = connectionMultiplexer.GetDatabase(db);

            var data = OtherRedis!.StringGet($"{cacheKey}");
            if (data == RedisValue.EmptyString)
            {
                System.Console.WriteLine($"empty data");
                return default!;
            }

            var info = data.HasValue ? JsonConvert.DeserializeObject<T>(data!) : default;
            return info!;
        }

        /// <summary>
        /// 用指定 Redis 的 key 設定 value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        /// <param name="db"></param>
        public static void SetOtherValue<T>(string connectionString, string cacheKey, T value, int db = 0)
        {
            var options = ConfigurationOptions.Parse(connectionString);
            options.AllowAdmin = true;
            options.ReconnectRetryPolicy = new ExponentialRetry(3000);

            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(options);
            OtherRedis = connectionMultiplexer.GetDatabase(db);

            if (value?.GetType() == typeof(string))
            {
                OtherRedis!.StringSet($"{cacheKey}", value.ToString());
                return;
            }
            var data = JsonConvert.SerializeObject(value);

            Redis!.StringSet($"{cacheKey}", data);
        }

        /// <summary>
        /// 取得 Hash 鍵的所有值
        /// </summary>
        /// <param name="hashKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static HashEntry[] HashGetAll(string hashKey, int db = 0)
        {
            LazyInitializer(db);

            var assemblyName = GetProjectName();

            var key = "";

            if (hashKey.Contains(assemblyName))
            {
                key = hashKey;
            }
            else
            {
                key = $"{assemblyName}:{hashKey}";
            }

            var data = Redis!.HashGetAll(key);
            if (data == null)
            {
                System.Console.WriteLine($"empty data");
                return default!;
            }

            return data!;
        }

        /// <summary>
        /// 以 IServer 來去得 key 的所有值
        /// </summary>
        /// <returns></returns>
        public static IServer? GetServer()
        {
            if (Servers != null && Servers.Length > 0)
            {
                return Servers[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static IEnumerable<RedisKey>? GetKeys(string pattern, int db = 0)
        {
            if (Servers != null && Servers.Length > 0)
            {
                var assemblyName = GetProjectName();

                var key = $"{assemblyName}:{pattern}";

                return Servers[0].Keys(db, key);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 寫入 Hash 鍵
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashKey"></param>
        /// <param name="hashEntries"></param>
        /// <param name="db"></param>
        public static void HashSet(string hashKey, HashEntry[] hashEntries, TimeSpan? expiry = null, int db = 0)
        {
            LazyInitializer(db);

            var assemblyName = GetProjectName();

            var key = $"{assemblyName}:{hashKey}";

            // 寫入 HashEntry
            Redis!.HashSet(key, hashEntries);

            // 設定過期時間
            if (expiry.HasValue)
            {
                Redis.KeyExpire(key, expiry);
            }
        }

        /// <summary>
        /// 檢查 key 確定存在就更新 value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static bool CheckAndUpdateKeyAsync(string checkKey, string newValue, int db = 0)
        {
            LazyInitializer(db);

            var assemblyName = GetProjectName();
            var key = $"{assemblyName}:{checkKey}";

            var script = @"
            if redis.call('EXISTS', KEYS[1]) == 1 then
                redis.call('SET', KEYS[1], ARGV[1])
                return true
            else
                return false
            end
            ";

            var result = (bool)Redis!.ScriptEvaluate(script, new RedisKey[] { key }, new RedisValue[] { newValue });
            return result;
        }

        /// <summary>
        /// 寫入 List 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="message"></param>
        /// <param name="db"></param>
        public static void ListRightPush(string listKey, string message, int db = 0)
        {
            LazyInitializer(db);

            var assemblyName = GetProjectName();

            var key = $"{assemblyName}:{listKey}";

            // 寫入 ListRightPush
            Redis!.ListRightPush(key, message);
        }

        /// <summary>
        /// 讀取 ListLength
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="db"></param>
        public static long ListLength(string listKey, int db = 0)
        {
            LazyInitializer(db);

            var assemblyName = GetProjectName();

            var key = $"{assemblyName}:{listKey}";

            // 讀取 ListLength
            return Redis!.ListLength(key);
        }

        /// <summary>
        /// 讀取 List 並輸出 List 所有資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listKey"></param>
        /// <param name="db"></param>
        public static RedisValue ListGetByIndex(string listKey, long index, int db = 0)
        {
            LazyInitializer(db);

            var assemblyName = GetProjectName();

            var key = $"{assemblyName}:{listKey}";

            // 讀取指定 index 資料
            return Redis!.ListGetByIndex(key, index);
        }
    }
}
