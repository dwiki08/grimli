using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Tools;

namespace Grimoire.UI
{
	public partial class PacketLogger : Form
	{
		public static PacketLogger Instance { get; } = new PacketLogger();

		private PacketLogger()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.txtPackets.Clear();
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			if (this.txtPackets.Text.Length > 0)
			{
				Clipboard.SetText(this.txtPackets.Text);
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			Proxy.Instance.ReceivedFromClient -= this.PacketCaptured;
			this.btnStart.Enabled = true;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			this.btnStart.Enabled = false;
			Proxy.Instance.ReceivedFromClient += this.PacketCaptured;
		}

		private void PacketCaptured(Grimoire.Networking.Message msg)
		{
			if (msg.RawContent != null && msg.RawContent.Contains("%xt%zm%"))
			{
				this.txtPackets.Invoke(new Action(delegate()
				{
					this.txtPackets.AppendText(msg.RawContent + Environment.NewLine);
				}));
			}
		}

		private void PacketLogger_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

		private async void btnSendOnce_ClickAsync(object sender, EventArgs e)
		{
			if (textToSend.TextLength > 0)
			{
				btnSendOnce.Enabled = false;
				await Proxy.Instance.SendToServer(textToSend.Text);
				btnSendOnce.Enabled = true;
			}
		}

		private async void btnSpam_Click(object sender, EventArgs e)
		{
			if (textToSend.TextLength < 1) return;
			if (btnSpam.Text.Equals("Spam"))
			{
				btnSpam.Text = "Stop";
				btnSendOnce.Enabled = false;
				List<string> listPackets = new List<string>();
				int spamTimes = Decimal.ToInt32(numSpamTimes.Value);
				int spamDelay = Decimal.ToInt32(numSpamDelay.Value);
				if (textToSend.TextLength > 0)
				{
					listPackets.Add(textToSend.Text);
					if(spamTimes > 0)
					{
						for(int i = 1; i <= spamTimes; i++)
						{
							if (btnSpam.Text.Equals("Stop"))
							{
								await Proxy.Instance.SendToServer(textToSend.Text);
								await Task.Delay(spamDelay);
							}
						}
						stopSpammer(false);
					}
					else
					{
						Spammer.Instance.Start(listPackets, spamDelay);
					}
				}
			}
			else
			{
				stopSpammer(true);
			}
		}

		private void stopSpammer(bool stopInstance)
		{
			btnSpam.Text = "Spam";
			btnSendOnce.Enabled = true;
			if(stopInstance) Spammer.Instance.Stop();
		}
	}
}
