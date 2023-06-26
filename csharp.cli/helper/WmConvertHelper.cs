using csharp.cli.model;

namespace csharp.cli;

public class WmConvertHelper
{
    // TODO 101 百家樂賽果 Bacc
    private static Dictionary<(int, string), string> Baccarat = new()
        {
            // WM code => RCG code
            // ! FIXME: RCG 沒有
            // BankerDragonBonus:莊龍寶
            // BankerNatural:莊例牌
            // PlayerDragonBonus:閒龍寶
            // PlayerNatural:閒例牌
            // Super6:幸運6
            // Tip_1_:小費
            // ! FIXME: WM 多了超和1-9點
            // 沒有莊(免傭)的 WM code 要再判斷 commission 欄位是否為 1，對應 RCG 的 ZhuangB 00010 莊(免傭)
            // ! FIXME: 有小費
            {(101, "Banker"),"Zhuang"},// 莊
            {(101, "Player"),"Xian"},// 閒
            {(101, "AnyPair"),"AnyPair"},// 任意對子
            {(101, "Big"),"Big"},// 大
            {(101, "Tie"),"He"},// 和
            {(101, "PerfectPair"),"PerfectPair"},// 完美對子            
            {(101, "Small"),"Small"},// 小
            {(101, "PPair"),"XDD"},// 閒對
            {(101, "BPair"),"ZDD"}// 莊對
        };

    // TODO 102 龍虎賽果 LongHu
    private static Dictionary<(int, string), string> DragonTiger = new()
        {
            // WM code => RCG code
            // ! FIXME: 有小費
            {(102, "Tie"),"He"},// 和
            {(102, "Tiger"),"Hu"},// 虎
            {(102, "TigerOdd"),"HuDan"},// 虎單
            {(102, "TigerBlack"),"HuHei"},// 虎黑
            {(102, "TigerRed"),"HuHong"},// 虎紅
            {(102, "TigerEven"),"HuShuang"},// 虎雙
            {(102, "Dragon"),"Long"},// 龍
            {(102, "DragonOdd"),"LongDan"},// 龍單
            {(102, "DragonBlack"),"LongHei"},// 龍黑
            {(102, "DragonRed"),"LongHong"},// 龍紅
            {(102, "DragonEven"),"LongShuang"}// 龍雙
        };

