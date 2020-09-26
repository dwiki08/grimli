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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Grimoire.UI.PacketSpammer));
			this.lstPackets = new global::System.Windows.Forms.ListBox();
			this.txtPacket = new global::System.Windows.Forms.TextBox();
			this.btnAdd = new global::System.Windows.Forms.Button();
			this.btnClear = new global::System.Windows.Forms.Button();
			this.btnLoad = new global::System.Windows.Forms.Button();
			this.btnSave = new global::System.Windows.Forms.Button();
			this.btnStart = new global::System.Windows.Forms.Button();
			this.btnStop = new global::System.Windows.Forms.Button();
			this.numDelay = new global::System.Windows.Forms.NumericUpDown();
			this.btnSend = new global::System.Windows.Forms.Button();
			this.btnRemove = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.numDelay).BeginInit();
			base.SuspendLayout();
			this.lstPackets.BackColor = global::System.Drawing.Color.White;
			this.lstPackets.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstPackets.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lstPackets.ForeColor = global::System.Drawing.Color.Black;
			this.lstPackets.FormattingEnabled = true;
			this.lstPackets.Location = new global::System.Drawing.Point(12, 12);
			this.lstPackets.Name = "lstPackets";
			this.lstPackets.Size = new global::System.Drawing.Size(276, 93);
			this.lstPackets.TabIndex = 0;
			this.txtPacket.Location = new global::System.Drawing.Point(12, 111);
			this.txtPacket.Name = "txtPacket";
			this.txtPacket.Size = new global::System.Drawing.Size(276, 20);
			this.txtPacket.TabIndex = 27;
			this.btnAdd.Location = new global::System.Drawing.Point(228, 137);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new global::System.Drawing.Size(60, 23);
			this.btnAdd.TabIndex = 28;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new global::System.EventHandler(this.btnAdd_Click);
			this.btnClear.Location = new global::System.Drawing.Point(162, 137);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new global::System.Drawing.Size(60, 23);
			this.btnClear.TabIndex = 29;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.btnLoad.Location = new global::System.Drawing.Point(162, 166);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new global::System.Drawing.Size(60, 23);
			this.btnLoad.TabIndex = 30;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new global::System.EventHandler(this.btnLoad_Click);
			this.btnSave.Location = new global::System.Drawing.Point(228, 166);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new global::System.Drawing.Size(60, 23);
			this.btnSave.TabIndex = 31;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new global::System.EventHandler(this.btnSave_Click);
			this.btnStart.Location = new global::System.Drawing.Point(213, 195);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new global::System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 32;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new global::System.EventHandler(this.btnStart_Click);
			this.btnStop.Location = new global::System.Drawing.Point(132, 195);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new global::System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 33;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new global::System.EventHandler(this.btnStop_Click);
			this.numDelay.Location = new global::System.Drawing.Point(32, 139);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numDelay;
			int[] array = new int[4];
			array[0] = 61000;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numDelay;
			int[] array2 = new int[4];
			array2[0] = 100;
			numericUpDown2.Minimum = new decimal(array2);
			this.numDelay.Name = "numDelay";
			this.numDelay.Size = new global::System.Drawing.Size(56, 20);
			this.numDelay.TabIndex = 34;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numDelay;
			int[] array3 = new int[4];
			array3[0] = 2000;
			numericUpDown3.Value = new decimal(array3);
			this.btnSend.Location = new global::System.Drawing.Point(51, 195);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new global::System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 35;
			this.btnSend.Text = "Send once";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new global::System.EventHandler(this.btnSend_Click);
			this.btnRemove.Location = new global::System.Drawing.Point(96, 137);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new global::System.Drawing.Size(60, 23);
			this.btnRemove.TabIndex = 36;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new global::System.EventHandler(this.btnRemove_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(299, 228);
			base.Controls.Add(this.btnRemove);
			base.Controls.Add(this.btnSend);
			base.Controls.Add(this.numDelay);
			base.Controls.Add(this.btnStop);
			base.Controls.Add(this.btnStart);
			base.Controls.Add(this.btnSave);
			base.Controls.Add(this.btnLoad);
			base.Controls.Add(this.btnClear);
			base.Controls.Add(this.btnAdd);
			base.Controls.Add(this.txtPacket);
			base.Controls.Add(this.lstPackets);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "PacketSpammer";
			this.Text = "Packet spammer";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.PacketSpammer_FormClosing);
			((global::System.ComponentModel.ISupportInitialize)this.numDelay).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
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
	}
}
