using Colorful;
using System.Drawing;
using Console = Colorful.Console;


namespace csharp.cli;

/// <summary>
/// BetAreaAllHelper
/// </summary>
public class BetAreaAllHelper
{
    /// <summary>
    /// 列印彩色標題
    /// </summary>
    public static void Head(int nLen, int iLen, int cLen, int wLen)
    {
        const string head = "{0} {1} {2} {3}";

        if (nLen < "\"areaName\"".Length)
        {
            nLen = "\"areaName\"".Length;
        }
        if (iLen < "\"BetArea\"".Length)
        {
            iLen = "\"BetArea\"".Length;
        }
        if (cLen < "\"context\"".Length)
        {
            cLen = "\"context\"".Length;
        }
        if (wLen < "沒有對應的代碼".Length)
        {
            wLen = "沒有對應的代碼".Length;
        }
        var colors = new Formatter[]
        {
            new ("\"areaName\"".PadRight(nLen), Color.Green),
            new ("\"BetArea\"".PadRight(iLen), Color.Blue),
            new ("\"context\"".PadRight(cLen), Color.Yellow),
            new ("\"WM code\"".PadRight(wLen), Color.White)
        };
        Console.WriteLineFormatted(head, Color.White, colors);
    }

    /// <summary>
    /// 列印欄位資訊
    /// </summary>
    /// <param name="areaName"></param>
    /// <param name="betArea"></param>
    /// <param name="context"></param>
    public static void Message(string message, string areaName, string betArea, string context, string wmCode, int nLen, int iLen, int cLen, int wLen)
    {
        if (nLen < "\"areaName\"".Length)
        {
            nLen = "\"areaName\"".Length;
        }
        if (iLen < "\"BetArea\"".Length)
        {
            iLen = "\"BetArea\"".Length;
        }
        if (cLen < "\"context\"".Length)
        {
            cLen = "\"context\"".Length;
        }
        if (wLen < "沒有對應的代碼".Length)
        {
            wLen = "沒有對應的代碼".Length;
        }
        var colors = new Formatter[]
        {
            new(areaName.PadRight(nLen), Color.Green),
            new(betArea.PadRight(iLen), Color.Blue),
            new(context.PadRight(cLen), Color.Yellow),
            new(wmCode.PadRight(wLen), Color.White)
        };
        Console.WriteLineFormatted(message, Color.White, colors);
    }

    /// <summary>
    /// 列印欄位資訊包含錯誤訊息
    /// </summary>
    /// <param name="message"></param>
    /// <param name="areaName"></param>
    /// <param name="betArea"></param>
    /// <param name="context"></param>
    public static void ErrorMessage(string message, string areaName, string betArea, string context, int nLen, int iLen, int cLen, int wLen)
    {
        if (nLen < "\"areaName\"".Length)
        {
            nLen = "\"areaName\"".Length;
        }
        if (iLen < "\"BetArea\"".Length)
        {
            iLen = "\"BetArea\"".Length;
        }
        if (cLen < "\"context\"".Length)
        {
            cLen = "\"context\"".Length;
        }
        if (wLen < "沒有對應的代碼".Length)
        {
            wLen = "沒有對應的代碼".Length;
        }
        var colors = new Formatter[]
        {
            new(areaName.PadRight(nLen), Color.Green),
            new(betArea.PadRight(iLen), Color.Blue),
            new(context.PadRight(cLen), Color.Yellow),
            new("沒有對應的代碼".PadRight(wLen), Color.Red)
        };
        Console.WriteLineFormatted(message, Color.White, colors);
    }
}
