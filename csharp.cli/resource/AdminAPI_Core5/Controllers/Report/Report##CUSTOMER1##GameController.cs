﻿using APPAPI.Models.Game;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APPAPI.Controllers
{
    public partial class ReportController : BaseController
    {
        /// <summary>
        /// EGSLOT 第二層注單
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

            return Json(result);
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