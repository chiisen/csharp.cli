using Colorful;
using System.Drawing;
using System.IO;
using System.Text;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 一個十元硬幣的紀錄資料
    /// </summary>
    public class Coin
    {
        /// <summary>
        /// 隨機擲出十元硬幣的亂數種子初始化
        /// </summary>
        private static readonly Random RandTenYuanCoin = new(Guid.NewGuid().GetHashCode());
        /// <summary>
        /// 正面或反面
        /// </summary>
        public int HeadOrTail { get; set; }
        /// <summary>
        /// 正面或反面的說明
        /// </summary>
        public string? HeadOrTailDesc { get; set; }
        public void ThrowCoin()
        {
            // 以十元硬幣為例:
            // 【十元】為陽，以數字【3】紀錄
            // 另一面為陰，以數字【2】紀錄
            // tenYuanCoin.Next() 後，ranNum >= 2 && ranNum < 4 值為 [ 2, 3 ]
            HeadOrTail = RandTenYuanCoin.Next(2, 4);

            // 十元硬幣 Head 正面(大頭)為陰，Tail 反面(十元)為陽
            Dictionary<int, string> tenYuanCoinHeadOrTail = new()
            {
                { 3, "十元(陽爻 ⚊ )" },
                { 2, "大頭(陰爻 ⚋ )" }
            };

            HeadOrTailDesc = tenYuanCoinHeadOrTail[HeadOrTail];
            var message = new Formatter[]
            {
                new(HeadOrTail, Color.LightGoldenrodYellow),
                new(HeadOrTailDesc, Color.Gray),
            };

            var stringFormat = "擲出硬幣為: {0} {1}";

            Console.WriteLineFormatted(stringFormat, Color.Gray, message);
        }
    }
    /// <summary>
    /// 六個爻的紀錄資料
    /// </summary>
    public class SixYao
    {
        /// <summary>
        /// 初爻
        /// </summary>
        public int Yao1 { get; set; }
        /// <summary>
        /// 初爻擲出硬幣的結果
        /// </summary>
        public List<int> YaoThreeCoin1 { get; set; } = new List<int>();
        /// <summary>
        /// 初爻擲出陰陽的結果
        /// </summary>
        public string YaoThreeYao1 { get; set; } = "";
        /// <summary>
        /// 顯示初爻紀錄
        /// </summary>
        public string? ShowYao1 { get; set; }
        /// <summary>
        /// 初爻
        /// </summary>
        public string? YaoTranslate1 { get; set; } = "初爻";
        /// <summary>
        /// 二爻
        /// </summary>
        public int Yao2 { get; set; }
        /// <summary>
        /// 二爻擲出硬幣的結果
        /// </summary>
        public List<int> YaoThreeCoin2 { get; set; } = new List<int>();
        /// <summary>
        /// 二爻擲出陰陽的結果
        /// </summary>
        public string YaoThreeYao2 { get; set; } = "";
        /// <summary>
        /// 顯示初爻紀錄
        /// </summary>
        public string? ShowYao2 { get; set; }
        /// <summary>
        /// 二爻
        /// </summary>
        public string? YaoTranslate2 { get; set; } = "二爻";
        /// <summary>
        /// 三爻
        /// </summary>
        public int Yao3 { get; set; }
        /// <summary>
        /// 三爻擲出硬幣的結果
        /// </summary>
        public List<int> YaoThreeCoin3 { get; set; } = new List<int>();
        /// <summary>
        /// 三爻擲出陰陽的結果
        /// </summary>
        public string YaoThreeYao3 { get; set; } = "";
        /// <summary>
        /// 顯示初爻紀錄
        /// </summary>
        public string? ShowYao3 { get; set; }
        /// <summary>
        /// 三爻
        /// </summary>
        public string? YaoTranslate3 { get; set; } = "三爻";
        /// <summary>
        /// 四爻
        /// </summary>
        public int Yao4 { get; set; }
        /// <summary>
        /// 四爻擲出硬幣的結果
        /// </summary>
        public List<int> YaoThreeCoin4 { get; set; } = new List<int>();
        /// <summary>
        /// 四爻擲出陰陽的結果
        /// </summary>
        public string YaoThreeYao4 { get; set; } = "";
        /// <summary>
        /// 顯示初爻紀錄
        /// </summary>
        public string? ShowYao4 { get; set; }
        /// <summary>
        /// 四爻
        /// </summary>
        public string? YaoTranslate4 { get; set; } = "四爻";
        /// <summary>
        /// 五爻
        /// </summary>
        public int Yao5 { get; set; }
        /// <summary>
        /// 五爻擲出硬幣的結果
        /// </summary>
        public List<int> YaoThreeCoin5 { get; set; } = new List<int>();
        /// <summary>
        /// 五爻擲出陰陽的結果
        /// </summary>
        public string YaoThreeYao5 { get; set; } = "";
        /// <summary>
        /// 顯示初爻紀錄
        /// </summary>
        public string? ShowYao5 { get; set; }
        /// <summary>
        /// 五爻
        /// </summary>
        public string? YaoTranslate5 { get; set; } = "五爻";
        /// <summary>
        /// 上爻
        /// </summary>
        public int Yao6 { get; set; }
        /// <summary>
        /// 上爻擲出硬幣的結果
        /// </summary>
        public List<int> YaoThreeCoin6 { get; set; } = new List<int>();
        /// <summary>
        /// 上爻擲出陰陽的結果
        /// </summary>
        public string YaoThreeYao6 { get; set; } = "";
        /// <summary>
        /// 顯示初爻紀錄
        /// </summary>
        public string? ShowYao6 { get; set; }
        /// <summary>
        /// 上爻
        /// </summary>
        public string? YaoTranslate6 { get; set; } = "上爻";
        public void SetYao(int index, List<Coin> list)
        {
            var threeCoin = new List<int>();
            list.ForEach( x =>
            {
                threeCoin.Add(x.HeadOrTail);
            });
            var value = threeCoin.Take(3).Sum();

            // 一次三枚十元硬幣為一爻，會擲出一爻情況為 [ 6, 7, 8, 9 ]
            // 三枚硬幣全部擲出十元為 9，全部反面為 6
            // 二個十元與一個反面為 8
            // 兩個反面與一個十元為 7
            Dictionary<int, string> yaoExplain = new()
            {
                { 6, "陰爻 ⚋ " },
                { 7, "陽爻 ⚊ (陰陰陽爻，陰極轉陽)" },
                { 8, "陰爻 ⚋ (陽陽陰爻，陽極轉陰)" },
                { 9, "陽爻 ⚊ " }
            };
            Dictionary<int, string> yaoExplain2 = new()
            {
                { 6, "六" },
                { 7, "九" },
                { 8, "六" },
                { 9, "九" }
            };
            Dictionary<int, string> yaoExplain3 = new()
            {
                { 6, "⚋" },
                { 7, "⚊" },
                { 8, "⚋" },
                { 9, "⚊" }
            };
            var translate = "";
            switch (index)
            {
                case 0:
                    {
                        this.Yao1 = value;
                        var explain2 = this.YaoTranslate1?.Replace("爻", "");
                        explain2 = $"{explain2}{yaoExplain2[value]}";
                        this.ShowYao1 = $"{yaoExplain[value]} {explain2}";
                        translate = this.YaoTranslate1;
                        this.YaoThreeCoin1 = threeCoin;
                        this.YaoThreeYao1 = yaoExplain3[value];
                    }
                    break;
                case 1:
                    {
                        this.Yao2 = value;
                        var explain2 = this.YaoTranslate2?.Replace("爻", "");
                        explain2 = $"{yaoExplain2[value]}{explain2}";
                        this.ShowYao2 = $"{yaoExplain[value]} {explain2}";
                        translate = this.YaoTranslate2;
                        this.YaoThreeCoin2 = threeCoin;
                        this.YaoThreeYao2 = yaoExplain3[value];
                    }
                    break;
                case 2:
                    {
                        this.Yao3 = value;
                        var explain2 = this.YaoTranslate3?.Replace("爻", "");
                        explain2 = $"{yaoExplain2[value]}{explain2}";
                        this.ShowYao3 = $"{yaoExplain[value]} {explain2}";
                        translate = this.YaoTranslate3;
                        this.YaoThreeCoin3 = threeCoin;
                        this.YaoThreeYao3 = yaoExplain3[value];
                    }
                    break;
                case 3:
                    {
                        this.Yao4 = value;
                        var explain2 = this.YaoTranslate4?.Replace("爻", "");
                        explain2 = $"{yaoExplain2[value]}{explain2}";
                        this.ShowYao4 = $"{yaoExplain[value]} {explain2}";
                        translate = this.YaoTranslate4;
                        this.YaoThreeCoin4 = threeCoin;
                        this.YaoThreeYao4 = yaoExplain3[value];
                    }
                    break;
                case 4:
                    {
                        this.Yao5 = value;
                        var explain2 = this.YaoTranslate5?.Replace("爻", "");
                        explain2 = $"{yaoExplain2[value]}{explain2}";
                        this.ShowYao5 = $"{yaoExplain[value]} {explain2}";
                        translate = this.YaoTranslate5;
                        this.YaoThreeCoin5 = threeCoin;
                        this.YaoThreeYao5 = yaoExplain3[value];
                    }
                    break;
                case 5:
                    {
                        this.Yao6 = value;
                        var explain2 = this.YaoTranslate6?.Replace("爻", "");
                        explain2 = $"{explain2}{yaoExplain2[value]}";
                        this.ShowYao6 = $"{yaoExplain[value]} {explain2}";
                        translate = this.YaoTranslate6;
                        this.YaoThreeCoin6 = threeCoin;
                        this.YaoThreeYao6 = yaoExplain3[value];
                    }
                    break;
            }

            var message = new Formatter[]
            {
                new(translate, Color.LightGoldenrodYellow),
                new(value, Color.Gray),
                new(yaoExplain[value], Color.Red),
            };

            var stringFormat = "{0}: {1} {2}";

            Console.WriteLineFormatted(stringFormat, Color.Gray, message);

            Console.WriteLine($"========", Color.Green);
        }
        /// <summary>
        /// 顯示目前卦的結果，Hexagram 是六十四卦之一
        /// </summary>
        public void ShowHexagram()
        {
            var sixtyFourHexagrams = new Dictionary<string, string>
            {
                { "⚊⚊⚊", "乾（天）" },
                { "⚊⚊⚋", "兌（澤）" },
                { "⚊⚋⚊", "離（火）" },
                { "⚊⚋⚋", "震（雷）" },
                { "⚋⚊⚊", "巽（風）" },
                { "⚋⚊⚋", "坎（水）" },
                { "⚋⚋⚊", "艮（山）" },
                { "⚋⚋⚋", "坤（地）" },
            };

            // 參考: https://zh.wikipedia.org/zh-tw/六十四卦
            var sixtyFourHexagrams2 = new Dictionary<Tuple<string, string>, string>
            {
                // (上卦 - 乾, 下卦) => 對照 1 ✅
                { new Tuple<string, string>("⚊⚊⚊", "⚊⚊⚊"), "乾為天 1" },
                { new Tuple<string, string>("⚊⚊⚊", "⚊⚊⚋"), "天澤履 10" },
                { new Tuple<string, string>("⚊⚊⚊", "⚊⚋⚊"), "天火同人 13" },
                { new Tuple<string, string>("⚊⚊⚊", "⚊⚋⚋"), "天雷無妄 25" },
                { new Tuple<string, string>("⚊⚊⚊", "⚋⚊⚊"), "天風姤 44" },
                { new Tuple<string, string>("⚊⚊⚊", "⚋⚊⚋"), "天水訟 6" },
                { new Tuple<string, string>("⚊⚊⚊", "⚋⚋⚊"), "天山遯 33" },
                { new Tuple<string, string>("⚊⚊⚊", "⚋⚋⚋"), "天地否 12" },
                // (上卦 - 兌, 下卦) => 對照 2 ✅
                { new Tuple<string, string>("⚊⚊⚋", "⚊⚊⚊"), "澤天夬 43" },
                { new Tuple<string, string>("⚊⚊⚋", "⚊⚊⚋"), "兌為澤 58" },
                { new Tuple<string, string>("⚊⚊⚋", "⚊⚋⚊"), "澤火革 49" },
                { new Tuple<string, string>("⚊⚊⚋", "⚊⚋⚋"), "澤雷隨 17" },
                { new Tuple<string, string>("⚊⚊⚋", "⚋⚊⚊"), "澤風大過 28" },
                { new Tuple<string, string>("⚊⚊⚋", "⚋⚊⚋"), "澤水困 47" },
                { new Tuple<string, string>("⚊⚊⚋", "⚋⚋⚊"), "澤山咸 31" },
                { new Tuple<string, string>("⚊⚊⚋", "⚋⚋⚋"), "澤地萃 45" },
                // (上卦 - 離, 下卦) => 對照 3 ✅
                { new Tuple<string, string>("⚊⚋⚊", "⚊⚊⚊"), "火天大有 14" },
                { new Tuple<string, string>("⚊⚋⚊", "⚊⚊⚋"), "火澤睽 38" },
                { new Tuple<string, string>("⚊⚋⚊", "⚊⚋⚊"), "離為火 30" },
                { new Tuple<string, string>("⚊⚋⚊", "⚊⚋⚋"), "火雷噬嗑 21" },
                { new Tuple<string, string>("⚊⚋⚊", "⚋⚊⚊"), "火風鼎 50" },
                { new Tuple<string, string>("⚊⚋⚊", "⚋⚊⚋"), "火水未濟 64" },
                { new Tuple<string, string>("⚊⚋⚊", "⚋⚋⚊"), "火山旅 56" },
                { new Tuple<string, string>("⚊⚋⚊", "⚋⚋⚋"), "火地晉 35" },
                // (上卦 - 震, 下卦) => 對照 4 ✅
                { new Tuple<string, string>("⚊⚋⚋", "⚊⚊⚊"), "雷天大壯 34" },
                { new Tuple<string, string>("⚊⚋⚋", "⚊⚊⚋"), "雷澤歸妹 54" },
                { new Tuple<string, string>("⚊⚋⚋", "⚊⚋⚊"), "雷火豐  55" },
                { new Tuple<string, string>("⚊⚋⚋", "⚊⚋⚋"), "震為雷 51" },
                { new Tuple<string, string>("⚊⚋⚋", "⚋⚊⚊"), "雷風恆 32" },
                { new Tuple<string, string>("⚊⚋⚋", "⚋⚊⚋"), "雷水解 40" },
                { new Tuple<string, string>("⚊⚋⚋", "⚋⚋⚊"), "雷山小過 62" },
                { new Tuple<string, string>("⚊⚋⚋", "⚋⚋⚋"), "雷地豫 16" },
                // (上卦 - 巽, 下卦) => 對照 5 ✅
                { new Tuple<string, string>("⚋⚊⚊", "⚊⚊⚊"), "風天小畜 9" },
                { new Tuple<string, string>("⚋⚊⚊", "⚊⚊⚋"), "風澤中孚 61" },
                { new Tuple<string, string>("⚋⚊⚊", "⚊⚋⚊"), "風火家人 37" },
                { new Tuple<string, string>("⚋⚊⚊", "⚊⚋⚋"), "風雷益 42" },
                { new Tuple<string, string>("⚋⚊⚊", "⚋⚊⚊"), "巽為風 57" },
                { new Tuple<string, string>("⚋⚊⚊", "⚋⚊⚋"), "風水渙 59" },
                { new Tuple<string, string>("⚋⚊⚊", "⚋⚋⚊"), "風山漸 53" },
                { new Tuple<string, string>("⚋⚊⚊", "⚋⚋⚋"), "風地觀 20" },
                // (上卦 - 坎, 下卦) => 對照 6 ✅
                { new Tuple<string, string>("⚋⚊⚋", "⚊⚊⚊"), "水天需 5" },
                { new Tuple<string, string>("⚋⚊⚋", "⚊⚊⚋"), "水澤節 60" },
                { new Tuple<string, string>("⚋⚊⚋", "⚊⚋⚊"), "水火既濟 63" },
                { new Tuple<string, string>("⚋⚊⚋", "⚊⚋⚋"), "水雷屯 3" },
                { new Tuple<string, string>("⚋⚊⚋", "⚋⚊⚊"), "水風井 48" },
                { new Tuple<string, string>("⚋⚊⚋", "⚋⚊⚋"), "坎為水 29" },
                { new Tuple<string, string>("⚋⚊⚋", "⚋⚋⚊"), "水山蹇 39" },
                { new Tuple<string, string>("⚋⚊⚋", "⚋⚋⚋"), "水地比 8" },
                // (上卦 - 艮, 下卦) => 對照 7 ✅
                { new Tuple<string, string>("⚋⚋⚊", "⚊⚊⚊"), "山天大畜 26" },
                { new Tuple<string, string>("⚋⚋⚊", "⚊⚊⚋"), "山澤損 41" },
                { new Tuple<string, string>("⚋⚋⚊", "⚊⚋⚊"), "山火賁 22" },
                { new Tuple<string, string>("⚋⚋⚊", "⚊⚋⚋"), "山雷頤 27" },
                { new Tuple<string, string>("⚋⚋⚊", "⚋⚊⚊"), "山風蠱 18" },
                { new Tuple<string, string>("⚋⚋⚊", "⚋⚊⚋"), "山水蒙 4" },
                { new Tuple<string, string>("⚋⚋⚊", "⚋⚋⚊"), "艮為山 52" },
                { new Tuple<string, string>("⚋⚋⚊", "⚋⚋⚋"), "山地剝 23" },
                // (上卦 - 坤, 下卦) => 對照 8 ✅
                { new Tuple<string, string>("⚋⚋⚋", "⚊⚊⚊"), "地天泰 11" },
                { new Tuple<string, string>("⚋⚋⚋", "⚊⚊⚋"), "地澤臨 19" },
                { new Tuple<string, string>("⚋⚋⚋", "⚊⚋⚊"), "地火明夷 36" },
                { new Tuple<string, string>("⚋⚋⚋", "⚊⚋⚋"), "地雷復 24" },
                { new Tuple<string, string>("⚋⚋⚋", "⚋⚊⚊"), "地風升 46" },
                { new Tuple<string, string>("⚋⚋⚋", "⚋⚊⚋"), "地水師 7" },
                { new Tuple<string, string>("⚋⚋⚋", "⚋⚋⚊"), "地山謙 15" },
                { new Tuple<string, string>("⚋⚋⚋", "⚋⚋⚋"), "坤為地 2" },
            };


            Console.WriteLine($"爻的顯示方式，由下往上寫", Color.Blue);
            Console.WriteLine($"========", Color.Red);

            Console.WriteLine($"{this.YaoTranslate6} {this.Yao6} {this.ShowYao6}");
            Console.WriteLine($"{this.YaoTranslate5} {this.Yao5} {this.ShowYao5}");
            Console.WriteLine($"{this.YaoTranslate4} {this.Yao4} {this.ShowYao4}");

            var upYao = $"{this.YaoThreeYao4}{this.YaoThreeYao5}{this.YaoThreeYao6}";

            Console.WriteLine($"上卦或外卦👆外在的環境與對外所持的態度 {sixtyFourHexagrams[upYao]}");

            Console.WriteLine($"========", Color.Red);

            var downYao = $"{this.YaoThreeYao1}{this.YaoThreeYao2}{this.YaoThreeYao3}";

            Console.WriteLine($"下卦或內卦👇本身的條件與內在的思維 {sixtyFourHexagrams[downYao]}");

            Console.WriteLine($"{this.YaoTranslate3} {this.Yao3} {this.ShowYao3}");
            Console.WriteLine($"{this.YaoTranslate2} {this.Yao2} {this.ShowYao2}");
            Console.WriteLine($"{this.YaoTranslate1} {this.Yao1} {this.ShowYao1}");

            Console.WriteLine($"========", Color.Red);

            // 取得後面的號碼
            string[] strResult = sixtyFourHexagrams2[new Tuple<string, string>(upYao, downYao)].Split(' ');

            Console.WriteLine($"卦象: {strResult[0]} - {strResult[1]}");

            Console.WriteLine($"========", Color.Red);

            var text = File.ReadAllText(@$"{AppDomain.CurrentDomain.BaseDirectory}resource\i-ching\{strResult[1]}.txt", Encoding.UTF8);

            Console.WriteLine($"{text}");
        }
    }
    /// <summary>
    /// 一個卦的紀錄資料
    /// </summary>
    public class Gua
    {
        /// <summary>
        /// 六爻
        /// </summary>
        public SixYao TheSixYao { get; set; } = new SixYao();
        /// <summary>
        /// 卜卦
        /// </summary>
        /// <returns></returns>
        public int Divination()
        {
            Console.WriteLine($"拜請四聖伏羲、文王、周公、孔子，弟子XXX住在XX地，因有X事的疑問，祈求降卦示吉凶。", Color.Red);
            Console.WriteLine($"按下 ENTER 繼續...", Color.Red);
            Console.ReadKey();
            Console.WriteLine($"========", Color.Red);

            // 六次擲三枚十元硬幣
            for (int j = 0; j < 6; j++)
            {
                // 以三枚十元硬幣占卜
                var hexagram = new List<Coin>();

                for (int i = 0; i < 3; i++)
                {
                    var coin = new Coin();
                    coin.ThrowCoin();

                    hexagram.Add(coin);
                }

                TheSixYao.SetYao(j, hexagram); 
            }

            TheSixYao.ShowHexagram();

            Console.WriteLine($"========", Color.Red);

            return 0;
        }
    }
    /// <summary>
    /// 易經占卜
    /// 命令列引數: i-ching
    /// </summary>
    public static void IChing()
    {
        _ = App.Command("i-ching", command =>
        {
            // 第二層 Help 的標題
            command.Description = "易經占卜說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
                var gua = new Gua();
                // 卜一卦
                gua.Divination();

                return 0;
            });
        });
    }
}
