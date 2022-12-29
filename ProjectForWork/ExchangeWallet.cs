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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Lavender)
            {
                this.BackColor = Color.DarkSlateGray;
                textBox1.BackColor = Color.SlateBlue;
                textBox2.BackColor = Color.SlateBlue;
                comboBox1.BackColor = Color.SlateBlue;
                comboBox2.BackColor = Color.SlateBlue;
                pictureBox1.BackColor = Color.LightGray;
                button1.BackColor = Color.SlateBlue;
                button2.BackColor = Color.SlateBlue;
            }
            else if (this.BackColor == Color.DarkSlateGray)
            {
                this.BackColor = Color.Lavender;
                textBox1.BackColor = Color.White;
                pictureBox1.BackColor = Color.Black;
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                comboBox1.BackColor = Color.White;
                comboBox2.BackColor = Color.White;
            }
        }
    }
}
