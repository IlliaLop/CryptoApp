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
    public partial class ExchangePage : Form
    {
        string[] wallets = { "USD", "EURO", "UAH", "GBP" };
        decimal[] WalletsRates = { 1, 0.94m, 36.93m, 0.83m };
        string[] WalletsSign = { "$", "€", "₴", "£" };

        public ExchangePage()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cryptingup.com/api/assets/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            var assets = new Assets();
            using (StreamReader reader = new StreamReader(stream))
            {
                string sReadData = reader.ReadToEnd();
                assets = JsonConvert.DeserializeObject<Assets>(sReadData);
            }
            response.Close();
            this.WindowState = FormWindowState.Maximized;
            if (assets.assets.Count == 0)
            {
                throw new ArgumentException("assets cant equals 0");
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    comboBox1.Items.Add($"{assets.assets[i].name}");
                }
            }

            for (int i = 0; i < wallets.Length; i++)
            {
                comboBox2.Items.Add(wallets[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cryptingup.com/api/assets/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            var assets = new Assets();
            using (StreamReader reader = new StreamReader(stream))
            {
                string sReadData = reader.ReadToEnd();
                assets = JsonConvert.DeserializeObject<Assets>(sReadData);
            }
            response.Close();
            decimal sum = Convert.ToInt32(textBox1.Text) * assets.assets[comboBox1.SelectedIndex].price * WalletsRates[comboBox2.SelectedIndex];
            textBox2.Text = $"{sum}{WalletsSign[comboBox2.SelectedIndex]}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPage form = new MainPage();
            form.ShowDialog();
            this.Close();
        }
    }
}
