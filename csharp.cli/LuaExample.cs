using NLua;

namespace csharp.cli
{
    /// <summary>
    /// 
    /// </summary>
    public class LuaExample
    {
        /// <summary>
        /// 
        /// </summary>
        public void RunLuaScript()
        {
            using (var lua = new Lua())
            {
                lua.DoString("print('Hello, World!')");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void RunLuaRegisterFunction()
        {
            using (var lua = new Lua())
            {
                lua.RegisterFunction("SayHello", this, GetType().GetMethod("SayHello"));
                lua.DoString("SayHello()");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void SayHello()
        {
            Console.WriteLine("Hello, World!");
        }
        /// <summary>
        /// 
        /// </summary>
        public int[] RunLuaResult()
        {
            using (var lua = new Lua())
            {
                object[] result = lua.DoString("return 1, 2, 3");
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                //Int64[] intArray = result.Cast<Int64>().ToArray();
                int[] intArray = result.Select(Convert.ToInt32).ToArray();
                return intArray;
            }
        }
    }
}
