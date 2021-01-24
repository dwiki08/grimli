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
	public partial class PacketSpammer : Form
	{
		public static PacketSpammer Instance { get; } = new PacketSpammer();

		private PacketSpammer()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.lstPackets.Items.Clear();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (this.txtPacket.Text.Length > 0)
			{
				this.lstPackets.Items.Add(this.txtPacket.Text);
				//this.txtPacket.Clear();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (this.lstPackets.Items.Count > 0)
			{
				this.SaveConfig();
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			this.lstPackets.Items.Clear();
			this.LoadConfig();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			Spammer.Instance.Stop();
			Spammer.Instance.IndexChanged -= this.IndexChanged;
			this.SetButtonsEnabled(true);
		}

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

		private async void btnSend_Click(object sender, EventArgs e)
		{
			if (this.txtPacket.TextLength > 0)
			{
				this.btnSend.Enabled = false;
				await Proxy.Instance.SendToServer(this.txtPacket.Text);
				this.btnSend.Enabled = true;
			}
		}

		private void PacketSpammer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}

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
							if (text.All(new Func<char, bool>(char.IsDigit))) this.numDelay.Value = int.Parse(text);
							//this.numDelay.Value = (text.All(new Func<char, bool>(char.IsDigit)) ? int.Parse(text) : 1000);
						}
					}
				}
			}
		}

		private void SetButtonsEnabled(bool enabled)
		{
			this.btnStart.Enabled = enabled;
			this.btnAdd.Enabled = enabled;
			this.btnClear.Enabled = enabled;
			this.btnLoad.Enabled = enabled;
		}

		private void IndexChanged(int index)
		{
			this.lstPackets.Invoke(new Action(delegate()
			{
				this.lstPackets.SelectedIndex = index;
				if (this.lstPackets.Items[index].Equals("STOP")) btnStop.PerformClick(); 
			}));
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.lstPackets.SelectedIndex;
			if (selectedIndex > -1)
			{
				this.lstPackets.Items.RemoveAt(selectedIndex);
			}
		}

        private void btnStopCmd_Click(object sender, EventArgs e)
        {
			this.lstPackets.Items.Add("STOP");
		}
    }
}