    // TODO 103 輪盤賽果 LunPan 
    private static Dictionary<(int, string), string> Roulette = new()
        {
            // WM code => RCG code
            {(103, "Num0"), "A0" },// 直接注：0
            {(103, "Num1"), "01" },// 直接注：1
            {(103, "Num2"), "02" },// 直接注：2
            {(103, "Num3"), "03" },// 直接注：3
            {(103, "Num4"), "04" },// 直接注：4
            {(103, "Num5"), "05" },// 直接注：5
            {(103, "Num6"), "06" },// 直接注：6
            {(103, "Num7"), "07" },// 直接注：7
            {(103, "Num8"), "08" },// 直接注：8
            {(103, "Num9"), "09" },// 直接注：9
            {(103, "Num10"), "10" },// 直接注：10
            {(103, "Num11"), "11" },// 直接注：11
            {(103, "Num12"), "12" },// 直接注：12
            {(103, "Num13"), "13" },// 直接注：13
            {(103, "Num14"), "14" },// 直接注：14
            {(103, "Num15"), "15" },// 直接注：15
            {(103, "Num16"), "16" },// 直接注：16
            {(103, "Num17"), "17" },// 直接注：17
            {(103, "Num18"), "18" },// 直接注：18
            {(103, "Num19"), "19" },// 直接注：19
            {(103, "Num20"), "20" },// 直接注：20
            {(103, "Num21"), "21" },// 直接注：21
            {(103, "Num22"), "22" },// 直接注：22
            {(103, "Num23"), "23" },// 直接注：23
            {(103, "Num24"), "24" },// 直接注：24
            {(103, "Num25"), "25" },// 直接注：25
            {(103, "Num26"), "26" },// 直接注：26
            {(103, "Num27"), "27" },// 直接注：27
            {(103, "Num28"), "28" },// 直接注：28
            {(103, "Num29"), "29" },// 直接注：29
            {(103, "Num30"), "30" },// 直接注：30
            {(103, "Num31"), "31" },// 直接注：31
            {(103, "Num32"), "32" },// 直接注：32
            {(103, "Num33"), "33" },// 直接注：33
            {(103, "Num34"), "34" },// 直接注：34
            {(103, "Num35"), "35" },// 直接注：35
            {(103, "Num36"), "36" },// 直接注：36
            {(103, "Num1_2"), "1,2," },// 分注：1,2
            {(103, "Num2_3"), "2,3," },// 分注：2,3
            {(103, "Num4_5"), "4,5," },// 分注：4,5
            {(103, "Num5_6"), "5,6," },// 分注：5,6
            {(103, "Num7_8"), "7,8," },// 分注：7,8
            {(103, "Num8_9"), "8,9," },// 分注：8,9
            {(103, "Num10_11"), "10，11," },// 分注：10，11
            {(103, "Num11_12"), "11，12," },// 分注：11，12
            {(103, "Num13_14"), "13，14," },// 分注：13，14
            {(103, "Num14_15"), "14，15," },// 分注：14，15
            {(103, "Num16_17"), "16，17," },// 分注：16，17
            {(103, "Num17_18"), "17，18," },// 分注：17，18
            {(103, "Num19_20"), "19，20," },// 分注：19，20
            {(103, "Num20_21"), "20，21," },// 分注：20，21
            {(103, "Num22_23"), "22，23," },// 分注：22，23
            {(103, "Num23_24"), "23，24," },// 分注：23，24
            {(103, "Num25_26"), "25，26," },// 分注：25，26
            {(103, "Num26_27"), "26，27," },// 分注：26，27
            {(103, "Num28_29"), "28，29," },// 分注：28，29
            {(103, "Num29_30"), "29，30," },// 分注：29，30
            {(103, "Num31_32"), "31，32," },// 分注：31，32
            {(103, "Num32_33"), "32，33," },// 分注：32，33
            {(103, "Num34_35"), "34，35," },// 分注：34，35
            {(103, "Num35_36"), "35，36," },// 分注：35，36
            {(103, "Num1_4"), "1,4," },// 分注：1，4
            {(103, "Num2_5"), "2,5," },// 分注：2，5
            {(103, "Num3_6"), "3,6," },// 分注：3，6
            {(103, "Num4_7"), "4,7," },// 分注：4，7
            {(103, "Num5_8"), "5,8," },// 分注：5，8
            {(103, "Num6_9"), "6,9," },// 分注：6，9
            {(103, "Num7_10"), "7,10," },// 分注：7，10
            {(103, "Num8_11"), "8,11," },// 分注：8，11
            {(103, "Num9_12"), "9,12," },// 分注：9，12
            {(103, "Num10_13"), "10,13," },// 分注：10，13
            {(103, "Num11_14"), "11,14," },// 分注：11，14
            {(103, "Num12_15"), "12,15," },// 分注：12，15
            {(103, "Num13_16"), "13,16," },// 分注：13，16
            {(103, "Num14_17"), "14,17," },// 分注：14，17
            {(103, "Num15_18"), "15,18," },// 分注：15，18
            {(103, "Num16_19"), "16,19," },// 分注：16，19
            {(103, "Num17_20"), "17,20," },// 分注：17，20
            {(103, "Num18_21"), "18,21," },// 分注：18，21
            {(103, "Num19_22"), "19,22," },// 分注：19，22
            {(103, "Num20_23"), "20,23," },// 分注：20，23
            {(103, "Num21_24"), "21,24," },// 分注：21，24
            {(103, "Num22_25"), "22,25," },// 分注：22，25
            {(103, "Num23_26"), "23,26," },// 分注：23，26
            {(103, "Num24_27"), "24,27," },// 分注：24，27
            {(103, "Num25_28"), "25,28," },// 分注：25，28
            {(103, "Num26_29"), "26,29," },// 分注：26，29
            {(103, "Num27_30"), "27,30," },// 分注：27，30
            {(103, "Num28_31"), "28,31," },// 分注：28，31
            {(103, "Num29_32"), "29,32," },// 分注：29，32
            {(103, "Num30_33"), "30,33," },// 分注：30，33
            {(103, "Num31_34"), "31,34," },// 分注：31，34
            {(103, "Num32_35"), "32,35," },// 分注：32，35
            {(103, "Num33_36"), "33,36," },// 分注：33，36
            {(103, "Column1"), "01,04,07,10,13,16,19,22,25,28,31,34," },// 列注1
            {(103, "Column2"), "02,05,08,11,14,17,20,23,26,29,32,35," },// 列注2
            {(103, "Column3"), "03,06,09,12,15,18,21,24,27,30,33,36," },// 列注3
            {(103, "Dozen1_12"), "01,02,03,04,05,06,07,08,09,10,11,12," },// 數位1-12
            {(103, "Dozen13_24"), "13,14,15,16,17,18,19,20,21,22,23,24," },// 數位13-24
            {(103, "Dozen25_36"), "25,26,27,28,29,30,31,32,33,34,35,36," },// 數位25-36
            {(103, "Num1_2_3_4_5_6"), "01,02,03,04,05,06," },// 線注：1,2,3,4,5,6
            {(103, "Num4_5_6_7_8_9"), "04,05,06,07,08,09," },// 線注：4,5,6,7,8,9
            {(103, "Num7_8_9_10_11_12"), "07,08,09,10,11,12," },// 線注：7,8,9,10,11,12
            {(103, "Num10_11_12_13_14_15"), "10,11,12,13,14,15," },// 線注：10,11,12,13,14,15
            {(103, "Num13_14_15_16_17_18"), "13,14,15,16,17,18," },// 線注：13,14,15,16,17,18
            {(103, "Num16_17_18_19_20_21"), "16,17,18,19,20,21," },// 線注：16,17,18,19,20,21
            {(103, "Num19_20_21_22_23_24"), "19,20,21,22,23,24," },// 線注：19,20,21,22,23,24
            {(103, "Num22_23_24_25_26_27"), "22,23,24,25,26,27," },// 線注：22,23,24,25,26,27
            {(103, "Num25_26_27_28_29_30"), "25,26,27,28,29,30," },// 線注：25,26,27,28,29,30
            {(103, "Num28_29_30_31_32_33"), "28,29,30,31,32,33," },// 線注：28,29,30,31,32,33
            {(103, "Num31_32_33_34_35_36"), "31,32,33,34,35,36," },// 線注：31,32,33,34,35,36
            {(103, "Num1_2_3"), "01,02,03," },// 街注：1,2,3
            {(103, "Num4_5_6"), "04,05,06," },// 街注：4,5,6
            {(103, "Num7_8_9"), "07,08,09," },// 街注：7,8,9
            {(103, "Num10_11_12"), "10,11,12," },// 街注：10，11，12
            {(103, "Num13_14_15"), "13,14,15," },// 街注：13，14，15
            {(103, "Num16_17_18"), "16,17,18," },// 街注：16，17，18
            {(103, "Num19_20_21"), "19,20,21," },// 街注：19，20，21
            {(103, "Num22_23_24"), "22,23,24," },// 街注：22，23，24
            {(103, "Num25_26_27"), "25,26,27," },// 街注：25，26，27
            {(103, "Num28_29_30"), "28,29,30," },// 街注：28，29，30
            {(103, "Num31_32_33"), "31,32,33," },// 街注：31，32，33
            {(103, "Num34_35_36"), "34,35,36," },// 街注：34，35，36
            {(103, "Num1_2_4_5"), "01,02,04,05," },// 角注：1,2,4,5
            {(103, "Num2_3_5_6"), "02,03,05,06" },// 角注：2,3,5,6
            {(103, "Num4_5_7_8"), "04,05,07,08" },// 角注：4,5,7,8
            {(103, "Num5_6_8_9"), "05,06,08,09" },// 角注：5,6,8,9
            {(103, "Num7_8_10_11"), "07,08,10,11" },// 角注：7,8,10,11
            {(103, "Num8_9_11_12"), "08,09,11,12" },// 角注：8,9,11,12
            {(103, "Num10_11_13_14"), "10,11,13,14," },// 角注：10,11,13,14
            {(103, "Num11_12_14_15"), "11,12,14,15," },// 角注：11,12,14,15
            {(103, "Num13_14_16_17"), "13,14,16,17," },// 角注：13,14,16,17
            {(103, "Num14_15_17_18"), "14,15,17,18," },// 角注：14,15,17,18
            {(103, "Num16_17_19_20"), "16,17,19,20," },// 角注：16,17,19,20
            {(103, "Num17_18_20_21"), "17,18,20,21," },// 角注：17,18,20,21
            {(103, "Num19_20_22_23"), "19,20,22,23," },// 角注：19,20,22,23
            {(103, "Num20_21_23_24"), "20,21,23,24," },// 角注：20,21,23,24
            {(103, "Num22_23_25_26"), "22,23,25,26," },// 角注：22,23,25,26
            {(103, "Num23_24_26_27"), "23,24,26,27," },// 角注：23,24,26,27
            {(103, "Num25_26_28_29"), "25,26,28,29," },// 角注：25,26,28,29
            {(103, "Num26_27_29_30"), "26,27,29,30," },// 角注：26,27,29,30
            {(103, "Num28_29_31_32"), "28,29,31,32," },// 角注：28,29,31,32
            {(103, "Num29_30_32_33"), "29,30,32,33," },// 角注：29,30,32,33
            {(103, "Num31_32_34_35"), "31,32,34,35," },// 角注：31,32,34,35
            {(103, "Num32_33_35_36"), "32,33,35,36," },// 角注：32,33,35,36
            {(103, "Num0_3"), "A0,03," },// 分注：0,3
            {(103, "Num0_2"), "A0,02," },// 分注：0,2
            {(103, "Num0_1"), "A0,01," },// 分注：0,1
            {(103, "Num0_2_3"), "A0,02,03," },// 3數：0,2,3
            {(103, "Num0_1_2"), "A0,01,02," },// 3數：0,1,2
            {(103, "Num0_1_2_3"), "A0,01,02,03," },// 4個號碼：0,1,2,3
            {(103, "Small"), "01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18," },// 小
            {(103, "Big"), "19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36," },// 大
            {(103, "Odd"), "01,03,05,07,09,11,13,15,17,19,21,23,25,27,29,31,33,35," },// 單
            {(103, "Even"), "02,04,06,08,10,12,14,16,18,20,22,24,26,28,30,32,34,36" },// 雙
            {(103, "Red"), "01,03,05,07,09,12,14,16,18,19,21,23,25,27,30,32,34,36," },// 紅
            {(103, "Black"), "02,04,06,08,10,11,13,15,17,20,22,24,26,28,29,31,33,35," }// 黑
        };

