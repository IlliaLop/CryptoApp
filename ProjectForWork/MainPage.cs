using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ProjectForWork
{
    public partial class MainPage : Form
    {
        private Assets assets;

        public MainPage()
        {
            InitializeComponent();
        }

        internal void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cryptingup.com/api/assets/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            using(StreamReader reader = new StreamReader(stream))
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
                for(int i = 0; i < 10; i++)
                {
                    textBox1.AppendText(Environment.NewLine + Environment.NewLine + $"Cryptocurrency: {assets.assets[i].asset_id.ToString()} - {assets.assets[i].name.ToString()}, price: {assets.assets[i].price.ToString()}$" + Environment.NewLine + Environment.NewLine);
                }    
            }

            stream.Dispose();
            response.Dispose();
        }

        internal void button1_Click(object sender, EventArgs e)
        {
            //e
            ExchangePage form2 = new ExchangePage();
            form2.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllInfo allInfo = new AllInfo();
            allInfo.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExchangesForm exchanges = new ExchangesForm();
            exchanges.ShowDialog();
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.Lavender)
            {
                BackColor = Color.DarkSlateGray;
                textBox1.BackColor = Color.SlateBlue;
                pictureBox1.BackColor = Color.LightGray;
                button1.BackColor = Color.SlateBlue;
                button2.BackColor = Color.SlateBlue;
                button3.BackColor = Color.SlateBlue;
                textBox2.BackColor = Color.SlateBlue;
                pictureBox2.BackColor = Color.LightGray;
            }
            else if (BackColor == Color.DarkSlateGray)
            {
                BackColor = Color.Lavender;
                textBox1.BackColor = Color.White;
                pictureBox1.BackColor = Color.Black;
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                pictureBox2.BackColor = Color.White;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cryptingup.com/api/assets/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream))
            {
                string sReadData = reader.ReadToEnd();
                assets = JsonConvert.DeserializeObject<Assets>(sReadData);
            }
            response.Close();
            var r = e;
            for (int i = 0; i < assets.assets.Count; i++)
            {
                if (textBox2.Text.ToLower() == assets.assets[i].name.ToLower())
                {
                    CryptoForm form = new CryptoForm($"Cryptocurrency: {assets.assets[i].asset_id.ToString()} - {assets.assets[i].name.ToString()}, price: {assets.assets[i].price.ToString()}, volume 24h {assets.assets[i].volume_24h}, change 1h: {assets.assets[i].change_1h}, change 24h: {assets.assets[i].change_24h}, change 7d: {assets.assets[i].change_7d}");
                    form.ShowDialog();
                    Close();
                }
            }

            stream.Dispose();
            response.Dispose();
        }
    }
}
