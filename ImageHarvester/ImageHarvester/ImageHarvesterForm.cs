using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Drawing;
using HtmlAgilityPack;

namespace ImageHarvester
{
    public partial class ImageHarvesterForm : Form
    {
        IList<string> imageUrls;

        public ImageHarvesterForm()
        {
            InitializeComponent();
        }

        private void btnFindImageUrls_Click(object sender, EventArgs e)
        {
            ParseHtml();
        }

        private void btnFindFromUrl_Click(object sender, System.EventArgs e)
        {
            ParseHtmlFromUrl();
        }

        void ParseHtml()
        {
            try
            {
                if (String.IsNullOrEmpty(txtHtml.Text)) return;

                imageUrls = new List<string>();

                ParseHtmlForImageUrls(txtHtml.Text);

                DisplayImageList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void ParseHtmlFromUrl()
        {
            try
            {
                imageUrls = new List<string>();

                // Bing Image Result for Cat, First Page
                string url = txtUrl.Text;// "http://www.bing.com/images/search?q=cat&go=&form=QB&qs=n";

                // For speed of dev, I use a WebClient
                WebClient client = new WebClient();
                string html = client.DownloadString(url);

                ParseHtmlForImageUrls(html);

                DisplayImageList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void ParseHtmlForImageUrls(string html)
        {

            // Load the Html into the agility pack
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            // Now, using LINQ to get all Images
            List<HtmlNode> imageNodes = null;
            int i = 0;
            foreach (var node in doc.DocumentNode.ChildNodes)
            {
                Console.WriteLine(i.ToString() + ": " + node.Name + ":" + node.NodeType.ToString());
                if (node.NodeType == HtmlNodeType.Element)
                {
                    DebugNode(node);
                }
                i++;
            }

            //imageNodes = (from HtmlNode node in doc.DocumentNode.SelectNodes("//img")
            //              where node.Name == "img"
            //              && node.Attributes["class"] != null
            //              && node.Attributes["class"].Value.StartsWith("img_")
            //              select node).ToList();

            //foreach (HtmlNode node in imageNodes)
            //{
            //    Console.WriteLine(node.Attributes["src"].Value);
            //    imageUrls.Add(node.Attributes["src"].Value);
            //}
        }

        void DebugNode(HtmlNode node)
        {
            int x = 0;
            foreach (var enode in node.ChildNodes)
            {
                if (enode.NodeType == HtmlNodeType.Element)
                {
                    if (enode.Name=="img")
                    {
                        if (enode.Attributes.Contains("src"))
                        {
                            string imageUrl = enode.Attributes["src"].Value;
                            if (!imageUrl.EndsWith("gif"))
                            {
                                imageUrls.Add(enode.Attributes["src"].Value);                            
                            }
                        }
                    }
                    else
                    {
                        DebugNode(enode);
                    }
                }
                x++;
            }
        }

        void DisplayImageList()
        {
            try
            {
                lstPics.DataSource = imageUrls;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnDisplayImages_Click(object sender, EventArgs e)
        {
            DisplayImages();
        }

        void DisplayImages()
        {
            try
            {
                this.flpPics.Controls.Clear();

                foreach (string imageUrl in imageUrls)
                {
                    var image = GetImageFromUrl(imageUrl);
                    if (image != null)
                    {
                        var pb = GetImagePictureBox(image);
                        pb.Tag = imageUrl;
                        this.flpPics.Controls.Add(pb);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        PictureBox GetImagePictureBox(Image image)
        {
            PictureBox pb = new PictureBox();
            try
            {
                pb.Size = new Size(128, 128);
                pb.SizeMode = PictureBoxSizeMode.Normal;
                pb.Image = image;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return pb;
        }

        private Image GetImageFromUrl(string url)
        {
            HttpWebRequest httpWebRequest;

            try
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            }
            catch (System.Exception)
            {
                Console.WriteLine("ERROR LOADING " + url);
                return null;
            }
            

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }

        private void btnSaveImages_Click(object sender, System.EventArgs e)
        {
            SaveImages();
        }

        void SaveImages()
        {
            try
            {
                int i = 0;
                foreach (var pb in this.flpPics.Controls.OfType<PictureBox>())
                {
                    pb.Image.Save(String.Format("Image{0}.jpg", i.ToString()), System.Drawing.Imaging.ImageFormat.Jpeg);
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
