using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: NLuaExample
    /// </summary>
    public static void NLuaExample()
    {
        _ = App.Command("nlua", command =>
        {
            // 第二層 Help 的標題
            command.Description = "NLuaExample 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                Console.WriteLine($"NLuaExample Start", Color.Azure);

                #region 測試NLua
                var luaExample = new LuaExample();
                luaExample.RunLuaScript();
                luaExample.RunLuaRegisterFunction();
                int[] result = luaExample.RunLuaResult();
                #endregion 測試NLua

                Console.WriteLine($"NLuaExample End", Color.Azure);
                return 0;
            });
        });
    }
}