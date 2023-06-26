using System.Diagnostics;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: plinq
    /// </summary>
    public static void Plinq()
    {
        _ = App.Command("plinq", command =>
        {
            // 第二層 Help 的標題
            command.Description = "plinq 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                Console.WriteLine($"plinq", Color.Azure);

                string path = @"C:\Program Files\Microsoft Office\Office16\";
                var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories).ToList();

                var sw = new Stopwatch();
                sw.Start();

                // 把 .AsParallel() 加上去就變成 PLINQ 陣述式, 把 .AsParallel() 拿掉就變成原始的 LINQ 陣述式
                //IEnumerable<string> resultsPLINQ = from f in files.AsParallel() select f;

                // 不過事實上你可以強迫 PLINQ 採用平行處理, 那就是下達.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                var resultsPLINQ = from f in files.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism) where f.Contains("ab") == true select f;
                
                var resultsListPLINQ = resultsPLINQ.ToList();
                Console.WriteLine("PLINQ - Found {0} files.", resultsListPLINQ.Count);

                sw.Stop();
                Console.WriteLine($"sw: {sw.ElapsedMilliseconds}");

                sw = new Stopwatch();
                sw.Start();

                // 把 .AsParallel() 加上去就變成 PLINQ 陣述式, 把 .AsParallel() 拿掉就變成原始的 LINQ 陣述式
                var resultsLINQ = from f in files where f.Contains("ab") == true select f;
                var resultsListLINQ = resultsLINQ.ToList();
                Console.WriteLine("LINQ - Found {0} files.", resultsListLINQ.Count);

                sw.Stop();
                Console.WriteLine($"sw: {sw.ElapsedMilliseconds}");

                
                return 0;
            });
        });
    }
}