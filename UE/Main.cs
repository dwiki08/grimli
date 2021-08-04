using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Networking;
using Grimoire.Networking.Handlers;
using Grimoire.Tools;
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

        bool countering = false;
        string dd = "Defense Drone";
        string ad = "Attack Drone";
        string ue = "Ultra Engineer";

        private async void attackUE()
        {
            while (chkStart.Checked)
            {
                if (!countering && Player.IsAlive && Player.IsLoggedIn)
                {
                    if (Player.Cell != "r2") Player.MoveToCell("r2", "Left");

                    if (World.IsMonsterAvailable(dd))
                    {
                        await killMonster(dd);
                    }
                    if (World.IsMonsterAvailable(ad))
                    {
                        await killMonster(ad);
                    }
                    if (World.IsMonsterAvailable(ue))
                    {
                        await killUE();
                    }
                } 
                else
                {
                    await Task.Delay(500);
                }
            }
        }

        private static IJsonMessageHandler HandlerRMP { get; } = new HandlerSkills();

        private async Task killMonster(string monsterName)
        {
            List<string> listSkills = new List<string>();
            foreach (Skill skill in BotManager.Instance.lstSkills.Items)
            {
                listSkills.Add(skill.Index);
            }

            if (listSkills.Count <= 0)
            {
                for (int i = 1; i <= 4; i++)
                {
                    listSkills.Add(i.ToString());
                }
            }

            int index = 0;
            while (World.IsMonsterAvailable(monsterName) && 
                !countering &&
                Player.IsLoggedIn &&
                Player.IsAlive &&
                chkStart.Checked)
            {
                if (!Player.HasTarget) Player.AttackMonster(monsterName);
                await Task.Delay(200);
                Player.UseSkill(listSkills[index]);
                index++;
                if (index == listSkills.Count) index = 0;
            }
        }

        private async Task killUE()
        {
            List<string> listSkills = new List<string>();
            foreach (Skill skill in BotManager.Instance.lstSkills.Items)
            {
                listSkills.Add(skill.Index);
            }

            if (listSkills.Count <= 0)
            {
                for (int i = 1; i <= 4; i++)
                {
                    listSkills.Add(i.ToString());
                }
            }

            int index = 0;
            while (World.IsMonsterAvailable(ue) && 
                !World.IsMonsterAvailable(dd) && 
                !World.IsMonsterAvailable(ad) &&
                Player.IsLoggedIn && 
                Player.IsAlive &&
                chkStart.Checked)
            {
                if (!Player.HasTarget) Player.AttackMonster(ue);
                await Task.Delay(200);
                Player.UseSkill(listSkills[index]);
                index++;
                if (index == listSkills.Count) index = 0;
            }
        }


        private async void chkStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStart.Checked)
            {
                if (!Player.Map.Contains("ultraengineer"))
                {
                    Player.JoinMap(tbMap.Text, "r2", "Left");
                    while (!Player.Map.Contains("ultraengineer"))
                    {
                        await Task.Delay(1000);
                    }
                } 
                else
                {
                    if (Player.Cell != "r2") Player.MoveToCell("r2");
                }
                Proxy.Instance.ReceivedFromServer += CapturePlayerData;
                Proxy.Instance.RegisterHandler(HandlerRMP);
                Flash.Call("SetInfiniteRange", new string[0]);
                attackUE();
            }
            else
            {
                Player.CancelTarget();
                Player.MoveToCell(Player.Cell, Player.Pad);
                Proxy.Instance.ReceivedFromServer -= CapturePlayerData;
                Proxy.Instance.UnregisterHandler(HandlerRMP);
            }
        }

        private void chkStart2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStart2.Checked)
            {
                Proxy.Instance.ReceivedFromServer += CapturePlayerData;
            }
            else
            {
                Proxy.Instance.ReceivedFromServer -= CapturePlayerData;
            }
        }

        private void botToggle(bool start)
        {
            if (start)
            {
                if (!BotManager.Instance.chkEnable.Checked)
                    BotManager.Instance.chkEnable.Checked = true;
            }
            else
            {
                if (BotManager.Instance.chkEnable.Checked)
                    BotManager.Instance.chkEnable.Checked = false;
            }
        }

        private void CapturePlayerData(Grimoire.Networking.Message message)
        {
            string msg = message.ToString();

            try
            {
                if (msg.Contains("prepares a counter attack"))
                {
                    Console.WriteLine("Countering attack");
                    countering = true;
                    Player.CancelTarget();
                    if (chkStart2.Checked) botToggle(false);
                }

                //"cmd":"aura--","aura":{"nam":"Counter Attack"
                if (msg.Contains("\"cmd\":\"aura--\",\"aura\":{\"nam\":\"Counter Attack\""))
                {
                    Console.WriteLine($"Stop counter attack");
                    countering = false;
                    Player.CancelTarget();
                    if (chkStart2.Checked) botToggle(true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("MyMsg: " + msg);
                Console.WriteLine("MyError: " + e.Message);
            }
        }
    }
}
