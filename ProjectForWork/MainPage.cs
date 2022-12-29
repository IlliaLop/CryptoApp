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
        public MainPage()
        {
            InitializeComponent();
        }

        internal void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cryptingup.com/api/assets/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();

            var assets = new Assets();
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
        }

        internal void button1_Click(object sender, EventArgs e)
        {
            //e
            ExchangePage form2 = new ExchangePage();
            form2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllInfo allInfo = new AllInfo();
            allInfo.ShowDialog();
            this.Close();
        }
    }
}
