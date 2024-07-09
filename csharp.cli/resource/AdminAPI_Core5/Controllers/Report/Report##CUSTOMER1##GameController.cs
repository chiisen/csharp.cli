using APPAPI.Models.Game;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APPAPI.Controllers
{
    public partial class ReportController : BaseController
    {
        /// <summary>
        /// 取得第二層注單
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [Route("History/##CUSTOMER##")]
        [HttpPost]
        public async Task<IActionResult> Get##CUSTOMER1##GameReportHistory([FromBody] W1GetBetRecordRequestModel requestData)
        {
            if(string.IsNullOrEmpty(requestData.summary_id))
            {
                throw new ValidateException("summary_id is Null");
            }
            if (string.IsNullOrEmpty(requestData.ReportTime))
            {
                throw new ValidateException("ReportTime is Null");
            }

            var result = await this._##CUSTOMER2##ApiDataLayer.GetBetRecord(requestData);
            if (result == null || result.Result == null)
            {
                return Json(new ResponseInfoModel<List<W1GetBetRecordDataGeneral>>
                {
                    Status = ResponseCode.Failure,
                    Desc = "SYSTEM_BUSY",
                    Result = new List<W1GetBetRecordDataGeneral>(),
                    ErrorDetail = result?.ErrorDetail
                });
            }
            if (result.Result.Count == 0)
            {
                return Json(new ResponseInfoModel<List<W1GetBetRecordDataGeneral>>
                {
                    Status = ResponseCode.Failure,
                    Desc = "SYSTEM_BUSY",
                    Result = new List<W1GetBetRecordDataGeneral>(),
                    ErrorDetail = result.ErrorDetail
                });
            }
            var history = new List<W1GetBetRecordDataGeneral>();
            result.Result.ForEach(x => {
                var record = new W1GetBetRecordDataGeneral
                {
                    // 電子 r1 ~ e7，體育 r1 ~ r9，真人 r1 ~ r7
                    r1 = x.recordId,
                    r2 = x.gameId,
                    r3 = "0", // 沒有彩金
                    r4 = x.betTime,
                    r5 = x.settleTime,
                    r6 = x.betAmount,
                    r7 = x.netWin
                });

                if (!string.IsNullOrEmpty(requestData.starDick))
                {
                    string[] parts = requestData.starDick.Split(',');
                    parts.ToList().ForEach(x => {
                        string[] cmd = x.Split('=');
                        record.SetFieldValue(record, cmd[0], cmd[1]);
                    });
                }

                history.Add(record);
            });

            var resp = new ResponseInfoModel<List<W1GetBetRecordDataGeneral>>
            {
                Status = ResponseCode.Success,
                Desc = ResponseMsg.Msg[ResponseCode.Success],
                Result = history
            };
            return Json(resp);
        }
        /// <summary>
        /// 取得注單第三層報表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Detail/##CUSTOMER##")]
        [HttpPost]
        public async Task<IActionResult> Get##CUSTOMER1##GameReportDetial([FromBody] W1GetBetDetailRequestModel request)
        {
            if (string.IsNullOrEmpty(request.record_id))
            {
                throw new ValidateException("Record Id is Null");
            }

            if (string.IsNullOrEmpty(request.lang))
            {
                throw new ValidateException("Lang is Null");
            }

            if (string.IsNullOrEmpty(request.ReportTime))
            {
                throw new ValidateException("ReportTime is Null");
            }

            var result = await this._##CUSTOMER2##ApiDataLayer.GetGameReportDetial(request);

            return Json(result);
        }
    }
}