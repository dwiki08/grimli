namespace Grimoire.UI
{
	public partial class PacketTamperer : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketTamperer));
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.btnToServer = new System.Windows.Forms.Button();
            this.chkFromClient = new System.Windows.Forms.CheckBox();
            this.chkFromServer = new System.Windows.Forms.CheckBox();
            this.btnToClient = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.Location = new System.Drawing.Point(13, 13);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(536, 69);
            this.txtSend.TabIndex = 0;
            this.txtSend.Text = "";
            // 
            // txtReceive
            // 
            this.txtReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceive.Location = new System.Drawing.Point(13, 150);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(536, 260);
            this.txtReceive.TabIndex = 1;
            this.txtReceive.Text = "";
            // 
            // btnToServer
            // 
            this.btnToServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToServer.Location = new System.Drawing.Point(465, 88);
            this.btnToServer.Name = "btnToServer";
            this.btnToServer.Size = new System.Drawing.Size(84, 23);
            this.btnToServer.TabIndex = 3;
            this.btnToServer.Text = "Send to server";
            this.btnToServer.UseVisualStyleBackColor = true;
            this.btnToServer.Click += new System.EventHandler(this.btnToServer_Click);
            // 
            // chkFromClient
            // 
            this.chkFromClient.AutoSize = true;
            this.chkFromClient.Location = new System.Drawing.Point(137, 94);
            this.chkFromClient.Name = "chkFromClient";
            this.chkFromClient.Size = new System.Drawing.Size(114, 17);
            this.chkFromClient.TabIndex = 4;
            this.chkFromClient.Text = "Capture from client";
            this.chkFromClient.UseVisualStyleBackColor = true;
            this.chkFromClient.CheckedChanged += new System.EventHandler(this.chkFromClient_CheckedChanged);
            // 
            // chkFromServer
            // 
            this.chkFromServer.AutoSize = true;
            this.chkFromServer.Location = new System.Drawing.Point(13, 94);
            this.chkFromServer.Name = "chkFromServer";
            this.chkFromServer.Size = new System.Drawing.Size(118, 17);
            this.chkFromServer.TabIndex = 5;
            this.chkFromServer.Text = "Capture from server";
            this.chkFromServer.UseVisualStyleBackColor = true;
            this.chkFromServer.CheckedChanged += new System.EventHandler(this.chkFromServer_CheckedChanged);
            // 
            // btnToClient
            // 
            this.btnToClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToClient.Location = new System.Drawing.Point(375, 88);
            this.btnToClient.Name = "btnToClient";
            this.btnToClient.Size = new System.Drawing.Size(84, 23);
            this.btnToClient.TabIndex = 6;
            this.btnToClient.Text = "Send to client";
            this.btnToClient.UseVisualStyleBackColor = true;
            this.btnToClient.Click += new System.EventHandler(this.btnToClient_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(293, 88);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Filter by text";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(81, 122);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(468, 20);
            this.tbFilter.TabIndex = 9;
            // 
            // PacketTamperer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 422);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnToClient);
            this.Controls.Add(this.chkFromServer);
            this.Controls.Add(this.chkFromClient);
            this.Controls.Add(this.btnToServer);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtSend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PacketTamperer";
            this.Text = "Packet Tamperer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacketTamperer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components;

		public global::System.Windows.Forms.RichTextBox txtSend;

		private global::System.Windows.Forms.RichTextBox txtReceive;

		private global::System.Windows.Forms.Button btnToServer;

		private global::System.Windows.Forms.CheckBox chkFromClient;

		private global::System.Windows.Forms.CheckBox chkFromServer;

		public global::System.Windows.Forms.Button btnToClient;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilter;
    }
}
