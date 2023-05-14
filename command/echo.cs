﻿using McMaster.Extensions.CommandLineUtils;
using System.Globalization;


public partial class Program
{
    public static void echo()
    {
        _ = _app.Command("echo", command =>
        {
            // 第二層 Help 的標題
            command.Description = "輸出用戶輸入的文字。";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var wordsArgument = command.Argument("[words]", "指定需要輸出的文字。");

            // 輸入指令說明
            var repeatOption = command.Option("-r|--repeat-count", "指定輸出重複次數", CommandOptionType.SingleValue);
            var upperOption = command.Option("--upper", "指定是否全部大寫", CommandOptionType.NoValue);

            command.OnExecute(() =>
            {
                var subject = wordsArgument.HasValue ? wordsArgument.Value : "world";
                if (upperOption.HasValue())
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
    }
}
