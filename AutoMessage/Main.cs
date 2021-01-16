using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Networking;

namespace ExamplePacketPlugin
{
    public partial class Main : Form
    {
        public static Main Instance { get; } = new Main();

        public Main()
        {
            InitializeComponent();
        }

        public JoinHandler Handler { get; } = new JoinHandler();

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        List<string> listLogNick = new List<string>();
        List<string> listException = new List<string>();

        private void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            string[] listNick = tbNickExceptiona.Text.Split(';');
            foreach (string ni in listNick)
            {
                listException.Add(ni.ToLower());
            }

            if (chkStart.Checked)
            {
                Proxy.Instance.ReceivedFromServer += ReceivedFromServer;
            }
            else
            {
                Proxy.Instance.ReceivedFromServer -= ReceivedFromServer;
            }
        }

        private void ReceivedFromServer(Grimoire.Networking.Message message)
        {
            string msg = message.ToString();
            if (chkStart.Checked && msg.Contains("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"uotls\",\"o\":"))
            {
                string guest = getBetweenList(msg, "\"strUsername\":\"", "\"");
                SendMessage(guest, txtMessager.Text, listException);
            }
        }

//=======================================================================================================================-

        List<string> listTrigger = new List<string>();
        List<string> listResponse = new List<string>();
        List<string> listException2 = new List<string>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string trigger = tbTrigger.Text;
            string response = tbResponse.Text;
            tbListTR.Text = tbListTR.Text + trigger + "|" + response + ";";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRep.Checked)
            {
                listTrigger.Clear();
                listResponse.Clear();
                listException2.Clear();

                string[] listTr = tbListTR.Text.Split(';');
                foreach(string l in listTr) {
                    if (l.Length < 2) continue;
                    string trigger = l.Split('|')[0];
                    listTrigger.Add(trigger);
                }

                foreach (string l in listTr)
                {
                    if (l.Length < 2) continue;
                    string response = l.Split('|')[1];
                    listResponse.Add(response);
                }

                string[] listNick = tbNickException.Text.Split(';');
                foreach (string ni in listNick)
                {
                    listException2.Add(ni.ToLower());
                }

                Proxy.Instance.ReceivedFromServer += ReceivedFromServer2;
            }
            else
            {
                Proxy.Instance.ReceivedFromServer -= ReceivedFromServer2;
            }
        }

        private void ReceivedFromServer2(Grimoire.Networking.Message message)
        {
            string msg = message.ToString();
            if (chkAutoRep.Checked && msg.Contains("%xt%chatm%"))
            {
                string chat = msg.Split('%')[4].Substring(5);
                string nick = msg.Split('%')[5].ToLower();

                if (nick == "remake")
                {
                    if (chat == "cuki")
                    {
                        SendMessage("", "pukii", new List<string>());
                    }
                    else if (chat == "remake kawaii")
                    {
                        SendMessage("", "WANGY WANGY WANGYYY >//<", new List<string>());
                    }
                    else
                    {
                        for (int i = 0; i < listTrigger.Count; i++)
                        {
                            if (listTrigger[i] == chat)
                            {
                                SendMessage(nick, listResponse[i], listException2);
                            }
                        }
                    };
                } 
                else
                {
                    for (int i = 0; i < listTrigger.Count; i++)
                    {
                        if (listTrigger[i] == chat)
                        {
                            SendMessage(nick, listResponse[i], listException2);
                        }
                    }
                }
            }
        }


        private async void SendMessage(string guest, string text, List<string> listException)
        {
            if (guest == null) return;
            string textMsg = text;
            textMsg = textMsg.Replace("{GUEST}", guest);

            if (!listException.Contains(guest.ToLower()))
            {
                if (radWorld.Checked)
                {
                    await Proxy.Instance.SendToServer("%xt%zm%message%1%" + textMsg + "%zone%"); //world
                    await Task.Delay(1000);
                }

                if (radWhisper.Checked)
                {
                    await Proxy.Instance.SendToServer("%xt%zm%whisper%1%" + textMsg + "%" + guest + "%"); //whisper
                    await Task.Delay(1000);
                }

                if (guest != "" || guest != null)
                {
                    listLogNick.Add(guest);
                    int count = 0;
                    foreach (string nick in listLogNick)
                    {
                        if (nick == guest) count += 1;
                    }

                    if (count >= numMaxResp.Value)
                    {
                        setText1(guest);
                        setText2(guest);
                    }
                }
            }
        }

        delegate void SetTextCallback(string text);
        private void setText1(string nick)
        {
            this.listException.Add(nick);
            if (this.tbNickException.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText1);
                this.Invoke(d, new object[] { nick });
            }
            else
            {
                this.tbNickException.Text = tbNickException.Text + nick + ";";
            }
        }

        private void setText2(string nick)
        {
            this.listException2.Add(nick);
            if (this.tbNickExceptiona.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText2);
                this.Invoke(d, new object[] { nick });
            }
            else
            {
                this.tbNickExceptiona.Text = tbNickExceptiona.Text + nick + ";";
            }
        }

        public static string getBetweenList(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                int IndexStart = 0;

                Start = strSource.IndexOf(strStart, IndexStart) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                IndexStart = Start;

                return strSource.Substring(Start, End - Start);
            }
            return null;
        }
    }
}
