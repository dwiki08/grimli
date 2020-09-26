using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Grimoire.Networking;
using Grimoire.Tools;

namespace Grimoire.UI
{
	// Token: 0x02000009 RID: 9
	public partial class PacketSpammer : Form
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000C1E0 File Offset: 0x0000A3E0
		public static PacketSpammer Instance { get; } = new PacketSpammer();

		// Token: 0x06000092 RID: 146 RVA: 0x0000C1E7 File Offset: 0x0000A3E7
		private PacketSpammer()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000C1F5 File Offset: 0x0000A3F5
		private void btnClear_Click(object sender, EventArgs e)
		{
			this.lstPackets.Items.Clear();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000C207 File Offset: 0x0000A407
		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (this.txtPacket.Text.Length > 0)
			{
				this.lstPackets.Items.Add(this.txtPacket.Text);
				this.txtPacket.Clear();
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000C243 File Offset: 0x0000A443
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (this.lstPackets.Items.Count > 0)
			{
				this.SaveConfig();
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000C25E File Offset: 0x0000A45E
		private void btnLoad_Click(object sender, EventArgs e)
		{
			this.lstPackets.Items.Clear();
			this.LoadConfig();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000C276 File Offset: 0x0000A476
		private void btnStop_Click(object sender, EventArgs e)
		{
			Spammer.Instance.Stop();
			Spammer.Instance.IndexChanged -= this.IndexChanged;
			this.SetButtonsEnabled(true);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000C2A0 File Offset: 0x0000A4A0
		private void btnStart_Click(object sender, EventArgs e)
		{
			if (this.lstPackets.Items.Count > 0)
			{
				this.SetButtonsEnabled(false);
				List<string> packets = this.lstPackets.Items.Cast<string>().ToList<string>();
				int delay = (int)this.numDelay.Value;
				Spammer.Instance.IndexChanged += this.IndexChanged;
				Spammer.Instance.Start(packets, delay);
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000C310 File Offset: 0x0000A510
		private async void btnSend_Click(object sender, EventArgs e)
		{
			if (this.txtPacket.TextLength > 0)
			{
				this.btnSend.Enabled = false;
				await Proxy.Instance.SendToServer(this.txtPacket.Text);
				this.btnSend.Enabled = true;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003342 File Offset: 0x00001542
		private void PacketSpammer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000C34C File Offset: 0x0000A54C
		private void SaveConfig()
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = "Save spammer file";
				openFileDialog.Filter = "XML files|*.xml";
				openFileDialog.CheckFileExists = false;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					using (XmlWriter xmlWriter = XmlWriter.Create(openFileDialog.FileName))
					{
						xmlWriter.WriteStartElement("autoer");
						foreach (object obj in this.lstPackets.Items)
						{
							string value = (string)obj;
							xmlWriter.WriteElementString("packet", value);
						}
						xmlWriter.WriteElementString("author", "Author");
						xmlWriter.WriteElementString("spamspeed", this.numDelay.Value.ToString());
						xmlWriter.WriteEndElement();
					}
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000C460 File Offset: 0x0000A660
		private void LoadConfig()
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = "Load spammer file";
				openFileDialog.Filter = "XML files|*.xml";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					foreach (XNode xnode in XElement.Load(openFileDialog.FileName).Nodes())
					{
						XElement xelement = (XElement)xnode;
						if (xelement.Name == "packet")
						{
							this.lstPackets.Items.Add(xelement.Value);
						}
						else if (xelement.Name == "spamspeed")
						{
							string text = xelement.Name.ToString();
							this.numDelay.Value = (text.All(new Func<char, bool>(char.IsDigit)) ? int.Parse(text) : 2000);
						}
					}
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000C580 File Offset: 0x0000A780
		private void SetButtonsEnabled(bool enabled)
		{
			this.btnStart.Enabled = enabled;
			this.btnAdd.Enabled = enabled;
			this.btnClear.Enabled = enabled;
			this.btnLoad.Enabled = enabled;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000C5B4 File Offset: 0x0000A7B4
		private void IndexChanged(int index)
		{
			this.lstPackets.Invoke(new Action(delegate()
			{
				this.lstPackets.SelectedIndex = index;
			}));
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000C5F0 File Offset: 0x0000A7F0
		private void btnRemove_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.lstPackets.SelectedIndex;
			if (selectedIndex > -1)
			{
				this.lstPackets.Items.RemoveAt(selectedIndex);
			}
		}
	}
}
