using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxShockwaveFlashObjects;
using Grimoire.Botting;
using Grimoire.Botting.Commands.Combat;
using Grimoire.FlashEoLHook;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Networking;
using Grimoire.Networking.Handlers;
using Grimoire.Properties;
using Grimoire.Tools;

namespace Grimoire.UI
{
	public partial class Root : Form
	{
		public static Root Instance { get; private set; }

		public AxShockwaveFlash Client
		{
			get
			{
				return this.flashPlayer;
			}
		}

		public Root()
		{
			EoLHook.Hook();
			this.InitializeComponent();
			Root.Instance = this;
		}

		private void Root_Load(object sender, EventArgs e)
		{
			Task.Factory.StartNew<Task>(new Func<Task>(Proxy.Instance.Start), TaskCreationOptions.LongRunning);
			this.flashPlayer.FlashCall += Flash.ProcessFlashCall;
			Flash.SwfLoadProgress += this.OnLoadProgress;
			Hotkeys.Instance.LoadHotkeys();
			this.InitFlashMovie();
		}

		private void OnLoadProgress(int progress)
		{
			if (progress < this.prgLoader.Maximum)
			{
				this.prgLoader.Value = progress;
				return;
			}
			Flash.SwfLoadProgress -= this.OnLoadProgress;
			this.flashPlayer.Visible = true;
			this.prgLoader.Visible = false;
		}

		private void chkAttack_MouseHover(object sender, EventArgs e)
		{
			ToolTip ToolTip1 = new ToolTip();
			ToolTip1.SetToolTip(this.chkAttack, "Using skill set from Bot Manager");
		}

		private void chkEnable_MouseHover(object sender, EventArgs e)
		{
			ToolTip ToolTip1 = new ToolTip();
			ToolTip1.SetToolTip(this.chkEnable, "Start bot manager");
		}

		private void botToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			this.ShowForm(BotManager.Instance);
		}

		private void fastTravelsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowForm(Travel.Instance);
		}

		private void loadersgrabbersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowForm(Loaders.Instance);
		}

		private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowForm(Hotkeys.Instance);
		}

		private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowForm(PluginManager.Instance);
		}

		private void snifferToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowForm(PacketLogger.Instance);
		}

		private void spammerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowForm(PacketSpammer.Instance);
		}

		private void tampererToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShowForm(PacketTamperer.Instance);
		}

		public void ShowForm(Form form)
		{
			if (form.Visible)
			{
				form.Hide();
				return;
			}
			form.Show();
			form.BringToFront();
		}

		private void InitFlashMovie()
		{
			byte[] aqlitegrimoire = Resources.aqlitegrimoire;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(8 + aqlitegrimoire.Length);
					binaryWriter.Write(1432769894);
					binaryWriter.Write(aqlitegrimoire.Length);
					binaryWriter.Write(aqlitegrimoire);
					memoryStream.Seek(0L, SeekOrigin.Begin);
					this.flashPlayer.OcxState = new AxHost.State(memoryStream, 1, false, null);
				}
			}
			EoLHook.Unhook();
		}

		private void btnBank_Click(object sender, EventArgs e)
		{
			Player.Bank.Show();
		}

		private void cbCells_SelectedIndexChanged(object sender, EventArgs e)
		{
			string cell = (string)this.cbCells.SelectedItem;
			if (cell != null)
			{
				string pad = (string)this.cbPads.SelectedItem;
				Player.MoveToCell(cell, pad ?? "Spawn");
			}
		}
		private void cbPads_SelectedIndexChanged(object sender, EventArgs e)
		{
			string pad = (string)cbPads.SelectedItem;
			if (pad != null)
			{
				string cell = (string)this.cbCells.SelectedItem;
				Player.MoveToCell(cell ?? Player.Cell, pad);
			}
		}

		private void cbCells_Click(object sender, EventArgs e)
		{
			if (!Player.IsLoggedIn) return;
			this.cbCells.Items.Clear();
			ComboBox.ObjectCollection items = this.cbCells.Items;
			object[] cells = World.Cells;
			items.AddRange(cells);
		}

		private void Root_FormClosing(object sender, FormClosingEventArgs e)
		{
			Hotkeys.InstalledHotkeys.ForEach(delegate (Hotkey h)
			{
				h.Uninstall();
			});
			KeyboardHook.Instance.Dispose();
			Proxy.Instance.Stop(true);
		}

		private static IJsonMessageHandler HandlerRMP { get; } = new HandlerSkills();

		private async void chkAttack_CheckedChangedAsync(object sender, EventArgs e)
		{
			if (chkAttack.Checked && !Player.IsLoggedIn)
			{
				chkAttack.Checked = false;
				return;
			}

			if (chkAttack.Checked)
			{
				Proxy.Instance.RegisterHandler(HandlerRMP);
				Flash.Call("SetInfiniteRange", new string[0]);

                /*CmdKill kill = new CmdKill
                {
                    Monster = "*"
                };

                await kill.Execute(BotManager.Instance.ActiveBotEngine);*/

                //string[] listSkills = tbSkills.Text.Split(';');
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
				while (chkAttack.Checked)
				{
					if (!Player.HasTarget) Player.AttackMonster("*");
					await Task.Delay(200);
					Player.UseSkill(listSkills[index]);
					index++;
					if (index == listSkills.Count) index = 0;
				}
			}
			else
			{
				Proxy.Instance.UnregisterHandler(HandlerRMP);
			}


			/*if (chkAttack.Checked)
            {
                listSkill.Add("1");
                listSkill.Add("2");
                listSkill.Add("3");
                listSkill.Add("4");
                Proxy.Instance.ReceivedFromClient += CaptureSkill;
            }
            else
            {
                Proxy.Instance.ReceivedFromClient -= CaptureSkill;
            }*/
		}

		private List<string> listSkill = new List<string>();
		private void CaptureSkill(Networking.Message msg)
		{
			if (msg.RawContent != null && msg.RawContent.Contains("%xt%zm%gar"))
			{
				foreach (string skill in listSkill)
				{
					Player.UseSkill(skill);
				}
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (chkEnable.Checked && (BotManager.Instance.lstCommands.Items.Count <= 0 || !Player.IsLoggedIn))
			{
				chkEnable.Checked = false;
				return;
			}

			if (chkEnable.Checked)
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
	}
}
