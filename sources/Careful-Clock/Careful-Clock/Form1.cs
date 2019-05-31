using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Careful_Clock
{
    //https://api.myjson.com/bins/1b2lp2
    public partial class Form1 : Form
    {
        private JObject json = new JObject();
        public Form1()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string read = client.DownloadString("https://api.myjson.com/bins/1b2lp2");
            json = JObject.Parse(read);
            textBox1.Text = json[0].ToString();
            textBox2.Text = json[1].ToString();
            textBox3.Text = json[2].ToString();
            textBox4.Text = json[3].ToString();
            textBox5.Text = json[4].ToString();
            textBox6.Text = json[5].ToString();
            textBox7.Text = json[6].ToString();
            textBox8.Text = json[7].ToString();
            textBox9.Text = json[8].ToString();
            textBox10.Text = json[9].ToString();
            textBox11.Text = json[10].ToString();
            textBox12.Text = json[11].ToString();
            textBox13.Text = json[12].ToString();
            textBox14.Text = json[13].ToString();
            textBox15.Text = json[14].ToString();
            textBox16.Text = json[15].ToString();
            button1.Enabled = false;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void TextBox16_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            json[0] = textBox1.Text;
            json[1] = textBox2.Text;
            json[2] = textBox3.Text;
            json[3] = textBox4.Text;
            json[4] = textBox5.Text;
            json[5] = textBox6.Text;
            json[6] = textBox7.Text;
            json[7] = textBox8.Text;
            json[8] = textBox9.Text;
            json[9] = textBox10.Text;
            json[10] = textBox11.Text;
            json[11] = textBox12.Text;
            json[12] = textBox13.Text;
            json[13] = textBox14.Text;
            json[14] = textBox15.Text;
            json[15] = textBox16.Text;
            WebClient upload = new WebClient();
            upload.Encoding = Encoding.UTF8;
            upload.Headers.Add("Content-Type","application/json");
            upload.UploadString("https://api.myjson.com/bins/1b2lp2", "Put",json.ToString());
            button1.Enabled = false;
            MessageBox.Show("업로드가 완료되었습니다.","완료");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string read = client.DownloadString("https://api.myjson.com/bins/1b2lp2");
            json = JObject.Parse(read);
            textBox1.Text = json["0"]["시작"].ToString();
            textBox2.Text = json["0"]["끝"].ToString();
            textBox3.Text = json["1"]["시작"].ToString();
            textBox4.Text = json["1"]["끝"].ToString();
            textBox5.Text = json["2"]["시작"].ToString();
            textBox6.Text = json["2"]["끝"].ToString();
            textBox7.Text = json["3"]["시작"].ToString();
            textBox8.Text = json["3"]["끝"].ToString();
            textBox9.Text = json["4"]["시작"].ToString();
            textBox10.Text = json["4"]["끝"].ToString();
            textBox11.Text = json["5"]["시작"].ToString();
            textBox12.Text = json["5"]["끝"].ToString();
            textBox13.Text = json["6"]["시작"].ToString();
            textBox14.Text = json["6"]["끝"].ToString();
            textBox15.Text = json["7"]["시작"].ToString();
            textBox16.Text = json["7"]["끝"].ToString();
            button1.Enabled = false;
        }
    }
}
