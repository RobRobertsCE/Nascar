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
    public partial class CautionsView : UserControl
    {
        #region fields
        private IList<CautionViewModel> cautions;
        #endregion

        #region ctor / init
        public CautionsView()
            : this(new List<CautionViewModel>())
        { }

        public CautionsView(IList<CautionViewModel> cautions)
        {
            InitializeComponent();

            InitializeCautionsList();
        }

        void InitializeCautionsList()
        {
            this.lstCautions.Items.Clear();

            cautions = new List<CautionViewModel>();
        }
        #endregion

        #region display cautions
        void DisplayCautions()
        {
            try
            {
                this.lstCautions.SuspendLayout();

                this.lstCautions.Items.Clear();

                foreach (CautionViewModel caution in cautions.OrderBy(c => c.LapNumber))
                {
                    DisplayCaution(caution);
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
                this.lstCautions.ResumeLayout();
            }
        }

        void DisplayCaution(CautionViewModel caution)
        {
            this.lstCautions.Items.Add(GetCautionItem(caution));
        }

        ListViewItem GetCautionItem(CautionViewModel caution)
        {
            ListViewItem lvi = new ListViewItem(caution.LapNumber.ToString());
            lvi.Tag = caution;

            lvi.SubItems.Add(caution.Note);
            lvi.SubItems.Add(caution.Laps.ToString());
            lvi.SubItems.Add(caution.Beneficiary);
            return lvi;
        }

        void UpdateCaption()
        {
            this.lblCaption.Text = String.Format("{0} Cautions for {1} Laps", cautions.Count(), cautions.Sum(c => c.Laps));
        }
        #endregion

        #region public methods
        public void AddCaution(CautionViewModel caution)
        {
            cautions.Add(caution);
            DisplayCautions();
        }

        public void SetFlagStates(IList<Nascar.Data.FlagState> flagStates)
        {
            try
            {
                InitializeCautionsList();

                foreach (Nascar.Data.FlagState cautionFlagState in flagStates.Where(s => (FlagState)s.flag_state == FlagState.Yellow).OrderBy(s => s.lap_number))
                {
                    CautionViewModel cautionModel = new CautionViewModel() { LapNumber = cautionFlagState.lap_number };

                    cautionModel.Beneficiary = cautionFlagState.beneficiary;
                    cautionModel.Note = cautionFlagState.comment;
                    cautionModel.ElapsedTime = cautionFlagState.elapsed_time;
                    cautionModel.TimeOfDay = cautionFlagState.time_of_day;

                    var greenFlag = flagStates.OrderBy(s => s.lap_number).Where(s => s.lap_number > cautionModel.LapNumber && (FlagState)s.flag_state == FlagState.Green).FirstOrDefault();

                    if (null != greenFlag)
                        cautionModel.Laps = greenFlag.lap_number - cautionModel.LapNumber;
                    else
                        cautionModel.Laps = -1;

                    cautions.Add(cautionModel);
                }

                DisplayCautions();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }

    public class CautionViewModel
    {
        public int LapNumber { get; set; }
        public int Laps { get; set; }
        public string Beneficiary { get; set; }
        public string Note { get; set; }
        public double ElapsedTime { get; set; }
        public double TimeOfDay { get; set; }

    }
}
