namespace Grimoire.UI
{
	public partial class Hotkeys : global::System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hotkeys));
            this.lstKeys = new System.Windows.Forms.ListBox();
            this.cbKeys = new System.Windows.Forms.ComboBox();
            this.cbActions = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstKeys
            // 
            this.lstKeys.BackColor = System.Drawing.Color.White;
            this.lstKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstKeys.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstKeys.ForeColor = System.Drawing.Color.Black;
            this.lstKeys.FormattingEnabled = true;
            this.lstKeys.HorizontalScrollbar = true;
            this.lstKeys.Location = new System.Drawing.Point(12, 68);
            this.lstKeys.Name = "lstKeys";
            this.lstKeys.Size = new System.Drawing.Size(230, 80);
            this.lstKeys.TabIndex = 28;
            // 
            // cbKeys
            // 
            this.cbKeys.FormattingEnabled = true;
            this.cbKeys.Items.AddRange(new object[] {
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
            "F12"});
            this.cbKeys.Location = new System.Drawing.Point(12, 12);
            this.cbKeys.Name = "cbKeys";
            this.cbKeys.Size = new System.Drawing.Size(72, 21);
            this.cbKeys.TabIndex = 29;
            // 
            // cbActions
            // 
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Items.AddRange(new object[] {
            "Show Bot",
            "Show Hotkeys",
            "Show Loaders",
            "Show Packet logger",
            "Show Packet spammer",
            "Show Fast travels",
            "Minimize to tray",
            "Show bank"});
            this.cbActions.Location = new System.Drawing.Point(90, 12);
            this.cbActions.Name = "cbActions";
            this.cbActions.Size = new System.Drawing.Size(152, 21);
            this.cbActions.TabIndex = 30;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(177, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 23);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(106, 39);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(65, 23);
            this.btnRemove.TabIndex = 32;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 23);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Hotkeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 186);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbActions);
            this.Controls.Add(this.cbKeys);
            this.Controls.Add(this.lstKeys);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Hotkeys";
            this.Text = "Hotkeys";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hotkeys_FormClosing);
            this.Load += new System.EventHandler(this.Hotkeys_Load);
            this.ResumeLayout(false);

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.ListBox lstKeys;

		private global::System.Windows.Forms.ComboBox cbKeys;

		private global::System.Windows.Forms.ComboBox cbActions;

		private global::System.Windows.Forms.Button btnAdd;

		private global::System.Windows.Forms.Button btnRemove;

		private global::System.Windows.Forms.Button btnSave;
	}
}
