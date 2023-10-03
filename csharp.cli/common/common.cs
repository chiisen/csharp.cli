using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace csharp.cli.common
{
    public static class Common
    {
        public static T JsonDeserialize<T>(string text)
        {

            try
            {
#pragma warning disable CS8603 // 可能有 Null 參考傳回。
                return JsonConvert.DeserializeObject<T>(text);
#pragma warning restore CS8603 // 可能有 Null 參考傳回。
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
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
        public static string ReplaceChineseNumerals(string? str)
        {
            if (str == null)
            {
                Console.WriteLine("Null str");
                return "";
            }
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
        /// <summary>
        /// 移除換行符號
        /// </summary>
        /// <returns></returns>
        public static string StringRemoveMultiLine(string target)
        {
            return target.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
        }
        /// <summary>
        /// 取得字串後方的註解
        /// </summary>
        /// <returns></returns>
        public static (string diff, string replace) GetTheCommentAfterTheString(this string source, string target)
        {
            var diff = "";
            if (source.Length > target.Length)
            {
                for (var j = target.Length - 1; j < source.Length; j++)
                {
                    diff += source[j];
                }
                var singleLine = StringRemoveMultiLine(target);
                return (diff, singleLine + diff);
            }
            return ("", "");
        }
    }
}
