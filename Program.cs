// See https://aka.ms/new-console-template for more information
using McMaster.Extensions.CommandLineUtils;
using System.Globalization;

public class Program
{
    static int Main(string[] args)
    {
        var app = new CommandLineApplication { Name = "csharp.cli.app" };
        app.HelpOption("-?|-h|--help");
        app.OnExecute(() =>
        {
            app.ShowHelp();
            return 0;
        });
        _ = app.Command("echo", command =>
        {
            command.Description = "輸出用戶輸入的文字。";
            command.HelpOption("-?|-h|-help");
            var wordsArgument = command.Argument("[words]", "指定需要輸出的文字。");
            var repeatOption = command.Option("-r|--repeat-count", "指定輸出重複次數", CommandOptionType.SingleValue);
            var upperOption = command.Option("--upper", "指定是否全部大寫", CommandOptionType.NoValue);
            command.OnExecute(() =>
            {
                var subject = wordsArgument.HasValue ? wordsArgument.Value : "world";
                if(upperOption.HasValue())
                {
                    subject = subject.ToUpper(CultureInfo.InvariantCulture);
                }
                var count = repeatOption.HasValue() ? repeatOption.Value() : "1";
                int repeat_count = int.Parse(count);
                for (int i = 0; i < repeat_count; ++i)
                {
                    Console.WriteLine(subject);
                }
                return 0;
            });
        });

        return app.Execute(args);
    }
}