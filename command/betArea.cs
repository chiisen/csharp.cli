using csharp.cli.model;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System.Globalization;

public partial class Program
{
    /// <summary>
    /// 查詢 betArea
    /// 命令列引數: bet-area Bacc -c "閒"
    /// </summary>
    public static void betArea()
    {
        _ = _app.Command("bet-area", command =>
        {
            // 第二層 Help 的標題
            command.Description = "查詢 betArea";
            command.HelpOption("-?|-h|-help");

            // 輸入參數說明
            var gameNameArgument = command.Argument("[gameName]", "指定需要輸出的遊戲。");

            // 輸入指令說明
            var idOption = command.Option("-i|--id", "指定輸出 betArea", CommandOptionType.SingleValue);
            var contextOption = command.Option("-c|--context", "指定輸出 betArea", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                BetArea json = JsonConvert.DeserializeObject<BetArea>(betAreaJson);
                if (json == null)
                {
                    Console.WriteLine($"null json");
                    return 1;
                }

                var gameName = gameNameArgument.HasValue ? gameNameArgument.Value : null;
                if (gameName == null)
                {
                    Console.WriteLine($"null gameName");
                    return 1;
                }

                gameName = gameName.ToLower(CultureInfo.InvariantCulture);

                string id = idOption.HasValue() ? idOption.Value() : null;
                if (id != null)
                {
                    id = string.Format("{0:00000}", Convert.ToInt16(id));
                    var ids = json.data.Where<BetAreaData>(x => x.gameName.ToLower() == gameName && x.betArea == id.ToString());
                    foreach (var item in ids)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                    return 0;
                }

                string context = contextOption.HasValue() ? contextOption.Value() : null;
                if (context != null)
                {
                    var contexts = json.data.Where<BetAreaData>(x => x.gameName.ToLower() == gameName && x.context == context);
                    foreach (var item in contexts)
                    {
                        Console.WriteLine($"{item.betArea} {item.context} {item.lang}");
                    }
                }

                return 0;
            });
        });
    }

    private static string betAreaJson = @"
{
  ""msgId"": 0,
  ""message"": ""OK"",
  ""data"": [
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00001"",
          ""context"": ""B"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00002"",
          ""context"": ""P"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00003"",
          ""context"": ""Tie"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00004"",
          ""context"": ""Banker Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00005"",
          ""context"": ""Player Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00006"",
          ""context"": ""Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00007"",
          ""context"": ""Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00008"",
          ""context"": ""Any Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00009"",
          ""context"": ""Perfect Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 1,
          ""gameName"": ""Bacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00001"",
          ""context"": ""Dragon"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00002"",
          ""context"": ""Tiger"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00003"",
          ""context"": ""Tie"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00004"",
          ""context"": ""Dragon Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00005"",
          ""context"": ""Dragon Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00006"",
          ""context"": ""Dragon Red"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00007"",
          ""context"": ""Dragon Black"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00008"",
          ""context"": ""Tiger Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00009"",
          ""context"": ""Tiger Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00010"",
          ""context"": ""Tiger Red"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00011"",
          ""context"": ""Tiger Black"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00012"",
          ""context"": ""DragonBig"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00013"",
          ""context"": ""DragonSmall"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00014"",
          ""context"": ""TigerBig"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00015"",
          ""context"": ""TigerSmall"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 2,
          ""gameName"": ""LongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00001"",
          ""context"": ""直接注：0"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00001"",
          ""context"": ""直接注：0"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00001"",
          ""context"": ""直接注：0"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00001"",
          ""context"": ""直接注：0"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00001"",
          ""context"": ""直接注：0"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00001"",
          ""context"": ""直接注：0"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00001"",
          ""context"": ""直接注：0"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00004"",
          ""context"": ""分注：0,3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00004"",
          ""context"": ""分注：0,3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00004"",
          ""context"": ""分注：0,3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00004"",
          ""context"": ""分注：0,3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00004"",
          ""context"": ""分注：0,3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00004"",
          ""context"": ""分注：0,3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00004"",
          ""context"": ""分注：0,3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00005"",
          ""context"": ""分注：0,2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00005"",
          ""context"": ""分注：0,2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00005"",
          ""context"": ""分注：0,2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00005"",
          ""context"": ""分注：0,2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00005"",
          ""context"": ""分注：0,2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00005"",
          ""context"": ""分注：0,2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00005"",
          ""context"": ""分注：0,2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00006"",
          ""context"": ""分注：0,1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00006"",
          ""context"": ""分注：0,1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00006"",
          ""context"": ""分注：0,1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00006"",
          ""context"": ""分注：0,1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00006"",
          ""context"": ""分注：0,1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00006"",
          ""context"": ""分注：0,1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00006"",
          ""context"": ""分注：0,1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00009"",
          ""context"": ""三數：0,2,3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00009"",
          ""context"": ""三數：0,2,3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00009"",
          ""context"": ""三數：0,2,3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00009"",
          ""context"": ""三數：0,2,3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00009"",
          ""context"": ""三數：0,2,3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00009"",
          ""context"": ""三數：0,2,3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00009"",
          ""context"": ""三數：0,2,3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00010"",
          ""context"": ""三數：0,1,2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00010"",
          ""context"": ""三數：0,1,2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00010"",
          ""context"": ""三數：0,1,2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00010"",
          ""context"": ""三數：0,1,2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00010"",
          ""context"": ""三數：0,1,2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00010"",
          ""context"": ""三數：0,1,2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00010"",
          ""context"": ""三數：0,1,2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00013"",
          ""context"": ""四個號碼：0,1,2,3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00013"",
          ""context"": ""四個號碼：0,1,2,3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00013"",
          ""context"": ""四個號碼：0,1,2,3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00013"",
          ""context"": ""四個號碼：0,1,2,3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00013"",
          ""context"": ""四個號碼：0,1,2,3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00013"",
          ""context"": ""四個號碼：0,1,2,3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00013"",
          ""context"": ""四個號碼：0,1,2,3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00015"",
          ""context"": ""直接注：1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00015"",
          ""context"": ""直接注：1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00015"",
          ""context"": ""直接注：1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00015"",
          ""context"": ""直接注：1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00015"",
          ""context"": ""直接注：1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00015"",
          ""context"": ""直接注：1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00015"",
          ""context"": ""直接注：1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00016"",
          ""context"": ""直接注：2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00016"",
          ""context"": ""直接注：2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00016"",
          ""context"": ""直接注：2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00016"",
          ""context"": ""直接注：2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00016"",
          ""context"": ""直接注：2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00016"",
          ""context"": ""直接注：2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00016"",
          ""context"": ""直接注：2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00017"",
          ""context"": ""直接注：3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00017"",
          ""context"": ""直接注：3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00017"",
          ""context"": ""直接注：3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00017"",
          ""context"": ""直接注：3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00017"",
          ""context"": ""直接注：3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00017"",
          ""context"": ""直接注：3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00017"",
          ""context"": ""直接注：3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00018"",
          ""context"": ""直接注：4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00018"",
          ""context"": ""直接注：4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00018"",
          ""context"": ""直接注：4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00018"",
          ""context"": ""直接注：4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00018"",
          ""context"": ""直接注：4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00018"",
          ""context"": ""直接注：4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00018"",
          ""context"": ""直接注：4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00019"",
          ""context"": ""直接注：5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00019"",
          ""context"": ""直接注：5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00019"",
          ""context"": ""直接注：5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00019"",
          ""context"": ""直接注：5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00019"",
          ""context"": ""直接注：5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00019"",
          ""context"": ""直接注：5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00019"",
          ""context"": ""直接注：5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00020"",
          ""context"": ""直接注：6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00020"",
          ""context"": ""直接注：6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00020"",
          ""context"": ""直接注：6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00020"",
          ""context"": ""直接注：6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00020"",
          ""context"": ""直接注：6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00020"",
          ""context"": ""直接注：6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00020"",
          ""context"": ""直接注：6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00021"",
          ""context"": ""直接注：7"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00021"",
          ""context"": ""直接注：7"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00021"",
          ""context"": ""直接注：7"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00021"",
          ""context"": ""直接注：7"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00021"",
          ""context"": ""直接注：7"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00021"",
          ""context"": ""直接注：7"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00021"",
          ""context"": ""直接注：7"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00022"",
          ""context"": ""直接注：8"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00022"",
          ""context"": ""直接注：8"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00022"",
          ""context"": ""直接注：8"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00022"",
          ""context"": ""直接注：8"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00022"",
          ""context"": ""直接注：8"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00022"",
          ""context"": ""直接注：8"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00022"",
          ""context"": ""直接注：8"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00023"",
          ""context"": ""直接注：9"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00023"",
          ""context"": ""直接注：9"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00023"",
          ""context"": ""直接注：9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00023"",
          ""context"": ""直接注：9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00023"",
          ""context"": ""直接注：9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00023"",
          ""context"": ""直接注：9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00023"",
          ""context"": ""直接注：9"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00024"",
          ""context"": ""直接注：10"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00024"",
          ""context"": ""直接注：10"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00024"",
          ""context"": ""直接注：10"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00024"",
          ""context"": ""直接注：10"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00024"",
          ""context"": ""直接注：10"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00024"",
          ""context"": ""直接注：10"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00024"",
          ""context"": ""直接注：10"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00025"",
          ""context"": ""直接注：11"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00025"",
          ""context"": ""直接注：11"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00025"",
          ""context"": ""直接注：11"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00025"",
          ""context"": ""直接注：11"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00025"",
          ""context"": ""直接注：11"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00025"",
          ""context"": ""直接注：11"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00025"",
          ""context"": ""直接注：11"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00026"",
          ""context"": ""直接注：12"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00026"",
          ""context"": ""直接注：12"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00026"",
          ""context"": ""直接注：12"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00026"",
          ""context"": ""直接注：12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00026"",
          ""context"": ""直接注：12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00026"",
          ""context"": ""直接注：12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00026"",
          ""context"": ""直接注：12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00027"",
          ""context"": ""直接注：13"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00027"",
          ""context"": ""直接注：13"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00027"",
          ""context"": ""直接注：13"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00027"",
          ""context"": ""直接注：13"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00027"",
          ""context"": ""直接注：13"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00027"",
          ""context"": ""直接注：13"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00027"",
          ""context"": ""直接注：13"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00028"",
          ""context"": ""直接注：14"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00028"",
          ""context"": ""直接注：14"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00028"",
          ""context"": ""直接注：14"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00028"",
          ""context"": ""直接注：14"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00028"",
          ""context"": ""直接注：14"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00028"",
          ""context"": ""直接注：14"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00028"",
          ""context"": ""直接注：14"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00029"",
          ""context"": ""直接注：15"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00029"",
          ""context"": ""直接注：15"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00029"",
          ""context"": ""直接注：15"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00029"",
          ""context"": ""直接注：15"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00029"",
          ""context"": ""直接注：15"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00029"",
          ""context"": ""直接注：15"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00029"",
          ""context"": ""直接注：15"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00030"",
          ""context"": ""直接注：16"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00030"",
          ""context"": ""直接注：16"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00030"",
          ""context"": ""直接注：16"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00030"",
          ""context"": ""直接注：16"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00030"",
          ""context"": ""直接注：16"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00030"",
          ""context"": ""直接注：16"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00030"",
          ""context"": ""直接注：16"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00031"",
          ""context"": ""直接注：17"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00031"",
          ""context"": ""直接注：17"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00031"",
          ""context"": ""直接注：17"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00031"",
          ""context"": ""直接注：17"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00031"",
          ""context"": ""直接注：17"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00031"",
          ""context"": ""直接注：17"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00031"",
          ""context"": ""直接注：17"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00032"",
          ""context"": ""直接注：18"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00032"",
          ""context"": ""直接注：18"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00032"",
          ""context"": ""直接注：18"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00032"",
          ""context"": ""直接注：18"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00032"",
          ""context"": ""直接注：18"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00032"",
          ""context"": ""直接注：18"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00032"",
          ""context"": ""直接注：18"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00033"",
          ""context"": ""直接注：19"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00033"",
          ""context"": ""直接注：19"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00033"",
          ""context"": ""直接注：19"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00033"",
          ""context"": ""直接注：19"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00033"",
          ""context"": ""直接注：19"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00033"",
          ""context"": ""直接注：19"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00033"",
          ""context"": ""直接注：19"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00034"",
          ""context"": ""直接注：20"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00034"",
          ""context"": ""直接注：20"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00034"",
          ""context"": ""直接注：20"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00034"",
          ""context"": ""直接注：20"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00034"",
          ""context"": ""直接注：20"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00034"",
          ""context"": ""直接注：20"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00034"",
          ""context"": ""直接注：20"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00035"",
          ""context"": ""直接注：21"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00035"",
          ""context"": ""直接注：21"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00035"",
          ""context"": ""直接注：21"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00035"",
          ""context"": ""直接注：21"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00035"",
          ""context"": ""直接注：21"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00035"",
          ""context"": ""直接注：21"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00035"",
          ""context"": ""直接注：21"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00036"",
          ""context"": ""直接注：22"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00036"",
          ""context"": ""直接注：22"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00036"",
          ""context"": ""直接注：22"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00036"",
          ""context"": ""直接注：22"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00036"",
          ""context"": ""直接注：22"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00036"",
          ""context"": ""直接注：22"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00036"",
          ""context"": ""直接注：22"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00037"",
          ""context"": ""直接注：23"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00037"",
          ""context"": ""直接注：23"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00037"",
          ""context"": ""直接注：23"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00037"",
          ""context"": ""直接注：23"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00037"",
          ""context"": ""直接注：23"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00037"",
          ""context"": ""直接注：23"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00037"",
          ""context"": ""直接注：23"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00038"",
          ""context"": ""直接注：24"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00038"",
          ""context"": ""直接注：24"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00038"",
          ""context"": ""直接注：24"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00038"",
          ""context"": ""直接注：24"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00038"",
          ""context"": ""直接注：24"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00038"",
          ""context"": ""直接注：24"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00038"",
          ""context"": ""直接注：24"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00039"",
          ""context"": ""直接注：25"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00039"",
          ""context"": ""直接注：25"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00039"",
          ""context"": ""直接注：25"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00039"",
          ""context"": ""直接注：25"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00039"",
          ""context"": ""直接注：25"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00039"",
          ""context"": ""直接注：25"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00039"",
          ""context"": ""直接注：25"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00040"",
          ""context"": ""直接注：26"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00040"",
          ""context"": ""直接注：26"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00040"",
          ""context"": ""直接注：26"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00040"",
          ""context"": ""直接注：26"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00040"",
          ""context"": ""直接注：26"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00040"",
          ""context"": ""直接注：26"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00040"",
          ""context"": ""直接注：26"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00041"",
          ""context"": ""直接注：27"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00041"",
          ""context"": ""直接注：27"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00041"",
          ""context"": ""直接注：27"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00041"",
          ""context"": ""直接注：27"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00041"",
          ""context"": ""直接注：27"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00041"",
          ""context"": ""直接注：27"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00041"",
          ""context"": ""直接注：27"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00042"",
          ""context"": ""直接注：28"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00042"",
          ""context"": ""直接注：28"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00042"",
          ""context"": ""直接注：28"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00042"",
          ""context"": ""直接注：28"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00042"",
          ""context"": ""直接注：28"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00042"",
          ""context"": ""直接注：28"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00042"",
          ""context"": ""直接注：28"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00043"",
          ""context"": ""直接注：29"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00043"",
          ""context"": ""直接注：29"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00043"",
          ""context"": ""直接注：29"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00043"",
          ""context"": ""直接注：29"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00043"",
          ""context"": ""直接注：29"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00043"",
          ""context"": ""直接注：29"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00043"",
          ""context"": ""直接注：29"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00044"",
          ""context"": ""直接注：30"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00044"",
          ""context"": ""直接注：30"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00044"",
          ""context"": ""直接注：30"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00044"",
          ""context"": ""直接注：30"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00044"",
          ""context"": ""直接注：30"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00044"",
          ""context"": ""直接注：30"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00044"",
          ""context"": ""直接注：30"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00045"",
          ""context"": ""直接注：31"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00045"",
          ""context"": ""直接注：31"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00045"",
          ""context"": ""直接注：31"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00045"",
          ""context"": ""直接注：31"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00045"",
          ""context"": ""直接注：31"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00045"",
          ""context"": ""直接注：31"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00045"",
          ""context"": ""直接注：31"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00046"",
          ""context"": ""直接注：32"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00046"",
          ""context"": ""直接注：32"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00046"",
          ""context"": ""直接注：32"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00046"",
          ""context"": ""直接注：32"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00046"",
          ""context"": ""直接注：32"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00046"",
          ""context"": ""直接注：32"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00046"",
          ""context"": ""直接注：32"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00047"",
          ""context"": ""直接注：33"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00047"",
          ""context"": ""直接注：33"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00047"",
          ""context"": ""直接注：33"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00047"",
          ""context"": ""直接注：33"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00047"",
          ""context"": ""直接注：33"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00047"",
          ""context"": ""直接注：33"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00047"",
          ""context"": ""直接注：33"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00048"",
          ""context"": ""直接注：34"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00048"",
          ""context"": ""直接注：34"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00048"",
          ""context"": ""直接注：34"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00048"",
          ""context"": ""直接注：34"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00048"",
          ""context"": ""直接注：34"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00048"",
          ""context"": ""直接注：34"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00048"",
          ""context"": ""直接注：34"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00049"",
          ""context"": ""直接注：35"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00049"",
          ""context"": ""直接注：35"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00049"",
          ""context"": ""直接注：35"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00049"",
          ""context"": ""直接注：35"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00049"",
          ""context"": ""直接注：35"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00049"",
          ""context"": ""直接注：35"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00049"",
          ""context"": ""直接注：35"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00050"",
          ""context"": ""直接注：36"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00050"",
          ""context"": ""直接注：36"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00050"",
          ""context"": ""直接注：36"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00050"",
          ""context"": ""直接注：36"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00050"",
          ""context"": ""直接注：36"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00050"",
          ""context"": ""直接注：36"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00050"",
          ""context"": ""直接注：36"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00051"",
          ""context"": ""分注：1,2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00051"",
          ""context"": ""分注：1,2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00051"",
          ""context"": ""分注：1,2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00051"",
          ""context"": ""分注：1,2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00051"",
          ""context"": ""分注：1,2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00051"",
          ""context"": ""分注：1,2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00051"",
          ""context"": ""分注：1,2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00052"",
          ""context"": ""分注：2,3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00052"",
          ""context"": ""分注：2,3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00052"",
          ""context"": ""分注：2,3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00052"",
          ""context"": ""分注：2,3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00052"",
          ""context"": ""分注：2,3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00052"",
          ""context"": ""分注：2,3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00052"",
          ""context"": ""分注：2,3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00053"",
          ""context"": ""分注：4,5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00053"",
          ""context"": ""分注：4,5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00053"",
          ""context"": ""分注：4,5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00053"",
          ""context"": ""分注：4,5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00053"",
          ""context"": ""分注：4,5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00053"",
          ""context"": ""分注：4,5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00053"",
          ""context"": ""分注：4,5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00054"",
          ""context"": ""分注：5,6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00054"",
          ""context"": ""分注：5,6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00054"",
          ""context"": ""分注：5,6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00054"",
          ""context"": ""分注：5,6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00054"",
          ""context"": ""分注：5,6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00054"",
          ""context"": ""分注：5,6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00054"",
          ""context"": ""分注：5,6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00055"",
          ""context"": ""分注：7,8"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00055"",
          ""context"": ""分注：7,8"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00055"",
          ""context"": ""分注：7,8"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00055"",
          ""context"": ""分注：7,8"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00055"",
          ""context"": ""分注：7,8"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00055"",
          ""context"": ""分注：7,8"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00055"",
          ""context"": ""分注：7,8"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00056"",
          ""context"": ""分注：8,9"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00056"",
          ""context"": ""分注：8,9"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00056"",
          ""context"": ""分注：8,9"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00056"",
          ""context"": ""分注：8,9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00056"",
          ""context"": ""分注：8,9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00056"",
          ""context"": ""分注：8,9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00056"",
          ""context"": ""分注：8,9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00057"",
          ""context"": ""分注：10,11"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00057"",
          ""context"": ""分注：10,11"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00057"",
          ""context"": ""分注：10,11"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00057"",
          ""context"": ""分注：10,11"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00057"",
          ""context"": ""分注：10,11"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00057"",
          ""context"": ""分注：10,11"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00057"",
          ""context"": ""分注：10,11"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00058"",
          ""context"": ""分注：11,12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00058"",
          ""context"": ""分注：11,12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00058"",
          ""context"": ""分注：11,12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00058"",
          ""context"": ""分注：11,12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00058"",
          ""context"": ""分注：11,12"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00058"",
          ""context"": ""分注：11,12"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00058"",
          ""context"": ""分注：11,12"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00059"",
          ""context"": ""分注：13,14"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00059"",
          ""context"": ""分注：13,14"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00059"",
          ""context"": ""分注：13,14"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00059"",
          ""context"": ""分注：13,14"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00059"",
          ""context"": ""分注：13,14"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00059"",
          ""context"": ""分注：13,14"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00059"",
          ""context"": ""分注：13,14"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00060"",
          ""context"": ""分注：14,15"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00060"",
          ""context"": ""分注：14,15"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00060"",
          ""context"": ""分注：14,15"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00060"",
          ""context"": ""分注：14,15"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00060"",
          ""context"": ""分注：14,15"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00060"",
          ""context"": ""分注：14,15"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00060"",
          ""context"": ""分注：14,15"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00061"",
          ""context"": ""分注：16,17"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00061"",
          ""context"": ""分注：16,17"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00061"",
          ""context"": ""分注：16,17"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00061"",
          ""context"": ""分注：16,17"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00061"",
          ""context"": ""分注：16,17"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00061"",
          ""context"": ""分注：16,17"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00061"",
          ""context"": ""分注：16,17"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00062"",
          ""context"": ""分注：17,18"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00062"",
          ""context"": ""分注：17,18"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00062"",
          ""context"": ""分注：17,18"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00062"",
          ""context"": ""分注：17,18"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00062"",
          ""context"": ""分注：17,18"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00062"",
          ""context"": ""分注：17,18"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00062"",
          ""context"": ""分注：17,18"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00063"",
          ""context"": ""分注：19,20"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00063"",
          ""context"": ""分注：19,20"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00063"",
          ""context"": ""分注：19,20"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00063"",
          ""context"": ""分注：19,20"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00063"",
          ""context"": ""分注：19,20"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00063"",
          ""context"": ""分注：19,20"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00063"",
          ""context"": ""分注：19,20"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00064"",
          ""context"": ""分注：20,21"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00064"",
          ""context"": ""分注：20,21"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00064"",
          ""context"": ""分注：20,21"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00064"",
          ""context"": ""分注：20,21"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00064"",
          ""context"": ""分注：20,21"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00064"",
          ""context"": ""分注：20,21"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00064"",
          ""context"": ""分注：20,21"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00065"",
          ""context"": ""分注：22,23"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00065"",
          ""context"": ""分注：22,23"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00065"",
          ""context"": ""分注：22,23"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00065"",
          ""context"": ""分注：22,23"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00065"",
          ""context"": ""分注：22,23"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00065"",
          ""context"": ""分注：22,23"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00065"",
          ""context"": ""分注：22,23"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00066"",
          ""context"": ""分注：23,24"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00066"",
          ""context"": ""分注：23,24"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00066"",
          ""context"": ""分注：23,24"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00066"",
          ""context"": ""分注：23,24"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00066"",
          ""context"": ""分注：23,24"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00066"",
          ""context"": ""分注：23,24"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00066"",
          ""context"": ""分注：23,24"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00067"",
          ""context"": ""分注：25,26"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00067"",
          ""context"": ""分注：25,26"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00067"",
          ""context"": ""分注：25,26"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00067"",
          ""context"": ""分注：25,26"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00067"",
          ""context"": ""分注：25,26"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00067"",
          ""context"": ""分注：25,26"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00067"",
          ""context"": ""分注：25,26"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00068"",
          ""context"": ""分注：26,27"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00068"",
          ""context"": ""分注：26,27"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00068"",
          ""context"": ""分注：26,27"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00068"",
          ""context"": ""分注：26,27"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00068"",
          ""context"": ""分注：26,27"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00068"",
          ""context"": ""分注：26,27"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00068"",
          ""context"": ""分注：26,27"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00069"",
          ""context"": ""分注：28,29"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00069"",
          ""context"": ""分注：28,29"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00069"",
          ""context"": ""分注：28,29"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00069"",
          ""context"": ""分注：28,29"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00069"",
          ""context"": ""分注：28,29"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00069"",
          ""context"": ""分注：28,29"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00069"",
          ""context"": ""分注：28,29"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00070"",
          ""context"": ""分注：29,30"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00070"",
          ""context"": ""分注：29,30"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00070"",
          ""context"": ""分注：29,30"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00070"",
          ""context"": ""分注：29,30"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00070"",
          ""context"": ""分注：29,30"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00070"",
          ""context"": ""分注：29,30"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00070"",
          ""context"": ""分注：29,30"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00071"",
          ""context"": ""分注：31,32"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00071"",
          ""context"": ""分注：31,32"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00071"",
          ""context"": ""分注：31,32"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00071"",
          ""context"": ""分注：31,32"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00071"",
          ""context"": ""分注：31,32"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00071"",
          ""context"": ""分注：31,32"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00071"",
          ""context"": ""分注：31,32"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00072"",
          ""context"": ""分注：32,33"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00072"",
          ""context"": ""分注：32,33"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00072"",
          ""context"": ""分注：32,33"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00072"",
          ""context"": ""分注：32,33"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00072"",
          ""context"": ""分注：32,33"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00072"",
          ""context"": ""分注：32,33"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00072"",
          ""context"": ""分注：32,33"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00073"",
          ""context"": ""分注：34,35"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00073"",
          ""context"": ""分注：34,35"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00073"",
          ""context"": ""分注：34,35"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00073"",
          ""context"": ""分注：34,35"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00073"",
          ""context"": ""分注：34,35"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00073"",
          ""context"": ""分注：34,35"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00073"",
          ""context"": ""分注：34,35"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00074"",
          ""context"": ""分注：35,36"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00074"",
          ""context"": ""分注：35,36"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00074"",
          ""context"": ""分注：35,36"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00074"",
          ""context"": ""分注：35,36"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00074"",
          ""context"": ""分注：35,36"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00074"",
          ""context"": ""分注：35,36"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00074"",
          ""context"": ""分注：35,36"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00075"",
          ""context"": ""分注：1,4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00075"",
          ""context"": ""分注：1,4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00075"",
          ""context"": ""分注：1,4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00075"",
          ""context"": ""分注：1,4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00075"",
          ""context"": ""分注：1,4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00075"",
          ""context"": ""分注：1,4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00075"",
          ""context"": ""分注：1,4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00076"",
          ""context"": ""分注：2,5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00076"",
          ""context"": ""分注：2,5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00076"",
          ""context"": ""分注：2,5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00076"",
          ""context"": ""分注：2,5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00076"",
          ""context"": ""分注：2,5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00076"",
          ""context"": ""分注：2,5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00076"",
          ""context"": ""分注：2,5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00077"",
          ""context"": ""分注：3,6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00077"",
          ""context"": ""分注：3,6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00077"",
          ""context"": ""分注：3,6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00077"",
          ""context"": ""分注：3,6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00077"",
          ""context"": ""分注：3,6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00077"",
          ""context"": ""分注：3,6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00077"",
          ""context"": ""分注：3,6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00078"",
          ""context"": ""分注：4,7"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00078"",
          ""context"": ""分注：4,7"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00078"",
          ""context"": ""分注：4,7"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00078"",
          ""context"": ""分注：4,7"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00078"",
          ""context"": ""分注：4,7"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00078"",
          ""context"": ""分注：4,7"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00078"",
          ""context"": ""分注：4,7"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00079"",
          ""context"": ""分注：5,8"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00079"",
          ""context"": ""分注：5,8"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00079"",
          ""context"": ""分注：5,8"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00079"",
          ""context"": ""分注：5,8"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00079"",
          ""context"": ""分注：5,8"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00079"",
          ""context"": ""分注：5,8"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00079"",
          ""context"": ""分注：5,8"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00080"",
          ""context"": ""分注：6,9"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00080"",
          ""context"": ""分注：6,9"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00080"",
          ""context"": ""分注：6,9"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00080"",
          ""context"": ""分注：6,9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00080"",
          ""context"": ""分注：6,9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00080"",
          ""context"": ""分注：6,9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00080"",
          ""context"": ""分注：6,9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00081"",
          ""context"": ""分注：7,10"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00081"",
          ""context"": ""分注：7,10"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00081"",
          ""context"": ""分注：7,10"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00081"",
          ""context"": ""分注：7,10"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00081"",
          ""context"": ""分注：7,10"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00081"",
          ""context"": ""分注：7,10"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00081"",
          ""context"": ""分注：7,10"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00082"",
          ""context"": ""分注：8,11"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00082"",
          ""context"": ""分注：8,11"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00082"",
          ""context"": ""分注：8,11"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00082"",
          ""context"": ""分注：8,11"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00082"",
          ""context"": ""分注：8,11"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00082"",
          ""context"": ""分注：8,11"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00082"",
          ""context"": ""分注：8,11"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00083"",
          ""context"": ""分注：9,12"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00083"",
          ""context"": ""分注：9,12"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00083"",
          ""context"": ""分注：9,12"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00083"",
          ""context"": ""分注：9,12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00083"",
          ""context"": ""分注：9,12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00083"",
          ""context"": ""分注：9,12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00083"",
          ""context"": ""分注：9,12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00084"",
          ""context"": ""分注：10,13"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00084"",
          ""context"": ""分注：10,13"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00084"",
          ""context"": ""分注：10,13"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00084"",
          ""context"": ""分注：10,13"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00084"",
          ""context"": ""分注：10,13"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00084"",
          ""context"": ""分注：10,13"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00084"",
          ""context"": ""分注：10,13"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00085"",
          ""context"": ""分注：11,14"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00085"",
          ""context"": ""分注：11,14"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00085"",
          ""context"": ""分注：11,14"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00085"",
          ""context"": ""分注：11,14"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00085"",
          ""context"": ""分注：11,14"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00085"",
          ""context"": ""分注：11,14"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00085"",
          ""context"": ""分注：11,14"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00086"",
          ""context"": ""分注：12,15"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00086"",
          ""context"": ""分注：12,15"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00086"",
          ""context"": ""分注：12,15"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00086"",
          ""context"": ""分注：12,15"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00086"",
          ""context"": ""分注：12,15"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00086"",
          ""context"": ""分注：12,15"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00086"",
          ""context"": ""分注：12,15"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00087"",
          ""context"": ""分注：13,16"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00087"",
          ""context"": ""分注：13,16"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00087"",
          ""context"": ""分注：13,16"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00087"",
          ""context"": ""分注：13,16"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00087"",
          ""context"": ""分注：13,16"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00087"",
          ""context"": ""分注：13,16"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00087"",
          ""context"": ""分注：13,16"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00088"",
          ""context"": ""分注：14,17"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00088"",
          ""context"": ""分注：14,17"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00088"",
          ""context"": ""分注：14,17"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00088"",
          ""context"": ""分注：14,17"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00088"",
          ""context"": ""分注：14,17"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00088"",
          ""context"": ""分注：14,17"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00088"",
          ""context"": ""分注：14,17"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00089"",
          ""context"": ""分注：15,18"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00089"",
          ""context"": ""分注：15,18"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00089"",
          ""context"": ""分注：15,18"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00089"",
          ""context"": ""分注：15,18"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00089"",
          ""context"": ""分注：15,18"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00089"",
          ""context"": ""分注：15,18"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00089"",
          ""context"": ""分注：15,18"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00090"",
          ""context"": ""分注：16,19"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00090"",
          ""context"": ""分注：16,19"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00090"",
          ""context"": ""分注：16,19"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00090"",
          ""context"": ""分注：16,19"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00090"",
          ""context"": ""分注：16,19"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00090"",
          ""context"": ""分注：16,19"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00090"",
          ""context"": ""分注：16,19"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00091"",
          ""context"": ""分注：17,20"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00091"",
          ""context"": ""分注：17,20"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00091"",
          ""context"": ""分注：17,20"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00091"",
          ""context"": ""分注：17,20"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00091"",
          ""context"": ""分注：17,20"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00091"",
          ""context"": ""分注：17,20"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00091"",
          ""context"": ""分注：17,20"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00092"",
          ""context"": ""分注：18,21"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00092"",
          ""context"": ""分注：18,21"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00092"",
          ""context"": ""分注：18,21"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00092"",
          ""context"": ""分注：18,21"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00092"",
          ""context"": ""分注：18,21"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00092"",
          ""context"": ""分注：18,21"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00092"",
          ""context"": ""分注：18,21"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00093"",
          ""context"": ""分注：19,22"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00093"",
          ""context"": ""分注：19,22"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00093"",
          ""context"": ""分注：19,22"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00093"",
          ""context"": ""分注：19,22"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00093"",
          ""context"": ""分注：19,22"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00093"",
          ""context"": ""分注：19,22"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00093"",
          ""context"": ""分注：19,22"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00094"",
          ""context"": ""分注：20,23"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00094"",
          ""context"": ""分注：20,23"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00094"",
          ""context"": ""分注：20,23"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00094"",
          ""context"": ""分注：20,23"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00094"",
          ""context"": ""分注：20,23"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00094"",
          ""context"": ""分注：20,23"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00094"",
          ""context"": ""分注：20,23"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00095"",
          ""context"": ""分注：21,24"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00095"",
          ""context"": ""分注：21,24"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00095"",
          ""context"": ""分注：21,24"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00095"",
          ""context"": ""分注：21,24"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00095"",
          ""context"": ""分注：21,24"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00095"",
          ""context"": ""分注：21,24"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00095"",
          ""context"": ""分注：21,24"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00096"",
          ""context"": ""分注：22,25"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00096"",
          ""context"": ""分注：22,25"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00096"",
          ""context"": ""分注：22,25"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00096"",
          ""context"": ""分注：22,25"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00096"",
          ""context"": ""分注：22,25"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00096"",
          ""context"": ""分注：22,25"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00096"",
          ""context"": ""分注：22,25"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00097"",
          ""context"": ""分注：23,26"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00097"",
          ""context"": ""分注：23,26"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00097"",
          ""context"": ""分注：23,26"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00097"",
          ""context"": ""分注：23,26"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00097"",
          ""context"": ""分注：23,26"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00097"",
          ""context"": ""分注：23,26"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00097"",
          ""context"": ""分注：23,26"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00098"",
          ""context"": ""分注：24,27"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00098"",
          ""context"": ""分注：24,27"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00098"",
          ""context"": ""分注：24,27"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00098"",
          ""context"": ""分注：24,27"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00098"",
          ""context"": ""分注：24,27"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00098"",
          ""context"": ""分注：24,27"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00098"",
          ""context"": ""分注：24,27"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00099"",
          ""context"": ""分注：25,28"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00099"",
          ""context"": ""分注：25,28"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00099"",
          ""context"": ""分注：25,28"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00099"",
          ""context"": ""分注：25,28"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00099"",
          ""context"": ""分注：25,28"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00099"",
          ""context"": ""Split：25,28"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00099"",
          ""context"": ""分注：25,28"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00100"",
          ""context"": ""分注：26,29"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00100"",
          ""context"": ""分注：26,29"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00100"",
          ""context"": ""分注：26,29"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00100"",
          ""context"": ""分注：26,29"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00100"",
          ""context"": ""分注：26,29"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00100"",
          ""context"": ""分注：26,29"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00100"",
          ""context"": ""分注：26,29"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00101"",
          ""context"": ""分注：27,30"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00101"",
          ""context"": ""分注：27,30"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00101"",
          ""context"": ""分注：27,30"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00101"",
          ""context"": ""分注：27,30"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00101"",
          ""context"": ""分注：27,30"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00101"",
          ""context"": ""Split：27,30"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00101"",
          ""context"": ""分注：27,30"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00102"",
          ""context"": ""分注：28,31"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00102"",
          ""context"": ""分注：28,31"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00102"",
          ""context"": ""分注：28,31"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00102"",
          ""context"": ""分注：28,31"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00102"",
          ""context"": ""Split：28,31"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00102"",
          ""context"": ""分注：28,31"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00102"",
          ""context"": ""分注：28,31"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00103"",
          ""context"": ""分注：29,32"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00103"",
          ""context"": ""分注：29,32"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00103"",
          ""context"": ""分注：29,32"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00103"",
          ""context"": ""分注：29,32"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00103"",
          ""context"": ""分注：29,32"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00103"",
          ""context"": ""Split：29,32"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00103"",
          ""context"": ""分注：29,32"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00104"",
          ""context"": ""分注：30,33"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00104"",
          ""context"": ""分注：30,33"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00104"",
          ""context"": ""分注：30,33"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00104"",
          ""context"": ""Split：30,33"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00104"",
          ""context"": ""分注：30,33"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00104"",
          ""context"": ""分注：30,33"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00104"",
          ""context"": ""分注：30,33"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00105"",
          ""context"": ""分注：31,34"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00105"",
          ""context"": ""Split：31,34"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00105"",
          ""context"": ""分注：31,34"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00105"",
          ""context"": ""分注：31,34"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00105"",
          ""context"": ""分注：31,34"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00105"",
          ""context"": ""分注：31,34"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00105"",
          ""context"": ""分注：31,34"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00106"",
          ""context"": ""分注：32,35"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00106"",
          ""context"": ""分注：32,35"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00106"",
          ""context"": ""分注：32,35"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00106"",
          ""context"": ""分注：32,35"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00106"",
          ""context"": ""分注：32,35"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00106"",
          ""context"": ""Split：32,35"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00106"",
          ""context"": ""分注：32,35"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00107"",
          ""context"": ""分注：33,36"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00107"",
          ""context"": ""分注：33,36"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00107"",
          ""context"": ""分注：33,36"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00107"",
          ""context"": ""分注：33,36"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00107"",
          ""context"": ""分注：33,36"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00107"",
          ""context"": ""Split：33,36"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00107"",
          ""context"": ""分注：33,36"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00108"",
          ""context"": ""街注：1,2,3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00108"",
          ""context"": ""街注：1,2,3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00108"",
          ""context"": ""街注：1,2,3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00108"",
          ""context"": ""街注：1,2,3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00108"",
          ""context"": ""街注：1,2,3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00108"",
          ""context"": ""Street：1,2,3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00108"",
          ""context"": ""街注：1,2,3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00109"",
          ""context"": ""街注：4,5,6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00109"",
          ""context"": ""Street：4,5,6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00109"",
          ""context"": ""街注：4,5,6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00109"",
          ""context"": ""街注：4,5,6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00109"",
          ""context"": ""街注：4,5,6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00109"",
          ""context"": ""街注：4,5,6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00109"",
          ""context"": ""街注：4,5,6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00110"",
          ""context"": ""街注：7,8,9"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00110"",
          ""context"": ""街注：7,8,9"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00110"",
          ""context"": ""街注：7,8,9"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00110"",
          ""context"": ""街注：7,8,9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00110"",
          ""context"": ""街注：7,8,9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00110"",
          ""context"": ""Street：7,8,9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00110"",
          ""context"": ""街注：7,8,9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00111"",
          ""context"": ""街注：10,11,12"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00111"",
          ""context"": ""街注：10,11,12"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00111"",
          ""context"": ""街注：10,11,12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00111"",
          ""context"": ""街注：10,11,12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00111"",
          ""context"": ""Street：10,11,12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00111"",
          ""context"": ""街注：10,11,12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00111"",
          ""context"": ""街注：10,11,12"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00112"",
          ""context"": ""街注：13,14,15"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00112"",
          ""context"": ""街注：13,14,15"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00112"",
          ""context"": ""街注：13,14,15"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00112"",
          ""context"": ""街注：13,14,15"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00112"",
          ""context"": ""街注：13,14,15"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00112"",
          ""context"": ""Street：13,14,15"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00112"",
          ""context"": ""街注：13,14,15"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00113"",
          ""context"": ""街注：16,17,18"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00113"",
          ""context"": ""街注：16,17,18"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00113"",
          ""context"": ""街注：16,17,18"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00113"",
          ""context"": ""街注：16,17,18"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00113"",
          ""context"": ""街注：16,17,18"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00113"",
          ""context"": ""Street：16,17,18"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00113"",
          ""context"": ""街注：16,17,18"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00114"",
          ""context"": ""街注：19,20,21"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00114"",
          ""context"": ""Street：19,20,21"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00114"",
          ""context"": ""街注：19,20,21"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00114"",
          ""context"": ""街注：19,20,21"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00114"",
          ""context"": ""街注：19,20,21"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00114"",
          ""context"": ""街注：19,20,21"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00114"",
          ""context"": ""街注：19,20,21"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00115"",
          ""context"": ""街注：22,23,24"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00115"",
          ""context"": ""街注：22,23,24"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00115"",
          ""context"": ""街注：22,23,24"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00115"",
          ""context"": ""街注：22,23,24"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00115"",
          ""context"": ""街注：22,23,24"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00115"",
          ""context"": ""Street：22,23,24"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00115"",
          ""context"": ""街注：22,23,24"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00116"",
          ""context"": ""街注：25,26,27"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00116"",
          ""context"": ""街注：25,26,27"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00116"",
          ""context"": ""街注：25,26,27"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00116"",
          ""context"": ""街注：25,26,27"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00116"",
          ""context"": ""街注：25,26,27"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00116"",
          ""context"": ""Street：25,26,27"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00116"",
          ""context"": ""街注：25,26,27"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00117"",
          ""context"": ""街注：28,29,30"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00117"",
          ""context"": ""街注：28,29,30"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00117"",
          ""context"": ""街注：28,29,30"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00117"",
          ""context"": ""街注：28,29,30"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00117"",
          ""context"": ""街注：28,29,30"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00117"",
          ""context"": ""Street：28,29,30"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00117"",
          ""context"": ""街注：28,29,30"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00118"",
          ""context"": ""街注：31,32,33"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00118"",
          ""context"": ""街注：31,32,33"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00118"",
          ""context"": ""街注：31,32,33"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00118"",
          ""context"": ""街注：31,32,33"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00118"",
          ""context"": ""Street：31,32,33"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00118"",
          ""context"": ""街注：31,32,33"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00118"",
          ""context"": ""街注：31,32,33"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00119"",
          ""context"": ""街注：34,35,36"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00119"",
          ""context"": ""街注：34,35,36"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00119"",
          ""context"": ""街注：34,35,36"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00119"",
          ""context"": ""街注：34,35,36"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00119"",
          ""context"": ""街注：34,35,36"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00119"",
          ""context"": ""街注：34,35,36"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00119"",
          ""context"": ""街注：34,35,36"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00120"",
          ""context"": ""角注：1,2,4,5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00120"",
          ""context"": ""角注：1,2,4,5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00120"",
          ""context"": ""角注：1,2,4,5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00120"",
          ""context"": ""角注：1,2,4,5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00120"",
          ""context"": ""角注：1,2,4,5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00120"",
          ""context"": ""角注：1,2,4,5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00120"",
          ""context"": ""角注：1,2,4,5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00121"",
          ""context"": ""角注：2,3,5,6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00121"",
          ""context"": ""角注：2,3,5,6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00121"",
          ""context"": ""角注：2,3,5,6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00121"",
          ""context"": ""角注：2,3,5,6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00121"",
          ""context"": ""角注：2,3,5,6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00121"",
          ""context"": ""角注：2,3,5,6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00121"",
          ""context"": ""角注：2,3,5,6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00122"",
          ""context"": ""角注：4,5,7,8"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00122"",
          ""context"": ""角注：4,5,7,8"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00122"",
          ""context"": ""角注：4,5,7,8"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00122"",
          ""context"": ""角注：4,5,7,8"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00122"",
          ""context"": ""角注：4,5,7,8"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00122"",
          ""context"": ""角注：4,5,7,8"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00122"",
          ""context"": ""角注：4,5,7,8"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00123"",
          ""context"": ""角注：5,6,8,9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00123"",
          ""context"": ""角注：5,6,8,9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00123"",
          ""context"": ""角注：5,6,8,9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00123"",
          ""context"": ""角注：5,6,8,9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00123"",
          ""context"": ""角注：5,6,8,9"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00123"",
          ""context"": ""角注：5,6,8,9"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00123"",
          ""context"": ""角注：5,6,8,9"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00124"",
          ""context"": ""角注：7,8,10,11"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00124"",
          ""context"": ""角注：7,8,10,11"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00124"",
          ""context"": ""角注：7,8,10,11"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00124"",
          ""context"": ""角注：7,8,10,11"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00124"",
          ""context"": ""角注：7,8,10,11"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00124"",
          ""context"": ""角注：7,8,10,11"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00124"",
          ""context"": ""角注：7,8,10,11"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00125"",
          ""context"": ""角注：8,9,11,12"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00125"",
          ""context"": ""角注：8,9,11,12"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00125"",
          ""context"": ""角注：8,9,11,12"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00125"",
          ""context"": ""角注：8,9,11,12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00125"",
          ""context"": ""角注：8,9,11,12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00125"",
          ""context"": ""角注：8,9,11,12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00125"",
          ""context"": ""角注：8,9,11,12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00126"",
          ""context"": ""角注：10,11,13,14"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00126"",
          ""context"": ""角注：10,11,13,14"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00126"",
          ""context"": ""角注：10,11,13,14"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00126"",
          ""context"": ""角注：10,11,13,14"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00126"",
          ""context"": ""角注：10,11,13,14"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00126"",
          ""context"": ""角注：10,11,13,14"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00126"",
          ""context"": ""角注：10,11,13,14"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00127"",
          ""context"": ""角注：11,12,14,15"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00127"",
          ""context"": ""角注：11,12,14,15"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00127"",
          ""context"": ""角注：11,12,14,15"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00127"",
          ""context"": ""角注：11,12,14,15"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00127"",
          ""context"": ""角注：11,12,14,15"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00127"",
          ""context"": ""角注：11,12,14,15"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00127"",
          ""context"": ""角注：11,12,14,15"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00128"",
          ""context"": ""角注：13,14,16,17"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00128"",
          ""context"": ""角注：13,14,16,17"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00128"",
          ""context"": ""角注：13,14,16,17"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00128"",
          ""context"": ""角注：13,14,16,17"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00128"",
          ""context"": ""角注：13,14,16,17"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00128"",
          ""context"": ""角注：13,14,16,17"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00128"",
          ""context"": ""角注：13,14,16,17"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00129"",
          ""context"": ""角注：14,15,17,18"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00129"",
          ""context"": ""角注：14,15,17,18"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00129"",
          ""context"": ""角注：14,15,17,18"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00129"",
          ""context"": ""角注：14,15,17,18"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00129"",
          ""context"": ""角注：14,15,17,18"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00129"",
          ""context"": ""角注：14,15,17,18"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00129"",
          ""context"": ""角注：14,15,17,18"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00130"",
          ""context"": ""角注：16,17,19,20"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00130"",
          ""context"": ""角注：16,17,19,20"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00130"",
          ""context"": ""角注：16,17,19,20"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00130"",
          ""context"": ""角注：16,17,19,20"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00130"",
          ""context"": ""角注：16,17,19,20"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00130"",
          ""context"": ""角注：16,17,19,20"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00130"",
          ""context"": ""角注：16,17,19,20"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00131"",
          ""context"": ""角注：17,18,20,21"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00131"",
          ""context"": ""角注：17,18,20,21"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00131"",
          ""context"": ""角注：17,18,20,21"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00131"",
          ""context"": ""角注：17,18,20,21"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00131"",
          ""context"": ""角注：17,18,20,21"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00131"",
          ""context"": ""角注：17,18,20,21"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00131"",
          ""context"": ""角注：17,18,20,21"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00132"",
          ""context"": ""角注：19,20,22,23"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00132"",
          ""context"": ""角注：19,20,22,23"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00132"",
          ""context"": ""角注：19,20,22,23"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00132"",
          ""context"": ""角注：19,20,22,23"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00132"",
          ""context"": ""角注：19,20,22,23"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00132"",
          ""context"": ""角注：19,20,22,23"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00132"",
          ""context"": ""角注：19,20,22,23"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00133"",
          ""context"": ""角注：20,21,23,24"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00133"",
          ""context"": ""角注：20,21,23,24"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00133"",
          ""context"": ""角注：20,21,23,24"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00133"",
          ""context"": ""角注：20,21,23,24"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00133"",
          ""context"": ""角注：20,21,23,24"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00133"",
          ""context"": ""角注：20,21,23,24"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00133"",
          ""context"": ""角注：20,21,23,24"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00134"",
          ""context"": ""角注：22,23,25,26"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00134"",
          ""context"": ""角注：22,23,25,26"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00134"",
          ""context"": ""角注：22,23,25,26"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00134"",
          ""context"": ""角注：22,23,25,26"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00134"",
          ""context"": ""角注：22,23,25,26"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00134"",
          ""context"": ""角注：22,23,25,26"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00134"",
          ""context"": ""角注：22,23,25,26"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00135"",
          ""context"": ""角注：23,24,26,27"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00135"",
          ""context"": ""角注：23,24,26,27"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00135"",
          ""context"": ""角注：23,24,26,27"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00135"",
          ""context"": ""角注：23,24,26,27"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00135"",
          ""context"": ""角注：23,24,26,27"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00135"",
          ""context"": ""角注：23,24,26,27"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00135"",
          ""context"": ""角注：23,24,26,27"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00136"",
          ""context"": ""角注：25,26,28,29"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00136"",
          ""context"": ""角注：25,26,28,29"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00136"",
          ""context"": ""角注：25,26,28,29"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00136"",
          ""context"": ""角注：25,26,28,29"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00136"",
          ""context"": ""角注：25,26,28,29"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00136"",
          ""context"": ""角注：25,26,28,29"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00136"",
          ""context"": ""角注：25,26,28,29"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00137"",
          ""context"": ""角注：26,27,29,30"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00137"",
          ""context"": ""角注：26,27,29,30"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00137"",
          ""context"": ""角注：26,27,29,30"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00137"",
          ""context"": ""角注：26,27,29,30"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00137"",
          ""context"": ""角注：26,27,29,30"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00137"",
          ""context"": ""角注：26,27,29,30"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00137"",
          ""context"": ""角注：26,27,29,30"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00138"",
          ""context"": ""角注：28,29,31,32"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00138"",
          ""context"": ""角注：28,29,31,32"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00138"",
          ""context"": ""角注：28,29,31,32"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00138"",
          ""context"": ""角注：28,29,31,32"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00138"",
          ""context"": ""角注：28,29,31,32"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00138"",
          ""context"": ""角注：28,29,31,32"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00138"",
          ""context"": ""角注：28,29,31,32"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00139"",
          ""context"": ""角注：29,30,32,33"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00139"",
          ""context"": ""角注：29,30,32,33"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00139"",
          ""context"": ""角注：29,30,32,33"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00139"",
          ""context"": ""角注：29,30,32,33"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00139"",
          ""context"": ""角注：29,30,32,33"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00139"",
          ""context"": ""角注：29,30,32,33"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00139"",
          ""context"": ""角注：29,30,32,33"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00140"",
          ""context"": ""角注：31,32,34,35"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00140"",
          ""context"": ""角注：31,32,34,35"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00140"",
          ""context"": ""角注：31,32,34,35"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00140"",
          ""context"": ""角注：31,32,34,35"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00140"",
          ""context"": ""角注：31,32,34,35"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00140"",
          ""context"": ""角注：31,32,34,35"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00140"",
          ""context"": ""角注：31,32,34,35"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00141"",
          ""context"": ""角注：32,33,35,36"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00141"",
          ""context"": ""角注：32,33,35,36"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00141"",
          ""context"": ""角注：32,33,35,36"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00141"",
          ""context"": ""角注：32,33,35,36"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00141"",
          ""context"": ""角注：32,33,35,36"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00141"",
          ""context"": ""角注：32,33,35,36"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00141"",
          ""context"": ""角注：32,33,35,36"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00142"",
          ""context"": ""線注：1,2,3,4,5,6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00142"",
          ""context"": ""線注：1,2,3,4,5,6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00142"",
          ""context"": ""線注：1,2,3,4,5,6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00142"",
          ""context"": ""線注：1,2,3,4,5,6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00142"",
          ""context"": ""線注：1,2,3,4,5,6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00142"",
          ""context"": ""線注：1,2,3,4,5,6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00142"",
          ""context"": ""線注：1,2,3,4,5,6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00143"",
          ""context"": ""線注：4,5,6,7,8,9"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00143"",
          ""context"": ""線注：4,5,6,7,8,9"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00143"",
          ""context"": ""線注：4,5,6,7,8,9"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00143"",
          ""context"": ""線注：4,5,6,7,8,9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00143"",
          ""context"": ""線注：4,5,6,7,8,9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00143"",
          ""context"": ""線注：4,5,6,7,8,9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00143"",
          ""context"": ""線注：4,5,6,7,8,9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00144"",
          ""context"": ""線注：7,8,9,10,11,12"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00144"",
          ""context"": ""線注：7,8,9,10,11,12"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00144"",
          ""context"": ""線注：7,8,9,10,11,12"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00144"",
          ""context"": ""線注：7,8,9,10,11,12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00144"",
          ""context"": ""線注：7,8,9,10,11,12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00144"",
          ""context"": ""線注：7,8,9,10,11,12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00144"",
          ""context"": ""線注：7,8,9,10,11,12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00145"",
          ""context"": ""線注：10,11,12,13,14,15"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00145"",
          ""context"": ""線注：10,11,12,13,14,15"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00145"",
          ""context"": ""線注：10,11,12,13,14,15"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00145"",
          ""context"": ""線注：10,11,12,13,14,15"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00145"",
          ""context"": ""線注：10,11,12,13,14,15"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00145"",
          ""context"": ""線注：10,11,12,13,14,15"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00145"",
          ""context"": ""線注：10,11,12,13,14,15"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00146"",
          ""context"": ""線注：13,14,15,16,17,18"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00146"",
          ""context"": ""線注：13,14,15,16,17,18"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00146"",
          ""context"": ""線注：13,14,15,16,17,18"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00146"",
          ""context"": ""線注：13,14,15,16,17,18"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00146"",
          ""context"": ""線注：13,14,15,16,17,18"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00146"",
          ""context"": ""線注：13,14,15,16,17,18"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00146"",
          ""context"": ""線注：13,14,15,16,17,18"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00147"",
          ""context"": ""線注：16,17,18,19,20,21"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00147"",
          ""context"": ""線注：16,17,18,19,20,21"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00147"",
          ""context"": ""線注：16,17,18,19,20,21"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00147"",
          ""context"": ""線注：16,17,18,19,20,21"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00147"",
          ""context"": ""線注：16,17,18,19,20,21"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00147"",
          ""context"": ""線注：16,17,18,19,20,21"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00147"",
          ""context"": ""線注：16,17,18,19,20,21"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00148"",
          ""context"": ""線注：19,20,21,22,23,24"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00148"",
          ""context"": ""線注：19,20,21,22,23,24"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00148"",
          ""context"": ""線注：19,20,21,22,23,24"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00148"",
          ""context"": ""線注：19,20,21,22,23,24"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00148"",
          ""context"": ""線注：19,20,21,22,23,24"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00148"",
          ""context"": ""線注：19,20,21,22,23,24"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00148"",
          ""context"": ""線注：19,20,21,22,23,24"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00149"",
          ""context"": ""線注：22,23,24,25,26,27"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00149"",
          ""context"": ""線注：22,23,24,25,26,27"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00149"",
          ""context"": ""線注：22,23,24,25,26,27"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00149"",
          ""context"": ""線注：22,23,24,25,26,27"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00149"",
          ""context"": ""線注：22,23,24,25,26,27"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00149"",
          ""context"": ""線注：22,23,24,25,26,27"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00149"",
          ""context"": ""線注：22,23,24,25,26,27"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00150"",
          ""context"": ""線注：25,26,27,28,29,30"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00150"",
          ""context"": ""線注：25,26,27,28,29,30"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00150"",
          ""context"": ""線注：25,26,27,28,29,30"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00150"",
          ""context"": ""線注：25,26,27,28,29,30"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00150"",
          ""context"": ""線注：25,26,27,28,29,30"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00150"",
          ""context"": ""線注：25,26,27,28,29,30"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00150"",
          ""context"": ""線注：25,26,27,28,29,30"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00151"",
          ""context"": ""線注：28,29,30,31,32,33"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00151"",
          ""context"": ""線注：28,29,30,31,32,33"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00151"",
          ""context"": ""線注：28,29,30,31,32,33"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00151"",
          ""context"": ""線注：28,29,30,31,32,33"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00151"",
          ""context"": ""線注：28,29,30,31,32,33"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00151"",
          ""context"": ""線注：28,29,30,31,32,33"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00151"",
          ""context"": ""線注：28,29,30,31,32,33"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00152"",
          ""context"": ""線注：31,32,33,34,35,36"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00152"",
          ""context"": ""線注：31,32,33,34,35,36"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00152"",
          ""context"": ""線注：31,32,33,34,35,36"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00152"",
          ""context"": ""線注：31,32,33,34,35,36"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00152"",
          ""context"": ""線注：31,32,33,34,35,36"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00152"",
          ""context"": ""線注：31,32,33,34,35,36"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00152"",
          ""context"": ""線注：31,32,33,34,35,36"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00153"",
          ""context"": ""數位1-12"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00153"",
          ""context"": ""數位1-12"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00153"",
          ""context"": ""數位1-12"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00153"",
          ""context"": ""數位1-12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00153"",
          ""context"": ""數位1-12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00153"",
          ""context"": ""數位1-12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00153"",
          ""context"": ""數位1-12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00154"",
          ""context"": ""數位13-24"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00154"",
          ""context"": ""數位13-24"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00154"",
          ""context"": ""數位13-24"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00154"",
          ""context"": ""數位13-24"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00154"",
          ""context"": ""數位13-24"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00154"",
          ""context"": ""數位13-24"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00154"",
          ""context"": ""數位13-24"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00155"",
          ""context"": ""數位25-36"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00155"",
          ""context"": ""數位25-36"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00155"",
          ""context"": ""數位25-36"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00155"",
          ""context"": ""數位25-36"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00155"",
          ""context"": ""數位25-36"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00155"",
          ""context"": ""數位25-36"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00155"",
          ""context"": ""數位25-36"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00156"",
          ""context"": ""列注一"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00156"",
          ""context"": ""列注一"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00156"",
          ""context"": ""列注一"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00156"",
          ""context"": ""列注一"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00156"",
          ""context"": ""列注一"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00156"",
          ""context"": ""列注一"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00156"",
          ""context"": ""列注一"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00157"",
          ""context"": ""列注二"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00157"",
          ""context"": ""列注二"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00157"",
          ""context"": ""列注二"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00157"",
          ""context"": ""列注二"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00157"",
          ""context"": ""列注二"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00157"",
          ""context"": ""列注二"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00157"",
          ""context"": ""列注二"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00158"",
          ""context"": ""列注三"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00158"",
          ""context"": ""列注三"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00158"",
          ""context"": ""列注三"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00158"",
          ""context"": ""列注三"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00158"",
          ""context"": ""列注三"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00158"",
          ""context"": ""列注三"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00158"",
          ""context"": ""列注三"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00159"",
          ""context"": ""小"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00159"",
          ""context"": ""小"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00159"",
          ""context"": ""小"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00159"",
          ""context"": ""小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00159"",
          ""context"": ""小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00159"",
          ""context"": ""小"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00159"",
          ""context"": ""小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00160"",
          ""context"": ""大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00160"",
          ""context"": ""大"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00160"",
          ""context"": ""大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00160"",
          ""context"": ""大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00160"",
          ""context"": ""大"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00160"",
          ""context"": ""大"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00160"",
          ""context"": ""大"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00161"",
          ""context"": ""單"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00161"",
          ""context"": ""單"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00161"",
          ""context"": ""單"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00161"",
          ""context"": ""單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00161"",
          ""context"": ""單"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00161"",
          ""context"": ""單"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00161"",
          ""context"": ""單"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00162"",
          ""context"": ""雙"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00162"",
          ""context"": ""雙"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00162"",
          ""context"": ""雙"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00162"",
          ""context"": ""雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00162"",
          ""context"": ""雙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00162"",
          ""context"": ""雙"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00162"",
          ""context"": ""雙"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00163"",
          ""context"": ""紅"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00163"",
          ""context"": ""紅"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00163"",
          ""context"": ""紅"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00163"",
          ""context"": ""紅"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00163"",
          ""context"": ""紅"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00163"",
          ""context"": ""紅"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00163"",
          ""context"": ""紅"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00164"",
          ""context"": ""黑"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00164"",
          ""context"": ""黑"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00164"",
          ""context"": ""黑"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00164"",
          ""context"": ""黑"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00164"",
          ""context"": ""黑"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00164"",
          ""context"": ""黑"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 3,
          ""gameName"": ""LunPan"",
          ""betArea"": ""00164"",
          ""context"": ""黑"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00001"",
          ""context"": ""單骰：1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00001"",
          ""context"": ""單骰：1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00001"",
          ""context"": ""單骰：1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00001"",
          ""context"": ""單骰：1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00001"",
          ""context"": ""單骰：1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00001"",
          ""context"": ""Odd-numbered Tai-Sais：1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00001"",
          ""context"": ""單骰：1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00002"",
          ""context"": ""單骰：2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00002"",
          ""context"": ""單骰：2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00002"",
          ""context"": ""單骰：2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00002"",
          ""context"": ""單骰：2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00002"",
          ""context"": ""單骰：2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00002"",
          ""context"": ""Odd-numbered Tai-Sais：2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00002"",
          ""context"": ""單骰：2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00003"",
          ""context"": ""單骰：3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00003"",
          ""context"": ""單骰：3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00003"",
          ""context"": ""單骰：3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00003"",
          ""context"": ""單骰：3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00003"",
          ""context"": ""單骰：3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00003"",
          ""context"": ""Odd-numbered Tai-Sais：3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00003"",
          ""context"": ""單骰：3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00004"",
          ""context"": ""單骰：4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00004"",
          ""context"": ""單骰：4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00004"",
          ""context"": ""單骰：4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00004"",
          ""context"": ""單骰：4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00004"",
          ""context"": ""Odd-numbered Tai-Sais：4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00004"",
          ""context"": ""單骰：4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00004"",
          ""context"": ""單骰：4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00005"",
          ""context"": ""單骰：5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00005"",
          ""context"": ""單骰：5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00005"",
          ""context"": ""單骰：5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00005"",
          ""context"": ""單骰：5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00005"",
          ""context"": ""單骰：5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00005"",
          ""context"": ""單骰：5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00005"",
          ""context"": ""Odd-numbered Tai-Sais：5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00006"",
          ""context"": ""單骰：6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00006"",
          ""context"": ""單骰：6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00006"",
          ""context"": ""單骰：6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00006"",
          ""context"": ""單骰：6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00006"",
          ""context"": ""Odd-numbered Tai-Sais：6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00006"",
          ""context"": ""單骰：6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00006"",
          ""context"": ""單骰：6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00007"",
          ""context"": ""對子：1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00007"",
          ""context"": ""對子：1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00007"",
          ""context"": ""對子：1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00007"",
          ""context"": ""對子：1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00007"",
          ""context"": ""對子：1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00007"",
          ""context"": ""pair ：1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00007"",
          ""context"": ""對子：1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00008"",
          ""context"": ""牌九：1, 2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00008"",
          ""context"": ""Pai Gow：1, 2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00008"",
          ""context"": ""牌九：1, 2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00008"",
          ""context"": ""牌九：1, 2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00008"",
          ""context"": ""牌九：1, 2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00008"",
          ""context"": ""牌九：1, 2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00008"",
          ""context"": ""牌九：1, 2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00009"",
          ""context"": ""牌九：1, 3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00009"",
          ""context"": ""牌九：1, 3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00009"",
          ""context"": ""牌九：1, 3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00009"",
          ""context"": ""牌九：1, 3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00009"",
          ""context"": ""牌九：1, 3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00009"",
          ""context"": ""Pai Gow：1, 3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00009"",
          ""context"": ""牌九：1, 3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00010"",
          ""context"": ""牌九：1, 4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00010"",
          ""context"": ""牌九：1, 4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00010"",
          ""context"": ""牌九：1, 4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00010"",
          ""context"": ""牌九：1, 4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00010"",
          ""context"": ""牌九：1, 4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00010"",
          ""context"": ""Pai Gow：1, 4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00010"",
          ""context"": ""牌九：1, 4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00011"",
          ""context"": ""牌九：1, 5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00011"",
          ""context"": ""牌九：1, 5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00011"",
          ""context"": ""牌九：1, 5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00011"",
          ""context"": ""牌九：1, 5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00011"",
          ""context"": ""牌九：1, 5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00011"",
          ""context"": ""Pai Gow：1, 5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00011"",
          ""context"": ""牌九：1, 5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00012"",
          ""context"": ""牌九：1, 6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00012"",
          ""context"": ""Pai Gow：1, 6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00012"",
          ""context"": ""牌九：1, 6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00012"",
          ""context"": ""牌九：1, 6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00012"",
          ""context"": ""牌九：1, 6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00012"",
          ""context"": ""牌九：1, 6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00012"",
          ""context"": ""牌九：1, 6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00013"",
          ""context"": ""對子：2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00013"",
          ""context"": ""對子：2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00013"",
          ""context"": ""對子：2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00013"",
          ""context"": ""對子：2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00013"",
          ""context"": ""對子：2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00013"",
          ""context"": ""pair ：2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00013"",
          ""context"": ""對子：2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00014"",
          ""context"": ""牌九：2, 3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00014"",
          ""context"": ""牌九：2, 3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00014"",
          ""context"": ""牌九：2, 3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00014"",
          ""context"": ""牌九：2, 3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00014"",
          ""context"": ""牌九：2, 3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00014"",
          ""context"": ""Pai Gow：2, 3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00014"",
          ""context"": ""牌九：2, 3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00015"",
          ""context"": ""牌九：2, 4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00015"",
          ""context"": ""牌九：2, 4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00015"",
          ""context"": ""牌九：2, 4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00015"",
          ""context"": ""牌九：2, 4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00015"",
          ""context"": ""牌九：2, 4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00015"",
          ""context"": ""Pai Gow：2, 4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00015"",
          ""context"": ""牌九：2, 4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00016"",
          ""context"": ""牌九：2, 5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00016"",
          ""context"": ""牌九：2, 5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00016"",
          ""context"": ""牌九：2, 5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00016"",
          ""context"": ""牌九：2, 5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00016"",
          ""context"": ""牌九：2, 5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00016"",
          ""context"": ""Pai Gow：2, 5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00016"",
          ""context"": ""牌九：2, 5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00017"",
          ""context"": ""牌九：2, 6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00017"",
          ""context"": ""牌九：2, 6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00017"",
          ""context"": ""牌九：2, 6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00017"",
          ""context"": ""牌九：2, 6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00017"",
          ""context"": ""牌九：2, 6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00017"",
          ""context"": ""Pai Gow：2, 6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00017"",
          ""context"": ""牌九：2, 6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00018"",
          ""context"": ""對子：3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00018"",
          ""context"": ""對子：3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00018"",
          ""context"": ""對子：3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00018"",
          ""context"": ""對子：3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00018"",
          ""context"": ""對子：3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00018"",
          ""context"": ""pair ：3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00018"",
          ""context"": ""對子：3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00019"",
          ""context"": ""Pai Gow：3, 4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00019"",
          ""context"": ""牌九：3, 4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00019"",
          ""context"": ""牌九：3, 4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00019"",
          ""context"": ""牌九：3, 4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00019"",
          ""context"": ""牌九：3, 4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00019"",
          ""context"": ""牌九：3, 4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00019"",
          ""context"": ""牌九：3, 4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00020"",
          ""context"": ""牌九：3, 5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00020"",
          ""context"": ""牌九：3, 5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00020"",
          ""context"": ""牌九：3, 5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00020"",
          ""context"": ""牌九：3, 5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00020"",
          ""context"": ""牌九：3, 5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00020"",
          ""context"": ""Pai Gow：3, 5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00020"",
          ""context"": ""牌九：3, 5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00021"",
          ""context"": ""牌九：3, 6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00021"",
          ""context"": ""牌九：3, 6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00021"",
          ""context"": ""牌九：3, 6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00021"",
          ""context"": ""牌九：3, 6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00021"",
          ""context"": ""牌九：3, 6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00021"",
          ""context"": ""Pai Gow：3, 6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00021"",
          ""context"": ""牌九：3, 6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00022"",
          ""context"": ""對子：4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00022"",
          ""context"": ""對子：4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00022"",
          ""context"": ""對子：4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00022"",
          ""context"": ""對子：4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00022"",
          ""context"": ""pair ：4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00022"",
          ""context"": ""對子：4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00022"",
          ""context"": ""對子：4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00023"",
          ""context"": ""牌九：4, 5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00023"",
          ""context"": ""牌九：4, 5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00023"",
          ""context"": ""Pai Gow：4, 5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00023"",
          ""context"": ""牌九：4, 5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00023"",
          ""context"": ""牌九：4, 5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00023"",
          ""context"": ""牌九：4, 5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00023"",
          ""context"": ""牌九：4, 5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00024"",
          ""context"": ""牌九：4, 6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00024"",
          ""context"": ""牌九：4, 6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00024"",
          ""context"": ""牌九：4, 6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00024"",
          ""context"": ""牌九：4, 6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00024"",
          ""context"": ""牌九：4, 6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00024"",
          ""context"": ""Pai Gow：4, 6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00024"",
          ""context"": ""牌九：4, 6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00025"",
          ""context"": ""對子：5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00025"",
          ""context"": ""對子：5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00025"",
          ""context"": ""對子：5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00025"",
          ""context"": ""對子：5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00025"",
          ""context"": ""對子：5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00025"",
          ""context"": ""pair ：5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00025"",
          ""context"": ""對子：5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00026"",
          ""context"": ""Pai Gow：5, 6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00026"",
          ""context"": ""牌九：5, 6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00026"",
          ""context"": ""牌九：5, 6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00026"",
          ""context"": ""牌九：5, 6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00026"",
          ""context"": ""牌九：5, 6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00026"",
          ""context"": ""牌九：5, 6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00026"",
          ""context"": ""牌九：5, 6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00027"",
          ""context"": ""對子：6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00027"",
          ""context"": ""對子：6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00027"",
          ""context"": ""對子：6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00027"",
          ""context"": ""對子：6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00027"",
          ""context"": ""對子：6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00027"",
          ""context"": ""對子：6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00027"",
          ""context"": ""對子：6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00028"",
          ""context"": ""總數：4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00028"",
          ""context"": ""總數：4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00028"",
          ""context"": ""總數：4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00028"",
          ""context"": ""總數：4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00028"",
          ""context"": ""總數：4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00028"",
          ""context"": ""總數：4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00028"",
          ""context"": ""總數：4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00029"",
          ""context"": ""總數：5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00029"",
          ""context"": ""總數：5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00029"",
          ""context"": ""總數：5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00029"",
          ""context"": ""總數：5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00029"",
          ""context"": ""總數：5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00029"",
          ""context"": ""總數：5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00029"",
          ""context"": ""總數：5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00030"",
          ""context"": ""總數：6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00030"",
          ""context"": ""總數：6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00030"",
          ""context"": ""總數：6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00030"",
          ""context"": ""總數：6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00030"",
          ""context"": ""總數：6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00030"",
          ""context"": ""總數：6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00030"",
          ""context"": ""總數：6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00031"",
          ""context"": ""總數：7"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00031"",
          ""context"": ""總數：7"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00031"",
          ""context"": ""總數：7"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00031"",
          ""context"": ""總數：7"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00031"",
          ""context"": ""總數：7"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00031"",
          ""context"": ""總數：7"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00031"",
          ""context"": ""總數：7"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00032"",
          ""context"": ""總數：8"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00032"",
          ""context"": ""總數：8"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00032"",
          ""context"": ""總數：8"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00032"",
          ""context"": ""總數：8"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00032"",
          ""context"": ""總數：8"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00032"",
          ""context"": ""總數：8"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00032"",
          ""context"": ""總數：8"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00033"",
          ""context"": ""總數：9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00033"",
          ""context"": ""總數：9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00033"",
          ""context"": ""總數：9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00033"",
          ""context"": ""總數：9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00033"",
          ""context"": ""總數：9"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00033"",
          ""context"": ""總數：9"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00033"",
          ""context"": ""總數：9"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00034"",
          ""context"": ""總數：10"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00034"",
          ""context"": ""總數：10"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00034"",
          ""context"": ""總數：10"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00034"",
          ""context"": ""總數：10"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00034"",
          ""context"": ""總數：10"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00034"",
          ""context"": ""總數：10"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00034"",
          ""context"": ""總數：10"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00035"",
          ""context"": ""總數：11"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00035"",
          ""context"": ""總數：11"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00035"",
          ""context"": ""總數：11"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00035"",
          ""context"": ""總數：11"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00035"",
          ""context"": ""總數：11"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00035"",
          ""context"": ""總數：11"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00035"",
          ""context"": ""總數：11"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00036"",
          ""context"": ""總數：12"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00036"",
          ""context"": ""總數：12"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00036"",
          ""context"": ""總數：12"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00036"",
          ""context"": ""總數：12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00036"",
          ""context"": ""總數：12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00036"",
          ""context"": ""總數：12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00036"",
          ""context"": ""總數：12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00037"",
          ""context"": ""總數：13"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00037"",
          ""context"": ""總數：13"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00037"",
          ""context"": ""總數：13"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00037"",
          ""context"": ""總數：13"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00037"",
          ""context"": ""總數：13"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00037"",
          ""context"": ""總數：13"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00037"",
          ""context"": ""總數：13"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00038"",
          ""context"": ""總數：14"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00038"",
          ""context"": ""總數：14"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00038"",
          ""context"": ""總數：14"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00038"",
          ""context"": ""總數：14"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00038"",
          ""context"": ""總數：14"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00038"",
          ""context"": ""總數：14"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00038"",
          ""context"": ""總數：14"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00039"",
          ""context"": ""總數：15"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00039"",
          ""context"": ""總數：15"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00039"",
          ""context"": ""總數：15"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00039"",
          ""context"": ""總數：15"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00039"",
          ""context"": ""總數：15"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00039"",
          ""context"": ""總數：15"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00039"",
          ""context"": ""總數：15"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00040"",
          ""context"": ""總數：16"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00040"",
          ""context"": ""總數：16"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00040"",
          ""context"": ""總數：16"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00040"",
          ""context"": ""總數：16"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00040"",
          ""context"": ""總數：16"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00040"",
          ""context"": ""總數：16"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00040"",
          ""context"": ""總數：16"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00041"",
          ""context"": ""總數：17"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00041"",
          ""context"": ""總數：17"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00041"",
          ""context"": ""總數：17"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00041"",
          ""context"": ""總數：17"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00041"",
          ""context"": ""總數：17"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00041"",
          ""context"": ""總數：17"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00041"",
          ""context"": ""總數：17"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00042"",
          ""context"": ""圍骰：1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00042"",
          ""context"": ""圍骰：1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00042"",
          ""context"": ""圍骰：1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00042"",
          ""context"": ""圍骰：1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00042"",
          ""context"": ""圍骰：1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00042"",
          ""context"": ""圍骰：1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00042"",
          ""context"": ""圍骰：1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00043"",
          ""context"": ""圍骰：2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00043"",
          ""context"": ""圍骰：2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00043"",
          ""context"": ""圍骰：2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00043"",
          ""context"": ""圍骰：2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00043"",
          ""context"": ""圍骰：2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00043"",
          ""context"": ""圍骰：2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00043"",
          ""context"": ""圍骰：2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00044"",
          ""context"": ""圍骰：3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00044"",
          ""context"": ""圍骰：3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00044"",
          ""context"": ""圍骰：3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00044"",
          ""context"": ""圍骰：3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00044"",
          ""context"": ""圍骰：3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00044"",
          ""context"": ""圍骰：3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00044"",
          ""context"": ""圍骰：3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00045"",
          ""context"": ""圍骰：4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00045"",
          ""context"": ""圍骰：4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00045"",
          ""context"": ""圍骰：4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00045"",
          ""context"": ""圍骰：4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00045"",
          ""context"": ""圍骰：4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00045"",
          ""context"": ""圍骰：4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00045"",
          ""context"": ""圍骰：4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00046"",
          ""context"": ""圍骰：5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00046"",
          ""context"": ""圍骰：5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00046"",
          ""context"": ""圍骰：5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00046"",
          ""context"": ""圍骰：5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00046"",
          ""context"": ""圍骰：5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00046"",
          ""context"": ""圍骰：5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00046"",
          ""context"": ""圍骰：5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00047"",
          ""context"": ""圍骰：6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00047"",
          ""context"": ""圍骰：6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00047"",
          ""context"": ""圍骰：6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00047"",
          ""context"": ""圍骰：6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00047"",
          ""context"": ""圍骰：6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00047"",
          ""context"": ""圍骰：6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00047"",
          ""context"": ""圍骰：6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00048"",
          ""context"": ""小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00048"",
          ""context"": ""小"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00048"",
          ""context"": ""小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00048"",
          ""context"": ""小"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00048"",
          ""context"": ""小"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00048"",
          ""context"": ""小"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00048"",
          ""context"": ""小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00049"",
          ""context"": ""大"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00049"",
          ""context"": ""大"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00049"",
          ""context"": ""大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00049"",
          ""context"": ""大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00049"",
          ""context"": ""大"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00049"",
          ""context"": ""大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00049"",
          ""context"": ""大"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00050"",
          ""context"": ""全圍"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00050"",
          ""context"": ""全圍"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00050"",
          ""context"": ""全圍"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00050"",
          ""context"": ""全圍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00050"",
          ""context"": ""全圍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00050"",
          ""context"": ""全圍"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00050"",
          ""context"": ""全圍"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00051"",
          ""context"": ""單"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00051"",
          ""context"": ""單"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00051"",
          ""context"": ""單"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00051"",
          ""context"": ""單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00051"",
          ""context"": ""單"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00051"",
          ""context"": ""單"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00051"",
          ""context"": ""單"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00052"",
          ""context"": ""雙"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00052"",
          ""context"": ""雙"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00052"",
          ""context"": ""雙"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00052"",
          ""context"": ""雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00052"",
          ""context"": ""雙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00052"",
          ""context"": ""雙"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 4,
          ""gameName"": ""ShaiZi"",
          ""betArea"": ""00052"",
          ""context"": ""雙"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00001"",
          ""context"": ""1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00001"",
          ""context"": ""1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00001"",
          ""context"": ""1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00001"",
          ""context"": ""1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00001"",
          ""context"": ""1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00001"",
          ""context"": ""1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00001"",
          ""context"": ""1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00002"",
          ""context"": ""2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00002"",
          ""context"": ""2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00002"",
          ""context"": ""2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00002"",
          ""context"": ""2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00002"",
          ""context"": ""2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00002"",
          ""context"": ""2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00002"",
          ""context"": ""2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00003"",
          ""context"": ""3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00003"",
          ""context"": ""3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00003"",
          ""context"": ""3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00003"",
          ""context"": ""3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00003"",
          ""context"": ""3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00003"",
          ""context"": ""3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00003"",
          ""context"": ""3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00004"",
          ""context"": ""4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00004"",
          ""context"": ""4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00004"",
          ""context"": ""4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00004"",
          ""context"": ""4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00004"",
          ""context"": ""4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00004"",
          ""context"": ""4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00004"",
          ""context"": ""4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00005"",
          ""context"": ""1-2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00005"",
          ""context"": ""1-2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00005"",
          ""context"": ""1-2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00005"",
          ""context"": ""1-2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00005"",
          ""context"": ""1-2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00005"",
          ""context"": ""1-2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00005"",
          ""context"": ""1-2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00006"",
          ""context"": ""1-3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00006"",
          ""context"": ""1-3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00006"",
          ""context"": ""1-3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00006"",
          ""context"": ""1-3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00006"",
          ""context"": ""1-3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00006"",
          ""context"": ""1-3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00006"",
          ""context"": ""1-3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00007"",
          ""context"": ""1-4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00007"",
          ""context"": ""1-4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00007"",
          ""context"": ""1-4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00007"",
          ""context"": ""1-4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00007"",
          ""context"": ""1-4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00007"",
          ""context"": ""1-4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00007"",
          ""context"": ""1-4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00008"",
          ""context"": ""2-3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00008"",
          ""context"": ""2-3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00008"",
          ""context"": ""2-3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00008"",
          ""context"": ""2-3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00008"",
          ""context"": ""2-3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00008"",
          ""context"": ""2-3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00008"",
          ""context"": ""2-3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00009"",
          ""context"": ""2-4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00009"",
          ""context"": ""2-4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00009"",
          ""context"": ""2-4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00009"",
          ""context"": ""2-4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00009"",
          ""context"": ""2-4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00009"",
          ""context"": ""2-4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00009"",
          ""context"": ""2-4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00010"",
          ""context"": ""3-4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00010"",
          ""context"": ""3-4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00010"",
          ""context"": ""3-4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00010"",
          ""context"": ""3-4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00010"",
          ""context"": ""3-4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00010"",
          ""context"": ""3-4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00010"",
          ""context"": ""3-4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00023"",
          ""context"": ""1-2-3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00023"",
          ""context"": ""1-2-3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00023"",
          ""context"": ""1-2-3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00023"",
          ""context"": ""1-2-3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00023"",
          ""context"": ""1-2-3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00023"",
          ""context"": ""1-2-3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00023"",
          ""context"": ""1-2-3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00024"",
          ""context"": ""1-2-4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00024"",
          ""context"": ""1-2-4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00024"",
          ""context"": ""1-2-4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00024"",
          ""context"": ""1-2-4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00024"",
          ""context"": ""1-2-4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00024"",
          ""context"": ""1-2-4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00024"",
          ""context"": ""1-2-4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00025"",
          ""context"": ""1-3-4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00025"",
          ""context"": ""1-3-4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00025"",
          ""context"": ""1-3-4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00025"",
          ""context"": ""1-3-4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00025"",
          ""context"": ""1-3-4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00025"",
          ""context"": ""1-3-4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00025"",
          ""context"": ""1-3-4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00026"",
          ""context"": ""2-3-4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00026"",
          ""context"": ""2-3-4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00026"",
          ""context"": ""2-3-4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00026"",
          ""context"": ""2-3-4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00026"",
          ""context"": ""2-3-4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00026"",
          ""context"": ""2-3-4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 5,
          ""gameName"": ""FanTan"",
          ""betArea"": ""00026"",
          ""context"": ""2-3-4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00001"",
          ""context"": ""B"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00002"",
          ""context"": ""P"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00003"",
          ""context"": ""Tie"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00004"",
          ""context"": ""Banker Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00005"",
          ""context"": ""Player Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00006"",
          ""context"": ""莊保險"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00006"",
          ""context"": ""Banker INS"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00006"",
          ""context"": ""莊保險"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00006"",
          ""context"": ""莊保險"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00006"",
          ""context"": ""莊保險"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00006"",
          ""context"": ""莊保險"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00006"",
          ""context"": ""莊保險"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00007"",
          ""context"": ""閒保險"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00007"",
          ""context"": ""閒保險"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00007"",
          ""context"": ""閒保險"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00007"",
          ""context"": ""閒保險"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00007"",
          ""context"": ""閒保險"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00007"",
          ""context"": ""Player INS"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00007"",
          ""context"": ""閒保險"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00008"",
          ""context"": ""大"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00008"",
          ""context"": ""大"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00008"",
          ""context"": ""大"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00008"",
          ""context"": ""大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00008"",
          ""context"": ""大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00008"",
          ""context"": ""Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00008"",
          ""context"": ""大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00009"",
          ""context"": ""Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00009"",
          ""context"": ""小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00009"",
          ""context"": ""小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00009"",
          ""context"": ""小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00009"",
          ""context"": ""小"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00009"",
          ""context"": ""小"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00009"",
          ""context"": ""小"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00010"",
          ""context"": ""任意對子"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00010"",
          ""context"": ""任意對子"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00010"",
          ""context"": ""任意對子"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00010"",
          ""context"": ""任意對子"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00010"",
          ""context"": ""任意對子"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00010"",
          ""context"": ""Any Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00010"",
          ""context"": ""任意對子"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00011"",
          ""context"": ""完美對子"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00011"",
          ""context"": ""完美對子"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00011"",
          ""context"": ""完美對子"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00011"",
          ""context"": ""完美對子"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00011"",
          ""context"": ""完美對子"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00011"",
          ""context"": ""完美對子"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 6,
          ""gameName"": ""InsuBacc"",
          ""betArea"": ""00011"",
          ""context"": ""完美對子"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00001"",
          ""context"": ""閒1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00001"",
          ""context"": ""P1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00001"",
          ""context"": ""閒1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00001"",
          ""context"": ""閒1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00001"",
          ""context"": ""閒1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00001"",
          ""context"": ""閒1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00001"",
          ""context"": ""閒1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00002"",
          ""context"": ""閒2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00002"",
          ""context"": ""閒2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00002"",
          ""context"": ""閒2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00002"",
          ""context"": ""閒2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00002"",
          ""context"": ""閒2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00002"",
          ""context"": ""P2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00002"",
          ""context"": ""閒2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00003"",
          ""context"": ""閒3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00003"",
          ""context"": ""閒3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00003"",
          ""context"": ""閒3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00003"",
          ""context"": ""閒3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00003"",
          ""context"": ""閒3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00003"",
          ""context"": ""P3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00003"",
          ""context"": ""閒3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00004"",
          ""context"": ""閒4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00004"",
          ""context"": ""閒4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00004"",
          ""context"": ""閒4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00004"",
          ""context"": ""閒4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00004"",
          ""context"": ""閒4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00004"",
          ""context"": ""P4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00004"",
          ""context"": ""閒4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00005"",
          ""context"": ""閒5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00005"",
          ""context"": ""閒5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00005"",
          ""context"": ""閒5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00005"",
          ""context"": ""P5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00005"",
          ""context"": ""閒5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00005"",
          ""context"": ""閒5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 7,
          ""gameName"": ""PokDeng"",
          ""betArea"": ""00005"",
          ""context"": ""閒5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00001"",
          ""context"": ""B1Equal"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00001"",
          ""context"": ""B1Equal"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00001"",
          ""context"": ""莊一平倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00001"",
          ""context"": ""莊一平倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00001"",
          ""context"": ""B1Equal"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00001"",
          ""context"": ""B1Equal"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00001"",
          ""context"": ""B1Equal"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00002"",
          ""context"": ""B1Double"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00002"",
          ""context"": ""B1Double"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00002"",
          ""context"": ""莊一翻倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00002"",
          ""context"": ""莊一翻倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00002"",
          ""context"": ""B1Double"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00002"",
          ""context"": ""B1Double"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00002"",
          ""context"": ""B1Double"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00003"",
          ""context"": ""B2Equal"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00003"",
          ""context"": ""B2Equal"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00003"",
          ""context"": ""莊二平倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00003"",
          ""context"": ""莊二平倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00003"",
          ""context"": ""B2Equal"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00003"",
          ""context"": ""B2Equal"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00003"",
          ""context"": ""B2Equal"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00004"",
          ""context"": ""B2Double"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00004"",
          ""context"": ""B2Double"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00004"",
          ""context"": ""莊二翻倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00004"",
          ""context"": ""莊二翻倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00004"",
          ""context"": ""B2Double"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00004"",
          ""context"": ""B2Double"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00004"",
          ""context"": ""B2Double"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00005"",
          ""context"": ""B3Equal"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00005"",
          ""context"": ""B3Equal"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00005"",
          ""context"": ""莊三平倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00005"",
          ""context"": ""莊三平倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00005"",
          ""context"": ""B3Equal"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00005"",
          ""context"": ""B3Equal"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00005"",
          ""context"": ""B3Equal"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00006"",
          ""context"": ""B3Double"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00006"",
          ""context"": ""B3Double"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00006"",
          ""context"": ""莊三翻倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00006"",
          ""context"": ""莊三翻倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00006"",
          ""context"": ""B3Double"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00006"",
          ""context"": ""B3Double"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00006"",
          ""context"": ""B3Double"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00007"",
          ""context"": ""P1Equal"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00007"",
          ""context"": ""P1Equal"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00007"",
          ""context"": ""閒一平倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00007"",
          ""context"": ""閒一平倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00007"",
          ""context"": ""P1Equal"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00007"",
          ""context"": ""P1Equal"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00007"",
          ""context"": ""P1Equal"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00008"",
          ""context"": ""P1Double"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00008"",
          ""context"": ""P1Double"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00008"",
          ""context"": ""閒一翻倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00008"",
          ""context"": ""閒一翻倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00008"",
          ""context"": ""P1Double"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00008"",
          ""context"": ""P1Double"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00008"",
          ""context"": ""P1Double"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00009"",
          ""context"": ""P2Equal"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00009"",
          ""context"": ""P2Equal"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00009"",
          ""context"": ""閒二平倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00009"",
          ""context"": ""閒二平倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00009"",
          ""context"": ""P2Equal"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00009"",
          ""context"": ""P2Equal"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00009"",
          ""context"": ""P2Equal"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00010"",
          ""context"": ""P2Double"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00010"",
          ""context"": ""P2Double"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00010"",
          ""context"": ""閒二翻倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00010"",
          ""context"": ""閒二翻倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00010"",
          ""context"": ""P2Double"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00010"",
          ""context"": ""P2Double"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00010"",
          ""context"": ""P2Double"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00011"",
          ""context"": ""P3Equal"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00011"",
          ""context"": ""P3Equal"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00011"",
          ""context"": ""閒三平倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00011"",
          ""context"": ""閒三平倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00011"",
          ""context"": ""P3Equal"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00011"",
          ""context"": ""P3Equal"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00011"",
          ""context"": ""P3Equal"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00012"",
          ""context"": ""P3Double"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00012"",
          ""context"": ""P3Double"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00012"",
          ""context"": ""閒三翻倍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00012"",
          ""context"": ""閒三翻倍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00012"",
          ""context"": ""P3Double"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00012"",
          ""context"": ""P3Double"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 8,
          ""gameName"": ""BullBull"",
          ""betArea"": ""00012"",
          ""context"": ""P3Double"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00001"",
          ""context"": ""閒1-直走"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00001"",
          ""context"": ""閒1-直走"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00001"",
          ""context"": ""閒1-直走"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00001"",
          ""context"": ""閒1-直走"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00001"",
          ""context"": ""閒1-直走"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00001"",
          ""context"": ""閒1-直走"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00001"",
          ""context"": ""閒1-直走"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00002"",
          ""context"": ""閒2-直走"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00002"",
          ""context"": ""閒2-直走"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00002"",
          ""context"": ""閒2-直走"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00002"",
          ""context"": ""閒2-直走"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00002"",
          ""context"": ""閒2-直走"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00002"",
          ""context"": ""閒2-直走"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00002"",
          ""context"": ""閒2-直走"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00003"",
          ""context"": ""閒3-直走"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00003"",
          ""context"": ""閒3-直走"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00003"",
          ""context"": ""閒3-直走"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00003"",
          ""context"": ""閒3-直走"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00003"",
          ""context"": ""閒3-直走"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00003"",
          ""context"": ""閒3-直走"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00003"",
          ""context"": ""閒3-直走"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00004"",
          ""context"": ""閒1-本注"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00004"",
          ""context"": ""閒1-本注"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00004"",
          ""context"": ""閒1-本注"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00004"",
          ""context"": ""閒1-本注"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00004"",
          ""context"": ""閒1-本注"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00004"",
          ""context"": ""閒1-本注"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00004"",
          ""context"": ""閒1-本注"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00005"",
          ""context"": ""閒2-本注"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00005"",
          ""context"": ""閒2-本注"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00005"",
          ""context"": ""閒2-本注"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00005"",
          ""context"": ""閒2-本注"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00005"",
          ""context"": ""閒2-本注"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00005"",
          ""context"": ""閒2-本注"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00005"",
          ""context"": ""閒2-本注"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00006"",
          ""context"": ""閒3-本注"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00006"",
          ""context"": ""閒3-本注"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00006"",
          ""context"": ""閒3-本注"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00006"",
          ""context"": ""閒3-本注"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00006"",
          ""context"": ""閒3-本注"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00006"",
          ""context"": ""閒3-本注"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 9,
          ""gameName"": ""SamBo"",
          ""betArea"": ""00006"",
          ""context"": ""閒3-本注"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00001"",
          ""context"": ""ที่หนึ่ง：1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00001"",
          ""context"": ""champion：1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00001"",
          ""context"": ""冠军：1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00001"",
          ""context"": ""冠軍：1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00001"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00001"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00001"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00001"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00002"",
          ""context"": ""ที่หนึ่ง：2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00002"",
          ""context"": ""champion：2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00002"",
          ""context"": ""冠军：2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00002"",
          ""context"": ""冠軍：2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00002"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00002"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00002"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00002"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00003"",
          ""context"": ""ที่หนึ่ง：3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00003"",
          ""context"": ""champion：3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00003"",
          ""context"": ""冠军：3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00003"",
          ""context"": ""冠軍：3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00004"",
          ""context"": ""ที่หนึ่ง：4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00004"",
          ""context"": ""champion：4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00004"",
          ""context"": ""冠军：4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00004"",
          ""context"": ""冠軍：4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00004"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00004"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00004"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00004"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00005"",
          ""context"": ""ที่หนึ่ง：5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00005"",
          ""context"": ""champion：5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00005"",
          ""context"": ""冠军：5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00005"",
          ""context"": ""冠軍：5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00005"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00005"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00005"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00005"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00006"",
          ""context"": ""ที่หนึ่ง：6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00006"",
          ""context"": ""champion：6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00006"",
          ""context"": ""冠军：6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00006"",
          ""context"": ""冠軍：6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00006"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00006"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00006"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00006"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00007"",
          ""context"": ""ที่หนึ่ง：7"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00007"",
          ""context"": ""champion：7"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00007"",
          ""context"": ""冠军：7"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00007"",
          ""context"": ""冠軍：7"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00007"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00007"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00007"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00007"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00008"",
          ""context"": ""ที่หนึ่ง：8"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00008"",
          ""context"": ""champion：8"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00008"",
          ""context"": ""冠军：8"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00008"",
          ""context"": ""冠軍：8"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00008"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00008"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00008"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00008"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00009"",
          ""context"": ""ที่หนึ่ง：9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00009"",
          ""context"": ""champion：9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00009"",
          ""context"": ""冠军：9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00009"",
          ""context"": ""冠軍：9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00009"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00009"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00009"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00009"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00010"",
          ""context"": ""ที่หนึ่ง：10"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00010"",
          ""context"": ""champion：10"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00010"",
          ""context"": ""冠军：10"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00010"",
          ""context"": ""冠軍：10"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00010"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00010"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00010"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00010"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00011"",
          ""context"": ""ที่หนึ่ง：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00011"",
          ""context"": ""champion：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00011"",
          ""context"": ""冠军：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00011"",
          ""context"": ""冠軍：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00011"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00011"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00011"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00011"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00012"",
          ""context"": ""ที่หนึ่ง：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00012"",
          ""context"": ""champion：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00012"",
          ""context"": ""冠军：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00012"",
          ""context"": ""冠軍：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00012"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00012"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00012"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00012"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00013"",
          ""context"": ""ที่หนึ่ง：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00013"",
          ""context"": ""champion：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00013"",
          ""context"": ""冠军：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00013"",
          ""context"": ""冠軍：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00013"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00013"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00013"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00013"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00014"",
          ""context"": ""ที่หนึ่ง：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00014"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00014"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00014"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00014"",
          ""context"": ""冠軍：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00014"",
          ""context"": ""冠军：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00014"",
          ""context"": ""champion：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00014"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00015"",
          ""context"": ""ที่สอง：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00015"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00015"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00015"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00015"",
          ""context"": ""亞軍：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00015"",
          ""context"": ""亚军：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00015"",
          ""context"": ""runner-up：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00015"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00016"",
          ""context"": ""ที่สอง：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00016"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00016"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00016"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00016"",
          ""context"": ""亞軍：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00016"",
          ""context"": ""亚军：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00016"",
          ""context"": ""runner-up：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00016"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00017"",
          ""context"": ""ที่สอง：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00017"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00017"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00017"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00017"",
          ""context"": ""亞軍：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00017"",
          ""context"": ""亚军：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00017"",
          ""context"": ""runner-up：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00017"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00018"",
          ""context"": ""ที่สอง：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00018"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00018"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00018"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00018"",
          ""context"": ""亞軍：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00018"",
          ""context"": ""亚军：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00018"",
          ""context"": ""runner-up：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00018"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00019"",
          ""context"": ""ที่สาม：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00019"",
          ""context"": ""3rd：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00019"",
          ""context"": ""第三名：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00019"",
          ""context"": ""第三名：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00019"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00019"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00019"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00019"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00020"",
          ""context"": ""ที่สาม：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00020"",
          ""context"": ""3rd：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00020"",
          ""context"": ""第三名：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00020"",
          ""context"": ""第三名：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00020"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00020"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00020"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00020"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00021"",
          ""context"": ""ที่สาม：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00021"",
          ""context"": ""3rd：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00021"",
          ""context"": ""第三名：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00021"",
          ""context"": ""第三名：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00021"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00021"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00021"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00021"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00022"",
          ""context"": ""ที่สาม：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00022"",
          ""context"": ""3rd：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00022"",
          ""context"": ""第三名：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00022"",
          ""context"": ""第三名：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00022"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00022"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00022"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00022"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00023"",
          ""context"": ""ที่สี่：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00023"",
          ""context"": ""4rd：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00023"",
          ""context"": ""第四名：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00023"",
          ""context"": ""第四名：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00023"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00023"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00023"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00023"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00024"",
          ""context"": ""ที่สี่：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00024"",
          ""context"": ""4rd：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00024"",
          ""context"": ""第四名：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00024"",
          ""context"": ""第四名：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00024"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00024"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00024"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00024"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00025"",
          ""context"": ""ที่สี่：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00025"",
          ""context"": ""4rd：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00025"",
          ""context"": ""第四名：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00025"",
          ""context"": ""第四名：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00025"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00025"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00025"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00025"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00026"",
          ""context"": ""ที่สี่：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00026"",
          ""context"": ""4rd：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00026"",
          ""context"": ""第四名：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00026"",
          ""context"": ""第四名：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00026"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00026"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00026"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00026"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00027"",
          ""context"": ""ที่ห้า：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00027"",
          ""context"": ""5rd：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00027"",
          ""context"": ""第五名：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00027"",
          ""context"": ""第五名：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00027"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00027"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00027"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00027"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00028"",
          ""context"": ""ที่ห้า：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00028"",
          ""context"": ""5rd：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00028"",
          ""context"": ""第五名：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00028"",
          ""context"": ""第五名：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00028"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00028"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00028"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00028"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00029"",
          ""context"": ""ที่ห้า：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00029"",
          ""context"": ""5rd：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00029"",
          ""context"": ""第五名：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00029"",
          ""context"": ""第五名：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00029"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00029"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00029"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00029"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00030"",
          ""context"": ""ที่ห้า：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00030"",
          ""context"": ""5rd：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00030"",
          ""context"": ""第五名：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00030"",
          ""context"": ""第五名：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00030"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00030"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00030"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00030"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00031"",
          ""context"": ""ที่หก：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00031"",
          ""context"": ""6rd：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00031"",
          ""context"": ""第六名：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00031"",
          ""context"": ""第六名：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00031"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00031"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00031"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00031"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00032"",
          ""context"": ""ที่หก：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00032"",
          ""context"": ""6rd：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00032"",
          ""context"": ""第六名：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00032"",
          ""context"": ""第六名：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00032"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00032"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00032"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00032"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00033"",
          ""context"": ""ที่หก：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00033"",
          ""context"": ""6rd：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00033"",
          ""context"": ""第六名：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00033"",
          ""context"": ""第六名：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00033"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00033"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00033"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00033"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00034"",
          ""context"": ""ที่หก：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00034"",
          ""context"": ""6rd：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00034"",
          ""context"": ""第六名：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00034"",
          ""context"": ""第六名：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00034"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00034"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00034"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00034"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00035"",
          ""context"": ""ที่เจ็ด：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00035"",
          ""context"": ""7rd：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00035"",
          ""context"": ""第七名：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00035"",
          ""context"": ""第七名：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00035"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00035"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00035"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00035"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00036"",
          ""context"": ""ที่เจ็ด：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00036"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00036"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00036"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00036"",
          ""context"": ""第七名：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00036"",
          ""context"": ""第七名：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00036"",
          ""context"": ""7rd：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00036"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00037"",
          ""context"": ""ที่เจ็ด：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00037"",
          ""context"": ""7rd：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00037"",
          ""context"": ""第七名：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00037"",
          ""context"": ""第七名：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00037"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00037"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00037"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00037"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00038"",
          ""context"": ""ที่เจ็ด：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00038"",
          ""context"": ""7rd：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00038"",
          ""context"": ""第七名：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00038"",
          ""context"": ""第七名：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00038"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00038"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00038"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00038"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00039"",
          ""context"": ""ที่แปด：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00039"",
          ""context"": ""8rd：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00039"",
          ""context"": ""第八名：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00039"",
          ""context"": ""第八名：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00039"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00039"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00039"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00039"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00040"",
          ""context"": ""ที่แปด：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00040"",
          ""context"": ""8rd：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00040"",
          ""context"": ""第八名：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00040"",
          ""context"": ""第八名：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00040"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00040"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00040"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00040"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00041"",
          ""context"": ""ที่แปด：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00041"",
          ""context"": ""8rd：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00041"",
          ""context"": ""第八名：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00041"",
          ""context"": ""第八名：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00041"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00041"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00041"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00041"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00042"",
          ""context"": ""ที่แปด：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00042"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00042"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00042"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00042"",
          ""context"": ""第八名：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00042"",
          ""context"": ""第八名：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00042"",
          ""context"": ""8rd：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00042"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00043"",
          ""context"": ""ที่เก้า：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00043"",
          ""context"": ""9rd：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00043"",
          ""context"": ""第九名：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00043"",
          ""context"": ""第九名：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00043"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00043"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00043"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00043"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00044"",
          ""context"": ""ที่เก้า：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00044"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00044"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00044"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00044"",
          ""context"": ""第九名：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00044"",
          ""context"": ""第九名：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00044"",
          ""context"": ""9rd：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00044"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00045"",
          ""context"": ""ที่เก้า：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00045"",
          ""context"": ""9rd：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00045"",
          ""context"": ""第九名：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00045"",
          ""context"": ""第九名：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00045"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00045"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00045"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00045"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00046"",
          ""context"": ""ที่เก้า：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00046"",
          ""context"": ""9rd：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00046"",
          ""context"": ""第九名：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00046"",
          ""context"": ""第九名：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00046"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00046"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00046"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00046"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00047"",
          ""context"": ""ที่สิบ：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00047"",
          ""context"": ""10rd：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00047"",
          ""context"": ""第十名：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00047"",
          ""context"": ""第十名：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00047"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00047"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00047"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00047"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00048"",
          ""context"": ""ที่สิบ：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00048"",
          ""context"": ""10rd：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00048"",
          ""context"": ""第十名：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00048"",
          ""context"": ""第十名：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00048"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00048"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00048"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00048"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00049"",
          ""context"": ""ที่สิบ：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00049"",
          ""context"": ""10rd：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00049"",
          ""context"": ""第十名：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00049"",
          ""context"": ""第十名：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00049"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00049"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00049"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00049"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00050"",
          ""context"": ""ที่สิบ：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00050"",
          ""context"": ""10rd：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00050"",
          ""context"": ""第十名：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00050"",
          ""context"": ""第十名：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00050"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00050"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00050"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00050"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00051"",
          ""context"": ""ที่หนึ่ง：มังกร"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00051"",
          ""context"": ""champion：Dragon"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00051"",
          ""context"": ""冠军：龙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00051"",
          ""context"": ""冠軍：龍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00051"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00051"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00051"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00051"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00052"",
          ""context"": ""ที่หนึ่ง：เสือ"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00052"",
          ""context"": ""champion：Tiger"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00052"",
          ""context"": ""冠军：虎"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00052"",
          ""context"": ""冠軍：虎"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00052"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00052"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00052"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00052"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00053"",
          ""context"": ""ที่สอง：มังกร"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00053"",
          ""context"": ""runner-up：Dragon"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00053"",
          ""context"": ""亚军：龙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00053"",
          ""context"": ""亞軍：龍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00053"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00053"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00053"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00053"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00054"",
          ""context"": ""ที่สอง：เสือ"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00054"",
          ""context"": ""runner-up：Tiger"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00054"",
          ""context"": ""亚军：虎"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00054"",
          ""context"": ""亞軍：虎"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00054"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00054"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00054"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00054"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00055"",
          ""context"": ""ที่สาม：มังกร"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00055"",
          ""context"": ""3rd：Dragon"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00055"",
          ""context"": ""第三名：龙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00055"",
          ""context"": ""第三名：龍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00055"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00055"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00055"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00055"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00056"",
          ""context"": ""ที่สาม：เสือ"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00056"",
          ""context"": ""3rd：Tiger"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00056"",
          ""context"": ""第三名：虎"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00056"",
          ""context"": ""第三名：虎"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00056"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00056"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00056"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00056"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00057"",
          ""context"": ""ที่สี่：มังกร"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00057"",
          ""context"": ""4rd：Dragon"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00057"",
          ""context"": ""第四名：龙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00057"",
          ""context"": ""第四名：龍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00057"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00057"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00057"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00057"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00058"",
          ""context"": ""ที่สี่：เสือ"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00058"",
          ""context"": ""4rd：Tiger"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00058"",
          ""context"": ""第四名：虎"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00058"",
          ""context"": ""第四名：虎"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00058"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00058"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00058"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00058"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00059"",
          ""context"": ""ที่ห้า：มังกร"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00059"",
          ""context"": ""5rd：Dragon"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00059"",
          ""context"": ""第五名：龙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00059"",
          ""context"": ""第五名：龍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00059"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00059"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00059"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00059"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00060"",
          ""context"": ""ที่ห้า：เสือ"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00060"",
          ""context"": ""5rd：Tiger"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00060"",
          ""context"": ""第五名：虎"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00060"",
          ""context"": ""第五名：虎"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00060"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00060"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00060"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00060"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00061"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：ใหญ่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00061"",
          ""context"": ""Top Two Sum：Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00061"",
          ""context"": ""和值：大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00061"",
          ""context"": ""和值：大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00061"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00061"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00061"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00061"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00062"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：เล็ก"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00062"",
          ""context"": ""Top Two Sum：Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00062"",
          ""context"": ""和值：小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00062"",
          ""context"": ""和值：小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00062"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00062"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00062"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00062"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00063"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00063"",
          ""context"": ""Top Two Sum：3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00063"",
          ""context"": ""和值：3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00063"",
          ""context"": ""和值：3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00063"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00063"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00063"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00063"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00064"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00064"",
          ""context"": ""Top Two Sum：4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00064"",
          ""context"": ""和值：4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00064"",
          ""context"": ""和值：4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00064"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00064"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00064"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00064"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00065"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00065"",
          ""context"": ""Top Two Sum：5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00065"",
          ""context"": ""和值：5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00065"",
          ""context"": ""和值：5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00065"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00065"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00065"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00065"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00066"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00066"",
          ""context"": ""Top Two Sum：6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00066"",
          ""context"": ""和值：6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00066"",
          ""context"": ""和值：6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00066"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00066"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00066"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00066"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00067"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：7"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00067"",
          ""context"": ""Top Two Sum：7"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00067"",
          ""context"": ""和值：7"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00067"",
          ""context"": ""和值：7"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00067"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00067"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00067"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00067"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00068"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：8"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00068"",
          ""context"": ""Top Two Sum：8"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00068"",
          ""context"": ""和值：8"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00068"",
          ""context"": ""和值：8"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00068"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00068"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00068"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00068"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00069"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：9"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00069"",
          ""context"": ""Top Two Sum：9"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00069"",
          ""context"": ""和值：9"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00069"",
          ""context"": ""和值：9"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00069"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00069"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00069"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00069"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00070"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：10"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00070"",
          ""context"": ""Top Two Sum：10"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00070"",
          ""context"": ""和值：10"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00070"",
          ""context"": ""和值：10"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00070"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00070"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00070"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00070"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00071"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：11"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00071"",
          ""context"": ""Top Two Sum：11"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00071"",
          ""context"": ""和值：11"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00071"",
          ""context"": ""和值：11"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00071"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00071"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00071"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00071"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00072"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：12"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00072"",
          ""context"": ""Top Two Sum：12"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00072"",
          ""context"": ""和值：12"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00072"",
          ""context"": ""和值：12"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00072"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00072"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00072"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00072"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00073"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00073"",
          ""context"": ""Top Two Sum：Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00073"",
          ""context"": ""和值：双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00073"",
          ""context"": ""和值：雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00073"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00073"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00073"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00073"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00074"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00074"",
          ""context"": ""Top Two Sum：Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00074"",
          ""context"": ""和值：单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00074"",
          ""context"": ""和值：單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00074"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00074"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00074"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00074"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00075"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：13"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00075"",
          ""context"": ""Top Two Sum：13"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00075"",
          ""context"": ""和值：13"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00075"",
          ""context"": ""和值：13"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00075"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00075"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00075"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00075"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00076"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：14"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00076"",
          ""context"": ""Top Two Sum：14"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00076"",
          ""context"": ""和值：14"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00076"",
          ""context"": ""和值：14"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00076"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00076"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00076"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00076"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00077"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：15"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00077"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00077"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00077"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00077"",
          ""context"": ""和值：15"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00077"",
          ""context"": ""和值：15"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00077"",
          ""context"": ""Top Two Sum：15"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00077"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00078"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：16"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00078"",
          ""context"": ""Top Two Sum：16"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00078"",
          ""context"": ""和值：16"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00078"",
          ""context"": ""和值：16"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00078"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00078"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00078"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00078"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00079"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：17"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00079"",
          ""context"": ""Top Two Sum：17"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00079"",
          ""context"": ""和值：17"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00079"",
          ""context"": ""和值：17"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00079"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00079"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00079"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00079"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00080"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：18"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00080"",
          ""context"": ""Top Two Sum：18"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00080"",
          ""context"": ""和值：18"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00080"",
          ""context"": ""和值：18"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00080"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00080"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00080"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00080"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00081"",
          ""context"": ""ผลรวมแชมป์และอันดับที่สอง：19"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00081"",
          ""context"": ""Top Two Sum：19"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00081"",
          ""context"": ""和值：19"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00081"",
          ""context"": ""和值：19"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00081"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00081"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00081"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 10,
          ""gameName"": ""RgRacing"",
          ""betArea"": ""00081"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00001"",
          ""context"": ""B"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00001"",
          ""context"": ""莊"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00001"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00001"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00001"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00001"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00002"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00002"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00002"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00002"",
          ""context"": ""閒"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00002"",
          ""context"": ""P"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00002"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00003"",
          ""context"": ""Tie"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00003"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00004"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00004"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00004"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00004"",
          ""context"": ""莊對"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00004"",
          ""context"": ""Banker Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00004"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00005"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00005"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00005"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00005"",
          ""context"": ""閒對"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00005"",
          ""context"": ""Player Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00005"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00006"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00006"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00006"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00006"",
          ""context"": ""大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00006"",
          ""context"": ""Big"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00006"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00007"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00007"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00007"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00007"",
          ""context"": ""小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00007"",
          ""context"": ""Small"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00007"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00008"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00008"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00008"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00008"",
          ""context"": ""任意對子"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00008"",
          ""context"": ""Any Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00008"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00009"",
          ""context"": """",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00009"",
          ""context"": """",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00009"",
          ""context"": """",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00009"",
          ""context"": ""完美對子"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00009"",
          ""context"": ""Perfect Pair"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00009"",
          ""context"": """",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 11,
          ""gameName"": ""BCBacc"",
          ""betArea"": ""00010"",
          ""context"": ""莊(免傭)"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00001"",
          ""context"": ""Dragon"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00001"",
          ""context"": ""龍"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00002"",
          ""context"": ""Tiger"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00002"",
          ""context"": ""虎"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00003"",
          ""context"": ""Tie"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00003"",
          ""context"": ""和"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00004"",
          ""context"": ""Dragon Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00004"",
          ""context"": ""龍單"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00005"",
          ""context"": ""Dragon Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00005"",
          ""context"": ""龍雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00006"",
          ""context"": ""Dragon Red"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00006"",
          ""context"": ""龍紅"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00007"",
          ""context"": ""Dragon Black"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00007"",
          ""context"": ""龍黑"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00008"",
          ""context"": ""Tiger Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00008"",
          ""context"": ""虎單"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00009"",
          ""context"": ""Tiger Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00009"",
          ""context"": ""虎雙"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00010"",
          ""context"": ""Tiger Red"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00010"",
          ""context"": ""虎紅"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00011"",
          ""context"": ""Tiger Black"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00011"",
          ""context"": ""虎黑"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00012"",
          ""context"": ""DragonBig"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00012"",
          ""context"": ""龍大"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00013"",
          ""context"": ""龍小"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00013"",
          ""context"": ""DragonSmall"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00014"",
          ""context"": ""TigerBig"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00014"",
          ""context"": ""虎大"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00015"",
          ""context"": ""TigerSmall"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 12,
          ""gameName"": ""BCLongHu"",
          ""betArea"": ""00015"",
          ""context"": ""虎小"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00001"",
          ""context"": ""แอนดาร์"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00001"",
          ""context"": ""Andar"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00001"",
          ""context"": ""Andar"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00001"",
          ""context"": ""안다"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00001"",
          ""context"": ""安達"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00001"",
          ""context"": ""安达"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00001"",
          ""context"": ""Andar"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00001"",
          ""context"": ""Andar"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00002"",
          ""context"": ""บาฮาร์"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00002"",
          ""context"": ""Bahar"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00002"",
          ""context"": ""巴哈"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00002"",
          ""context"": ""巴哈"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00002"",
          ""context"": ""바하"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00002"",
          ""context"": ""Bahar"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00002"",
          ""context"": ""Bahar"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 15,
          ""gameName"": ""AndarBahar"",
          ""betArea"": ""00002"",
          ""context"": ""Bahar"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00001"",
          ""context"": ""คี่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00001"",
          ""context"": ""Odd"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00001"",
          ""context"": ""单"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00001"",
          ""context"": ""單"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00001"",
          ""context"": ""Odd"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00001"",
          ""context"": ""Odd"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00001"",
          ""context"": ""Odd"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00001"",
          ""context"": ""Odd"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00002"",
          ""context"": ""คู่"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00002"",
          ""context"": ""Even"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00002"",
          ""context"": ""双"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00002"",
          ""context"": ""雙"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00002"",
          ""context"": ""Even"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00002"",
          ""context"": ""Even"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00002"",
          ""context"": ""Even"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00002"",
          ""context"": ""Even"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00003"",
          ""context"": ""4白"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00003"",
          ""context"": ""4白"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00003"",
          ""context"": ""4白"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00003"",
          ""context"": ""4白"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00003"",
          ""context"": ""4白"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00003"",
          ""context"": ""4白"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00003"",
          ""context"": ""4白"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00003"",
          ""context"": ""4白"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00004"",
          ""context"": ""3白1紅"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00004"",
          ""context"": ""3白1紅"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00004"",
          ""context"": ""3白1紅"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00004"",
          ""context"": ""3白1紅"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00004"",
          ""context"": ""3白1紅"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00004"",
          ""context"": ""3白1紅"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00004"",
          ""context"": ""3白1紅"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00004"",
          ""context"": ""3白1紅"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00005"",
          ""context"": ""3紅1白"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00005"",
          ""context"": ""3紅1白"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00005"",
          ""context"": ""3紅1白"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00005"",
          ""context"": ""3紅1白"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00005"",
          ""context"": ""3紅1白"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00005"",
          ""context"": ""3紅1白"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00005"",
          ""context"": ""3紅1白"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00005"",
          ""context"": ""3紅1白"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00006"",
          ""context"": ""4紅"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00006"",
          ""context"": ""4紅"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00006"",
          ""context"": ""4紅"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00006"",
          ""context"": ""4紅"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00006"",
          ""context"": ""4紅"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00006"",
          ""context"": ""4紅"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00006"",
          ""context"": ""4紅"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 16,
          ""gameName"": ""SeDie"",
          ""betArea"": ""00006"",
          ""context"": ""4紅"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00001"",
          ""context"": ""高"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00001"",
          ""context"": ""高"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00001"",
          ""context"": ""Hi"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00001"",
          ""context"": ""สูง"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00001"",
          ""context"": ""높음"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00001"",
          ""context"": ""ြမှင့်"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00001"",
          ""context"": ""Tinggi"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00001"",
          ""context"": ""Cao"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00002"",
          ""context"": ""低"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00002"",
          ""context"": ""低"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00002"",
          ""context"": ""Lo"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00002"",
          ""context"": ""ต่ำ"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00002"",
          ""context"": ""낮음"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00002"",
          ""context"": ""နိမ့်"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00002"",
          ""context"": ""Rendah"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00002"",
          ""context"": ""Thấp"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00003"",
          ""context"": ""11 Hi-Lo"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00003"",
          ""context"": ""11 Hi-Lo"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00003"",
          ""context"": ""11 Hi-Lo"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00003"",
          ""context"": ""11 ไฮโล"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00003"",
          ""context"": ""11 Hi-Lo"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00003"",
          ""context"": ""11ဟို-လို"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00003"",
          ""context"": ""11 tinggi-rendah"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00003"",
          ""context"": ""11 Cao-Thấp"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00004"",
          ""context"": ""骰 1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00004"",
          ""context"": ""骰 1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00004"",
          ""context"": ""Dice 1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00004"",
          ""context"": ""ไฮโล 1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00004"",
          ""context"": ""주사위 1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00004"",
          ""context"": ""အံဇာတံုး 1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00004"",
          ""context"": ""Dadu 1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00004"",
          ""context"": ""Xúc xắc 1"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00005"",
          ""context"": ""骰 2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00005"",
          ""context"": ""骰 2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00005"",
          ""context"": ""Dice 2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00005"",
          ""context"": ""ไฮโล 2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00005"",
          ""context"": ""주사위 2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00005"",
          ""context"": ""အံဇာတံုး 2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00005"",
          ""context"": ""Dadu 2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00005"",
          ""context"": ""Xúc xắc 2"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00006"",
          ""context"": ""骰 3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00006"",
          ""context"": ""骰 3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00006"",
          ""context"": ""Dice 3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00006"",
          ""context"": ""ไฮโล 3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00006"",
          ""context"": ""주사위 3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00006"",
          ""context"": ""အံဇာတံုး 3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00006"",
          ""context"": ""Dadu 3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00006"",
          ""context"": ""Xúc xắc 3"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00007"",
          ""context"": ""骰 4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00007"",
          ""context"": ""骰 4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00007"",
          ""context"": ""Dice 4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00007"",
          ""context"": ""ไฮโล 4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00007"",
          ""context"": ""주사위 4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00007"",
          ""context"": ""အံဇာတံုး 4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00007"",
          ""context"": ""Dadu 4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00007"",
          ""context"": ""Xúc xắc 4"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00008"",
          ""context"": ""骰 5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00008"",
          ""context"": ""骰 5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00008"",
          ""context"": ""Dice 5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00008"",
          ""context"": ""ไฮโล 5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00008"",
          ""context"": ""주사위 5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00008"",
          ""context"": ""အံဇာတံုး 5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00008"",
          ""context"": ""Dadu 5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00008"",
          ""context"": ""Xúc xắc 5"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00009"",
          ""context"": ""骰 6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00009"",
          ""context"": ""骰 6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00009"",
          ""context"": ""Dice 6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00009"",
          ""context"": ""ไฮโล 6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00009"",
          ""context"": ""주사위 6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00009"",
          ""context"": ""အံဇာတံုး 6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00009"",
          ""context"": ""Dadu 6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00009"",
          ""context"": ""Xúc xắc 6"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00010"",
          ""context"": ""1and2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00010"",
          ""context"": ""1and2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00010"",
          ""context"": ""1and2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00010"",
          ""context"": ""1and2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00010"",
          ""context"": ""1and2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00010"",
          ""context"": ""1and2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00010"",
          ""context"": ""1and2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00010"",
          ""context"": ""1and2"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00011"",
          ""context"": ""2and3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00011"",
          ""context"": ""2and3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00011"",
          ""context"": ""2and3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00011"",
          ""context"": ""2and3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00011"",
          ""context"": ""2and3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00011"",
          ""context"": ""2and3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00011"",
          ""context"": ""2and3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00011"",
          ""context"": ""2and3"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00012"",
          ""context"": ""3and4"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00012"",
          ""context"": ""3and4"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00012"",
          ""context"": ""3and4"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00012"",
          ""context"": ""3and4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00012"",
          ""context"": ""3and4"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00012"",
          ""context"": ""3and4"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00012"",
          ""context"": ""3and4"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00012"",
          ""context"": ""3and4"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00013"",
          ""context"": ""4and5"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00013"",
          ""context"": ""4and5"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00013"",
          ""context"": ""4and5"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00013"",
          ""context"": ""4and5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00013"",
          ""context"": ""4and5"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00013"",
          ""context"": ""4and5"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00013"",
          ""context"": ""4and5"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00013"",
          ""context"": ""4and5"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00014"",
          ""context"": ""5and6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00014"",
          ""context"": ""5and6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00014"",
          ""context"": ""5and6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00014"",
          ""context"": ""5and6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00014"",
          ""context"": ""5and6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00014"",
          ""context"": ""5and6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00014"",
          ""context"": ""5and6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00014"",
          ""context"": ""5and6"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00015"",
          ""context"": ""4and1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00015"",
          ""context"": ""4and1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00015"",
          ""context"": ""4and1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00015"",
          ""context"": ""4and1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00015"",
          ""context"": ""4and1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00015"",
          ""context"": ""4and1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00015"",
          ""context"": ""4and1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00015"",
          ""context"": ""4and1"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00016"",
          ""context"": ""6and2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00016"",
          ""context"": ""6and2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00016"",
          ""context"": ""6and2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00016"",
          ""context"": ""6and2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00016"",
          ""context"": ""6and2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00016"",
          ""context"": ""6and2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00016"",
          ""context"": ""6and2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00016"",
          ""context"": ""6and2"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00017"",
          ""context"": ""6and3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00017"",
          ""context"": ""6and3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00017"",
          ""context"": ""6and3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00017"",
          ""context"": ""6and3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00017"",
          ""context"": ""6and3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00017"",
          ""context"": ""6and3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00017"",
          ""context"": ""6and3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00017"",
          ""context"": ""6and3"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00018"",
          ""context"": ""4and2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00018"",
          ""context"": ""4and2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00018"",
          ""context"": ""4and2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00018"",
          ""context"": ""4and2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00018"",
          ""context"": ""4and2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00018"",
          ""context"": ""4and2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00018"",
          ""context"": ""4and2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00018"",
          ""context"": ""4and2"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00019"",
          ""context"": ""5and3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00019"",
          ""context"": ""5and3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00019"",
          ""context"": ""5and3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00019"",
          ""context"": ""5and3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00019"",
          ""context"": ""5and3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00019"",
          ""context"": ""5and3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00019"",
          ""context"": ""5and3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00019"",
          ""context"": ""5and3"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00020"",
          ""context"": ""5and1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00020"",
          ""context"": ""5and1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00020"",
          ""context"": ""5and1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00020"",
          ""context"": ""5and1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00020"",
          ""context"": ""5and1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00020"",
          ""context"": ""5and1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00020"",
          ""context"": ""5and1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00020"",
          ""context"": ""5and1"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00021"",
          ""context"": ""5and2"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00021"",
          ""context"": ""5and2"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00021"",
          ""context"": ""5and2"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00021"",
          ""context"": ""5and2"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00021"",
          ""context"": ""5and2"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00021"",
          ""context"": ""5and2"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00021"",
          ""context"": ""5and2"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00021"",
          ""context"": ""5and2"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00022"",
          ""context"": ""6and1"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00022"",
          ""context"": ""6and1"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00022"",
          ""context"": ""6and1"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00022"",
          ""context"": ""6and1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00022"",
          ""context"": ""6and1"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00022"",
          ""context"": ""6and1"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00022"",
          ""context"": ""6and1"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00022"",
          ""context"": ""6and1"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00023"",
          ""context"": ""5低"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00023"",
          ""context"": ""5低"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00023"",
          ""context"": ""5 Lo"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00023"",
          ""context"": ""ต่ำ 5"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00023"",
          ""context"": ""5 낮음"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00023"",
          ""context"": ""5နိမ့်"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00023"",
          ""context"": ""5 rendah"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00023"",
          ""context"": ""5 Thấp"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00024"",
          ""context"": ""6低"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00024"",
          ""context"": ""6低"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00024"",
          ""context"": ""6 Lo"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00024"",
          ""context"": ""ต่ำ 6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00024"",
          ""context"": ""6 낮음"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00024"",
          ""context"": ""6နိမ့်"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00024"",
          ""context"": ""6 rendah"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00024"",
          ""context"": ""6 Thấp"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00025"",
          ""context"": ""1低"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00025"",
          ""context"": ""1低"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00025"",
          ""context"": ""1 Lo"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00025"",
          ""context"": ""ต่ำ 1"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00025"",
          ""context"": ""1 낮음"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00025"",
          ""context"": ""1နိမ့်"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00025"",
          ""context"": ""1 rendah"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00025"",
          ""context"": ""1 Thấp"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00026"",
          ""context"": ""3低"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00026"",
          ""context"": ""3低"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00026"",
          ""context"": ""3 Lo"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00026"",
          ""context"": ""ต่ำ 3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00026"",
          ""context"": ""3 낮음"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00026"",
          ""context"": ""3နိမ့်"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00026"",
          ""context"": ""3 rendah"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00026"",
          ""context"": ""3 Thấp"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00027"",
          ""context"": ""6高"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00027"",
          ""context"": ""6高"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00027"",
          ""context"": ""6 Hi"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00027"",
          ""context"": ""สูง 6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00027"",
          ""context"": ""6 높음"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00027"",
          ""context"": ""6ြမှင့်"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00027"",
          ""context"": ""6 tinggi"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00027"",
          ""context"": ""6 Cao"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00028"",
          ""context"": ""4高"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00028"",
          ""context"": ""4高"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00028"",
          ""context"": ""4 Hi"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00028"",
          ""context"": ""สูง 4"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00028"",
          ""context"": ""4 높음"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00028"",
          ""context"": ""4ြမှင့်"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00028"",
          ""context"": ""4 tinggi"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00028"",
          ""context"": ""4 Cao"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00029"",
          ""context"": ""1and2and3"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00029"",
          ""context"": ""1and2and3"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00029"",
          ""context"": ""1and2and3"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00029"",
          ""context"": ""1and2and3"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00029"",
          ""context"": ""1and2and3"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00029"",
          ""context"": ""1and2and3"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00029"",
          ""context"": ""1and2and3"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00029"",
          ""context"": ""1and2and3"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00030"",
          ""context"": ""4and5and6"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00030"",
          ""context"": ""4and5and6"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00030"",
          ""context"": ""4and5and6"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00030"",
          ""context"": ""4and5and6"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00030"",
          ""context"": ""4and5and6"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00030"",
          ""context"": ""4and5and6"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00030"",
          ""context"": ""4and5and6"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 17,
          ""gameName"": ""HiLo"",
          ""betArea"": ""00030"",
          ""context"": ""4and5and6"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00001"",
          ""context"": ""撞柱"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00001"",
          ""context"": ""撞柱"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00001"",
          ""context"": ""Hit the pillar"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00001"",
          ""context"": ""ชนเสา"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00001"",
          ""context"": ""골대 맞다"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00001"",
          ""context"": ""ထပ်တူ"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00001"",
          ""context"": ""Nilai sama"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00001"",
          ""context"": ""Sút trúng khung thành"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00002"",
          ""context"": ""射中龍門"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00002"",
          ""context"": ""射中龙门"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00002"",
          ""context"": ""Hit the goals"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00002"",
          ""context"": ""ยิงเข้าเป้า"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00002"",
          ""context"": ""슛 골인"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00002"",
          ""context"": ""အလယ်မှတ်တူ"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00002"",
          ""context"": ""Gol"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00002"",
          ""context"": ""Sút vào lưới"",
          ""lang"": ""vi-VN""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00003"",
          ""context"": ""不中"",
          ""lang"": ""zh-TW""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00003"",
          ""context"": ""不中"",
          ""lang"": ""zh-CN""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00003"",
          ""context"": ""Miss the goals"",
          ""lang"": ""en-US""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00003"",
          ""context"": ""ไม่เข้าเป้า"",
          ""lang"": ""th-TH""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00003"",
          ""context"": ""노 골"",
          ""lang"": ""ko-KR""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00003"",
          ""context"": ""မတူ"",
          ""lang"": ""en-MY""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00003"",
          ""context"": ""Tidak gol"",
          ""lang"": ""id-ID""
      },
      {
          ""gameId"": 18,
          ""gameName"": ""BCSDD"",
          ""betArea"": ""00003"",
          ""context"": ""Không sút trúng"",
          ""lang"": ""vi-VN""
      }
  ],
  ""timestamp"": 1684229165
}
";
}
