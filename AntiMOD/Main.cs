using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Networking;
using Grimoire.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExamplePacketPlugin
{
    public partial class Main : Form
    {
        public static Main Instance { get; } = new Main();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStart.Checked)
            {

                if (tbLogs.Lines.Length > 50)
                    tbLogs.Text = "";
                Proxy.Instance.ReceivedFromServer += CapturePlayerData;
            }
            else
            {
                Proxy.Instance.ReceivedFromServer -= CapturePlayerData;
            }
        }

        private string username = "";
        private string accessLevel = "";
        private string map = "";

        private void CapturePlayerData(Grimoire.Networking.Message message)
        {
            string msg = message.ToString();

            try
            {
                //"cmd": "initUserData"
                if (msg.Contains("\"cmd\":\"initUserData\""))
                {
                    JObject packet = (JObject)JObject.Parse(msg)["b"]["o"];
                    JObject data = (JObject)packet["data"];
                    JValue accessLevel = (JValue)data["intAccessLevel"];
                    JValue username = (JValue)data["strUsername"];

                    this.accessLevel = accessLevel?.ToString();
                    this.username = username?.ToString();
                    showLog(this.username, this.accessLevel);

                    Console.WriteLine($"Log1: {this.username} | {this.accessLevel}");
                }

                //"cmd": "initUserDatas"
                if (msg.Contains("\"cmd\":\"initUserDatas\""))
                {
                    JObject packet = (JObject)JObject.Parse(msg)["b"]["o"];
                    JArray datas = (JArray)packet["a"];

                    foreach (JObject data in datas)
                    {
                        JObject _data = (JObject)data["data"];
                        string accessLevel = _data.GetValue("intAccessLevel")?.ToString();
                        string username = _data.GetValue("strUsername")?.ToString();

                        this.accessLevel = accessLevel;
                        this.username = username;
                        showLog(this.username, this.accessLevel);

                        Console.WriteLine($"Log2: {this.username} | {this.accessLevel}");
                    }
                }

                //"cmd":"moveToArea"
                if (msg.Contains("\"cmd\":\"moveToArea\""))
                {
                    if (this.tbLogs.Lines.Length > 30)
                    {
                        clearTextLog();
                    }

                    JObject packet = (JObject)JObject.Parse(msg)["b"]["o"];
                    string areaName = packet.GetValue("areaName")?.ToString();

                    if (map != "")
                        setTextLog(Environment.NewLine);

                    this.map = areaName;
                    setTextLog($"MAP : {map.ToUpper()} {Environment.NewLine}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("MyMsg: " + msg);
                Console.WriteLine("MyError: " + e.Message);
            }
        }

        private void showLog(string username, string accessLevel)
        {
            int _accessLevel = int.Parse(accessLevel);
            string color, log = "";

            switch (_accessLevel)
            {
                case 30:
                    color = "Dark Green";
                    break;
                case 40:
                    color = "Light Green";
                    break;
                case 50:
                    color = "Purple";
                    break;
                case 60:
                    color = "Yellow";
                    break;
                default:
                    color = "Unknown";
                    break;
            }

            if (_accessLevel >= 30)
            {
                string text = $"==> [STAFF  | {_accessLevel}/{color} | {username}] <==";
                string strip = "";
                for (int i = 0; i < text.Length; i++)
                {
                    strip += "-";
                }
                log += $"{strip} {Environment.NewLine} {text} {Environment.NewLine} {strip} {Environment.NewLine}";
                modAction();
            }
            else
            {
                if (!chkModOnly.Checked)
                log += $"-Player | {_accessLevel} | {username} | {Environment.NewLine}";
            }

            setTextLog(log);
        }

        delegate void SetTextCallback(string text);
        private void setTextLog(string log)
        {
            if (this.tbLogs.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setTextLog);
                this.Invoke(d, new object[] { log });
            }
            else
            {
                this.tbLogs.Text += log;
            }
        }

        private void clearTextLog()
        {
            if (this.tbLogs.InvokeRequired)
            {
                this.tbLogs.Invoke(new Action(() => this.tbLogs.Text = ""));
            }
            else
            {
                this.tbLogs.Text = "";
            }
        }

        private async void modAction()
        {
            if (chkStopBot.Checked)
            {
                BotManager.Instance.chkEnable.Checked = false;
            }

            await Task.Delay(1000);

            if (chkLogout.Checked)
            {
                Player.Logout();
            }

            for (int i = 0; i < numBeep.Value; i++)
                Console.Beep();

        }

        private void btnModAction_Click(object sender, EventArgs e)
        {
            showLog("Username", "60");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            tbLogs.Text = "";
        }
    }
}
