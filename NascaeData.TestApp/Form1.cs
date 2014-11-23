using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NascarApi;
using NascarApi.Models;
using NascarApi.Models.LiveFeed;
using NascarApi.Processors;
using NascarApi.Readers;

namespace NascarApi.TestApp
{
    public partial class Form1 : Form
    {
        bool isCancel = false;

        double vT = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        #region ProcessSingle
        private void button1_Click(object sender, EventArgs e)
        {
            int series_id = Convert.ToInt32(textBox1.Text);
            int race_id = Convert.ToInt32(textBox2.Text);
            int run_id = Convert.ToInt32(textBox3.Text);

            ProcessRaceRun(series_id, race_id, run_id);
        }
        #endregion

        #region LoadAllTracks
        private void btnAllTracks_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAllTracks();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void LoadAllTracks()
        {
            using (Nascar.Data.NascarDbContext sourceContext = new Nascar.Data.NascarDbContext("NascarDbContext"))
            {
                using (NascarApi.Data.NascarDbContext targetContext = new NascarApi.Data.NascarDbContext())
                {
                    foreach (Nascar.Data.Track source in sourceContext.Tracks.Where(t => t.track_id > 0))
                    {
                        if (!targetContext.Tracks.Any(r => r.track_id == source.track_id))
                        {
                            var newTarget = targetContext.Tracks.Create();

                            newTarget.track_id = source.track_id;

                            newTarget.track_length = source.track_length;
                            newTarget.track_name = source.track_name;
                            if (source.track_length < 1)
                            {
                                newTarget.track_type_id = 1;
                            }
                            else if (source.track_length < 2.4)
                            {
                                newTarget.track_type_id = 2;
                            }
                            else if (source.track_length < 2.67)
                            {
                                newTarget.track_type_id = 3;
                            }
                            else
                            {
                                newTarget.track_type_id = 4;
                            }

                            targetContext.Tracks.Add(newTarget);

                            targetContext.SaveChanges();

                            Console.WriteLine(String.Format("Added {0}", newTarget.track_name));
                        }
                    }
                }
            }
        }
        #endregion

        #region LoadAllRaces
        private void btnAllRaces_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAllRaces();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void LoadAllRaces()
        {
            using (Nascar.Data.NascarDbContext sourceContext = new Nascar.Data.NascarDbContext("NascarDbContext"))
            {
                using (NascarApi.Data.NascarDbContext targetContext = new NascarApi.Data.NascarDbContext())
                {
                    foreach (Nascar.Data.Race sourceRace in sourceContext.Races.Where(r => r.race_id > 0 && r.track_id > 0))
                    {
                        if (!targetContext.Races.Any(r => r.race_id == sourceRace.race_id))
                        {
                            var newRace = targetContext.Races.Create();

                            newRace.race_id = sourceRace.race_id;
                            newRace.is_points_race = true;
                            newRace.race_name = sourceRace.race_name;
                            newRace.season_id = 1;
                            newRace.series_id = sourceRace.series_id;
                            newRace.track_id = sourceRace.track_id;
                            newRace.race_number = sourceRace.race_id;
                            newRace.main_event_date = DateTime.Now;

                            targetContext.Races.Add(newRace);

                            targetContext.SaveChanges();

                            Console.WriteLine(String.Format("Added Race {0}", newRace.race_id));
                        }
                    }
                }
            }
        }
        #endregion

        #region ProcessAllFeedData
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                ProcessAllFeedData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void ProcessAllFeedData()
        {
            using (Nascar.Data.NascarDbContext context = new Nascar.Data.NascarDbContext("NascarDbContext"))
            {

                var groupQuery = context.RawFeedRecordViews
                    .OrderBy(r => r.series_id)
                    .ThenBy(r => r.race_id)
                    .ThenBy(r => r.run_id)
                    .GroupBy(g => new { g.series_id, g.race_id, g.run_id }).ToList();

                int idx = 0;

                foreach (var item in groupQuery)
                {
                    Console.WriteLine(String.Format("Starting #{0}: {1} {2} {3}", idx.ToString(), item.Key.series_id, item.Key.race_id, item.Key.run_id));
                    try
                    {
                        ProcessRaceRun(item.Key.series_id, item.Key.race_id, item.Key.run_id);
                    Console.WriteLine(String.Format("Completed #{0}: {1} {2} {3}", idx.ToString(), item.Key.series_id, item.Key.race_id, item.Key.run_id));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }                    
                    idx++;
                }
            }
        }
        #endregion

        #region ProcessRaceRun
        void ProcessRaceRun(int series_id, int race_id, int run_id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("{0} {1} {2}", series_id, race_id, run_id));

            IFeedProcessorT<LiveFeedModel> processor = new LiveFeedProcessor(1, series_id, race_id);

