using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectForWork
{
    public partial class CryptoForm : Form
    {
        private string SearchingText = "";
        public CryptoForm(string searchingText)
        {
            InitializeComponent();
            SearchingText = searchingText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPage form = new MainPage();
            form.ShowDialog();
            Close();
        }

        private void CryptoForm_Load(object sender, EventArgs e)
        {
            CryptoBox.Text = SearchingText;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.Lavender)
            {
                BackColor = Color.DarkSlateGray;
                pictureBox1.BackColor = Color.LightGray;
                button2.BackColor = Color.SlateBlue;
                CryptoBox.BackColor = Color.SlateBlue;
            }
            else if (BackColor == Color.DarkSlateGray)
            {
                BackColor = Color.Lavender;
                pictureBox1.BackColor = Color.Black;
                button2.BackColor = Color.White;
                CryptoBox.BackColor = Color.SlateBlue;
            }
        }
    }
}
