using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Botting;
using Grimoire.Botting.Commands.Map;

namespace Grimoire.UI
{
	// Token: 0x0200000E RID: 14
	public partial class Travel : Form
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000DA RID: 218 RVA: 0x0000EC07 File Offset: 0x0000CE07
		public static Travel Instance { get; } = new Travel();

		// Token: 0x060000DB RID: 219 RVA: 0x0000EC0E File Offset: 0x0000CE0E
		private Travel()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00003342 File Offset: 0x00001542
		private void Travel_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000EC1C File Offset: 0x0000CE1C
		private void chkPriv_CheckedChanged(object sender, EventArgs e)
		{
			this.numPriv.Enabled = this.chkPriv.Checked;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000EC34 File Offset: 0x0000CE34
		private void btnTercess_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Enter", "Spawn")
			});
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000EC84 File Offset: 0x0000CE84
		private void btnTwins_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Twins", "Left")
			});
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000ECD4 File Offset: 0x0000CED4
		private void btnTaro_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Taro", "Left")
			});
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000ED24 File Offset: 0x0000CF24
		private void btnSwindle_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Swindle", "Left")
			});
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000ED74 File Offset: 0x0000CF74
		private void btnNulgath_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Boss", "Top")
			});
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
		private void btnNulgath2_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Boss2", "Right")
			});
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000EE12 File Offset: 0x0000D012
		private void btnEscherion_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("escherion", "Boss", "Left")
			});
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000EE3A File Offset: 0x0000D03A
		private void btnDage_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("underworld", "s1", "Left")
			});
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000EE64 File Offset: 0x0000D064
		private CmdTravel CreateJoinCommand(string map, string cell = "Enter", string pad = "Spawn")
		{
			return new CmdTravel
			{
				Map = (this.chkPriv.Checked ? (map + string.Format("-{0}", this.numPriv.Value)) : map),
				Cell = cell,
				Pad = pad
			};
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000EEBC File Offset: 0x0000D0BC
		private async void ExecuteTravel(List<IBotCommand> cmds)
		{
			this.grpTravel.Enabled = false;
			foreach (IBotCommand botCommand in cmds)
			{
				await botCommand.Execute(null);
				await Task.Delay(1000);
			}
			List<IBotCommand>.Enumerator enumerator = default(List<IBotCommand>.Enumerator);
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(delegate()
				{
					this.grpTravel.Enabled = true;
				}));
			}
			else
			{
				this.grpTravel.Enabled = true;
			}
		}
	}
}
