namespace Grimoire.UI
{
	// Token: 0x0200000A RID: 10
	public partial class PacketTamperer : global::System.Windows.Forms.Form
	{
		// Token: 0x060000AD RID: 173 RVA: 0x0000CF4E File Offset: 0x0000B14E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000CF70 File Offset: 0x0000B170
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Grimoire.UI.PacketTamperer));
			this.txtSend = new global::System.Windows.Forms.RichTextBox();
			this.txtReceive = new global::System.Windows.Forms.RichTextBox();
			this.btnToServer = new global::System.Windows.Forms.Button();
			this.chkFromClient = new global::System.Windows.Forms.CheckBox();
			this.chkFromServer = new global::System.Windows.Forms.CheckBox();
			this.btnToClient = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.txtSend.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtSend.Location = new global::System.Drawing.Point(13, 13);
			this.txtSend.Name = "txtSend";
			this.txtSend.Size = new global::System.Drawing.Size(536, 69);
			this.txtSend.TabIndex = 0;
			this.txtSend.Text = "";
			this.txtReceive.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtReceive.Location = new global::System.Drawing.Point(13, 117);
			this.txtReceive.Name = "txtReceive";
			this.txtReceive.Size = new global::System.Drawing.Size(536, 239);
			this.txtReceive.TabIndex = 1;
			this.txtReceive.Text = "";
			this.btnToServer.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnToServer.Location = new global::System.Drawing.Point(465, 88);
			this.btnToServer.Name = "btnToServer";
			this.btnToServer.Size = new global::System.Drawing.Size(84, 23);
			this.btnToServer.TabIndex = 3;
			this.btnToServer.Text = "Send to server";
			this.btnToServer.UseVisualStyleBackColor = true;
			this.btnToServer.Click += new global::System.EventHandler(this.btnToServer_Click);
			this.chkFromClient.AutoSize = true;
			this.chkFromClient.Location = new global::System.Drawing.Point(137, 94);
			this.chkFromClient.Name = "chkFromClient";
			this.chkFromClient.Size = new global::System.Drawing.Size(114, 17);
			this.chkFromClient.TabIndex = 4;
			this.chkFromClient.Text = "Capture from client";
			this.chkFromClient.UseVisualStyleBackColor = true;
			this.chkFromClient.CheckedChanged += new global::System.EventHandler(this.chkFromClient_CheckedChanged);
			this.chkFromServer.AutoSize = true;
			this.chkFromServer.Location = new global::System.Drawing.Point(13, 94);
			this.chkFromServer.Name = "chkFromServer";
			this.chkFromServer.Size = new global::System.Drawing.Size(118, 17);
			this.chkFromServer.TabIndex = 5;
			this.chkFromServer.Text = "Capture from server";
			this.chkFromServer.UseVisualStyleBackColor = true;
			this.chkFromServer.CheckedChanged += new global::System.EventHandler(this.chkFromServer_CheckedChanged);
			this.btnToClient.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnToClient.Location = new global::System.Drawing.Point(375, 88);
			this.btnToClient.Name = "btnToClient";
			this.btnToClient.Size = new global::System.Drawing.Size(84, 23);
			this.btnToClient.TabIndex = 6;
			this.btnToClient.Text = "Send to client";
			this.btnToClient.UseVisualStyleBackColor = true;
			this.btnToClient.Click += new global::System.EventHandler(this.btnToClient_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(561, 368);
			base.Controls.Add(this.btnToClient);
			base.Controls.Add(this.chkFromServer);
			base.Controls.Add(this.chkFromClient);
			base.Controls.Add(this.btnToServer);
			base.Controls.Add(this.txtReceive);
			base.Controls.Add(this.txtSend);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "PacketTamperer";
			this.Text = "Packet Tamperer";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.PacketTamperer_FormClosing);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000D7 RID: 215
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.RichTextBox txtSend;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.RichTextBox txtReceive;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.Button btnToServer;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.CheckBox chkFromClient;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.CheckBox chkFromServer;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Button btnToClient;
	}
}
