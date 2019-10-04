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
        string[] url = System.IO.File.ReadAllLines("url.txt");
        public Form1()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            try
            {
                richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
            catch { }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/json");
            client.UploadString(url[0], "Put", richTextBox1.Text);
            MessageBox.Show("업로드가 완료되었습니다","끝");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            richTextBox1.Text = client.DownloadString(url[0]);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            saveFileDialog1.ShowDialog();
            try
            {
                string path = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(path, richTextBox1.Text);
            }
            catch { }
        }
    }
}
