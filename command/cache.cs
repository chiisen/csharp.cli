using McMaster.Extensions.CommandLineUtils;
using System.Runtime.Caching;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: cache -r keyName
    /// </summary>
    public static void cache()
    {
        _ = App.Command("cache", (Action<CommandLineApplication>)(command =>
        {
            // 第二層 Help 的標題
            command.Description = "cache 測試";
            command.HelpOption("-?|-h|-help");

            // 輸入指令說明
            var getOption = command.Option("-g|--get", "指定輸出為讀取", CommandOptionType.SingleValue);
            var setOption = command.Option("-s|--set", "指定輸出為寫入", CommandOptionType.SingleValue);
            var valueOption = command.Option("-v|--value", "指定輸出為寫入的內容", CommandOptionType.SingleValue);
            var removeOption = command.Option("-r|--remove", "移除指定快取", CommandOptionType.SingleValue);

            command.OnExecute((Func<int>)(() =>
            {
                var get = getOption.HasValue() ? getOption.Value() : null;
                var set = setOption.HasValue() ? setOption.Value() : null;
                var setValue = valueOption.HasValue() ? valueOption.Value() : null;
                var remove = removeOption.HasValue() ? removeOption.Value() : null;

                // 取得快取資料筆數
                long cacheCount = Program.Cache.GetCount();

                if (get != null)
                {
                    // 檢查快取是否存在
                    bool isSet = Program.Cache[get] != null;
                    if(isSet)
                    {
                        // 讀取快取
                        string value = (string)Program.Cache[get];
                        Console.WriteLine($"讀取快取 key: {get} value: {value}，快取資料筆數: {cacheCount}");
                    }
                    else
                    {
                        Console.WriteLine($"讀取快取 key: {get} 不存在，快取資料筆數: {cacheCount}");
                    }
                    return 0;
                }

                if (set != null)
                {
                    if(setValue == null)
                    {
                        Console.WriteLine($"快取 key: {set} 寫入的內容為: null，快取資料筆數: {cacheCount}");
                        return 1;
                    }
                    // 檢查快取是否存在
                    bool isSet = Program.Cache[set] != null;
                    if (isSet)
                    {
                        string value = (string)Program.Cache[set];
                        Console.WriteLine($"快取已經存在 key: {set} value: {value}，快取資料筆數: {cacheCount}");
                    }
                    else
                    {
                        // 寫入快取 (指定時間後回收快取)
                        var policy = new CacheItemPolicy()
                        {
                            AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(SECONDS_EXPIRATION), // 指定秒數後回收
                        };
                        Program.Cache.Add(set, (object)setValue, policy);

                        string value = (string)Program.Cache[set];
                        cacheCount = Program.Cache.GetCount();
                        Console.WriteLine($"寫入快取 key: {set} value: {value}，快取資料筆數: {cacheCount}");
                    }
                    return 0;
                }

                if (remove != null)
                {
                    // 檢查快取是否存在
                    bool isSet = Program.Cache[remove] != null;
                    if (isSet)
                    {
                        string value = (string)Program.Cache[remove];

                        // 移除快取
                        Program.Cache.Remove(remove);
                        cacheCount = Program.Cache.GetCount();
                        Console.WriteLine($"移除快取 key: {remove} value: {value}，快取資料筆數: {cacheCount}");
                    }
                    else
                    {
                        Console.WriteLine($"移除快取 key: {remove} 不存在，快取資料筆數: {cacheCount}");
                    }
                    return 0;
                }

                return 0;
            }));
        }));
    }
}
