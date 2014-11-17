using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.WinApp.Views;

namespace Nascar.WinApp
{
    public partial class CautionLightDialog : Form
    {
        public CautionLightDialog()
        {
            InitializeComponent();
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbG.Checked)
            {
                this.cautionLightView1.LightState = CautionLightState.Green;
            }
            else if (rbY.Checked)
            {
                this.cautionLightView1.LightState = CautionLightState.Yellow;
            }
            else if (rbR.Checked)
            {
                this.cautionLightView1.LightState = CautionLightState.Red;
            }
            else if (rbO.Checked)
            {
                this.cautionLightView1.LightState = CautionLightState.Off;
            }
        }
    }
}
