using NascarApi.Data;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public abstract class FeedProcessor<T> : IFeedProcessor<T>
    {
        #region properties
        int runId;
        public int run_id
        {
            get { return runId; }
            protected set { runId = value; }
        }
        Run run;
        public Run Run
        {
            get
            {
                if (null == run)
                    run = GetRun();

                return run;
            }
        }

        int raceId;
        public int race_id
        {
            get { return raceId; }
            protected set { raceId = value; }
        }
        Race race = null;
        public Race Race
        {
            get
            {
                if (null == race)
                    race = GetRace();

                return race;
            }
        }

        int seriesId;
        public int series_id
        {
            get { return seriesId; }
            protected set { seriesId = value; }
        }
        Series series = null;
        public Series Series
        {
            get
            {
                if (null == series)
                    series = GetSeries();

                return series;
            }
        }

        int seasonId;
        public int season_id
        {
            get { return seasonId; }
            protected set { seasonId = value; }
        }
        Season season = null;
        public Season Season
        {
            get
            {
                if (null == season)
                    season = GetSeason();

                return season;
            }
        }

        string messageHeader = String.Empty;
        protected virtual string MessageHeader
        {
            get
            {
                if (String.IsNullOrEmpty(messageHeader))
                    messageHeader = String.Format("SeasonId:{0, -5}, SeriesId:{1, -2}, RaceId:{2, -5}, RunId{3, -3} {4}", this.season_id.ToString(), this.series_id.ToString(), this.race_id.ToString(), this.run_id.ToString(), DateTime.Now.ToString());

                return messageHeader;
            }
        }

        NascarDbContext dbcontext = null;
        protected virtual NascarDbContext Context
        {
            get
            {
                if (null == dbcontext)
                    dbcontext = new NascarDbContext();

                return dbcontext;
            }
        }
        #endregion

        #region public Process
        public void ProcessJson(string feedJson)
        {
            try
            {
                this.ProcessModel(this.GetModel(feedJson));
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }

        public abstract void ProcessModel(T model);
        #endregion

        #region ctor / init
        public FeedProcessor(int season_id, int series_id, int race_id)
        {
            this.season_id = season_id;
            this.series_id = series_id;
            this.race_id = race_id;

            this.InitializeFeedProcessor();
        }

        protected virtual void InitializeFeedProcessor()
        {

        }

        #endregion

        #region common
        protected virtual void ExceptionHandler(Exception ex)
        {
            LogMessage(ex.ToString());
        }

        protected virtual void LogMessage(string message)
        {
            Console.WriteLine(String.Format("{0}: {1}", MessageHeader, message));
        }

        #endregion

        #region data
        private Data.Run GetRun()
        {
            return this.Context.Runs.Where(r => r.race_id == this.race_id & r.run_id == this.run_id).FirstOrDefault();
        }
        private Data.Race GetRace()
        {
            return this.Context.Races.Find(this.race_id);
        }
        private Data.Series GetSeries()
        {
            return this.Context.Series.Find(this.series_id);
        }
        private Data.Season GetSeason()
        {
            return this.Context.Seasons.Find(this.season_id);
        }
        #endregion

        #region GetModel
        protected internal T GetModel(string feedJson)
        {
            return JsonConvert.DeserializeObject<T>(feedJson);
        }
        #endregion
    }
}
