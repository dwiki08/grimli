namespace Grimoire.UI
{
	// Token: 0x02000006 RID: 6
	public partial class Hotkeys : global::System.Windows.Forms.Form
	{
		// Token: 0x06000079 RID: 121 RVA: 0x0000AEC4 File Offset: 0x000090C4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000AEE4 File Offset: 0x000090E4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Grimoire.UI.Hotkeys));
			this.lstKeys = new global::System.Windows.Forms.ListBox();
			this.cbKeys = new global::System.Windows.Forms.ComboBox();
			this.cbActions = new global::System.Windows.Forms.ComboBox();
			this.btnAdd = new global::System.Windows.Forms.Button();
			this.btnRemove = new global::System.Windows.Forms.Button();
			this.btnSave = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lstKeys.BackColor = global::System.Drawing.Color.White;
			this.lstKeys.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstKeys.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lstKeys.ForeColor = global::System.Drawing.Color.Black;
			this.lstKeys.FormattingEnabled = true;
			this.lstKeys.HorizontalScrollbar = true;
			this.lstKeys.Location = new global::System.Drawing.Point(12, 68);
			this.lstKeys.Name = "lstKeys";
			this.lstKeys.Size = new global::System.Drawing.Size(230, 80);
			this.lstKeys.TabIndex = 28;
			this.cbKeys.FormattingEnabled = true;
			this.cbKeys.Items.AddRange(new object[]
			{
				"Left",
				"Up",
				"Right",
				"Down",
				"D0",
				"D1",
				"D2",
				"D3",
				"D4",
				"D5",
				"D6",
				"D7",
				"D8",
				"D9",
				"A",
				"B",
				"C",
				"D",
				"E",
				"F",
				"G",
				"H",
				"I",
				"J",
				"K",
				"L",
				"M",
				"N",
				"O",
				"P",
				"Q",
				"R",
				"S",
				"T",
				"U",
				"V",
				"W",
				"X",
				"Y",
				"Z",
				"F1",
				"F2",
				"F3",
				"F4",
				"F5",
				"F6",
				"F7",
				"F8",
				"F9",
				"F10",
				"F11",
				"F12"
			});
			this.cbKeys.Location = new global::System.Drawing.Point(12, 12);
			this.cbKeys.Name = "cbKeys";
			this.cbKeys.Size = new global::System.Drawing.Size(72, 21);
			this.cbKeys.TabIndex = 29;
			this.cbActions.FormattingEnabled = true;
			this.cbActions.Items.AddRange(new object[]
			{
				"Show Bot",
				"Show Hotkeys",
				"Show Loaders",
				"Show Packet logger",
				"Show Packet spammer",
				"Show Fast travels",
				"Minimize to tray",
				"Show bank"
			});
			this.cbActions.Location = new global::System.Drawing.Point(90, 12);
			this.cbActions.Name = "cbActions";
			this.cbActions.Size = new global::System.Drawing.Size(152, 21);
			this.cbActions.TabIndex = 30;
			this.btnAdd.Location = new global::System.Drawing.Point(177, 39);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new global::System.Drawing.Size(65, 23);
			this.btnAdd.TabIndex = 31;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new global::System.EventHandler(this.btnAdd_Click);
			this.btnRemove.Location = new global::System.Drawing.Point(106, 39);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new global::System.Drawing.Size(65, 23);
			this.btnRemove.TabIndex = 32;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new global::System.EventHandler(this.btnRemove_Click);
			this.btnSave.Location = new global::System.Drawing.Point(12, 154);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new global::System.Drawing.Size(230, 23);
			this.btnSave.TabIndex = 33;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new global::System.EventHandler(this.btnSave_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(255, 186);
			base.Controls.Add(this.btnSave);
			base.Controls.Add(this.btnRemove);
			base.Controls.Add(this.btnAdd);
			base.Controls.Add(this.cbActions);
			base.Controls.Add(this.cbKeys);
			base.Controls.Add(this.lstKeys);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Hotkeys";
			this.Text = "Hotkeys";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Hotkeys_FormClosing);
			base.Load += new global::System.EventHandler(this.Hotkeys_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040000B2 RID: 178
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.ListBox lstKeys;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.ComboBox cbKeys;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.ComboBox cbActions;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.Button btnAdd;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.Button btnRemove;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.Button btnSave;
	}
}
