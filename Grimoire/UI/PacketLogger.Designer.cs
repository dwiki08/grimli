namespace Grimoire.UI
{
	// Token: 0x02000008 RID: 8
	public partial class PacketLogger : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008E RID: 142 RVA: 0x0000BE29 File Offset: 0x0000A029
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000BE48 File Offset: 0x0000A048
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketLogger));
            this.txtPackets = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.textToSend = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.x = new System.Windows.Forms.Label();
            this.numSpamTimes = new System.Windows.Forms.NumericUpDown();
            this.btnSendOnce = new System.Windows.Forms.Button();
            this.btnSpam = new System.Windows.Forms.Button();
            this.numSpamDelay = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpamTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpamDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPackets
            // 
            this.txtPackets.Location = new System.Drawing.Point(12, 12);
            this.txtPackets.Multiline = true;
            this.txtPackets.Name = "txtPackets";
            this.txtPackets.Size = new System.Drawing.Size(420, 160);
            this.txtPackets.TabIndex = 15;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(357, 178);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(276, 178);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(195, 178);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 18;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(114, 178);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textToSend
            // 
            this.textToSend.Location = new System.Drawing.Point(21, 232);
            this.textToSend.Name = "textToSend";
            this.textToSend.Size = new System.Drawing.Size(401, 20);
            this.textToSend.TabIndex = 44;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.x);
            this.groupBox2.Controls.Add(this.numSpamTimes);
            this.groupBox2.Controls.Add(this.btnSendOnce);
            this.groupBox2.Controls.Add(this.btnSpam);
            this.groupBox2.Controls.Add(this.numSpamDelay);
            this.groupBox2.Location = new System.Drawing.Point(12, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 74);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spammer";
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.Location = new System.Drawing.Point(234, 50);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(12, 13);
            this.x.TabIndex = 10;
            this.x.Text = "x";
            // 
            // numSpamTimes
            // 
            this.numSpamTimes.Location = new System.Drawing.Point(169, 45);
            this.numSpamTimes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpamTimes.Name = "numSpamTimes";
            this.numSpamTimes.Size = new System.Drawing.Size(64, 20);
            this.numSpamTimes.TabIndex = 9;
            // 
            // btnSendOnce
            // 
            this.btnSendOnce.Location = new System.Drawing.Point(335, 43);
            this.btnSendOnce.Name = "btnSendOnce";
            this.btnSendOnce.Size = new System.Drawing.Size(75, 23);
            this.btnSendOnce.TabIndex = 6;
            this.btnSendOnce.Text = "Send Once";
            this.btnSendOnce.UseVisualStyleBackColor = true;
            this.btnSendOnce.Click += new System.EventHandler(this.btnSendOnce_ClickAsync);
            // 
            // btnSpam
            // 
            this.btnSpam.Location = new System.Drawing.Point(254, 43);
            this.btnSpam.Name = "btnSpam";
            this.btnSpam.Size = new System.Drawing.Size(75, 23);
            this.btnSpam.TabIndex = 7;
            this.btnSpam.Text = "Spam";
            this.btnSpam.UseVisualStyleBackColor = true;
            this.btnSpam.Click += new System.EventHandler(this.btnSpam_Click);
            // 
            // numSpamDelay
            // 
            this.numSpamDelay.Location = new System.Drawing.Point(9, 45);
            this.numSpamDelay.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numSpamDelay.Name = "numSpamDelay";
            this.numSpamDelay.Size = new System.Drawing.Size(75, 20);
            this.numSpamDelay.TabIndex = 8;
            this.numSpamDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // PacketLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 298);
            this.Controls.Add(this.textToSend);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPackets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PacketLogger";
            this.Text = "Packet logger";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacketLogger_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpamTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpamDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x040000C3 RID: 195
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.TextBox txtPackets;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.Button btnStart;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.Button btnStop;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Button btnCopy;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textToSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label x;
        private System.Windows.Forms.NumericUpDown numSpamTimes;
        private System.Windows.Forms.Button btnSendOnce;
        private System.Windows.Forms.Button btnSpam;
        private System.Windows.Forms.NumericUpDown numSpamDelay;
    }
}
