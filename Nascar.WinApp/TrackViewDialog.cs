using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nascar.WinApp
{
    public partial class TrackViewDialog : Form
    {
        int i = 0;

        public TrackViewDialog()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackView1.BackgroundImage = Image.FromFile(@"C:\Users\rroberts\Pictures\nascar\oval2.png");
        }

        private void trackView1_MouseMove(object sender, MouseEventArgs e)
        {
            txtXY.Text = e.Location.ToString();
        }

        private void TrackViewDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                AddPosition();
                i++;
            }
        }

        void AddPosition()
        {
            lstXY.Items.Add(String.Format("{0}:{1}", i.ToString(), txtXY.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in lstXY.Items)
            {
                sb.AppendLine(item.ToString());
            }

            System.IO.File.WriteAllText(@"c:\Path.txt", sb.ToString());
        }

        string[] lines;
        private void button3_Click(object sender, EventArgs e)
        {
            lines = System.IO.File.ReadAllLines(@"c:\Path.txt");
            lstXY.Items.Clear();

            points = new List<Point>();
            
            foreach (var line in lines)
            {
                lstXY.Items.Add(line);
                string[] data = line.Split(':');
                data[1]=data[1].Replace("{X=","");
                data[1]=data[1].Replace("Y=","");
                data[1]=data[1].Replace("}","");
                string[] pts = data[1].Split(',');
                Point p = new Point(Convert.ToInt32(pts[0]), Convert.ToInt32(pts[1]));
                points.Add(p);
            }
        }
        //5:{X=637,Y=270}
        List<Point> points;
        private void button4_Click(object sender, EventArgs e)
        {
            double totalDistance = 0;
            for (int i = 1; i < points.Count(); i++)
            {
                totalDistance += CalcDistance(points[i - 1].X, points[i - 1].Y, points[i].X, points[i].Y);
            }

            Console.WriteLine("Total Distance: " + totalDistance.ToString());
        }

        double CalcDistance(int x1, int y1, int x2, int y2)
        {
           return    Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        //Total Distance: 1476.29061044718

    }
}
