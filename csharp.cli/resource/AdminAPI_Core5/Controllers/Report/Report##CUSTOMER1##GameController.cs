using APPAPI.Models.Game;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APPAPI.Controllers
{
    public partial class ReportController : BaseController
    {
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
    }
}