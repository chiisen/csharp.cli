namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// multi-thread 範例程式
    /// 命令列引數: multi-thread
    /// </summary>
    public static void MultiThread()
    {
        _ = App.Command("multi-thread", command =>
        {
            // 第二層 Help 的標題
            command.Description = "multi-thread 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                var taskList = new List<Task>();
                for (var i = 0; i < 10; i++)
                {
                    var id = i.ToString();

                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            var r = new Random(); // 宣告一個 Random 物件：r
                            //r.Next(); // 括號內沒有東西則從 0 到 int 最大值(2,147,483,647)隨機取一數
                            //r.Next(10000); // 從 0 到 Maxvalue隨機取一數
                            var d = r.Next(1000, 10000); // Min 到 Max隨機取一數

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
                var allTask = Task.WhenAll(taskList);
                try
                {
                    allTask.Wait();
                }
                catch
                {
                    // ignored
                }

                switch (allTask.Status)
                {
                    case TaskStatus.RanToCompletion:
                        Console.WriteLine("success!");
                        break;
                    case TaskStatus.Faulted:
                        Console.WriteLine("something wrong");
                        break;
                }
                return 0;
            });
        });
    }
}
