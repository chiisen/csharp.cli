public partial class Program
{
    /// <summary>
    /// 讀取 csv。
    /// 命令列引數: csv csvFile.csv
    /// </summary>
    public static void csv()
    {
        _ = _app.Command("csv", command =>
        {
            // 第二層 Help 的標題
            command.Description = "讀取 csv。";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var pathArgument = command.Argument("[path]", "指定 csv 路徑與檔名。");

            command.OnExecute(() =>
            {
                var path = pathArgument.HasValue ? pathArgument.Value : null;
                string p = currentPath + path;
                Console.WriteLine($"讀取csv: {p}");
                using (var reader = new StreamReader(p))
                {
                    List<string> listA = new();
                    List<string> listB = new();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        listA.Add(values[0]);
                        listB.Add(values[1]);
                    }
                }

                Console.WriteLine($"csv");
                return 0;
            });
        });
    }
}
