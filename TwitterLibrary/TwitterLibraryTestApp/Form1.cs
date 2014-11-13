using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitterLibrary;

namespace TwitterLibraryTestApp
{
    public partial class Form1 : Form
    {
        TwitterReader r = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == r) r = new TwitterReader();
                r.ReadHttpClient();
                r.ReadHttpWebRequest();
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
                if (null == r) r = new TwitterReader();
                this.textBox1.Text = r.DoIt();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
