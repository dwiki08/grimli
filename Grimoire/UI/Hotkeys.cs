using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.UI
{
	// Token: 0x02000006 RID: 6
	public partial class Hotkeys : Form
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000ABED File Offset: 0x00008DED
		public static Hotkeys Instance { get; } = new Hotkeys();

		// Token: 0x0600006D RID: 109
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern IntPtr GetForegroundWindow();

		// Token: 0x0600006E RID: 110
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600006F RID: 111 RVA: 0x0000ABF4 File Offset: 0x00008DF4
		private string configPath
		{
			get
			{
				return Path.Combine(Application.StartupPath, "hotkeys.json");
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000AC05 File Offset: 0x00008E05
		private Hotkeys()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000AC13 File Offset: 0x00008E13
		private void Hotkeys_Load(object sender, EventArgs e)
		{
			this.lstKeys.DisplayMember = "Text";
			this.cbActions.SelectedIndex = 0;
			this.cbKeys.SelectedIndex = 0;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000AC40 File Offset: 0x00008E40
		private void btnRemove_Click(object sender, EventArgs e)
		{
			Hotkey hotkey = (Hotkey)this.lstKeys.SelectedItem;
			if (hotkey != null)
			{
				hotkey.Uninstall();
				Hotkeys.InstalledHotkeys.Remove(hotkey);
				this.lstKeys.Items.Remove(hotkey);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000AC84 File Offset: 0x00008E84
		private void btnAdd_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.cbActions.SelectedIndex;
			if (selectedIndex > -1 && this.cbKeys.SelectedIndex > -1)
			{
				Keys keys = (Keys)Enum.Parse(typeof(Keys), this.cbKeys.SelectedItem.ToString());
				if (!KeyboardHook.Instance.TargetedKeys.Contains(keys))
				{
					Hotkey hotkey = new Hotkey
					{
						ActionIndex = selectedIndex,
						Key = keys,
						Text = string.Format("{0}: {1}", keys, this.cbActions.Items[selectedIndex])
					};
					hotkey.Install();
					Hotkeys.InstalledHotkeys.Add(hotkey);
					this.lstKeys.Items.Add(hotkey);
				}
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000AD4A File Offset: 0x00008F4A
		private void btnSave_Click(object sender, EventArgs e)
		{
			File.WriteAllText(this.configPath, JsonConvert.SerializeObject(Hotkeys.InstalledHotkeys));
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000AD64 File Offset: 0x00008F64
		public void LoadHotkeys()
		{
			if (File.Exists(this.configPath))
			{
				Hotkey[] array = JsonConvert.DeserializeObject<Hotkey[]>(File.ReadAllText(this.configPath));
				if (array != null)
				{
					Hotkeys.InstalledHotkeys.AddRange(array);
					foreach (Hotkey hotkey in Hotkeys.InstalledHotkeys)
					{
						this.lstKeys.Items.Add(hotkey);
						hotkey.Install();
					}
				}
			}
			KeyboardHook.Instance.KeyDown += this.OnKeyDown;
			this._processId = Process.GetCurrentProcess().Id;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000AE1C File Offset: 0x0000901C
		public void OnKeyDown(Keys key)
		{
			Hotkey hotkey = Hotkeys.InstalledHotkeys.First((Hotkey h) => h.Key == key);
			if (this.ApplicationContainsFocus() || (string)this.cbActions.Items[hotkey.ActionIndex] == "Minimize to tray")
			{
				Hotkeys.Actions[hotkey.ActionIndex]();
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000AE90 File Offset: 0x00009090
		public bool ApplicationContainsFocus()
		{
			IntPtr foregroundWindow = Hotkeys.GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return false;
			}
			int num;
			Hotkeys.GetWindowThreadProcessId(foregroundWindow, out num);
			return num == this._processId;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003342 File Offset: 0x00001542
		private void Hotkeys_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

		// Token: 0x040000AF RID: 175
		public static readonly Action[] Actions = new Action[]
		{
			delegate()
			{
				Root.Instance.ShowForm(BotManager.Instance);
			},
			delegate()
			{
				Root.Instance.ShowForm(Hotkeys.Instance);
			},
			delegate()
			{
				Root.Instance.ShowForm(Loaders.Instance);
			},
			delegate()
			{
				Root.Instance.ShowForm(PacketLogger.Instance);
			},
			delegate()
			{
				Root.Instance.ShowForm(PacketSpammer.Instance);
			},
			delegate()
			{
				Root.Instance.ShowForm(Travel.Instance);
			},
			delegate()
			{
				if (Root.Instance.Visible)
				{
					Root.Instance.Hide();
					return;
				}
				Root.Instance.Show();
			},
			delegate()
			{
				Player.Bank.Show();
			}
		};

		// Token: 0x040000B0 RID: 176
		public static readonly List<Hotkey> InstalledHotkeys = new List<Hotkey>();

		// Token: 0x040000B1 RID: 177
		private int _processId;
	}
}