    // TODO 104 骰宝賽果 ShaiZi （同110）
    private static Dictionary<(int, string), string> Sicbo = new()
        {
            // WM code => RCG code
            {(104, "OneDice1"), "A01" },// 單骰：1
            {(104, "OneDice2"), "A02" },// 單骰：2
            {(104, "OneDice3"), "A03" },// 單骰：3
            {(104, "OneDice4"), "A04" },// 單骰：4
            {(104, "OneDice5"), "A05" },// 單骰：5
            {(104, "OneDice6"), "A06" },// 單骰：6
            {(104, "DoubleDice1"), "B11" },// 對子：1
            {(104, "DoubleDice2"), "B22" },// 對子：2
            {(104, "DoubleDice3"), "B33" },// 對子：3
            {(104, "DoubleDice4"), "B44" },// 對子：4
            {(104, "DoubleDice5"), "B55" },// 對子：5
            {(104, "DoubleDice6"), "B66" },// 對子：6
            {(104, "TwoDice12"), "B12" },// 牌9：1,2
            {(104, "TwoDice13"), "B13" },// 牌9：1,3
            {(104, "TwoDice14"), "B14" },// 牌9：1,4
            {(104, "TwoDice15"), "B15" },// 牌9：1,5
            {(104, "TwoDice16"), "B16" },// 牌9：1,6
            {(104, "TwoDice23"), "B23" },// 牌9：2,3
            {(104, "TwoDice24"), "B24" },// 牌9：2,4
            {(104, "TwoDice25"), "B25" },// 牌9：2,5
            {(104, "TwoDice26"), "B26" },// 牌9：2,6
            {(104, "TwoDice34"), "B34" },// 牌9：3,4
            {(104, "TwoDice35"), "B35" },// 牌9：3,5
            {(104, "TwoDice36"), "B36" },// 牌9：3,6
            {(104, "TwoDice45"), "B45" },// 牌9：4,5
            {(104, "TwoDice46"), "B46" },// 牌9：4,6
            {(104, "TwoDice56"), "B56" },// 牌9：5,6
            {(104, "Sum4"), "C04" },// 總數：4
            {(104, "Sum5"), "C05" },// 總數：5
            {(104, "Sum6"), "C06" },// 總數：6
            {(104, "Sum7"), "C07" },// 總數：7
            {(104, "Sum8"), "C08" },// 總數：8
            {(104, "Sum9"), "C09" },// 總數：9
            {(104, "Sum10"), "C10" },// 總數：10
            {(104, "Sum11"), "C11" },// 總數：11
            {(104, "Sum12"), "C12" },// 總數：12
            {(104, "Sum13"), "C13" },// 總數：13
            {(104, "Sum14"), "C14" },// 總數：14
            {(104, "Sum15"), "C15" },// 總數：15
            {(104, "Sum16"), "C16" },// 總數：16
            {(104, "Sum17"), "C17" },// 總數：17
            {(104, "Leopard1"), "D01" },// 圍骰：1
            {(104, "Leopard2"), "D02" },// 圍骰：2
            {(104, "Leopard3"), "D03" },// 圍骰：3
            {(104, "Leopard4"), "D04" },// 圍骰：4
            {(104, "Leopard5"), "D05" },// 圍骰：5
            {(104, "Leopard6"), "D06" },// 圍骰：6
            {(104, "AllLeopard"), "F01" },// 全圍
            {(104, "Small"), "E01" },// 小
            {(104, "Big"), "E02" },// 大
            {(104, "Odd"), "G01" },// 單
            {(104, "Even"), "G02" }// 雙            
        };

