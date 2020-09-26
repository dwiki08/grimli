using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Grimoire.UI
{
	// Token: 0x0200000C RID: 12
	public partial class RawCommandEditor : Form
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000BB RID: 187 RVA: 0x0000DB8A File Offset: 0x0000BD8A
		public string Input
		{
			get
			{
				return this.txtCmd.Text;
			}
		}

		// Token: 0x17000012 RID: 18
		// (set) Token: 0x060000BC RID: 188 RVA: 0x0000DB97 File Offset: 0x0000BD97
		public string Content
		{
			set
			{
				this.txtCmd.Text = value;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000DBA5 File Offset: 0x0000BDA5
		private RawCommandEditor()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000DBB3 File Offset: 0x0000BDB3
		private void RawCommandEditor_Load(object sender, EventArgs e)
		{
			this.txtCmd.Select();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000DBC0 File Offset: 0x0000BDC0
		private void txtCmd_KeyDown(object sender, KeyEventArgs e)
		{
			Keys keyCode = e.KeyCode;
			if (keyCode == Keys.Return)
			{
				this.btnOK.PerformClick();
				return;
			}
			if (keyCode != Keys.Escape)
			{
				return;
			}
			this.btnCancel.PerformClick();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000DBF8 File Offset: 0x0000BDF8
		public static string Show(string content)
		{
			string result;
			using (RawCommandEditor rawCommandEditor = new RawCommandEditor
			{
				Content = content
			})
			{
				result = ((rawCommandEditor.ShowDialog() == DialogResult.OK) ? rawCommandEditor.Input : null);
			}
			return result;
		}
	}
}
