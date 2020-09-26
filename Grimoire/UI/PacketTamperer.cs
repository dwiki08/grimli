using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Grimoire.Networking;

namespace Grimoire.UI
{
	// Token: 0x0200000A RID: 10
	public partial class PacketTamperer : Form
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000CDB7 File Offset: 0x0000AFB7
		public static PacketTamperer Instance { get; } = new PacketTamperer();

		// Token: 0x060000A4 RID: 164 RVA: 0x0000CDBE File Offset: 0x0000AFBE
		private PacketTamperer()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003342 File Offset: 0x00001542
		private void PacketTamperer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000CDCC File Offset: 0x0000AFCC
		private void chkFromServer_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkFromServer.Checked)
			{
				Proxy.Instance.ReceivedFromServer += this.ReceivedFromServer;
				return;
			}
			Proxy.Instance.ReceivedFromServer -= this.ReceivedFromServer;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000CE08 File Offset: 0x0000B008
		private void chkFromClient_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chkFromClient.Checked)
			{
				Proxy.Instance.ReceivedFromClient += this.ReceivedFromClient;
				return;
			}
			Proxy.Instance.ReceivedFromClient -= this.ReceivedFromClient;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000CE44 File Offset: 0x0000B044
		private async void btnToClient_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtSend.Text))
			{
				this.btnToClient.Enabled = false;
				await Proxy.Instance.SendToClient(this.txtSend.Text);
				this.btnToClient.Enabled = true;
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000CE80 File Offset: 0x0000B080
		private async void btnToServer_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.txtSend.Text))
			{
				this.btnToServer.Enabled = false;
				await Proxy.Instance.SendToServer(this.txtSend.Text);
				this.btnToServer.Enabled = true;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000CEBC File Offset: 0x0000B0BC
		private void ReceivedFromClient(Grimoire.Networking.Message message)
		{
			this.txtSend.Invoke(new Action(delegate()
			{
				this.Append("From client: " + message.RawContent);
			}));
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000CEF8 File Offset: 0x0000B0F8
		private void ReceivedFromServer(Grimoire.Networking.Message message)
		{
			this.txtSend.Invoke(new Action(delegate()
			{
				this.Append("From server: " + message.RawContent);
			}));
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000CF31 File Offset: 0x0000B131
		private void Append(string text)
		{
			this.txtReceive.AppendText(text + Environment.NewLine + Environment.NewLine);
		}
	}
}
