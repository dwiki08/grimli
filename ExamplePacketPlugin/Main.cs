using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Networking;
using Grimoire.UI;
using Newtonsoft.Json.Linq;
using SkillsHack;

namespace ExamplePacketPlugin
{
    public partial class Main : Form
    {
        public static Main Instance { get; } = new Main();

        public XtNoManaHandler XtNoManaHandler { get; } = new XtNoManaHandler();

        private string msgToSend;

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

        private void Append(string text, TextBox textBox)
        {
            textBox.AppendText(text + Environment.NewLine + Environment.NewLine);
        }

        private void checkIntercpt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIntercpt.Checked)
            {
                Proxy.Instance.ReceivedFromServer += ReceivedFromServerForCD;
            }
            else
            {
                Proxy.Instance.ReceivedFromServer -= ReceivedFromServerForCD;
            }
        }

        private void ReceivedFromServerForCD(Grimoire.Networking.Message message)
        {
            string msg = message.ToString();

            try
            {
                if (msg.Contains("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"sAct\""))
                {
                    msgToSend = msg;
                    setTextLog(msg);

                    JObject packet = (JObject)JObject.Parse(msg)["b"]["o"];
                    JObject actions = (JObject)packet["actions"];
                    JArray pasive = (JArray)actions["pasive"];
                    JArray active = (JArray)actions["active"];

                    foreach (JObject skill in active)
                    {
                        string cd = skill.GetValue("cd")?.ToString();
                    }

                    setNumValue(numFromA, Convert.ToDecimal(((JObject)active[0]).GetValue("cd")).ToString());
                    setNumValue(numFrom1, Convert.ToDecimal(((JObject)active[1]).GetValue("cd")).ToString());
                    setNumValue(numFrom2, Convert.ToDecimal(((JObject)active[2]).GetValue("cd")).ToString());
                    setNumValue(numFrom3, Convert.ToDecimal(((JObject)active[3]).GetValue("cd")).ToString());
                    setNumValue(numFrom4, Convert.ToDecimal(((JObject)active[4]).GetValue("cd")).ToString());

                    /*numFromA.Value = Convert.ToDecimal(((JObject)active[0]).GetValue("cd"));
                    numFrom1.Value = Convert.ToDecimal(((JObject)active[1]).GetValue("cd"));
                    numFrom2.Value = Convert.ToDecimal(((JObject)active[2]).GetValue("cd"));
                    numFrom3.Value = Convert.ToDecimal(((JObject)active[3]).GetValue("cd"));
                    numFrom4.Value = Convert.ToDecimal(((JObject)active[4]).GetValue("cd"));*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("MyMsg: " + msg);
                Console.WriteLine("MyError: " + e.Message);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (msgToSend.Length > 0)
            {
                List<string> listReplacer = new List<string>();
                listReplacer.Add(cdSkillA.Value.ToString());
                listReplacer.Add(cdSkill1.Value.ToString());
                listReplacer.Add(cdSkill2.Value.ToString());
                listReplacer.Add(cdSkill3.Value.ToString());
                listReplacer.Add(cdSkill4.Value.ToString());

                JObject msg = JObject.Parse(msgToSend);
                JObject packet = (JObject)msg["b"]["o"];
                JObject actions = (JObject)packet["actions"];
                JArray pasive = (JArray)actions["pasive"];
                JArray active = (JArray)actions["active"];

                for (int i = 0; i < listReplacer.Count; i++)
                {
                    string desc = active[i]["desc"].ToString();
                    string dmg = active[i]["damage"]?.ToString(); //ok
                    active[i]["desc"] = $"(dmg: {dmg}) {desc}";
                    active[i]["cd"] = listReplacer[i];
                    if (i == 5) active[i]["cd"] = 60000;
                    if (chkRange.Checked) active[i]["range"] = "90000";
                }

                //msgToSend = msg.ToString();
                setTextLog(msg.ToString());
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.textIntercept.Text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = this.textIntercept.Text;
            if (Player.IsLoggedIn && !string.IsNullOrEmpty(msg))
            {
                //await Proxy.Instance.SendToClient(msg);
                PacketTamperer tamperer = PacketTamperer.Instance;
                tamperer.txtSend.Text = msg;
                //tamperer.sendToClient();
                //tamperer.btnToClient.PerformClick();

                Root.Instance.ShowForm(PacketTamperer.Instance);

                //Console.WriteLine("SentMsg: " + msg);
            }
        }

        delegate void SetTextCallback(string text);
        private void setTextLog(string log)
        {
            if (this.textIntercept.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setTextLog);
                this.Invoke(d, new object[] { log });
            }
            else
            {
                this.textIntercept.Text = log;
            }
        }

        delegate void SetNumCallback(NumericUpDown num, string text);
        private void setNumValue(NumericUpDown num, string log)
        {
            if (num.InvokeRequired)
            {
                SetNumCallback d = new SetNumCallback(setNumValue);
                this.Invoke(d, new object[] { num, log });
            }
            else
            {
                num.Value = Convert.ToDecimal(log);
            }
        }

        public static string replaceBetween(string strSource, string strStart, string strEnd, List<string> replacer)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                List<string> skillList = new List<string>();
                int Start, End;
                int IndexStart = 0;

                for (int i = 0; i < replacer.Count; i++)
                {
                    Start = strSource.IndexOf(strStart, IndexStart) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    IndexStart = Start;

                    strSource = strSource.Remove(Start, End - Start);
                    strSource = strSource.Insert(Start, replacer[i]);

                    //skillList.Add(strSource.Substring(Start, End - Start));
                }

                return strSource;
            }
            return null;
        }

        public static List<string> getBetweenList(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                List<string> skillList = new List<string>();
                int Start, End;
                int IndexStart = 0;

                for (int i = 0; i <= 5; i++)
                {
                    Start = strSource.IndexOf(strStart, IndexStart) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    IndexStart = Start;
                    skillList.Add(strSource.Substring(Start, End - Start));
                }

                return skillList;
            }
            return null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            cdSkillA.Value = numFromA.Value;
            cdSkill1.Value = numFrom1.Value;
            cdSkill2.Value = numFrom2.Value;
            cdSkill3.Value = numFrom3.Value;
            cdSkill4.Value = numFrom4.Value;
        }
    }
}
