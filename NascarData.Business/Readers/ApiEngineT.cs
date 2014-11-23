namespace NascarApi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NascarApi.Models;
    using Newtonsoft.Json;

    public class ApiEngineT<T> : ApiEngine
    {
        #region events
        public event IApiModelEventDelegate ApiModelReceived;
        protected virtual void OnApiModelReceived(IApiModel model)
        {
            if (null != ApiModelReceived)
            {
                ApiModelReceived(this, new IApiModelEventArgs(model));
            }
        }

        public event ApiModelEventDelegate<T> ApiModelEvent;
        private void OnApiModelEvent(T model)
        {
            if (null != ApiModelEvent)
                ApiModelEvent.Invoke(this, new ApiModelEventArgs<T>(model));
        }
        protected override void OnApiResult(ApiFeedType feedType, string jsonResult)
        {
            if (null != ApiModelEvent)
            {
                T model = GetModel(jsonResult);
                this.OnApiModelEvent(model);
            }
            base.OnApiResult(feedType, jsonResult);
        }
        #endregion

        #region ctor
        public ApiEngineT(SeriesType seriesType, int raceId, ApiFeedType feedType)
            : base(seriesType, raceId, feedType)
        { }
        public ApiEngineT(SeriesType seriesType, int raceId, int season, SessionType sessionType)
            : base(seriesType, raceId, season, sessionType)
        { }
        #endregion

        #region GetModel
        protected internal T GetModel(string jsonResult)
        {
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }
        #endregion
    }
}
