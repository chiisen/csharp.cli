using DocumentFormat.OpenXml.Spreadsheet;
using McMaster.Extensions.CommandLineUtils;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: multi-thread "words" -r 10
    /// </summary>
    public static void multiThread()
    {
        _ = _app.Command("multi-thread", command =>
        {
            // 第二層 Help 的標題
            command.Description = "multi-thread 說明";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var wordsArgument = command.Argument("[words]", "指定需要輸出的文字。");

            // 輸入指令說明
            var repeatOption = command.Option("-r|--repeat-count", "指定輸出重複次數", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var words = wordsArgument.HasValue ? wordsArgument.Value : "world";

                var count = repeatOption.HasValue() ? repeatOption.Value() : "1";

                Console.WriteLine($"example => words: {words}, count: {count}");

                List<Task> taskList = new ();
                for (int i = 0; i < 10; i++)
                {
                    string id = i.ToString();

                    taskList.Add(Task.Run(async () => {
                        try
                        {
                            Random r = new(); // 宣告一個 Random 物件：r
                            //r.Next(); // 括號內沒有東西則從 0 到 int 最大值(2,147,483,647)隨機取一數
                            //r.Next(10000); // 從 0 到 Maxvalue隨機取一數
                            int d = r.Next(1000, 10000); // Min 到 Max隨機取一數

                            Console.WriteLine($"id: {id}, Delay: {d} ");
                            await Task.Delay(d);
                            Console.WriteLine($"> id: {id}, Done: {d} ");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                            throw;
                        }
                    }));
                }
                Task allTask = Task.WhenAll(taskList);
                try
                {
                    allTask.Wait();
                }
                catch { }

                if (allTask.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("success!");
                }
                else if (allTask.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine("something wrong");
                }
                return 0;
            });
        });
    }
}
