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
	public partial class Travel : Form
	{
		public static Travel Instance { get; } = new Travel();

		private Travel()
		{
			this.InitializeComponent();
		}

		private void Travel_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

		private void chkPriv_CheckedChanged(object sender, EventArgs e)
		{
			this.numPriv.Enabled = this.chkPriv.Checked;
		}

		private void btnTercess_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Enter", "Spawn")
			});
		}

		private void btnTwins_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Twins", "Left")
			});
		}

		private void btnTaro_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Taro", "Left")
			});
		}

		private void btnSwindle_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Swindle", "Left")
			});
		}

		private void btnNulgath_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Boss", "Top")
			});
		}

		private void btnNulgath2_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("citadel", "m22", "Left"),
				this.CreateJoinCommand("tercessuinotlim", "Boss2", "Right")
			});
		}

		private void btnEscherion_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("escherion", "Boss", "Left")
			});
		}

		private void btnDage_Click(object sender, EventArgs e)
		{
			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("underworld", "s1", "Left")
			});
		}

		private void button1_Click(object sender, EventArgs e)
		{

			this.ExecuteTravel(new List<IBotCommand>
			{
				this.CreateJoinCommand("underworld", "r11", "Left")
			});
		}

		private CmdTravel CreateJoinCommand(string map, string cell = "Enter", string pad = "Spawn")
		{
			return new CmdTravel
			{
				Map = (this.chkPriv.Checked ? (map + string.Format("-{0}", this.numPriv.Value)) : map),
				Cell = cell,
				Pad = pad
			};
		}

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
