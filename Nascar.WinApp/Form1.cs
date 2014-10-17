using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Web;
using Nascar.Models;
using Newtonsoft.Json;

namespace Nascar.WinApp
{
    public partial class Form1 : Form
    {
        string resultJson = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LiveFeedClient client = new LiveFeedClient();

            resultJson = client.GetData();

            if (!String.IsNullOrEmpty(resultJson))
            {
                Console.WriteLine(resultJson);
            }
            else
            {
                Console.WriteLine("null");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                resultJson = Properties.Resources.cup_live_feed;
                LiveFeedModel model = JsonConvert.DeserializeObject<LiveFeedModel>(resultJson);
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