    // TODO 105 牛牛賽果 BullBull
    private static Dictionary<(int, string), string> NiuNiu = new()
        {
            // WM code => RCG code
            // ! FIXME: 有小費
            {(105, "Player1Double"),"P1Double"},// 閒一翻倍
            {(105, "Player1Equal"),"P1Equal"},// 閒一平倍
            {(105, "Player2Double"),"P2Double"},// 閒二翻倍
            {(105, "Player2Equal"),"P2Equal"},// 閒二平倍
            {(105, "Player3Double"),"P3Double"},// 閒三翻倍
            {(105, "Player3Equal"),"P3Equal"}// 閒三平倍
        };

    // TODO 107 番攤賽果 FanTan
    private static Dictionary<(int, string), string> Fantan = new()
        {
            // WM code => RCG code
            // ! FIXME: WM 多了【念】、【通】
            // ! FIXME: RCG 沒有單與雙
            {(107, "Fan1") , "01," }, // 1番
            {(107, "Fan2") , "02," }, // 2番
            {(107, "Fan3") , "03," }, // 3番
            {(107, "Fan4") , "04," }, // 4番
            {(107, "Kwok12"), "01,02," }, // 12角
            {(107, "Kwok13"), "01,03," }, // 13角 - WM 玩法沒有13角
            {(107, "Kwok14"), "01,04," }, // 14角
            {(107, "Kwok23"), "02,03," }, // 23角
            {(107, "Kwok24"), "02,04," }, // 24角 - WM 玩法沒有24角
            {(107, "Kwok34"), "03,04," }, // 34角
            {(107, "Ssh123"), "01,02,03" }, // 三門 123
            {(107, "Ssh124"), "01,02,04" }, // 三門 124
            {(107, "Ssh134"), "01,03,04" }, // 三門 134
            {(107, "Ssh234"), "02,03,04" } // 三門 234
        };

