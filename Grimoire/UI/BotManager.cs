using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Grimoire.Botting;
using Grimoire.Botting.Commands;
using Grimoire.Botting.Commands.Combat;
using Grimoire.Botting.Commands.Item;
using Grimoire.Botting.Commands.Map;
using Grimoire.Botting.Commands.Misc;
using Grimoire.Botting.Commands.Misc.Statements;
using Grimoire.Botting.Commands.Quest;
using Grimoire.Game.Data;
using Newtonsoft.Json;
using Grimoire.Game;
using Grimoire.Properties;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Grimoire.Networking;
using Grimoire.Networking.Handlers;
using Grimoire.Tools;

namespace Grimoire.UI
{
    // Something needs to be done about this monstrous class. Can we reduce the amount of controls?!?!?!
    public partial class BotManager : Form
    {
        public static BotManager Instance { get; } = new BotManager();

        private IBotEngine _activeBotEngine = new Bot();

        public IBotEngine ActiveBotEngine
        {
            get => _activeBotEngine;
            set
            {
                if (_activeBotEngine.IsRunning)
                    throw new InvalidOperationException("Cannot set a new bot engine while the current one is running");
                _activeBotEngine = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        private ListBox SelectedList
        {
            get
            {
                switch (cbLists.SelectedIndex)
                {
                    case 1:
                        return lstSkills;
                    case 2:
                        return lstQuests;
                    case 3:
                        return lstDrops;
                    case 4:
                        return lstBoosts;
                    default: return lstCommands;
                }
            }
        }

        private List<StatementCommand> _statementCommands;
        private Dictionary<string, string> _defaultControlText;

        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All
        };

        private BotManager()
        {
            InitializeComponent();
        }

        private void BotManager_Load(object sender, EventArgs e)
        {
            _panels = new[] { pnlCombat, pnlMap, pnlQuest, pnlItem, pnlMisc, pnlOptions, pnlSaved, pnlClientSide, pnlFroztt };
            pnlCombat.Size = new Size(379, 315);
            pnlMap.Size = new Size(343, 315);
            pnlQuest.Size = new Size(349, 315);
            pnlItem.Size = new Size(318, 315);
            pnlMisc.Size = new Size(442, 315);
            pnlOptions.Size = new Size(283, 315);
            pnlSaved.Size = new Size(438, 315);
            pnlClientSide.Size = new Size(283, 315);
            pnlFroztt.Size = new Size(438, 315);
            HidePanels(pnlCombat);
            lstBoosts.DisplayMember = "Text";
            lstQuests.DisplayMember = "Text";
            lstSkills.DisplayMember = "Text";
            cbBoosts.DisplayMember = "Name";
            cbServers.DisplayMember = "Name";
            cbStatement.DisplayMember = "Text";
            cbLists.SelectedIndex = 0;
            _statementCommands = JsonConvert.DeserializeObject<List<StatementCommand>>(Resources.statementcmds, _serializerSettings);
            _defaultControlText = JsonConvert.DeserializeObject<Dictionary<string, string>>(Resources.defaulttext, _serializerSettings);
            OptionsManager.StateChanged += OnOptionsStateChanged;
        }

        private void TextboxEnter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text == _defaultControlText[t.Name])
                t.Clear();
        }

