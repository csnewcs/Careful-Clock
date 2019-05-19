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
            client.DownloadFile("file.json","https://api.myjson.com/bins/1b2lp2");
            JObject json = JObject.Parse(System.IO.File.ReadAllText("file.json"));
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
        }
    }
}
