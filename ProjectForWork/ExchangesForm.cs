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

namespace ProjectForWork
{
    public partial class ExchangesForm : Form
    {
        public ExchangesForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainPage form = new MainPage();
            form.ShowDialog();
            Close();
        }

        private void Exchanges_Load(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cryptingup.com/api/exchanges");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            Exchanges exchanges = new Exchanges();
            using (StreamReader reader = new StreamReader(stream))
            {
                string sReadData = reader.ReadToEnd();
                exchanges = JsonConvert.DeserializeObject<Exchanges>(sReadData);
            }
            response.Close();
            textBox1.Text = "TOP 8 exchanges NOW";
            if (exchanges.exchanges.Count == 0)
            {
                throw new ArgumentException("exchanges cant equals 0");
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    textBox1.AppendText(Environment.NewLine + Environment.NewLine + $"Cryptocurrency: {exchanges.exchanges[i].exchange_id} - {exchanges.exchanges[i].name}, volume 24h: {exchanges.exchanges[i].volume_24h}, website: {exchanges.exchanges[i].website}" + Environment.NewLine + Environment.NewLine);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.Lavender)
            {
                BackColor = Color.DarkSlateGray;
                textBox1.BackColor = Color.SlateBlue;
                pictureBox1.BackColor = Color.LightGray;
                button3.BackColor = Color.SlateBlue;
            }
            else if (this.BackColor == Color.DarkSlateGray)
            {
                BackColor = Color.Lavender;
                textBox1.BackColor = Color.White;
                pictureBox1.BackColor = Color.Black;
                button3.BackColor = Color.White;
            }
        }
    }
}
