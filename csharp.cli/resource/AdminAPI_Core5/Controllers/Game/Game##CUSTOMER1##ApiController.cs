using APPAPI.Common;
using APPAPI.Helper;
using APPAPI.Models;
using APPAPI.Models.Game;
using APPAPI.Models.Game.Rcg;
using APPAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPAPI.Controllers
{
    public partial class GameController : BaseController
    {
        /// <summary>
        /// ##CUSTOMER## - GetGameToken
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [Route("GetGameToken/##CUSTOMER##")]
        [HttpPost]
        public async Task<IActionResult> GetGameToken##CUSTOMER##([FromBody] ##CUSTOMER1##GetGameTokenRequestModel requestData)
        {
            if (string.IsNullOrEmpty(requestData.device))
            {
                throw new ValidateException("device is Null");
            }
            if (string.IsNullOrEmpty(requestData.lang))
            {
                throw new ValidateException("lang is Null");
            }
            if (string.IsNullOrEmpty(requestData.lobbyURL))
            {
                throw new ValidateException("lobbyURL is Null");
            }

            //3.語系要轉Royal專用
            requestData.lang = LanguageHelper.GetLangCode(GameClubNameModel.##CUSTOMER##, requestData.lang);

            var ip = _iPHelper.GetUserIp(this.HttpContext);

            var result = await this._##CUSTOMER2##ApiDataLayer.GetGameToken(requestData, ip);

            return Json(result);
        }
    }
}