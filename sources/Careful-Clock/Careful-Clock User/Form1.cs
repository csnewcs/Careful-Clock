using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Careful_Clock_User
{
    //https://api.myjson.com/bins/1b2lp2
    public partial class Form1 : Form
    {
        int test = 0;
        private Hashtable Hashtable = new Hashtable();
        private int[] timer = new int[] { };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string adress = "https://api.myjson.com/bins/1b2lp2";
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string time = client.DownloadString(adress);
            JObject json = JObject.Parse(time);
            for (int i = 0;i < json.Count ;i++)
            {
                string toint = json[i.ToString()].ToString();
                string[] split = toint.Split(':');
                Hashtable.Add(i.ToString(), int.Parse(split[0]) * 60 + int.Parse(split[1]) );
            }
            this.timer = new int[json.Count];
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Hashtable = new Hashtable();
            string adress = "https://api.myjson.com/bins/1b2lp2";
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string time = client.DownloadString(adress);
            JObject json = JObject.Parse(time);
            for (int i = 0; i < json.Count; i++)
            {
                string toint = json[i.ToString()].ToString();
                string[] split = toint.Split(':');
                Hashtable.Add(i.ToString(), int.Parse(split[0]) * 60 + int.Parse(split[1]));
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value = test;
            test++;
        }
    }
}
