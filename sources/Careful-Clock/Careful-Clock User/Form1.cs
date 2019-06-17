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
        private int present = 0;
        private int now = 0;
        private Hashtable Hashtable = new Hashtable();
        private Hashtable backup = new Hashtable();
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
                Hashtable.Add(i, int.Parse(split[0]) * 60 + int.Parse(split[1]) );
            }
            backup = Hashtable;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Hashtable.Clear();
            string adress = "https://api.myjson.com/bins/1b2lp2";
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string time = client.DownloadString(adress);
            JObject json = JObject.Parse(time);
            for (int i = 0; i < json.Count; i++)
            {
                string toint = json[i.ToString()].ToString();
                string[] split = toint.Split(':');
                Hashtable.Add(i, int.Parse(split[0]) * 60 + int.Parse(split[1]));
            }
            if (Hashtable != backup)
            {
                timer1.Start();
                backup = Hashtable;
                present = 0;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan();
            try
            {
                circularProgressBar1.Maximum = (int)Hashtable[present];
                try
                {
                    DateTime timeone = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    DateTime timetwo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)Hashtable[present] / 60, (int)Hashtable[present] % 60, 0);
                    span = timetwo - timeone;
                    circularProgressBar1.Value = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
                    if (circularProgressBar1.Value < 0) { int exit = int.Parse("exit!"); }
                }
                catch
                {
                    present++;
                }
                circularProgressBar1.Text = $"{span}";
            }
            catch
            {
                timer1.Stop();
                MessageBox.Show("오늘자 시간표가 끝났습니다.","끝");
            }
        }
    }
}
