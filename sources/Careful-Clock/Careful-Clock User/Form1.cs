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
            Hashtable hashtable = new Hashtable();

        }
    }
}