        private void TextboxLeave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (string.IsNullOrEmpty(t.Text))
            {
                if (_defaultControlText.TryGetValue(t.Name, out string def))
                    t.Text = def;
            }
        }

        public void OnServersLoaded(Server[] servers)
        {
            if (servers?.Length > 0 && cbServers.Items.Count <= 1)
            {
                cbServers.Items.AddRange(servers);
                cbServers.SelectedIndex = 0;
            }
        }

        private void MoveListItem(int direction)
        {
            if (SelectedList.SelectedItem == null || SelectedList.SelectedIndex < 0)
                return;
            int newIndex = SelectedList.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= SelectedList.Items.Count)
                return;
            object selected = SelectedList.SelectedItem;
            SelectedList.Items.Remove(selected);
            SelectedList.Items.Insert(newIndex, selected);
            SelectedList.SetSelected(newIndex, true);
        }

        private bool clearSkillAfter = false;
        private Configuration GenerateConfiguration()
        {
            List<Skill> randSkills = new List<Skill>();
            if (lstSkills.Items.Cast<Skill>().ToList().Count > 0)
            {
                randSkills = lstSkills.Items.Cast<Skill>().ToList();
                clearSkillAfter = false;
            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {
                    randSkills.Add(new Skill
                    {
                        Text = $"{i}: {Skill.GetSkillName("" + i)}",
                        Index = "" + i,
                        Type = Skill.SkillType.Normal
                    });
                }
                clearSkillAfter = true;
            }

            return new Configuration
            {
                Author = txtAuthor.Text,
                Description = txtDescription.Text,
                Commands = lstCommands.Items.Cast<IBotCommand>().ToList(),
                Skills = randSkills,
                Quests = lstQuests.Items.Cast<Quest>().ToList(),
                Boosts = lstBoosts.Items.Cast<InventoryItem>().ToList(),
                Drops = lstDrops.Items.Cast<string>().ToList(),
                SkillDelay = (int)numSkillD.Value,
                ExitCombatBeforeRest = chkExitRest.Checked,
                ExitCombatBeforeQuest = chkExistQuest.Checked,
                Server = (Server)cbServers.SelectedItem,
                AutoRelogin = chkRelog.Checked,
                RelogDelay = (int)numRelogDelay.Value,
                RelogRetryUponFailure = chkRelogRetry.Checked,
                BotDelay = (int)numBotDelay.Value,
                DropDelay = 0,
                EnablePickup = chkPickup.Checked,
                EnablePickupV2 = chkPickupv2.Checked,
                EnablePickupAll = chkPickupAll.Checked,
                EnableRejection = chkReject.Checked,
                WaitForSkills = chkSkillCD.Checked,
                SkipDelayIndexIf = chkSkip.Checked,
                InfiniteAttackRange = chkInfiniteRange.Checked,
                ProvokeMonsters = chkProvoke.Checked,
                EnemyMagnet = chkMagnet.Checked,
                LagKiller = chkLag.Checked,
                HidePlayers = chkHidePlayers.Checked,
                SkipCutscenes = chkSkipCutscenes.Checked,
                DisableAnimations = chkDisableAnims.Checked,
                WalkSpeed = (int)numWalkSpeed.Value,
                NotifyUponDrop = lstSoundItems.Items.Cast<string>().ToList(),
                RestIfMp = chkMP.Checked,
                RestIfHp = chkHP.Checked,
                RestMp = (int)numRestMP.Value,
                RestHp = (int)numRest.Value,
                RestartUponDeath = chkRestartDeath.Checked,
                PopNotify = chkPopNotify.Checked
            };
        }

        public void ApplyConfiguration(Configuration config)
        {
            if (config == null)
                return;

            if (!chkMerge.Checked || ActiveBotEngine.IsRunning)
            {
                lstCommands.Items.Clear();
                lstBoosts.Items.Clear();
                lstDrops.Items.Clear();
                lstQuests.Items.Clear();
                lstSkills.Items.Clear();
                lstSoundItems.Items.Clear();
            }

            txtSavedAuthor.Text = config.Author ?? "Author";
            txtSavedDesc.Text = config.Description ?? "Description";

            if (config.Commands?.Count > 0)
                lstCommands.Items.AddRange(config.Commands.ToArray());
            if (config.Skills?.Count > 0)
                lstSkills.Items.AddRange(config.Skills.ToArray());
            if (config.Quests?.Count > 0)
                lstQuests.Items.AddRange(config.Quests.ToArray());
            if (config.Boosts?.Count > 0)
                lstBoosts.Items.AddRange(config.Boosts.ToArray());
            if (config.Drops?.Count > 0)
                lstDrops.Items.AddRange(config.Drops.ToArray());

            numSkillD.Value = config.SkillDelay;
            chkExitRest.Checked = config.ExitCombatBeforeRest;
            chkExistQuest.Checked = config.ExitCombatBeforeQuest;
            if (config.Server != null)
                cbServers.SelectedIndex = cbServers.Items.Cast<Server>().ToList().FindIndex(s => s.Name == config.Server.Name);
            chkRelog.Checked = config.AutoRelogin;
            numRelogDelay.Value = config.RelogDelay;
            chkRelogRetry.Checked = config.RelogRetryUponFailure;
            numBotDelay.Value = config.BotDelay;
            chkPickup.Checked = config.EnablePickup;
            chkPickupv2.Checked = config.EnablePickupV2;
            chkPickupAll.Checked = config.EnablePickupAll;
            chkReject.Checked = config.EnableRejection;
            chkSkillCD.Checked = config.WaitForSkills;
            chkSkip.Checked = config.SkipDelayIndexIf;
            chkInfiniteRange.Checked = config.InfiniteAttackRange;
            chkProvoke.Checked = config.ProvokeMonsters;
            chkMagnet.Checked = config.EnemyMagnet;
            chkHidePlayers.Checked = config.HidePlayers;
            chkSkipCutscenes.Checked = config.SkipCutscenes;
            chkDisableAnims.Checked = config.DisableAnimations;
            numWalkSpeed.Value = config.WalkSpeed <= 0 ? 8 : config.WalkSpeed;
            if (config.NotifyUponDrop?.Count > 0)
                lstSoundItems.Items.AddRange(config.NotifyUponDrop.ToArray());
            numRestMP.Value = config.RestMp;
            numRest.Value = config.RestHp;
            chkMP.Checked = config.RestIfMp;
            chkHP.Checked = config.RestIfHp;
            chkRestartDeath.Checked = config.RestartUponDeath;
            chkPopNotify.Checked = config.PopNotify;
            txtAuthor.Text = config.Author;
            txtDescription.Text = config.Description;
        }

        private void OnConfigurationChanged(Configuration config)
        {
            if (InvokeRequired)
                Invoke(new Action(() => ApplyConfiguration(config)));
            else
                ApplyConfiguration(config);
        }

        private void OnIndexChanged(int index)
        {
            if (index > -1)
            {
                if (InvokeRequired)
                    Invoke(new Action(() => { lstCommands.SelectedIndex = index; }));
                else
                    lstCommands.SelectedIndex = index;
            }
        }

        private void OnIsRunningChanged(bool isRunning)
        {
            if (!isRunning)
            {
                ActiveBotEngine.IsRunningChanged -= OnIsRunningChanged;
                ActiveBotEngine.IndexChanged -= OnIndexChanged;
                ActiveBotEngine.ConfigurationChanged -= OnConfigurationChanged;

                void Action()
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    btnClear.Enabled = true;
                    btnRemove.Enabled = true;
                }

                if (InvokeRequired)
                    Invoke((Action)Action);
                else
                    Action();
            }

            if (InvokeRequired)
                Invoke(new Action(() => { chkEnable.Checked = isRunning; }));
            else
                chkEnable.Checked = isRunning;
        }

        public void AddCommand(IBotCommand cmd)
        {
            lstCommands.Items.Add(cmd);
        }

        #region  Untabbed

        private void MoveListItemByKey(int direction)
        {
            if (this.SelectedList.SelectedItem == null || this.SelectedList.SelectedIndex < 0)
            {
                return;
            }
            int num = this.SelectedList.SelectedIndex + direction;
            if (num < 0 || num >= this.SelectedList.Items.Count)
            {
                return;
            }
            object selectedItem = this.SelectedList.SelectedItem;
            this.SelectedList.Items.Remove(selectedItem);
            this.SelectedList.Items.Insert(num, selectedItem);
            if (direction == 1)
            {
                this.SelectedList.SetSelected(num - 1, true);
            }
        }

        private void AddCommand(IBotCommand cmd, bool Insert)
        {
            if (Insert)
            {
                this.lstCommands.Items.Insert((this.lstCommands.SelectedIndex > -1) ? this.lstCommands.SelectedIndex : this.lstCommands.Items.Count, cmd);
                return;
            }
            this.lstCommands.Items.Add(cmd);
        }

        private void lstBoxs_KeyPress(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Up)
            {
                this.MoveListItemByKey(-1);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Down)
            {
                this.MoveListItemByKey(1);
            }
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Delete)
            {
                this.btnRemove.PerformClick();
            }
        }
        private void lstCommands_DoubleClick(object sender, EventArgs e)
        {
            int index = lstCommands.SelectedIndex;
            if (index > -1)
            {
                object cmd = lstCommands.Items[index];

                string result = JsonConvert.SerializeObject(cmd, Formatting.Indented, _serializerSettings);

                string mod = RawCommandEditor.Show(result);

                if (mod != null)
                {
                    try
                    {
                        IBotCommand modifiedCmd = (IBotCommand)JsonConvert.DeserializeObject(mod, cmd.GetType());
                        lstCommands.Items.Remove(cmd);
                        lstCommands.Items.Insert(index, modifiedCmd);
                    }
                    catch { }
                }
            }
        }

        private void chkEnable_Click(object sender, EventArgs e)
        {
            if (/*!Player.IsAlive || !Player.IsLoggedIn ||*/ lstCommands.Items.Count <= 0)
            {
                chkEnable.Checked = false;
                return;
            }

            if (chkEnable.Checked)
            {
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnClear.Enabled = false;
                btnRemove.Enabled = false;
                ActiveBotEngine.IsRunningChanged += OnIsRunningChanged;
                ActiveBotEngine.IndexChanged += OnIndexChanged;
                ActiveBotEngine.ConfigurationChanged += OnConfigurationChanged;
                ActiveBotEngine.Start(GenerateConfiguration());
            }
            else
            {
                if (clearSkillAfter) lstSkills.Items.Clear();
                ActiveBotEngine.Stop();
            }
        }

        private Panel[] _panels;

        private void HidePanels(Panel exception)
        {
            exception.Location = new Point(219, 27);
            switch (exception.Name)
            {
                case "pnlCombat":
                    Size = new Size(624, 392);
                    break;
                case "pnlMap":
                    Size = new Size(589, 392);
                    break;
                case "pnlItem":
                    Size = new Size(562, 392);
                    break;
                case "pnlQuest":
                    Size = new Size(562, 392);
                    break;
                case "pnlMisc":
                    Size = new Size(682, 392);
                    break;
                case "pnlOptions":
                    Size = new Size(527, 392);
                    break;
                case "pnlSaved":
                    Size = new Size(683, 392);
                    break;
                case "pnlClientSide":
                    Size = new Size(527, 392);
                    break;
                case "pnlFroztt":
                    Size = new Size(632, 392);
                    break;
                default: return;
            }
            foreach (Panel p in _panels)
                p.Visible = p == exception;
        }

        private void combatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlCombat);
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlMap);
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlItem);
        }

        private void questToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlQuest);
        }

        private void miscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlMisc);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlOptions);
        }

        private void clientSideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlClientSide);
        }

        private void froztt13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlFroztt);
        }

        private void botsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePanels(pnlSaved);
            txtSaved.Text = Path.Combine(Application.StartupPath, "Bots");
            UpdateTree();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selected = SelectedList.SelectedIndex;
            if (selected > -1)
            {
                SelectedList.Items.RemoveAt(selected);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveListItem(1);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveListItem(-1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                lstBoosts.Items.Clear();
                lstCommands.Items.Clear();
                lstDrops.Items.Clear();
                lstQuests.Items.Clear();
                lstSkills.Items.Clear();
            }
            else
                SelectedList.Items.Clear();
        }

        private void cbLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoosts.Visible = SelectedList == lstBoosts;
            lstCommands.Visible = SelectedList == lstCommands;
            lstDrops.Visible = SelectedList == lstDrops;
            lstQuests.Visible = SelectedList == lstQuests;
            lstSkills.Visible = SelectedList == lstSkills;
        }

        private void BotManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        #endregion

        #region Combat tab
        private CancellationTokenSource _cts;
        private int _skillIndex;
        private static IJsonMessageHandler HandlerRMP { get; } = new HandlerSkills();
        private async void btnAutoCombat_Click(object sender, EventArgs e)
        {
            if (!chkEnable.Checked && btnAutoCombat.Text.Equals("Auto Combat"))
            {
                btnAutoCombat.Text = "Stop Combat";

                if (chkInfiniteRMP.Checked)
                {
                    Proxy.Instance.RegisterHandler(HandlerRMP);
                    Flash.Call("SetInfiniteRange", new string[0]);
                    chkInfiniteRMP.Enabled = false;
                }

                List<Skill> ls = new List<Skill>();
                if (lstSkills.Items.Count > 0)
                {
                    for (int i = 0; i < lstSkills.Items.Count; i++)
                    {
                        ls.Add((Skill)lstSkills.Items[i]);
                    }
                }
                else
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        string index = "" + i;
                        ls.Add(new Skill
                        {
                            Text = $"{index}: {Skill.GetSkillName(index)}",
                            Index = index,
                            Type = Skill.SkillType.Normal
                        });
                    }
                }

                _skillIndex = 0;
                while (btnAutoCombat.Text.Equals("Stop Combat") && Player.IsLoggedIn && Player.IsAlive)
                {
                    Player.AttackMonster("*");
                    Skill s = ls[_skillIndex];

                    if (s.Type == Skill.SkillType.Safe)
                    {
                        if (s.SafeMp)
                        {
                            if ((double)Player.Mana / Player.ManaMax * 100 <= s.SafeHealth)
                                Player.UseSkill(s.Index);
                        }
                        else
                        {
                            if ((double)Player.Health / Player.HealthMax * 100 <= s.SafeHealth)
                                Player.UseSkill(s.Index);
                        }
                    }
                    else
                    {
                        Player.UseSkill(s.Index);
                    }

                    int count = ls.Count - 1;

                    _skillIndex = _skillIndex >= count ? 0 : ++_skillIndex;
                    await Task.Delay(200);
                }
            }
            else
            {
                btnAutoCombat.Text = "Auto Combat";
                if (chkInfiniteRMP.Checked) Proxy.Instance.UnregisterHandler(HandlerRMP);
                chkInfiniteRMP.Enabled = true;
            }
        }
        private void btnAttack_Click(object sender, EventArgs e)
        {
            string monster = string.IsNullOrEmpty(this.txtMonster.Text) ? "*" : this.txtMonster.Text;
            string monId = "";
            if (monster.Split(' ')[0].Equals("/id"))
            {
                monId = monster.Split(' ')[1];
            }
            bool flag = this.txtMonster.Text == "Monster (*  = random)";
            if (flag)
            {
                monster = "*";
            }
            this.AddCommand(new CmdAttack
            {
                Monster = monster,
                MonId = monId
            }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            string monster = string.IsNullOrEmpty(this.txtMonster.Text) ? "*" : this.txtMonster.Text;
            string monId = "";
            if (monster.Split(' ')[0].Equals("/id"))
            {
                monId = monster.Split(' ')[1];
            }
            bool flag = this.txtMonster.Text == "Monster (*  = random)";
            if (flag) monster = "*";
            this.AddCommand(new CmdKill
            {
                Monster = monster,
                MonId = monId
            }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnKillF_Click(object sender, EventArgs e)
        {
            if (txtKillFItem.Text.Length > 0 && txtKillFQ.Text.Length > 0)
            {
                string monster = string.IsNullOrEmpty(this.txtKillFMonster.Text) ? "*" : this.txtKillFMonster.Text;
                string monId = "";
                if (monster.Split(' ')[0].Equals("/id"))
                {
                    monId = monster.Split(' ')[1];
                }
                bool flag = this.txtKillFMonster.Text == "Monster (*  = random)";
                if (flag) monster = "*";
                string text = this.txtKillFItem.Text;
                string text2 = this.txtKillFQ.Text;

                if (chkAddToWhitelist.Checked)
                {
                    if (txtKillFItem.Text.Length <= 0) return;
                    string[] items = txtKillFItem.Text.Split(new char[] {
                        ','
                    });

                    foreach (string item in items)
                    {
                        if (!lstDrops.Items.Cast<string>().ToList().Any((string d) => d.Equals(item, StringComparison.OrdinalIgnoreCase)))
                            lstDrops.Items.Add(item);
                    }
                }

                int times = 0;

                CmdKillFor cmd = new CmdKillFor
                {
                    ItemType = (this.rbItems.Checked ? ItemType.Items : ItemType.TempItems),
                    Monster = monster,
                    ItemName = text,
                    Quantity = text2,
                    IsGetDrops = chkGetDropKillFor.Checked,
                    AfterKills = int.TryParse(this.txtAfterXKill.Text, out times) ? times : 1
                };

                if (rbForQuest.Checked) {
                    cmd = new CmdKillFor
                    {
                        Monster = monster,
                        QuestId = txtForQuestId.Text
                    };
                }

                this.AddCommand(cmd, (Control.ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        bool isAddToWhitelist = false;
        private void chkGetDropKillFor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGetDropKillFor.Checked)
            {
                isAddToWhitelist = chkAddToWhitelist.Checked;
                chkAddToWhitelist.Checked = false;
                chkAddToWhitelist.Enabled = false;
                txtAfterXKill.Enabled = true;
            }
            else
            {
                chkAddToWhitelist.Checked = isAddToWhitelist;
                chkAddToWhitelist.Enabled = true;
                txtAfterXKill.Enabled = false;
            }
        }

        private void rbTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTemp.Checked)
            {
                chkGetDropKillFor.Enabled = false;
                chkGetDropKillFor.Checked = false;
                txtAfterXKill.Enabled = false;
            }
            else
            {
                chkGetDropKillFor.Enabled = true;
            }
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            string index = numSkill.Text;
            lstSkills.Items.Add(new Skill
            {
                Text = $"{index}: {Skill.GetSkillName(index)}",
                Index = index,
                Type = Skill.SkillType.Normal
            });
        }

        private void btnAllSkill_Click(object sender, EventArgs e)
        {
            //string index = numSkill.Text;
            for (int i = 1; i <= 5; i++)
            {
                lstSkills.Items.Add(new Skill
                {
                    Text = $"{i}: {Skill.GetSkillName("" + i)}",
                    Index = "" + i,
                    Type = Skill.SkillType.Normal
                });
            }
        }

        private void btnAddSkillCmd_Click(object sender, EventArgs e)
        {
            string index = numSkill.Text;
            int safe = (int)numSafe.Value;
            this.AddCommand(new CmdUseSkill
            {
                Skill = new Skill
                {
                    Text = $"[S] {index}: {Skill.GetSkillName(index)}",
                    Index = index,
                    SafeHealth = safe,
                    Type = Skill.SkillType.Safe,
                    SafeMp = chkSafeMp.Checked
                },
                Wait = false
            }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnAddSafe_Click(object sender, EventArgs e)
        {
            string index = numSkill.Text;
            int safe = (int)numSafe.Value;
            lstSkills.Items.Add(new Skill
            {
                Text = $"[S] {index}: {Skill.GetSkillName(index)}",
                Index = index,
                SafeHealth = safe,
                Type = Skill.SkillType.Safe,
                SafeMp = chkSafeMp.Checked
            });
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdRest(), (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnRestF_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdRest { Full = true }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }
        private void AddSkill(Skill skill, bool Insert)
        {
            if (Insert)
            {
                this.lstSkills.Items.Insert((this.lstSkills.SelectedIndex > -1) ? this.lstSkills.SelectedIndex : this.lstSkills.Items.Count, skill);
                return;
            }
            this.lstSkills.Items.Add(skill);
        }

        private void btnAddSkillSet_Click(object sender, EventArgs e)
        {
            if (this.txtSkillSetName.TextLength > 0)
            {
                this.AddSkill(new Skill
                {
                    Text = "[" + this.txtSkillSetName.Text.ToUpper() + "]",
                    Type = Skill.SkillType.Label
                }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnUseSkillSet_Click(object sender, EventArgs e)
        {
            if (this.txtSkillSetName.TextLength > 0)
            {
                this.AddCommand(new CmdSkillSet
                {
                    Name = this.txtSkillSetName.Text.ToUpper()
                }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        #endregion

        #region Map tab
        private void btnJoin_Click(object sender, EventArgs e)
        {
            string map = txtJoin.Text,
                   cell = string.IsNullOrEmpty(txtJoinCell.Text) ? "Enter" : txtJoinCell.Text,
                   pad = string.IsNullOrEmpty(txtJoinPad.Text) ? "Spawn" : txtJoinPad.Text;
            if (map.Length > 0)
            {
                this.AddCommand(new CmdJoin { Map = map, Cell = cell, Pad = pad }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnCellSwap_Click(object sender, EventArgs e)
        {
            txtJoin.Text = Player.Map;
            txtJoinCell.Text = txtCell.Text;
            txtJoinPad.Text = txtPad.Text;
        }

        private void btnCurrCell_Click(object sender, EventArgs e)
        {
            txtCell.Text = Player.Cell;
            txtPad.Text = Player.Pad;
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            string cell = string.IsNullOrEmpty(txtCell.Text) ? "Enter" : txtCell.Text,
                pad = string.IsNullOrEmpty(txtPad.Text) ? "Spawn" : txtPad.Text;
            this.AddCommand(new CmdMoveToCell { Cell = cell, Pad = pad }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnJumpBlank_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdMoveToCell { Cell = "Blank", Pad = "Spawn" }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnWalk_Click(object sender, EventArgs e)
        {
            string x = numWalkX.Value.ToString(), y = numWalkY.Value.ToString();
            this.AddCommand(new CmdWalk { X = x, Y = y }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnWalkCur_Click(object sender, EventArgs e)
        {
            float[] pos = Player.Position;
            numWalkX.Value = (decimal)pos[0];
            numWalkY.Value = (decimal)pos[1];
        }

        #endregion

        #region Item tab
        private void btnItem_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text;
            if (item.Length > 0 && cbItemCmds.SelectedIndex > -1)
            {
                IBotCommand cmd;

                switch (cbItemCmds.SelectedIndex)
                {
                    case 1:
                        cmd = new CmdSell { ItemName = item };
                        break;
                    case 2:
                        cmd = new CmdEquip { ItemName = item };
                        break;
                    case 3:
                        cmd = new CmdBankTransfer { ItemName = item, TransferFromBank = false };
                        break;
                    case 4:
                        cmd = new CmdBankTransfer { ItemName = item, TransferFromBank = true };
                        break;
                    default:
                        cmd = new CmdGetDrop { ItemName = item };
                        break;
                }
                this.AddCommand(cmd, (Control.ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnMapItem_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdMapItem { ItemId = (int)numMapItem.Value }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnWhitelist_Click(object sender, EventArgs e)
        {
            string item = txtWhitelist.Text;
            if (item.Length > 0)
                lstDrops.Items.Add(item);
        }

        private void chkPickupAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPickupAll.Checked)
            {
                chkPickupv2.Enabled = false;
                chkPickupv2.Checked = false;
                chkPickup.Enabled = false;
                chkPickup.Checked = false;
                chkReject.Checked = false;
                chkReject.Enabled = false;
            }
            else
            {
                chkPickupv2.Enabled = true;
                chkPickup.Enabled = true;
                chkReject.Enabled = true;
            }
        }

        private void chkPickup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPickup.Checked)
            {
                chkPickupv2.Enabled = false;
                chkPickupv2.Checked = false;
                chkPickupAll.Enabled = false;
                chkPickupAll.Checked = false;
            }
            else
            {
                chkPickupv2.Enabled = true;
                chkPickupAll.Enabled = true;
            }
        }

        private void chkPickupv2_CheckedChanged(object sender, EventArgs e)
        {

            if (chkPickupv2.Checked)
            {
                chkPickup.Enabled = false;
                chkPickup.Checked = false;
                chkPickupAll.Enabled = false;
                chkPickupAll.Checked = false;
            }
            else
            {
                chkPickup.Enabled = true;
                chkPickupAll.Enabled = true;
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string bank = txtSwapBank.Text, inv = txtSwapInv.Text;
            if (bank.Length > 0 && inv.Length > 0)
            {
                this.AddCommand(new CmdBankSwap
                {
                    InventoryItemName = inv,
                    BankItemName = bank
                }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void btnBoost_Click(object sender, EventArgs e)
        {
            if (cbBoosts.SelectedIndex > -1)
                lstBoosts.Items.Add(cbBoosts.SelectedItem);
        }

        private void cbBoosts_Click(object sender, EventArgs e)
        {
            cbBoosts.Items.Clear();
            cbBoosts.Items.AddRange(Player.Inventory.Items.Where(i => i.Category == "ServerUse").ToArray());
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (txtShopItem.TextLength > 0)
                this.AddCommand(new CmdBuy { ItemName = txtShopItem.Text, ShopId = (int)numShopId.Value }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        #endregion

        #region Quest tab

        private void btnQuestAdd_Click(object sender, EventArgs e)
        {
            Quest q = new Quest { Id = (int)numQuestID.Value };
            if (chkQuestItem.Checked)
                q.ItemId = numQuestItem.Value.ToString();
            q.Text = q.ItemId != null ? $"{q.Id}:{q.ItemId}" : q.Id.ToString();
            lstQuests.Items.Add(q);
        }

        private void btnQuestComplete_Click(object sender, EventArgs e)
        {
            Quest q = new Quest();
            CmdCompleteQuest cmd = new CmdCompleteQuest
            {
                CompleteTry = (int)numQuestTry.Value,
                ReAccept = chkReAccept.Checked,
                InBlank = chkCompleteBlank.Checked
            };
            q.Id = (int)numQuestID.Value;
            if (chkQuestItem.Checked)
                q.ItemId = numQuestItem.Value.ToString();
            cmd.Quest = q;
            this.AddCommand(cmd, (Control.ModifierKeys & Keys.Control) == Keys.Control);

        }

        private void btnQuestAccept_Click(object sender, EventArgs e)
        {
            Quest q = new Quest { Id = (int)numQuestID.Value };
            this.AddCommand(new CmdAcceptQuest { Quest = q }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void chkQuestItem_CheckedChanged(object sender, EventArgs e)
        {
            numQuestItem.Enabled = chkQuestItem.Checked;
        }

        private void btnAddToWhitelist_Click(object sender, EventArgs e)
        {
            int idQuest = Decimal.ToInt32(numQuestId2.Value);
            Player.Quests.Load(idQuest);

            if (chkReward.Checked)
            {
                List<String> items = Grabber.GetQuestRewards(idQuest);
                foreach (String item in items)
                {
                    if (item.Length > 0)
                        lstDrops.Items.Add(item);
                }
            }

            if (chkRequir.Checked)
            {
                List<String> items = Grabber.GetQuestRequirment(idQuest);
                foreach (String item in items)
                {
                    if (item.Length > 0)
                        lstDrops.Items.Add(item);
                }
            }
        }

        #endregion

        #region Misc tab
        private void btnAgroOn_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdProvoke { Set = true }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnAgroOff_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdProvoke { Set = false }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnPacket_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdPacket
            {
                Packet = txtPacket.Text,
                SpamTimes = Decimal.ToInt32(numSpamTimes.Value),
                ForClient = chkPckToClient.Checked
            }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            int delay = (int)numDelay.Value;
            this.AddCommand(new CmdDelay { Delay = delay }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            string player = txtPlayer.Text;
            if (player.Length > 0)
                this.AddCommand(new CmdGotoPlayer { PlayerName = player }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnIndexUp_Click(object sender, EventArgs e)
        {
            int index = (int)numGotoIndex.Value;
            this.AddCommand(new CmdIndex
            {
                Index = index,
                Type = CmdIndex.IndexCommand.Up
            }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnIndexDown_Click(object sender, EventArgs e)
        {
            int index = (int)numGotoIndex.Value;
            this.AddCommand(new CmdIndex
            {
                Index = index,
                Type = CmdIndex.IndexCommand.Down
            }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnBotDelay_Click(object sender, EventArgs e)
        {
            int delay = (int)numBotDelay.Value;
            this.AddCommand(new CmdBotDelay { Delay = delay }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdStop(), (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdRestart(), (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load bot";
                ofd.InitialDirectory = Path.Combine(Application.StartupPath, "Bots");
                ofd.Filter = "Grimoire bots|*.gbot";
                ofd.DefaultExt = ".gbot";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (TryDeserialize(File.ReadAllText(ofd.FileName), out Configuration cfg))
                        ApplyConfiguration(cfg);
                }
            }
        }

        private bool TryDeserialize(string json, out Configuration config)
        {
            try
            {
                config = JsonConvert.DeserializeObject<Configuration>(json, _serializerSettings);
                return true;
            }
            catch { }


            config = null;
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Save bot";
                ofd.InitialDirectory = Path.Combine(Application.StartupPath, "Bots");
                ofd.DefaultExt = ".gbot";
                ofd.Filter = "Grimoire bots|*.gbot";
                ofd.CheckFileExists = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Configuration cfg = GenerateConfiguration();
                    try
                    {
                        File.WriteAllText(
                            ofd.FileName, JsonConvert.SerializeObject(cfg, Formatting.Indented, _serializerSettings));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unable to save bot: {ex.Message}");
                    }
                }
            }
        }

        private void btnLoadCmd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                string defPath = Path.Combine(Application.StartupPath, "Bots");
                ofd.Title = "Select bot to load";
                ofd.Filter = "Grimoire bots|*.gbot";
                ofd.InitialDirectory = defPath;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lstCommands.Items.Add(new CmdLoadBot
                    {
                        BotFileName = Path.GetFileName(ofd.FileName)
                    });
                }
            }
        }

        private void cbStatement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategories.SelectedIndex > -1 && cbStatement.SelectedIndex > -1)
            {
                StatementCommand cmd = (StatementCommand)cbStatement.SelectedItem;
                txtStatement1.Enabled = cmd.Description1 != null;
                txtStatement2.Enabled = cmd.Description2 != null;
                txtStatement1.Text = cmd.Description1;
                txtStatement2.Text = cmd.Description2;
            }
        }

        private void btnStatementAdd_Click(object sender, EventArgs e)
        {
            if (cbCategories.SelectedIndex > -1 && cbStatement.SelectedIndex > -1)
            {
                string value1 = txtStatement1.Text;
                string value2 = txtStatement2.Text;
                StatementCommand cmd =
                    (StatementCommand)Activator.CreateInstance(cbStatement.SelectedItem.GetType());
                cmd.Value1 = value1;
                cmd.Value2 = value2;

                this.AddCommand((IBotCommand)cmd, (Control.ModifierKeys & Keys.Control) == Keys.Control);
            }
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbCategories.SelectedIndex;
            if (index > -1)
            {
                cbStatement.Items.Clear();
                string text = cbCategories.SelectedItem.ToString();
                cbStatement.Items.AddRange(_statementCommands.Where(s => s.Tag == text).ToArray());
            }
        }

        private void btnGotoLabel_Click(object sender, EventArgs e)
        {
            if (txtLabel.TextLength > 0)
                this.AddCommand(new CmdGotoLabel { Label = txtLabel.Text }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnAddLabel_Click(object sender, EventArgs e)
        {
            if (txtLabel.TextLength > 0)
                this.AddCommand(new CmdLabel { Name = txtLabel.Text }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdLogout(), (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        #endregion

        #region Saved bots tab

        private void UpdateTree()
        {
            if (!string.IsNullOrEmpty(txtSaved.Text) && Directory.Exists(txtSaved.Text))
            {
                lblBots.Text = $"Number of Bots: {Directory.EnumerateFiles(txtSaved.Text, "*.gbot", SearchOption.AllDirectories).Count()}";
                treeBots.Nodes.Clear();
                AddTreeNodes(treeBots, txtSaved.Text);
            }
        }

        private void treeBots_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selection = Path.Combine(txtSaved.Text, e.Node.FullPath);
            if (File.Exists(selection))
            {
                if (TryDeserialize(File.ReadAllText(selection), out Configuration cfg))
                    ApplyConfiguration(cfg);
                else return;
            }
            lblCommands.Text = $"Number of{Environment.NewLine}Commands: {lstCommands.Items.Count}";
            lblSkills.Text = $"Skills: {lstSkills.Items.Count}";
            lblQuests.Text = $"Quests: {lstQuests.Items.Count}";
            lblDrops.Text = $"Drops: {lstDrops.Items.Count}";
            lblBoosts.Text = $"Boosts: {lstBoosts.Items.Count}";
        }

        private void treeBots_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string collapsed = Path.Combine(txtSaved.Text, e.Node.FullPath);
            if (Directory.Exists(collapsed))
            {
                AddTreeNodes(e.Node, collapsed);
                if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text == "Loading...")
                    e.Node.Nodes.RemoveAt(0);
            }
        }

        private void AddTreeNodes(TreeNode node, string path)
        {
            foreach (string dir in Directory.EnumerateDirectories(
                path, "*", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(dir);
                if (node.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    node.Nodes.Add(add).Nodes.Add("Loading...");
                }
            }

            foreach (string file in Directory.EnumerateFiles(
                path, "*.gbot", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(file);
                if (node.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    node.Nodes.Add(add);
                }
            }
        }

        private void AddTreeNodes(TreeView tree, string path)
        {
            foreach (string dir in Directory.EnumerateDirectories(
                path, "*", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(dir);
                if (tree.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    tree.Nodes.Add(add).Nodes.Add("Loading...");
                }
            }

            foreach (string file in Directory.EnumerateFiles(
                path, "*.gbot", SearchOption.TopDirectoryOnly))
            {
                string add = Path.GetFileName(file);
                if (tree.Nodes.Cast<TreeNode>().ToList().All(n => n.Text != add))
                {
                    tree.Nodes.Add(add);
                }
            }
        }

        private void btnSavedAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSaved.Text))
            {
                string newDir = Path.Combine(txtSaved.Text, txtSavedAdd.Text);

                if (!Directory.Exists(newDir))
                {
                    try
                    {
                        Directory.CreateDirectory(newDir);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unable to create directory: {ex.Message}", "Grimoire",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                UpdateTree();
            }
        }

        #endregion

        #region Options tab

        private void btnSoundAdd_Click(object sender, EventArgs e)
        {
            if (txtSoundItem.TextLength > 0)
                lstSoundItems.Items.Add(txtSoundItem.Text);
        }

        private void btnCmdPing_Click(object sender, EventArgs e)
        {
            this.AddCommand(new CmdPing
            {
                PopMsg = chkPopNotify.Checked
            }, (Control.ModifierKeys & Keys.Control) == Keys.Control);
        }

        private void btnSoundDelete_Click(object sender, EventArgs e)
        {
            int index = lstSoundItems.SelectedIndex;
            if (index > -1)
                lstSoundItems.Items.RemoveAt(index);
        }

        private void btnSoundClear_Click(object sender, EventArgs e)
        {
            lstSoundItems.Items.Clear();
        }

        private void btnSoundTest_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Console.Beep();
        }

        private void chkInfiniteRange_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.InfiniteRange = chkInfiniteRange.Checked;
        }

        private void chkProvoke_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.ProvokeMonsters = chkProvoke.Checked;
        }

        private void chkMagnet_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.EnemyMagnet = chkMagnet.Checked;
        }

        private void chkLag_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.LagKiller = chkLag.Checked;
        }

        private void chkHidePlayers_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.HidePlayers = chkHidePlayers.Checked;
        }

        private void chkSkipCutscenes_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.SkipCutscenes = chkSkipCutscenes.Checked;
        }

        private void numWalkSpeed_ValueChanged(object sender, EventArgs e)
        {
            OptionsManager.WalkSpeed = (int)numWalkSpeed.Value;
        }

        private void chkDisableAnims_CheckedChanged(object sender, EventArgs e)
        {
            OptionsManager.DisableAnimations = chkDisableAnims.Checked;
        }

        private void OnOptionsStateChanged(bool state)
        {
            if (InvokeRequired)
                Invoke(new Action(() => chkEnableSettings.Checked = state));
            else
                chkEnableSettings.Checked = state;
        }

        /*private void chkEnableSettings_Click(object sender, EventArgs e)
        {
            if (chkEnableSettings.Checked)
                OptionsManager.Start();
            else
                OptionsManager.Stop();
        }*/

        private void chkEnableSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableSettings.Checked)
                OptionsManager.Start();
            else
                OptionsManager.Stop();
        }

        #endregion}

        #region Client side
        private async void btnSetLevel_Click(object sender, EventArgs e)
        {
            string packet =
                "{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"2000\",\"intLevel\":" + tbLevel.Text + "}}}";
            await Proxy.Instance.SendToClient(packet);
        }

        private async void btnDoomBSkip_Click(object sender, EventArgs e)
        {
            btnDoomBSkip.Enabled = false;
            string toClient1 = "{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"updateQuest\",\"iValue\":20,\"iIndex\":126}}}";
            await Proxy.Instance.SendToClient(toClient1);
            await Task.Delay(1000);

            string toServer = "%xt%zm%setAchievement%79%ia0%18%1%";
            await Proxy.Instance.SendToServer(toServer);
            await Task.Delay(1000);

            string toClient2 = "{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"updateQuest\",\"iValue\":27,\"iIndex\":127}}}";
            await Proxy.Instance.SendToClient(toClient2);
            await Task.Delay(1000);

            string toClient3 = "%xt%server%-1%Doomvault B - Unlocked !%";
            await Proxy.Instance.SendToClient(toClient3);
            await Task.Delay(1000);

            btnDoomBSkip.Enabled = true;
        }
        #endregion

        #region Frozt ShortHunt
        private void btnGetMapF_Click(object sender, EventArgs e)
        {
            tbCellF.Text = Player.Cell;
            tbPadF.Text = Player.Pad;
            tbMapF.Text = Player.Map;
        }

        private void btnAddCmdFrozzt_Click(object sender, EventArgs e)
        {
            if (tbItemNameF.Text.Length > 0 && tbItemQtyF.Text.Length > 0)
            {
                string monster = string.IsNullOrEmpty(this.tbMonNameF.Text) ? "*" : this.tbMonNameF.Text;
                string monId = "";
                if (monster.Split(' ')[0].Equals("/id"))
                {
                    monId = monster.Split(' ')[1];
                }
                bool flag = this.tbMonNameF.Text == "Monster (*  = random)";
                if (flag) monster = "*";
                string text = this.tbItemNameF.Text;
                string text2 = this.tbItemQtyF.Text;

                if (chkAddToWhitelistF.Checked)
                {
                    if (tbItemNameF.Text.Length <= 0) return;
                    string[] items = tbItemNameF.Text.Split(new char[] {
                        ','
                    });

                    foreach (string item in items)
                    {
                        if (!lstDrops.Items.Cast<string>().ToList().Any((string d) => d.Equals(item, StringComparison.OrdinalIgnoreCase)))
                            lstDrops.Items.Add(item);
                    }
                }

                int times = 0;

                CmdShortHunt cmd = new CmdShortHunt
                {
                    Map = tbMapF.Text,
                    Cell = tbCellF.Text,
                    Pad = tbPadF.Text,
                    ItemType = (chkIsTempF.Checked ? ItemType.TempItems : ItemType.Items),
                    Monster = monster,
                    ItemName = text,
                    Quantity = text2,
                    IsGetDrops = chkGetAfterF.Checked,
                    AfterKills = int.TryParse(this.tbGetAfterF.Text, out times) ? times : 1
                };

                this.AddCommand(cmd, (Control.ModifierKeys & Keys.Control) == Keys.Control);
            }

        }
        #endregion

        private void rbForQuest_CheckedChanged(object sender, EventArgs e)
        {
            chkAddToWhitelist.Enabled = !rbForQuest.Checked;
            chkGetDropKillFor.Enabled = !rbForQuest.Checked;
            txtAfterXKill.Enabled = !rbForQuest.Checked;
            txtKillFItem.Enabled = !rbForQuest.Checked;
            txtKillFQ.Enabled = !rbForQuest.Checked;
        }
    }
}
