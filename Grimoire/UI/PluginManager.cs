using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Grimoire.Tools.Plugins;

namespace Grimoire.UI
{
	// Token: 0x02000017 RID: 23
	public partial class PluginManager : Form
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000027FF File Offset: 0x000009FF
		public static PluginManager Instance { get; } = new PluginManager();

		// Token: 0x0600009D RID: 157 RVA: 0x0000A2D8 File Offset: 0x000084D8
		public PluginManager()
		{
			this.InitializeComponent();
			BotManager.Instance.SizeChanged += this.Root_SizeChanged;
			BotManager.Instance.VisibleChanged += this.Root_VisibleChanged;
			this.lstLoaded.DisplayMember = "Name";
			if (Program.PluginsManager.LoadedPlugins.Count > 0)
			{
				ListBox.ObjectCollection items = this.lstLoaded.Items;
				object[] items2 = Program.PluginsManager.LoadedPlugins.ToArray();
				items.AddRange(items2);
				this.lstLoaded.SelectedIndex = 0;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000659C File Offset: 0x0000479C
		private void Root_SizeChanged(object sender, EventArgs e)
		{
			FormWindowState windowState = ((Form)sender).WindowState;
			if (windowState != FormWindowState.Maximized)
			{
				base.WindowState = windowState;
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000021B7 File Offset: 0x000003B7
		private void Root_VisibleChanged(object sender, EventArgs e)
		{
			base.Visible = ((Form)sender).Visible;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000A36C File Offset: 0x0000856C
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = "Load Grimoire plugin";
				openFileDialog.Filter = "Dynamic Link Library|*.dll";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.txtPlugin.Text = openFileDialog.FileName;
					if (openFileDialog.FileName == Path.Combine(Program.PluginsPath, Path.GetFileName(openFileDialog.FileName)))
					{
						this.chkAutoload.Checked = true;
						this.chkAutoload.Enabled = false;
					}
					else
					{
						this.chkAutoload.Checked = false;
						this.chkAutoload.Enabled = true;
					}
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000A420 File Offset: 0x00008620
		private void btnLoad_Click(object sender, EventArgs e)
		{
			string text;
			if (File.Exists(text = this.txtPlugin.Text))
			{
				if (this.chkAutoload.Enabled && this.chkAutoload.Checked)
				{
					string text2 = Path.Combine(Program.PluginsPath, Path.GetFileName(text));
					if (!File.Exists(text2))
					{
						try
						{
							File.Copy(text, text2);
							text = text2;
							this.txtPlugin.Text = text;
						}
						catch (Exception ex)
						{
							MessageBox.Show(string.Format("Unable to copy {0} to {1}\n{2}", text, text2, ex.Message));
						}
					}
				}
				if (Program.PluginsManager.Load(text))
				{
					this.txtPlugin.Clear();
					this.lstLoaded.Items.Clear();
					ListBox.ObjectCollection items = this.lstLoaded.Items;
					object[] items2 = Program.PluginsManager.LoadedPlugins.ToArray();
					items.AddRange(items2);
					this.lstLoaded.SelectedIndex = this.lstLoaded.Items.Count - 1;
					return;
				}
				MessageBox.Show(Program.PluginsManager.LastError, "Grimoire", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000A538 File Offset: 0x00008738
		private void btnUnload_Click(object sender, EventArgs e)
		{
			GrimoirePlugin grimoirePlugin = (GrimoirePlugin)this.lstLoaded.SelectedItem;
			if (grimoirePlugin != null)
			{
				if (Program.PluginsManager.Unload(grimoirePlugin))
				{
					this.lstLoaded.Items.Remove(grimoirePlugin);
					this.lblAuthor.Text = "Plugin created by:";
					this.txtDesc.Clear();
					return;
				}
				MessageBox.Show(grimoirePlugin.LastError, "Grimoire", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000A5A8 File Offset: 0x000087A8
		private void lstLoaded_SelectedIndexChanged(object sender, EventArgs e)
		{
			GrimoirePlugin grimoirePlugin = (GrimoirePlugin)this.lstLoaded.SelectedItem;
			if (grimoirePlugin != null)
			{
				this.lblAuthor.Text = string.Format("Plugin created by: {0}", grimoirePlugin.Author);
				this.txtDesc.Text = grimoirePlugin.Description;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000022D7 File Offset: 0x000004D7
		private void PluginManager_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				base.Hide();
			}
		}
	}
}
