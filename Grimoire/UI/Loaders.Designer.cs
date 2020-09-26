namespace Grimoire.UI
{
	// Token: 0x02000007 RID: 7
	public partial class Loaders : global::System.Windows.Forms.Form
	{
		// Token: 0x06000083 RID: 131 RVA: 0x0000B854 File Offset: 0x00009A54
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000B874 File Offset: 0x00009A74
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loaders));
            this.txtLoaders = new System.Windows.Forms.TextBox();
            this.cbLoad = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbGrab = new System.Windows.Forms.ComboBox();
            this.btnGrab = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.treeGrabbed = new System.Windows.Forms.TreeView();
            this.numQuestPlus = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoaders
            // 
            this.txtLoaders.Location = new System.Drawing.Point(12, 12);
            this.txtLoaders.Name = "txtLoaders";
            this.txtLoaders.Size = new System.Drawing.Size(136, 20);
            this.txtLoaders.TabIndex = 29;
            // 
            // cbLoad
            // 
            this.cbLoad.FormattingEnabled = true;
            this.cbLoad.Items.AddRange(new object[] {
            "Hair shop",
            "Shop",
            "Quest",
            "Armor customizer"});
            this.cbLoad.Location = new System.Drawing.Point(12, 38);
            this.cbLoad.Name = "cbLoad";
            this.cbLoad.Size = new System.Drawing.Size(136, 21);
            this.cbLoad.TabIndex = 30;
            this.cbLoad.SelectedIndexChanged += new System.EventHandler(this.cbLoad_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 65);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(136, 23);
            this.btnLoad.TabIndex = 31;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbGrab
            // 
            this.cbGrab.FormattingEnabled = true;
            this.cbGrab.Items.AddRange(new object[] {
            "Shop items",
            "Quest IDs",
            "Quest items, drop rates",
            "Inventory items",
            "Temp inventory items",
            "Bank items",
            "Monsters"});
            this.cbGrab.Location = new System.Drawing.Point(12, 301);
            this.cbGrab.Name = "cbGrab";
            this.cbGrab.Size = new System.Drawing.Size(229, 21);
            this.cbGrab.TabIndex = 33;
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(166, 328);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(75, 23);
            this.btnGrab.TabIndex = 34;
            this.btnGrab.Text = "Grab";
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(85, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // treeGrabbed
            // 
            this.treeGrabbed.LabelEdit = true;
            this.treeGrabbed.Location = new System.Drawing.Point(12, 94);
            this.treeGrabbed.Name = "treeGrabbed";
            this.treeGrabbed.Size = new System.Drawing.Size(229, 201);
            this.treeGrabbed.TabIndex = 38;
            // 
            // numQuestPlus
            // 
            this.numQuestPlus.Enabled = false;
            this.numQuestPlus.Location = new System.Drawing.Point(167, 13);
            this.numQuestPlus.Name = "numQuestPlus";
            this.numQuestPlus.Size = new System.Drawing.Size(75, 20);
            this.numQuestPlus.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "+";
            // 
            // btnFAccept
            // 
            this.btnFAccept.Enabled = false;
            this.btnFAccept.Location = new System.Drawing.Point(166, 37);
            this.btnFAccept.Name = "btnFAccept";
            this.btnFAccept.Size = new System.Drawing.Size(77, 23);
            this.btnFAccept.TabIndex = 42;
            this.btnFAccept.Text = "FAccept";
            this.btnFAccept.UseVisualStyleBackColor = true;
            this.btnFAccept.Click += new System.EventHandler(this.btnFAccept_Click);
            // 
            // Loaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 360);
            this.Controls.Add(this.btnFAccept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numQuestPlus);
            this.Controls.Add(this.treeGrabbed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGrab);
            this.Controls.Add(this.cbGrab);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cbLoad);
            this.Controls.Add(this.txtLoaders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Loaders";
            this.Text = "Loaders and grabbers";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Loaders_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numQuestPlus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x040000BA RID: 186
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.TextBox txtLoaders;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.ComboBox cbLoad;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.Button btnLoad;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.ComboBox cbGrab;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.Button btnGrab;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Button btnSave;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.TreeView treeGrabbed;
        private System.Windows.Forms.NumericUpDown numQuestPlus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFAccept;
    }
}
