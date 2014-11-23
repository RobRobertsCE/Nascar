namespace NascarApi
{
    using System;
    using System.Collections.Generic;
    using NascarApi.Data;
    using NascarApi.Models;
    using NascarApi.Models.Flag;
    using NascarApi.Models.Leaderboard;
    using NascarApi.Models.LiveFeed;
    using NascarApi.Models.Points;
    using NascarApi.Models.Qualifying;
    using NascarApi.Models.Weather;
    using NascarApi.Processors;
    using NascarApi.Readers;

    public class ApiSessionEngine : IDisposable
    {
        #region events
        public event ApiEngineStartedDelegate ApiEngineStarted;
        protected virtual void OnApiEngineStarted()
        {
            if (null != ApiEngineStarted)
            {
                ApiEngineStarted(this, EventArgs.Empty);
            }
        }

        public event ApiEngineStoppedDelegate ApiEngineStopped;
        protected virtual void OnApiEngineStopped()
        {
            if (null != ApiEngineStopped)
            {
                ApiEngineStopped(this, EventArgs.Empty);
            }
        }

        public event ApiEngineErrorDelegate ApiFeedEngineError;
        protected virtual void OnApiFeedEngineError(Exception ex)
        {
            if (null != ApiFeedEngineError)
            {
                ApiFeedEngineError(this, ex);
            }
        }

        public event IApiModelEventDelegate ApiModelReceived;
        protected virtual void OnApiModelReceived(IApiModel model)
        {
            if (null != ApiModelReceived)
            {
                ApiModelReceived(this, new IApiModelEventArgs(model));
            }
        }
        #endregion

        #region fields
        protected int raceId;
        protected int seriesId;
        protected int season;
        protected IList<IApiEngine> engines;
        protected IDictionary<ApiFeedType, IFeedProcessor> processors;
        #endregion

        #region public properties
        public Race Race { get; protected set; }
        public SessionType SessionType { get; protected set; }
        public bool ProcessFeeds { get; set; }
        #endregion

        #region ctor
        public ApiSessionEngine(Race race)
            : this(race, SessionType.Any)
        { }
        public ApiSessionEngine(Race race, SessionType sessionType)
        {
            this.Race = race;
            this.SessionType = sessionType;

            InitializeApiSession();
        }
        protected virtual void InitializeApiSession()
        {
            this.raceId = Race.race_id;
            this.seriesId = Race.series_id;
            this.season = Race.season_id;

            this.InitializeApiEngines();
            this.InitializeProcessors();

        }
        protected virtual void InitializeApiEngines()
        {
            engines = new List<IApiEngine>();
            SeriesType series = (SeriesType)this.seriesId;

            engines.Add(new ApiEngineT<FlagModel>(series, this.raceId, ApiFeedType.LiveFlag));
            engines.Add(new ApiEngineT<LeaderboardModel>(series, this.raceId, this.season, this.SessionType));
            engines.Add(new ApiEngineT<LiveFeedModel>(series, this.raceId, ApiFeedType.LiveFeed));
            engines.Add(new ApiEngineT<PointsModel>(series, this.raceId, ApiFeedType.LivePoints));
            engines.Add(new ApiEngineT<QualifyingModel>(series, this.raceId, ApiFeedType.LiveQualifying));
            engines.Add(new ApiEngineT<WeatherUndergroundModel>(series, this.raceId, ApiFeedType.LiveWeather));

            AddHandlers();
        }      
        protected virtual void InitializeProcessors()
        {
            processors = new Dictionary<ApiFeedType, IFeedProcessor>();

            processors.Add(ApiFeedType.LiveFlag, new FlagFeedProcessor(this.season, this.seriesId, this.raceId));
            processors.Add(ApiFeedType.Leaderboard, new LeaderboardFeedProcessor(this.season, this.seriesId, this.raceId));
            processors.Add(ApiFeedType.LiveFeed, new LiveFeedProcessor(this.season, this.seriesId, this.raceId));
            processors.Add(ApiFeedType.LivePoints, new PointsFeedProcessor(this.season, this.seriesId, this.raceId));
            processors.Add(ApiFeedType.LiveQualifying, new QualifyingFeedProcessor(this.season, this.seriesId, this.raceId));
            processors.Add(ApiFeedType.LiveWeather, new WeatherFeedProcessor(this.season, this.seriesId, this.raceId));
        }
        #endregion

        #region ExceptionHandler
        protected virtual void ExceptionHandler(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            this.OnApiFeedEngineError(ex);
        }
        #endregion

        #region engine event handlers
        protected virtual void engine_ApiFeedEngineError(object sender, Exception e)
        {
            try
            {
                this.ExceptionHandler(e);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        protected virtual void engine_ApiEngineStopped(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(String.Format("{0} ApiEngine Stopped.", ((IApiEngine)sender).Feed.ToString()));
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        protected virtual void engine_ApiEngineStarted(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(String.Format("{0} ApiEngine Started.", ((IApiEngine)sender).Feed.ToString()));
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        protected virtual void engine_ApiModelReceived(object sender, IApiModelEventArgs e)
        {
            this.OnApiModelReceived(e.Model);
        }
        void engine_ApiResult(object sender, ApiFeedType feedType, string jsonResult)
        {
            try
            {
                processors[feedType].ProcessJson(jsonResult);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        #endregion

        #region public start / stop
        public virtual void Start()
        {
            StartApiEngines();
        }
        public virtual void Stop()
        {
            StopApiEngines();
        }
        #endregion

        #region protected methods
        protected virtual void AddHandlers()
        {
            foreach (IApiEngine engine in engines)
            {
                engine.ApiEngineStarted += engine_ApiEngineStarted;
                engine.ApiEngineStopped += engine_ApiEngineStopped;
                engine.ApiFeedEngineError += engine_ApiFeedEngineError;
                engine.ApiModelReceived += engine_ApiModelReceived;
                engine.ApiResult += engine_ApiResult;
            }
        }      
        protected virtual void RemoveHandlers()
        {
            foreach (IApiEngine engine in engines)
            {
                engine.ApiEngineStarted -= engine_ApiEngineStarted;
                engine.ApiEngineStopped -= engine_ApiEngineStopped;
                engine.ApiFeedEngineError -= engine_ApiFeedEngineError;
                engine.ApiModelReceived -= engine_ApiModelReceived;
                engine.ApiResult -= engine_ApiResult;
            }
        }
        protected virtual void StartApiEngines()
        {
            foreach (IApiEngine engine in engines)
            {
                engine.Start();
            }
        }
        protected virtual void StopApiEngines()
        {
            foreach (IApiEngine engine in engines)
            {
                engine.Stop();
            }
        }
        #endregion

        #region dispose
        public void Dispose()
        {
            if (null!=engines)
            {
                this.RemoveHandlers();
                engines = null;
            }
        }
        #endregion
    }
}
