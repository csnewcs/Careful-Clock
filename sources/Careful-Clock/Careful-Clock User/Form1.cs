using System;
using System.Collections;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Careful_Clock_User
{
    //https://api.myjson.com/bins/1b2lp2
    public partial class Form1 : Form
    {
        private int present = 0;
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
                Hashtable.Add(i, (int.Parse(split[0]) * 3600) + (int.Parse(split[1]) * 60));
            }
            backup = Hashtable;
            JObject restart = JObject.Parse(client.DownloadString("https://api.myjson.com/bins/ok3k1"));
            string mac = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
            try
            {
                restart[mac] = false;
            }
            catch
            {
                restart.Add(mac,false);
            }
            client.Headers.Add("Content-Type", "application/json");
            client.UploadString("https://api.myjson.com/bins/ok3k1", "Put", restart.ToString());
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Hashtable.Clear();
            string adress = "https://api.myjson.com/bins/1b2lp2";
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/json");
            string time = client.DownloadString(adress);
            JObject json = JObject.Parse(time);
            for (int i = 0; i < json.Count; i++)
            {
                string toint = json[i.ToString()].ToString();
                string[] split = toint.Split(':');
                Hashtable.Add(i, (int.Parse(split[0]) * 3600) + (int.Parse(split[1]) * 60));
            }
            if (Hashtable != backup)
            {
               timer1.Start();
                backup = Hashtable;
                present = 0;
            }
            JObject restart = JObject.Parse(client.DownloadString("https://api.myjson.com/bins/ok3k1"));
            if ((bool)restart["restart"])
            {
                Application.Restart();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int now = present;
            TimeSpan span = new TimeSpan();
            try
            {
                if (now == 0) { circularProgressBar1.Maximum = (int)Hashtable[now]; }
                else { circularProgressBar1.Maximum = (int)Hashtable[now] - (int)Hashtable[now - 1]; }
                try
                {
                    DateTime timeone = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    DateTime timetwo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)Hashtable[present] / 3600, ((int)Hashtable[present] % 3600) / 60, 0);
                    span = timetwo - timeone;
                    circularProgressBar1.Text = $"{span}";
                    if (now == 0)
                    {
                        circularProgressBar1.Value = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
                    }
                    else
                    {
                        circularProgressBar1.Value = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) - (int)Hashtable[now - 1];
                    }
                    if (circularProgressBar1.Value >= circularProgressBar1.Maximum) { int exit = int.Parse("exit!"); }
                }
                catch
                {
                    present++;
                    if (present % 2 == 0)
                    {
                        label1.Text = $"{present / 2}교시 시작까지";
                    }
                    else
                    {
                        label1.Text = $"{present / 2}교시 종료까지";
                    }
                }
            }
            catch
            {
                timer1.Stop();
                MessageBox.Show("오늘자 시간표가 끝났습니다.","끝");
            }
        }
        private void size(object sender, EventArgs e)
        {
            circularProgressBar1.Location = new Point((int)Math.Round(Size.Width * 0.036), (int)Math.Round(Size.Height * 0.01));
            int[] vs = new int[2] { (int)Math.Round(Size.Width * 0.9), (int)Math.Round(Size.Height * 0.9) };
            if (vs[0] >= vs[1])
            {
                circularProgressBar1.Size = new Size(vs[1], vs[1]);
                circularProgressBar1.Location = new Point(circularProgressBar1.Location.X + (vs[0] - vs[1]) / 2, circularProgressBar1.Location.Y);
            }
            else
            {
                circularProgressBar1.Size = new Size(vs[0], vs[0]);
                circularProgressBar1.Location = new Point(circularProgressBar1.Location.X, circularProgressBar1.Location.Y + (vs[1] - vs[0]) / 2);
            }
        }
    }
}
