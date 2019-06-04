using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edit_Schedule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/json");
            client.UploadString("https://api.myjson.com/bins/1b2lp2", "Put", richTextBox1.Text);
            MessageBox.Show("업로드가 완료되었습니다","끝");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            richTextBox1.Text = client.DownloadString("https://api.myjson.com/bins/1b2lp2");
        }
    }
}
