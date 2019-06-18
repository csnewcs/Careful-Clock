﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
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
            int now = present;
            TimeSpan span = new TimeSpan();
            try
            {
                if (now == 0) { circularProgressBar1.Maximum = (int)Hashtable[now]; }
                else { circularProgressBar1.Maximum = (int)Hashtable[now] - (int)Hashtable[now - 1]; }
                try
                {
                    DateTime timeone = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    DateTime timetwo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)Hashtable[present] / 60, (int)Hashtable[present] % 60, 0);
                    span = timetwo - timeone;
                    circularProgressBar1.Text = $"{span}";
                    if (now == 0)
                    {
                        circularProgressBar1.Value = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
                    }
                    else
                    {
                        circularProgressBar1.Value = (DateTime.Now.Hour * 60 + DateTime.Now.Minute) - (int)Hashtable[now - 1];
                    }
                    if (circularProgressBar1.Value >= circularProgressBar1.Maximum) { int exit = int.Parse("exit!"); }
                }
                catch
                {
                    present++;
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
