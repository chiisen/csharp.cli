public partial class Program
{
    public static void csv()
    {
        _ = _app.Command("csv", command =>
        {
            command.OnExecute(() =>
            {
                Console.WriteLine($"csv");
                return 0;
            });
        });
    }
}
