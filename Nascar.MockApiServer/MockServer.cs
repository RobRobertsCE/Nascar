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
        private int idx = 0;
        #endregion

        private Nascar.Data.NascarDbContext _context = null;
        protected internal virtual Nascar.Data.NascarDbContext Context
        {
            get
            {
                if (null == _context)
                    _context = new NascarDbContext();

                return _context;
            }
        }

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

            DisplayMessage(String.Format("New State: [{0}]", newFormState.ToString()));
        } 
        #endregion

        #region display
        void DisplayMessage(string message)
        {
            txtDisplay.AppendText(message + Environment.NewLine);
            txtDisplay.SelectionStart = (txtDisplay.Text.Length - 1);
            txtDisplay.ScrollToCaret();
        }
        #endregion

        #region start
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        void StartServer()
        {
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
            
        }
        #endregion
    }
}
