using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nascar.WinApp.Views
{
    public partial class LapLeadersView : UserControl
    {
        #region fields
        private IList<LapLeaderViewModel> lapLeaders;
        #endregion

        #region ctor / init
        public LapLeadersView()
            : this(new List<CautionViewModel>())
        { }

        public LapLeadersView(IList<CautionViewModel> cautions)
        {
            InitializeComponent();

            InitializeLapLeadersList();
        }

        void InitializeLapLeadersList()
        {
            this.lstLapLeaders.Items.Clear();

            lapLeaders = new List<LapLeaderViewModel>();
        }
        #endregion

        #region display lap leaders
        void DisplayLapLeaders()
        {
            try
            {
                this.lstLapLeaders.SuspendLayout();

                this.lstLapLeaders.Items.Clear();

                foreach (LapLeaderViewModel leader in lapLeaders.OrderBy(l => l.NumberOfLapsLed ))
                {
                    DisplayLapLeader(leader);
                }

                UpdateCaption();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.lstLapLeaders.ResumeLayout();
            }
        }

        void DisplayLapLeader(LapLeaderViewModel leader)
        {
            this.lstLapLeaders.Items.Add(GetLapLeaderItem(leader));
        }

        ListViewItem GetLapLeaderItem(LapLeaderViewModel leader)
        {
            ListViewItem lvi = new ListViewItem(leader.CarNumber.ToString());
            lvi.Tag = leader;

            lvi.SubItems.Add(leader.NumberOfTimesLed.ToString());
            lvi.SubItems.Add(leader.NumberOfLapsLed.ToString());

            return lvi;
        }

        void UpdateCaption()
        {
            this.lblCaption.Text = String.Format("{0} Leaders", lapLeaders.Count());
        }
        #endregion

        #region public methods
        public void AddLapLeader(LapLeaderViewModel leader)
        {
            lapLeaders.Add(leader);
            DisplayLapLeaders();
        }

        public void SetLapLeaders(IList<LapLeaderViewModel> lapLeaderList)
        {
            try
            {
                InitializeLapLeadersList();

                this.lapLeaders = lapLeaderList;

                DisplayLapLeaders();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }

    public class LapLeaderViewModel
    {
        public int CarNumber { get; set; }
        public int NumberOfTimesLed { get; set; }
        public int NumberOfLapsLed { get; set; }
    }
}
