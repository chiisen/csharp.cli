using System.Text.RegularExpressions;

namespace csharp.cli.common
{
    public class Common
    {
        /// <summary>
        /// 檢查是否為數字
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public static bool IsNumeric(string areaId) => int.TryParse(areaId, out int n);

        /// <summary>
        /// 置換中國數字為阿拉伯數字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceChineseNumerals(string str)
        {
            str = str.Replace("一", "1");
            str = str.Replace("二", "2");
            str = str.Replace("三", "3");
            str = str.Replace("四", "4");
            str = str.Replace("五", "5");
            str = str.Replace("六", "6");
            str = str.Replace("七", "7");
            str = str.Replace("八", "8");
            str = str.Replace("九", "9");

            return str;
        }

        /// <summary>
        /// 檢查是否為英文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLetter(string str)
        {
            return Regex.Matches(str, "[a-zA-Z]").Count > 0;
        }
    }
}
