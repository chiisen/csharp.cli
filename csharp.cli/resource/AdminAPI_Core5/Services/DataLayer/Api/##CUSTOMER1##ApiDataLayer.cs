using APPAPI.Common;
using APPAPI.Middleware;
using APPAPI.Models;
using APPAPI.Models.Game;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace APPAPI.Services.DataLayer.Api
{
    /// <summary>
    /// ##CUSTOMER## ApiDataLayer
    /// </summary>
    public class ##CUSTOMER1##ApiDataLayer : BaseApiDataLayer
    {
        /// <summary>
        /// LogHelper
        /// </summary>
        protected LogHelper<##CUSTOMER1##ApiDataLayer> _logger;
        private RcgApiSetup _apiSetup;
        private DbConnection _dbConnection;
        private JsonSerializerOptions JsonOptions { get; set; }
        private readonly ScopedLogTemp _logScope;

        /// <summary>
        /// 建構子注入
        /// </summary>
        /// <param name="appSetting"></param>
        /// <param name="webSiteSettingService"></param>
        /// <param name="httpService"></param>
        /// <param name="commonService"></param>
        /// <param name="cacheService"></param>
        /// <param name="gameDataLayer"></param>
        /// <param name="memberDataLayer"></param>
        /// <param name="jwtService"></param>
        /// <param name="redisService"></param>
        /// <param name="w1WalletDataLayer"></param>
        /// <param name="h1WalletDataLayer"></param>
        /// <param name="unReturnAccountDataLayer"></param>
        /// <param name="webCacheDataLayer"></param>
        /// <param name="logger"></param>
        /// <param name="iServiceProvider"></param>
        /// <param name="logScope"></param>
        public ##CUSTOMER1##ApiDataLayer(
            AppSetting appSetting,
            WebSiteSettingService webSiteSettingService,
            HttpService httpService,
            CommonService commonService,
            CacheService cacheService,
            GameDataLayer gameDataLayer,
            MemberDataLayer memberDataLayer,
            JWTService jwtService,
            RedisService redisService,
            W1WalletDataLayer w1WalletDataLayer,
            H1WalletDataLayer h1WalletDataLayer,
            UnReturnAccountDataLayer unReturnAccountDataLayer,
            WebCacheDataLayer webCacheDataLayer,
            LogHelper<##CUSTOMER1##ApiDataLayer> logger,

        IServiceProvider iServiceProvider,
            ScopedLogTemp logScope)
        : base(appSetting, webSiteSettingService, httpService, commonService, cacheService, gameDataLayer, memberDataLayer,
            jwtService, redisService, h1WalletDataLayer, w1WalletDataLayer, unReturnAccountDataLayer, webCacheDataLayer,
            iServiceProvider, logScope)
        {
            this._logger = logger;
            this._thirdPartyId = GameClubNameModel.##CUSTOMER##;
            this._dbConnection = appSetting.DbConnection;
            this._w1WalletDataLayer = w1WalletDataLayer;
            this._h1WalletDataLayer = h1WalletDataLayer;
            JsonOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            _logScope = logScope;
        }

        /// <summary>
        /// ##CUSTOMER## 進線
        /// </summary>
        /// <param name="paramList"></param>
        /// <param name="clientIP"></param>
        /// <returns></returns>
        public async Task<ResponseInfoModel<UrlInfoModel<string>>> GetGameToken(##CUSTOMER1##GetGameTokenRequestModel paramList, string clientIP)
        {
            var MaintainStatus = await this._gameDataLayer.GetGameClubMaintainStatusInfo();
            var result = await this._h1WalletDataLayer.ForwardGame(this._thirdPartyId,
                MaintainStatus.##CUSTOMER1##Room_StartFlag, this._appSetting.GameEntryRoom.##CUSTOMER##,
                async () =>
                {
                    // 取得進線網址
                    var forwardGameResult =
                        await this._h1WalletDataLayer.ForwardGameH1WalletFunction(
                            new W1ForwardGameRequestModel<W1ForwardGameConfig##CUSTOMER## > ()
                    {
                        club_id = await this._jwtService.ParseToken(JwtColumn.Club_Id),
                        platform = GameClubNameModel.##CUSTOMER##,
                        game_Name = "",
                        gameConfig = new()
                        {
                            clientIP = clientIP,
                            device = paramList.device,
                            lang = paramList.lang,
                            lobbyURL = paramList.lobbyURL,
                            gameCode = paramList.gameCode
                        },
                        club_Ename = await this._jwtService.ParseToken(JwtColumn.Club_Ename),
                        franchiser_id = await this._jwtService.ParseToken(JwtColumn.Franchiser_Id),
                        currency = await this._jwtService.ParseToken(JwtColumn.ForwardGameCurrency),
                    });

                    // ##CUSTOMER## 在進線前要設定限注
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    _ = this._w1WalletDataLayer.SetLimit(this._dbConnection.daydb, GameClubNameModel.##CUSTOMER##);
                    sw.Stop();
                    this._logScope.DicStepData.Add("##CUSTOMER1##ApiDataLayer-SetLimit", sw.ElapsedMilliseconds);

                    return forwardGameResult;
                });
            return result;
        }

        /// <summary>
        /// ##CUSTOMER## 取得報表
        /// </summary>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public async Task<ResponseInfoModel<List<W1GetBetRecordData##CUSTOMER##>>>GetBetRecord(W1GetBetRecordRequestModel paramList)
        {
            var betRecordResult = await this._w1WalletDataLayer.GetBetRecord<W1GetBetRecordData##CUSTOMER##>(paramList, this._thirdPartyId);

            return betRecordResult;
        }
        /// <summary>
        /// ##CUSTOMER## 取得注單第三層報表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseInfoModel<string>> GetGameReportDetial(W1GetBetDetailRequestModel request)
        {
            var result = await this._w1WalletDataLayer.GetBetDetial<string>(request, this._thirdPartyId);

            return new ResponseInfoModel<string>()
            {
                Status = result.Status,
                Desc = result.Desc,
                Result = result.Status == ResponseCode.Success ? result.Result : null,
            };
        }
    }
}