    // TODO 108 色碟賽果 SeDie
    private static Dictionary<(int, string), string> Sedie = new()
        {
            // WM code => RCG code
            // ! FIXME: RCG 沒有大與小
            // ! FIXME: 有小費
            {(108, "Even"),"Even"},// 雙
            {(108, "Odd"),"Odd"},// 單            
            {(108, "W4"), "Red0" },// 四白
            {(108, "W3R1"), "Red1" },// 三白一紅
            {(108, "R3W1"), "Red3" },// 三紅一白
            {(108, "R4"), "Red4" }// 四紅
        };

    // TODO 110 鱼虾蟹賽果 ShaiZi （同104）
    private static Dictionary<(int, string), string> FishPrawnCrab = new()
        {
            // WM code => RCG code
            {(110, "Dice1"), "A01" },// 單骰：1
            {(110, "Dice2"), "A02" },// 單骰：2
            {(110, "Dice3"), "A03" },// 單骰：3
            {(110, "Dice4"), "A04" },// 單骰：4
            {(110, "Dice5"), "A05" },// 單骰：5
            {(110, "Dice6"), "A06" },// 單骰：6
            {(110, "Sum4"), "C04" },// 總數：4
            {(110, "Sum5"), "C05" },// 總數：5
            {(110, "Sum6"), "C06" },// 總數：6
            {(110, "Sum7"), "C07" },// 總數：7
            {(110, "Sum8"), "C08" },// 總數：8
            {(110, "Sum9"), "C09" },// 總數：9
            {(110, "Sum10"), "C10" },// 總數：10
            {(110, "Sum11"), "C11" },// 總數：11
            {(110, "Sum12"), "C12" },// 總數：12
            {(110, "Sum13"), "C13" },// 總數：13
            {(110, "Sum14"), "C14" },// 總數：14
            {(110, "Sum15"), "C15" },// 總數：15
            {(110, "Sum16"), "C16" },// 總數：16
            {(110, "Sum17"), "C17" },// 總數：17
            {(110, "Triples1"), "D01" },// 圍骰：1
            {(110, "Triples2"), "D02" },// 圍骰：2
            {(110, "Triples3"), "D03" },// 圍骰：3
            {(110, "Triples4"), "D04" },// 圍骰：4
            {(110, "Triples5"), "D05" },// 圍骰：5
            {(110, "Triples6"), "D06" },// 圍骰：6
            {(110, "Anytriples"), "F01" },// 全圍
            {(110, "Small"), "E01" },// 小
            {(110, "Big"), "E02" },// 大
            {(110, "Odd"), "G01" },// 單
            {(110, "Even"), "G02" }// 雙
        };

