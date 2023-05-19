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
                if(path == null)
                {
                    Console.WriteLine($"null path");
                    return 1;
                }
                Console.WriteLine($"讀取csv: {path}");
                using (var reader = new StreamReader(path))
                {
                    List<string> lineList = new();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        lineList.Add(line);
                    }
                    foreach(var line in lineList)
                    {
                        Console.WriteLine(line);
                    }
                }
                return 0;
            });
        });
    }
}
