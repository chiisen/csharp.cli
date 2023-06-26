using Colorful;
using System.Drawing;
using Console = Colorful.Console;


namespace csharp.cli;

/// <summary>
/// BetAreaHelper
/// </summary>
public class BetAreaHelper
{
    public static void Message(string? areaName, string? betArea, string? context)
    {
        var isNull = false;
        if (areaName == null)
        {
            Console.WriteLine($"null areaName");
            isNull = true;
        }
        if (betArea == null)
        {
            Console.WriteLine($"null betArea");
            isNull = true;
        }
        if (context == null)
        {
            Console.WriteLine($"null context");
            isNull = true;
        }
        if (isNull == true)
        {
            return;
        }
        const string message = "{0} {1} {2}";
        var colors = new Formatter[]
        {
            new (areaName, Color.Red),
            new (betArea, Color.Blue),
            new (context, Color.Yellow)
        };
        Console.WriteLineFormatted(message, Color.White, colors);
    }
}
