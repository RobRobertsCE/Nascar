using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data;
using Nascar.Models;
using Newtonsoft.Json;

namespace Nascar.MockApiServer
{
    public partial class MockServer : Form
    {
        #region enums
        private enum FormState
        {
            None,
            Loading,
            Ready,
            Listening,
            Busy,
            Error
        }
        #endregion

        #region fields
        private int rawFeedIdx = 0;
        private IList<RawFeed> feeds = null;
        private FormState currentFormState = FormState.None;
        LiveFeedProcessor processor = null;
        #endregion

        #region properties
        private NascarDbContext _context = null;
        protected internal virtual NascarDbContext Context
        {
            get
            {
                if (null == _context)
                    _context = new NascarDbContext();

                return _context;
            }
        }
        #endregion

        #region ctor/init
        public MockServer()
        {
            InitializeComponent();
        }

        void InitializeMockServer()
        {
            SetFormState(FormState.Loading);
        }

        private void MockServer_Load(object sender, EventArgs e)
        {
            try
            {
                SetFormState(FormState.Ready);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        #endregion

        #region form state
        void SetFormState(FormState newFormState)
        {
            Color statusIndicatorColor = Color.LightGray;

            switch (newFormState)
            {
                case FormState.None:
                    {
                        btnStart.Enabled = false;
                        btnStop.Enabled = false;
                        break;
                    }
                case FormState.Loading:
                    {
                        btnStart.Enabled = false;
                        btnStop.Enabled = false;
                        break;
                    }
                case FormState.Ready:
                    {
                        statusIndicatorColor = Color.LightGray;
                        btnStart.Enabled = true;
                        btnStop.Enabled = false;
                        break;
                    }
                case FormState.Listening:
                    {
                        statusIndicatorColor = Color.LightGreen;
                        btnStart.Enabled = false;
                        btnStop.Enabled = true;
                        break;
                    }
                case FormState.Busy:
                    {
                        statusIndicatorColor = Color.LimeGreen;
                        btnStart.Enabled = false;
                        btnStop.Enabled = false;
                        break;
                    }
                case FormState.Error:
                    {
                        statusIndicatorColor = Color.Red;
                        btnStart.Enabled = false;
                        btnStop.Enabled = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            picStatusIndicator.BackColor = statusIndicatorColor;

            DisplayMessage(String.Format("State Change: [{0}] to [{1}]", currentFormState.ToString(), newFormState.ToString()));

            currentFormState = newFormState;

        }
        #endregion

        #region display
        void DisplayMessage(string message)
        {
            txtDisplay.AppendText(message + Environment.NewLine);
            txtDisplay.SelectionStart = (txtDisplay.Text.Length - 1);
            txtDisplay.ScrollToCaret();
        }
        void DisplayData(string feedData)
        {
            txtData.Text = feedData;
        }
        #endregion

        #region start
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        void StartServer()
        {
            processor = new LiveFeedProcessor();

            SetFormState(FormState.Listening);
        }
        #endregion

        #region stop
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }
        void StopServer()
        {
            SetFormState(FormState.Ready);
        }
        #endregion

        #region data
        void LoadData()
        {
            using (NascarDbContext ctx = new NascarDbContext())
            {
                feeds = ctx.RawFeeds.OrderBy(c => c.RawFeedKey).ToList();
            }
        }
        RawFeed GetNextFeed()
        {
            RawFeed data = null;
            
            DisplayMessage(String.Format("Getting Feed #{0}", rawFeedIdx.ToString()));

            if (rawFeedIdx < feeds.Count - 1)
            {
                data = feeds[rawFeedIdx];
                rawFeedIdx++;
            }
            else
            {
                throw new ArgumentException("rawFeedIdx");
            }

            return data;
        }
        #endregion

        #region live feed
        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadNextFeed();
        }
        void LoadNextFeed()
        {
            try
            {
                RawFeed feed = GetNextFeed();

                string feedData = feed.RawFeedData;

                DisplayData(feedData);

                LiveFeedModel model = GetModel(feedData);

                ProcessFeedModel(model);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "rawFeedIdx")
                {
                    DisplayMessage("End of Feeds.");
                }
                else
                {
                    DisplayMessage(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }
        LiveFeedModel GetModel(string feedData)
        {
            return JsonConvert.DeserializeObject<LiveFeedModel>(feedData);
        }
        #endregion

        #region live feed processor

        void ProcessFeedModel(LiveFeedModel model)
        {
            processor.ProcessLiveFeed(model);
        }

        #endregion
    }
}