    // TODO 128 安達巴哈賽果 AndarBahar
    private static Dictionary<(int, string), string> AndarBahar = new()
        {
            // WM code => RCG code
            // ! FIXME: 有小費
            {(128, "Andar"), "Andar" },// 安達
            {(128, "Bahar"), "Bahar" }// 巴哈
        };

    /// <summary>
    /// WM betResult 轉為 RCG 的格式
    /// </summary>
    /// <param name="record"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static string BetCodeToRcg(WMDataReportResponse.Result record)
    {
        if (record is null)
        {
            Console.WriteLine($"WM - null record");
            return "";
        }
        if (record.betCode is null)
        {
            Console.WriteLine($"WM - null record.betCode");
            return "";
        }
        switch (record.gid)
        {
            case 101:// TODO 101 百家樂賽果 Bacc
                     // 沒有莊(免傭)的 WM code 要再判斷 commission 欄位是否為 1，對應 RCG 的 ZhuangB 00010 莊(免傭)
                if (record.commission == "1")
                {
                    if (record.betCode == "Banker")
                    {
                        return "ZhuangB";
                    }
                }
                if (Baccarat.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return Baccarat[(record.gid, record.betCode)];
            case 102:// TODO 102 龍虎賽果 LongHu
                if (DragonTiger.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return DragonTiger[(record.gid, record.betCode)];
            case 103:// TODO 103 輪盤賽果 LunPan 
                if (Roulette.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return Roulette[(record.gid, record.betCode)];
            case 104:// TODO 104 骰宝賽果 ShaiZi （同110）
                if (Sicbo.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return Sicbo[(record.gid, record.betCode)];
            case 105:// TODO 105 牛牛賽果 BullBull
                if (NiuNiu.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return NiuNiu[(record.gid, record.betCode)];
            case 107:// TODO 107 番攤賽果 FanTan
                if (Fantan.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return Fantan[(record.gid, record.betCode)];
            case 108:// TODO 108 色碟賽果 SeDie
                if (Sedie.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return Sedie[(record.gid, record.betCode)];
            case 110:// TODO 110 鱼虾蟹賽果 ShaiZi （同104）
                if (FishPrawnCrab.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return FishPrawnCrab[(record.gid, record.betCode)];
            case 128:// TODO 128 安達巴哈賽果 AndarBahar
                if (AndarBahar.ContainsKey((record.gid, record.betCode)) == false)
                {
                    Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                    return "";
                }
                return AndarBahar[(record.gid, record.betCode)];

            default:
                Console.WriteLine($"WM - Translate the unconvertible betCode: {record.betCode}, betId: {record.betId}, gid: {record.gid}, betTime: {record.betTime:yyyy-MM-dd HH:mm:ss.ffffff}");
                return "";
        }
    }
}
