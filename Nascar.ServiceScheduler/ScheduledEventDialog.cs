using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data.Schedule;

namespace Nascar.ServiceScheduler
{
    public partial class ScheduledEventDialog : Form
    {
        public RaceEvent ScheduledEvent
        {
            get
            {
                return this.eventView1.ScheduledEvent;
            }           
        }

        public ScheduledEventDialog(RaceEvent scheduledEvent)
        {
            InitializeComponent();
            this.eventView1.ScheduledEvent = scheduledEvent;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