            using (Nascar.Data.NascarDbContext context = new Nascar.Data.NascarDbContext("NascarDbContext"))
            {
                int idx = 0;
               var records = context.RawFeedRecords.Where(r => r.race_id == race_id && r.run_id == run_id).OrderBy(r => r.FeedTimestamp);
                
                Stopwatch timeFeedProcess = new Stopwatch();
                foreach (Nascar.Data.RawFeedRecord item in records)
                {
                    timeFeedProcess.Start();
                    processor.ProcessJson(item.data);
                    timeFeedProcess.Stop();
                    idx++;
                    vT += timeFeedProcess.ElapsedMilliseconds;
                    string display = String.Format("Processed feed {0} of {1} (Key {2}) elapsed ms: {3}", idx.ToString(), records.Count(), item.RawFeedKey.ToString(), timeFeedProcess.ElapsedMilliseconds.ToString());
                    sb.AppendLine(display);
                    timeFeedProcess.Reset();
                }

                sb.AppendLine(String.Format("Processed {0} feeds, {1} cars. Average per feed: {2}, Average per car: {3}", records.Count().ToString(), (43 * records.Count()).ToString(), ((double)vT / records.Count()).ToString(), ((double)vT / (43 * records.Count())).ToString()));
            }

            System.IO.File.WriteAllText(String.Format("c:\\temp\\feeddata{0}_{1}_{2}.txt", series_id.ToString(), race_id.ToString(), run_id.ToString()), sb.ToString());
        }
        #endregion

        #region ApiEngineT testing
        ApiEngineT<LiveFeedModel> engine = null;
        private void btnRefactorTest_Click(object sender, EventArgs e)
        {
            try
            {
                engine = new ApiEngineT<LiveFeedModel>(SeriesType.SprintCup, 4315, ApiFeedType.LiveFeed);

                engine.ApiEngineStarted += engine_ApiEngineStarted;
                engine.ApiEngineStopped += engine_ApiEngineStopped;
                engine.ApiFeedEngineError += engine_ApiFeedEngineError;
                engine.ApiModelEvent += engine_ApiModelEvent;
                engine.ApiResult += engine_ApiResult;

                engine.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                engine.Stop();

                engine.ApiEngineStarted -= engine_ApiEngineStarted;
                engine.ApiEngineStopped -= engine_ApiEngineStopped;
                engine.ApiFeedEngineError -= engine_ApiFeedEngineError;
                engine.ApiModelEvent -= engine_ApiModelEvent;
                engine.ApiResult -= engine_ApiResult;

                engine.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void engine_ApiResult(object sender, ApiFeedType feedType, string jsonResult)
        {
            Console.WriteLine("engine_ApiResult: " + jsonResult);
        }
        void engine_ApiModelEvent(object sender, ApiModelEventArgs<LiveFeedModel> e)
        {
            Console.WriteLine("engine_ApiModelEvent: " + e.ToString());
        }
        void engine_ApiFeedEngineError(object sender, Exception e)
        {
            Console.WriteLine("engine_ApiFeedEngineError: " + e.ToString());
        }
        void engine_ApiEngineStopped(object sender, EventArgs e)
        {
            Console.WriteLine("engine_ApiEngineStopped");
        }
        void engine_ApiEngineStarted(object sender, EventArgs e)
        {
            Console.WriteLine("engine_ApiEngineStarted");
        }
        #endregion

        #region ApiSessionEngine testing
        ApiSessionEngine session;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                NascarApi.Data.Race race=null;

                using (NascarApi.Data.NascarDbContext context = new NascarApi.Data.NascarDbContext())
                {
                    race = context.Races.Where(r=>r.race_id==4319).FirstOrDefault();
                }

                session = new ApiSessionEngine(race);

                session.ApiEngineStarted += session_ApiEngineStarted;
                session.ApiEngineStopped += session_ApiEngineStopped;
                session.ApiFeedEngineError += session_ApiFeedEngineError;
                session.ApiModelReceived += session_ApiModelReceived;

                session.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                session.Stop();

                session.ApiEngineStarted -= session_ApiEngineStarted;
                session.ApiEngineStopped -= session_ApiEngineStopped;
                session.ApiFeedEngineError -= session_ApiFeedEngineError;
                session.ApiModelReceived -= session_ApiModelReceived;

                session.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void session_ApiModelReceived(object sender, IApiModelEventArgs e)
        {
            Console.WriteLine("session_ApiModelReceived: " + e.ToString());
        }
        void session_ApiFeedEngineError(object sender, Exception e)
        {
            Console.WriteLine("session_ApiFeedEngineError: " + e.ToString());
        }
        void session_ApiEngineStopped(object sender, EventArgs e)
        {
            Console.WriteLine("session_ApiEngineStopped");
        }
        void session_ApiEngineStarted(object sender, EventArgs e)
        {
            Console.WriteLine("session_ApiEngineStarted");
        }
        #endregion
    }
}
