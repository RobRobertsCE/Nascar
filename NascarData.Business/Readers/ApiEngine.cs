namespace NascarApi.Readers
{
    using System;
    using System.Timers;
    using NascarApi.Models;
    using Newtonsoft.Json;

    public abstract class ApiEngine
        : IApiEngine, IDisposable
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

        public event ApiResultDelegate ApiResult;
        protected virtual void OnApiResult(ApiFeedType feedType, string jsonResult)
        {
            if (null != ApiResult)
            {
                ApiResult(this, feedType, jsonResult);
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

        #region consts
        const double DefaultTimerInterval = 60000;
        #endregion

        #region fields
        private double timerInterval = DefaultTimerInterval;

        private IApiClient apiClient = null;
        private Timer apiClientTimer = null;
        #endregion

        #region public properties
        public int RaceId { get; protected internal set; }
        public SeriesType Series { get; protected internal set; }
        public ApiFeedType Feed { get; protected set; }
        public double TimerInterval
        {
            get
            {
                return timerInterval;
            }
            set
            {
                if (timerInterval == value) return;
                timerInterval = value;
                if (TimerIsRunning)
                {
                    InitializeTimer();
                }
            }
        }
        public ApiEngineState State { get; protected set; }
        #endregion

        #region protected properties
        protected internal bool TimerIsRunning
        {
            get
            {
                if (null == apiClientTimer || !apiClientTimer.Enabled)
                    return false;
                else
                    return true;
            }
        }
        #endregion

        #region ctor/init
        public ApiEngine(SeriesType seriesType, int raceId, ApiFeedType feedType)
        {
            if (feedType == ApiFeedType.Leaderboard)
                throw new InvalidOperationException("Use ApiEngine Ctor with season and sessionType params for leaderboard feed.");

            this.Series = seriesType;
            this.RaceId = raceId;
            this.Feed = feedType;

            apiClient = ApiClientFactory.GetApiClient(this.Series, this.RaceId, this.Feed);
            apiClient.DataReceived += ApiDataReceived;

            this.State = ApiEngineState.Ready;
        }
        public ApiEngine(SeriesType seriesType, int raceId, int season, SessionType sessionType)
        {
            this.Series = seriesType;
            this.RaceId = raceId;
            this.Feed = ApiFeedType.Leaderboard;

            apiClient = ApiClientFactory.GetApiLeaderboardClient(this.Series, this.RaceId, season, sessionType);
            apiClient.DataReceived += ApiDataReceived;

            this.State = ApiEngineState.Ready;
        }
        #endregion

        #region exception handler
        protected virtual void ExceptionHandler(Exception ex)
        {
            this.OnApiFeedEngineError(ex);
        }
        #endregion

        #region timer methods
        protected internal void InitializeTimer()
        {
            if (TimerIsRunning)
            {
                Stop();
                apiClientTimer.Dispose();
            }
            apiClientTimer = new Timer(TimerInterval);
            apiClientTimer.Elapsed += apiClientTimer_Elapsed;
        }
        protected internal void RestartTimer()
        {
            if (null == apiClientTimer)
            {
                InitializeTimer();
            }
            else if (TimerIsRunning)
            {
                Stop();
            }

            Start();
        }
        protected internal void apiClientTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.RequestApiData();
        }
        #endregion

        #region public methods
        public void Start()
        {
            try
            {
                if (null == this.apiClientTimer)
                {
                    this.InitializeTimer();
                }
                else if (this.TimerIsRunning)
                    return;

                this.apiClientTimer.Start();

                this.OnApiEngineStarted();

                this.RequestApiData();

                this.State = ApiEngineState.Running;
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        public void Stop()
        {
            try
            {
                if (null != this.apiClientTimer && this.TimerIsRunning)
                {
                    this.apiClientTimer.Stop();
                }

                this.OnApiEngineStopped();
                
                this.State = ApiEngineState.Ready;
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }        
        #endregion

        #region ApiData Request/Receive
        protected virtual void RequestApiData()
        {
            try
            {
                apiClient.BeginGetDataAsync();
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }

        }
        void ApiDataReceived(object sender, ApiFeedType feedType, string jsonResult)
        {
            try
            {
                this.NotifyListeners(feedType, jsonResult);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }
        protected virtual void NotifyListeners(ApiFeedType feedType, string jsonResult)
        {
            try
            {
                this.OnApiResult(feedType, jsonResult);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }

        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            if (null != apiClientTimer)
            {
                apiClientTimer.Stop();
                apiClientTimer.Dispose();
            }
            if (apiClient != null)
            {
                apiClient.DataReceived -= ApiDataReceived;
                apiClient.Dispose();
            }
        }
        #endregion
    }
}
