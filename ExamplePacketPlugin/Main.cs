using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Networking;
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

        //CD HACK SECTION
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
            if (msg.Contains("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"sAct\""))
            {
                msgToSend = msg;
                textIntercept.Text = msg;

                numFromA.Value = Convert.ToDecimal(getBetweenList(textIntercept.Text, "\"cd\":\"", "\"}")[0].ToString());
                numFrom1.Value = Convert.ToDecimal(getBetweenList(textIntercept.Text, "\"cd\":\"", "\"}")[1].ToString());
                numFrom2.Value = Convert.ToDecimal(getBetweenList(textIntercept.Text, "\"cd\":\"", "\"}")[2].ToString());
                numFrom3.Value = Convert.ToDecimal(getBetweenList(textIntercept.Text, "\"cd\":\"", "\"}")[3].ToString());
                numFrom4.Value = Convert.ToDecimal(getBetweenList(textIntercept.Text, "\"cd\":\"", "\"}")[4].ToString());
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (msgToSend.Length > 0)
            {
                string _msgToSend = msgToSend;

                List<string> listReplacer = new List<string>();
                listReplacer.Add(cdSkillA.Value.ToString());
                listReplacer.Add(cdSkill1.Value.ToString());
                listReplacer.Add(cdSkill2.Value.ToString());
                listReplacer.Add(cdSkill3.Value.ToString());
                listReplacer.Add(cdSkill4.Value.ToString());
                _msgToSend = replaceBetween(_msgToSend, "\"cd\":\"", "\"}", listReplacer);

                if (checkNoMana.Checked)
                {
                    List<string> listMp = new List<string>();
                    listMp.Add("0");
                    listMp.Add("0");
                    listMp.Add("0");
                    listMp.Add("0");
                    listMp.Add("0");
                    _msgToSend = replaceBetween(_msgToSend, "\"mp\":\"", "\",", listMp);
                }

                if (chkRange.Checked)
                {
                    List<string> listRange = new List<string>();
                    listRange.Add("900000");
                    listRange.Add("900000");
                    listRange.Add("900000");
                    listRange.Add("900000");
                    listRange.Add("900000");
                    _msgToSend = replaceBetween(_msgToSend, "\"range\":\"", "\",", listRange);

                }

                textIntercept.Text = _msgToSend;
            }
        }

        private async void btnChange_Click(object sender, EventArgs e)
        {
            if (Player.IsLoggedIn)
            {
                btnChange.Enabled = false;
                await Proxy.Instance.SendToClient(textIntercept.Text);
                btnChange.Enabled = true;
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
        private void LogCaptured(Grimoire.Networking.Message msg)
        {
            if (msg.RawContent != null && msg.RawContent.Contains("%xt%zm%gar"))
            {
                txtLog.Text = XtNoManaHandler.Log;
            }
        }

        private void chkActiveNM_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkActiveNM.Checked)
            {
                Proxy.Instance.RegisterHandler(XtNoManaHandler);
                Proxy.Instance.ReceivedFromClient += this.LogCaptured;
            }
            else
            {
                Proxy.Instance.UnregisterHandler(XtNoManaHandler);
                Proxy.Instance.ReceivedFromClient -= this.LogCaptured;
            }
        }

        private string[] listCombo;
        private void CaptureSkill(Grimoire.Networking.Message msg)
        {
            if (msg.RawContent != null && msg.RawContent.Contains("%xt%zm%gar"))
            {
                foreach(string skill in listCombo)
                {
                    Player.UseSkill(skill);
                }
            }
        }

        private void chkStartFCombo_CheckedChanged(object sender, EventArgs e)
        {
            listCombo = tbFCombo.Text.Split(';');
            if (chkStartFCombo.Checked)
            {
                Proxy.Instance.ReceivedFromClient += CaptureSkill;
            }
            else
            {
                Proxy.Instance.ReceivedFromClient -= CaptureSkill;
            }

        }
    }
}
