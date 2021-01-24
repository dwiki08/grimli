namespace Grimoire.UI
{
	// Token: 0x02000009 RID: 9
	public partial class PacketSpammer : global::System.Windows.Forms.Form
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x0000C61E File Offset: 0x0000A81E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000C640 File Offset: 0x0000A840
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketSpammer));
            this.lstPackets = new System.Windows.Forms.ListBox();
            this.txtPacket = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnStopCmd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // lstPackets
            // 
            this.lstPackets.BackColor = System.Drawing.Color.White;
            this.lstPackets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPackets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPackets.ForeColor = System.Drawing.Color.Black;
            this.lstPackets.FormattingEnabled = true;
            this.lstPackets.Location = new System.Drawing.Point(12, 12);
            this.lstPackets.Name = "lstPackets";
            this.lstPackets.Size = new System.Drawing.Size(276, 93);
            this.lstPackets.TabIndex = 0;
            // 
            // txtPacket
            // 
            this.txtPacket.Location = new System.Drawing.Point(12, 111);
            this.txtPacket.Name = "txtPacket";
            this.txtPacket.Size = new System.Drawing.Size(276, 20);
            this.txtPacket.TabIndex = 27;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(228, 137);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(162, 137);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(162, 166);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(60, 23);
            this.btnLoad.TabIndex = 30;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 166);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(213, 195);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 32;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(132, 195);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 33;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(12, 137);
            this.numDelay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(56, 20);
            this.numDelay.TabIndex = 34;
            this.numDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(51, 195);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 35;
            this.btnSend.Text = "Send once";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(96, 137);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(60, 23);
            this.btnRemove.TabIndex = 36;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnStopCmd
            // 
            this.btnStopCmd.Location = new System.Drawing.Point(82, 166);
            this.btnStopCmd.Name = "btnStopCmd";
            this.btnStopCmd.Size = new System.Drawing.Size(75, 23);
            this.btnStopCmd.TabIndex = 37;
            this.btnStopCmd.Text = "Stop (cmd)";
            this.btnStopCmd.UseVisualStyleBackColor = true;
            this.btnStopCmd.Click += new System.EventHandler(this.btnStopCmd_Click);
            // 
            // PacketSpammer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 228);
            this.Controls.Add(this.btnStopCmd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtPacket);
            this.Controls.Add(this.lstPackets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PacketSpammer";
            this.Text = "Packet spammer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacketSpammer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x040000CA RID: 202
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.ListBox lstPackets;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.TextBox txtPacket;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Button btnAdd;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.Button btnClear;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.Button btnLoad;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.Button btnSave;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Button btnStart;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Button btnStop;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.NumericUpDown numDelay;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Button btnSend;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnStopCmd;
    }
}
