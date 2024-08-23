#nullable disable // 臨時禁用可為 null 的參考型別檢查

using Coravel.Invocable;
using H1WalletAPI.Common.Helper;
using H1WalletAPI.Common.Repository.H1.Request;
using H1WalletAPI.Common.Repository.H1.Response;
using H1WalletAPI.Common.Service.Request;
using H1WalletAPI.Common.Service.Response;
using H1WalletAPI.Interface.Service;
using Newtonsoft.Json;
using System.Diagnostics;

namespace H1WalletAPI.Schedule;

/// <summary>
/// 從 W1 拉 5 分鐘匯總帳
/// </summary>
public class ##CUSTOMER##BetSummarySchedule : IInvocable
{
    private readonly IW1Service _w1Service;
    private readonly IH1WalletService _h1WalletService;
    private readonly LogHelper<##CUSTOMER##BetSummarySchedule> _logger;
    private readonly IBetSummaryService2 _betSummaryService2;
    private readonly IDuplicateCheckService _duplicateCheckService;
    private static readonly string ThirdParty_Id = "##CUSTOMER##"; // 指定廠商代號
    private readonly string _key = $"{ThirdParty_Id}BetSummary";    // T_SystemParameters 的 Key

    /// <summary>
    /// 
    /// </summary>
    /// <param name="w1Service"></param>
    /// <param name="h1WalletService"></param>
    /// <param name="logger"></param>
    /// <param name="betSummaryService2"></param>
    /// <param name="buDuplicateCheckService"></param>
    public ##CUSTOMER##BetSummarySchedule(IW1Service w1Service, IH1WalletService h1WalletService, LogHelper<##CUSTOMER##BetSummarySchedule> logger, IBetSummaryService2 betSummaryService2, IDuplicateCheckService buDuplicateCheckService)
    {
        _w1Service = w1Service;
        _h1WalletService = h1WalletService;
        _logger = logger;
        _betSummaryService2 = betSummaryService2;
        _duplicateCheckService = buDuplicateCheckService;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task Invoke()
    {
        // 排程開關
        var scheduleSwitch = await _h1WalletService.GetScheduleSwitchAsync(new GetSystemParameterRequest()
        {
            Param_key = $"{ThirdParty_Id}BetSummarySwitch"
        });

        if (!scheduleSwitch) return;

        var responseList = new List<GetBetSummaryServiceResponse>();
        var sw = new Stopwatch();

        try
        {
            // 取得同步錢包異動紀錄的時間基準
            var parameterResponse = await _h1WalletService.GetSystemParameterAsync(new GetSystemParameterRequest()
            {
                Param_key = _key
            });

            // 檢查有無資料，沒資料的話新增預設值
            if (parameterResponse == null)
            {
                var model = new AddSystemParameterRequest()
                {
                    Param_key = _key,
                    Param_value = "",
                    Param_name = "注單匯總紀錄",
                    Descption = "紀錄排程時間基準點",
                    Min_value = DateTime.Now.AddMinutes(-8).Ticks.ToString(),   // 將 Ticks 轉成 String 存進 DB
                    Max_value = DateTime.Now.AddMinutes(-6).Ticks.ToString(),   // 將 Ticks 轉成 String 存進 DB
                };

                var addResult = await _h1WalletService.AddSystemParameterAsync(model);
                if (addResult)
                {
                    parameterResponse = JsonConvert.DeserializeObject<GetSystemParameterResponse>(JsonConvert.SerializeObject(model));
                }
                else
                {
                    return; // 新增失敗就結束排程
                }
            }
            else
            {
                var ticks = long.Parse(parameterResponse.Max_value);
                var startTime = new DateTime(ticks).AddTicks(1);
                var endTime = startTime.AddMinutes(1);
                parameterResponse.Min_value = startTime.Ticks.ToString();
                parameterResponse.Max_value = endTime.Ticks.ToString();
            }

            // 起始時間不可以小於結束時間
            if (new DateTime(long.Parse(parameterResponse.Min_value)) > new DateTime(long.Parse(parameterResponse.Max_value))) return;
            // 結束時間不可以大於現在時間 -6 分鐘
            if (new DateTime(long.Parse(parameterResponse.Max_value)) > DateTime.Now.AddMinutes(-6)) return;

             // 呼叫 W1 取得注單匯總紀錄
             responseList = await _w1Service.GetBetSummaryAsync(new GetBetSummaryServiceRequest()
            {
                StartTime = new DateTime(long.Parse(parameterResponse.Min_value)),
                EndTime = new DateTime(long.Parse(parameterResponse.Max_value)),
                SearchType = 2,  // 1:ReportTime 2:UpdateTime
                game_id = $"{ThirdParty_Id}"
             });

            // 確保只有特定的 ThirdParty_Id
            responseList = responseList
                 .Where(x => x.game_id.ToUpper() == $"{ThirdParty_Id}")
                 .ToList();

            // 更新排程時間基準
            await _h1WalletService.UpdateSystemParameterAsync(new UpdateSystemParameterRequest
            {
                Param_key = parameterResponse.Param_key,
                Param_value = parameterResponse.Param_value,
                Param_name = parameterResponse.Param_name,
                Descption = parameterResponse.Descption,
                Min_value = parameterResponse.Min_value,
                Max_value = parameterResponse.Max_value,
            });

            if (!responseList.Any()) return;

            sw.Start();

            var list = responseList
                .Where(x => _duplicateCheckService.AddCheck(x.id + x.game_id))
                .Select(x => new AddBetSummaryRequest()
                {
                    id = x.id,
                    club_id = x.club_id,
                    franchiser_id = x.franchiser_id,
                    game_id = x.game_id,
                    game_type = x.game_type,
                    bet_type = x.bet_type,
                    bet_amount = x.bet_amount,
                    turnover = x.turnover,
                    win = x.win,
                    netwin = x.netwin,
                    jackpotWin = x.jackpotWin,
                    reportDatetime = x.reportDatetime,
                    currency = x.currency,
                    recordCount = x.recordCount
                }).ToList();

            _logger.ScheduleLog($"{ThirdParty_Id}BetSummarySchedule", responseList.Count.ToString(), "Start");

            await _betSummaryService2.AddBetSummaryHandlerAsync(list);

            sw.Stop();
            _logger.ScheduleLog($"{ThirdParty_Id}BetSummarySchedule", null, "End", sw.ElapsedMilliseconds);
        }
        catch (AggregateException error)
        {
            sw.Stop();

            foreach (Exception item in error.InnerExceptions)
            {
                _logger.ScheduleErrorLog(item, $"{ThirdParty_Id}BetSummarySchedule", responseList.Count.ToString(), "fail", sw.ElapsedMilliseconds);
            }
        }
        catch (Exception ex)
        {
            sw.Stop();
            _logger.ScheduleErrorLog(ex, $"{ThirdParty_Id}BetSummarySchedule", responseList.Count.ToString(), "fail", sw.ElapsedMilliseconds);
        }
    }
}