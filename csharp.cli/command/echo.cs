﻿using McMaster.Extensions.CommandLineUtils;
using System.Globalization;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 輸出用戶輸入的文字。
    /// 命令列引數: echo words -r 3
    /// </summary>
    public static void Echo()
    {
        _ = App.Command("echo", command =>
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
                var words = wordsArgument.HasValue ? wordsArgument.Value : "world";
                if (words == null)
                {
                    Console.WriteLine($"null words");
                    return 1;
                }
                if (upperOption.HasValue())
                {
                    words = words.ToUpper(CultureInfo.InvariantCulture);
                }
                var count = repeatOption.HasValue() ? repeatOption.Value() : "1";
                if (count == null)
                {
                    Console.WriteLine($"null count");
                    return 1;
                }
                var repeatCount = int.Parse(count);
                for (var i = 0; i < repeatCount; ++i)
                {
                    Console.WriteLine($"{i},{words}");
                }
                Console.WriteLine($"按任何鍵結束。");
                Console.ReadKey();
                return 0;
            });
        });
    }
}

