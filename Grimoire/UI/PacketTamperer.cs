using System;
using System.Windows.Forms;
using Grimoire.Networking;

namespace Grimoire.UI
{
	public partial class PacketTamperer : Form
	{
		public static PacketTamperer Instance { get; } = new PacketTamperer();

		private PacketTamperer()
		{
			this.InitializeComponent();
		}

		private void PacketTamperer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

		private void chkFromServer_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkFromServer.Checked)
			{
				Proxy.Instance.ReceivedFromServer += this.ReceivedFromServer;
				return;
			}
			Proxy.Instance.ReceivedFromServer -= this.ReceivedFromServer;
		}

		private void chkFromClient_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkFromClient.Checked)
			{
				Proxy.Instance.ReceivedFromClient += this.ReceivedFromClient;
				return;
			}
			Proxy.Instance.ReceivedFromClient -= this.ReceivedFromClient;
		}

		private async void btnToClient_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtSend.Text))
			{
				this.btnToClient.Enabled = false;
				await Proxy.Instance.SendToClient(this.txtSend.Text);
				this.btnToClient.Enabled = true;
			}
		}

		private async void btnToServer_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtSend.Text))
			{
				this.btnToServer.Enabled = false;
				await Proxy.Instance.SendToServer(this.txtSend.Text);
				this.btnToServer.Enabled = true;
			}
		}

		private void ReceivedFromClient(Grimoire.Networking.Message message)
		{
			string text = message.RawContent;
			if (text.Contains(tbFilter.Text))
			{
				this.txtSend.Invoke(new Action(delegate ()
				{
					this.Append("From client: " + text);
				}));
			}
		}

		private void ReceivedFromServer(Grimoire.Networking.Message message)
		{
			string text = message.RawContent;
			if (text.Contains(tbFilter.Text))
			{
				this.txtSend.Invoke(new Action(delegate ()
				{
					this.Append("From server: " + text);
				}));
			}
		}

		private void Append(string text)
		{
			this.txtReceive.AppendText(text + Environment.NewLine + Environment.NewLine);
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
			txtReceive.Text = "";
        }
    }
}
