using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Tools;

namespace Grimoire.UI
{
    public partial class Loaders : Form
    {
        public static Loaders Instance { get; } = new Loaders();

        private Loaders()
        {
            this.InitializeComponent();
        }
        private void cbLoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoad.SelectedIndex == 2)
            {
                numQuestPlus.Enabled = true;
                btnFAccept.Enabled = true;
            }
            else
            {
                numQuestPlus.Enabled = false;
                btnFAccept.Enabled = false;
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            switch (this.cbLoad.SelectedIndex)
            {
                case 0:
                    {
                        int id;
                        if (int.TryParse(this.txtLoaders.Text, out id))
                        {
                            Shop.LoadHairShop(id);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        int id;
                        if (int.TryParse(this.txtLoaders.Text, out id))
                        {
                            Shop.Load(id);
                            return;
                        }
                        break;
                    }
                case 2:
                    {
                        if (this.txtLoaders.Text.Contains(","))
                        {
                            this.LoadQuests(this.txtLoaders.Text);

                            return;
                        }
                        int id;
                        if (int.TryParse(this.txtLoaders.Text, out id))
                        {
                            int questId = Int32.Parse(txtLoaders.Text);
                            string quests = "";
                            int increament = (int)numQuestPlus.Value;
                            if (increament > 0)
                            {
                                for (int i = 0; i <= increament; i++)
                                {
                                    quests += questId + (i < increament ? "," : "");
                                    questId++;
                                }
                                LoadQuests(quests);
                            }
                            else
                            {
                                Player.Quests.Load(id);
                            }
                            return;
                        }
                        break;
                    }
                case 3:
                    Shop.LoadArmorCustomizer();
                    return;
                default:
                    return;
            }
        }

        private void LoadQuests(string str)
        {
            string[] source = str.Split(new char[]
            {
                ','
            });
            if (source.All((string s) => s.All(new Func<char, bool>(char.IsDigit))))
            {
                Player.Quests.Load(source.Select(new Func<string, int>(int.Parse)).ToList<int>());
            }
        }

        private void btnFAccept_Click(object sender, EventArgs e)
        {
            if (txtLoaders.Text == null) return;
            int questId = Int32.Parse(txtLoaders.Text);
            List<int> listQuests = new List<int>();
            for (int i = 0; i <= (int)numQuestPlus.Value; i++)
            {
                listQuests.Add(questId);
                questId++;
            }

            _ = acceptBatchAsync(listQuests);
        }
        private async Task acceptBatchAsync(List<int> listQuest)
        {
            //btnFAccept.Enabled = false;
            Player.Quests.Get(listQuest);
            await Task.Delay(1000);
            for (int i = 0; i <= listQuest.Count; i++)
            {
                if (!Player.Quests.IsInProgress(listQuest[i]))
                {
                    Player.Quests.Accept(listQuest[i]);
                    await Task.Delay(1000);
                }
            }
            //btnFAccept.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Save grabber data";
                openFileDialog.CheckFileExists = false;
                openFileDialog.Filter = "Text files|*.txt";
                openFileDialog.ShowDialog();
            }
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            this.treeGrabbed.BeginUpdate();
            this.treeGrabbed.Nodes.Clear();
            switch (this.cbGrab.SelectedIndex)
            {
                case 0:
                    Grabber.GrabShopItems(this.treeGrabbed);
                    break;
                case 1:
                    Grabber.GrabQuestIds(this.treeGrabbed);
                    break;
                case 2:
                    Grabber.GrabQuests(this.treeGrabbed);
                    break;
                case 3:
                    Grabber.GrabInventoryItems(this.treeGrabbed);
                    break;
                case 4:
                    Grabber.GrabTempItems(this.treeGrabbed);
                    break;
                case 5:
                    Grabber.GrabBankItems(this.treeGrabbed);
                    break;
                case 6:
                    Grabber.GrabMonsters(this.treeGrabbed);
                    break;
            }
            this.treeGrabbed.EndUpdate();
        }

        private void Loaders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                base.Hide();
            }
        }

    }
}
