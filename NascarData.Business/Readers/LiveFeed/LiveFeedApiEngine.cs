namespace NascarApi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NascarApi.Models.LiveFeed;
    using Newtonsoft.Json;

    public class LiveFeedApiEngine : ApiEngine
    {
        #region events
        public event LiveFeedEventDelegate LiveFeedEvent;
        private void OnLiveFeedEvent(LiveFeedModel model)
        {
            if (null != LiveFeedEvent)
                LiveFeedEvent.Invoke(this, new LiveFeedModelEventArgs(model));
        }
        protected override void OnApiResult(ApiFeedType feedType, string jsonResult)
        {
            if (null != LiveFeedEvent)
            {
                LiveFeedModel model = GetModel(jsonResult);
                this.OnLiveFeedEvent(model);
            }
            base.OnApiResult(feedType, jsonResult);
        }
        #endregion

        #region ctor
        public LiveFeedApiEngine(SeriesType seriesType, int raceId)
            : base(seriesType, raceId, ApiFeedType.LiveFeed )
        { }
        #endregion

        #region GetModel
        protected internal LiveFeedModel GetModel(string jsonResult)
        {
            return JsonConvert.DeserializeObject<LiveFeedModel>(jsonResult);
        }
        #endregion
    }
}
