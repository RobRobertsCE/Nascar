using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventLogTest
{
    public partial class Form1 : Form
    {
        private const string EventLogSource = "Rob_EventLogSource";
        private const string EventLogName = "Rob_EventLogName";
        private int eventId = 0;

        public Form1()
        {
            InitializeComponent();

            try
            {
                eventLog1 = new System.Diagnostics.EventLog();
                eventLog1.Source = EventLogSource;
                eventLog1.Log = EventLogName;
                if (!System.Diagnostics.EventLog.SourceExists(EventLogSource))
                {
                    System.Diagnostics.EventLog.CreateEventSource(
                        EventLogSource, EventLogName);
                }
             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string binData  = "Hello World";
                byte[] bin = Encoding.UTF8.GetBytes(binData);
                eventLog1.WriteEntry("Testing.", System.Diagnostics.EventLogEntryType.Information, eventId++,1,bin);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
