using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Grimoire.UI
{
	public partial class RawCommandEditor : Form
	{
		public string Input
		{
			get
			{
				return this.txtCmd.Text;
			}
		}

		public string Content
		{
			set
			{
				this.txtCmd.Text = value;
			}
		}

		private RawCommandEditor()
		{
			this.InitializeComponent();
		}

		private void RawCommandEditor_Load(object sender, EventArgs e)
		{
			this.txtCmd.Select();
		}

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

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
