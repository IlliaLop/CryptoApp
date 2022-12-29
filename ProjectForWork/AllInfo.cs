using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectForWork
{
    public partial class AllInfo : Form
    {
        private Assets assets;

        public AllInfo()
        {
            InitializeComponent();
        }

        private void AllInfo_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cryptingup.com/api/assets/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                string sReadData = reader.ReadToEnd();
                assets = JsonConvert.DeserializeObject<Assets>(sReadData);
            }
            response.Close();
            textBox1.Text = "TOP 10 Cryptocurrencies NOW";
            if (assets.assets.Count == 0)
            {
                throw new ArgumentException("assets cant equals 0");
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    textBox1.AppendText(Environment.NewLine + Environment.NewLine + $"Cryptocurrency: {assets.assets[i].asset_id.ToString()} - {assets.assets[i].name.ToString()}, price: {assets.assets[i].price.ToString()}, volume 24h {assets.assets[i].volume_24h}, change 1h: {assets.assets[i].change_1h}, change 24h: {assets.assets[i].change_24h}, change 7d: {assets.assets[i].change_7d}" + Environment.NewLine + Environment.NewLine);
                }
            }
            stream.Dispose();
            response.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainPage form = new MainPage();
            form.ShowDialog();
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.Lavender)
            {
                BackColor = Color.DarkSlateGray;
                textBox1.BackColor = Color.Gainsboro;
                button1.BackColor = Color.Gainsboro;
                button2.BackColor = Color.Gainsboro;
            }
            else if (BackColor == Color.DarkSlateGray)
            {
                BackColor = Color.Lavender;
                textBox1.BackColor = Color.White;
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
            }
        }
    }
}
