namespace Grimoire.UI
{
	// Token: 0x0200000E RID: 14
	public partial class Travel : global::System.Windows.Forms.Form
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x0000EEFD File Offset: 0x0000D0FD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000EF1C File Offset: 0x0000D11C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Grimoire.UI.Travel));
			this.btnDage = new global::System.Windows.Forms.Button();
			this.btnEscherion = new global::System.Windows.Forms.Button();
			this.btnNulgath2 = new global::System.Windows.Forms.Button();
			this.btnNulgath = new global::System.Windows.Forms.Button();
			this.btnSwindle = new global::System.Windows.Forms.Button();
			this.btnTaro = new global::System.Windows.Forms.Button();
			this.btnTwins = new global::System.Windows.Forms.Button();
			this.btnTercess = new global::System.Windows.Forms.Button();
			this.grpTravel = new global::System.Windows.Forms.GroupBox();
			this.numPriv = new global::System.Windows.Forms.NumericUpDown();
			this.chkPriv = new global::System.Windows.Forms.CheckBox();
			this.grpTravel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numPriv).BeginInit();
			base.SuspendLayout();
			this.btnDage.Location = new global::System.Drawing.Point(6, 247);
			this.btnDage.Name = "btnDage";
			this.btnDage.Size = new global::System.Drawing.Size(125, 23);
			this.btnDage.TabIndex = 0;
			this.btnDage.Text = "Dage";
			this.btnDage.UseVisualStyleBackColor = true;
			this.btnDage.Click += new global::System.EventHandler(this.btnDage_Click);
			this.btnEscherion.Location = new global::System.Drawing.Point(6, 218);
			this.btnEscherion.Name = "btnEscherion";
			this.btnEscherion.Size = new global::System.Drawing.Size(125, 23);
			this.btnEscherion.TabIndex = 1;
			this.btnEscherion.Text = "Escherion";
			this.btnEscherion.UseVisualStyleBackColor = true;
			this.btnEscherion.Click += new global::System.EventHandler(this.btnEscherion_Click);
			this.btnNulgath2.Location = new global::System.Drawing.Point(6, 189);
			this.btnNulgath2.Name = "btnNulgath2";
			this.btnNulgath2.Size = new global::System.Drawing.Size(125, 23);
			this.btnNulgath2.TabIndex = 2;
			this.btnNulgath2.Text = "Nulgath 2 (tercess)";
			this.btnNulgath2.UseVisualStyleBackColor = true;
			this.btnNulgath2.Click += new global::System.EventHandler(this.btnNulgath2_Click);
			this.btnNulgath.Location = new global::System.Drawing.Point(6, 160);
			this.btnNulgath.Name = "btnNulgath";
			this.btnNulgath.Size = new global::System.Drawing.Size(125, 23);
			this.btnNulgath.TabIndex = 3;
			this.btnNulgath.Text = "Nulgath (tercess)";
			this.btnNulgath.UseVisualStyleBackColor = true;
			this.btnNulgath.Click += new global::System.EventHandler(this.btnNulgath_Click);
			this.btnSwindle.Location = new global::System.Drawing.Point(6, 131);
			this.btnSwindle.Name = "btnSwindle";
			this.btnSwindle.Size = new global::System.Drawing.Size(125, 23);
			this.btnSwindle.TabIndex = 4;
			this.btnSwindle.Text = "Swindle";
			this.btnSwindle.UseVisualStyleBackColor = true;
			this.btnSwindle.Click += new global::System.EventHandler(this.btnSwindle_Click);
			this.btnTaro.Location = new global::System.Drawing.Point(6, 102);
			this.btnTaro.Name = "btnTaro";
			this.btnTaro.Size = new global::System.Drawing.Size(125, 23);
			this.btnTaro.TabIndex = 5;
			this.btnTaro.Text = "Taro";
			this.btnTaro.UseVisualStyleBackColor = true;
			this.btnTaro.Click += new global::System.EventHandler(this.btnTaro_Click);
			this.btnTwins.Location = new global::System.Drawing.Point(6, 73);
			this.btnTwins.Name = "btnTwins";
			this.btnTwins.Size = new global::System.Drawing.Size(125, 23);
			this.btnTwins.TabIndex = 6;
			this.btnTwins.Text = "Twins";
			this.btnTwins.UseVisualStyleBackColor = true;
			this.btnTwins.Click += new global::System.EventHandler(this.btnTwins_Click);
			this.btnTercess.Location = new global::System.Drawing.Point(6, 44);
			this.btnTercess.Name = "btnTercess";
			this.btnTercess.Size = new global::System.Drawing.Size(125, 23);
			this.btnTercess.TabIndex = 7;
			this.btnTercess.Text = "Tercessuinotlim";
			this.btnTercess.UseVisualStyleBackColor = true;
			this.btnTercess.Click += new global::System.EventHandler(this.btnTercess_Click);
			this.grpTravel.Controls.Add(this.numPriv);
			this.grpTravel.Controls.Add(this.btnDage);
			this.grpTravel.Controls.Add(this.btnEscherion);
			this.grpTravel.Controls.Add(this.btnNulgath2);
			this.grpTravel.Controls.Add(this.btnNulgath);
			this.grpTravel.Controls.Add(this.btnSwindle);
			this.grpTravel.Controls.Add(this.btnTaro);
			this.grpTravel.Controls.Add(this.btnTwins);
			this.grpTravel.Controls.Add(this.btnTercess);
			this.grpTravel.Controls.Add(this.chkPriv);
			this.grpTravel.Location = new global::System.Drawing.Point(13, 13);
			this.grpTravel.Name = "grpTravel";
			this.grpTravel.Size = new global::System.Drawing.Size(138, 276);
			this.grpTravel.TabIndex = 8;
			this.grpTravel.TabStop = false;
			this.grpTravel.Text = "Fast travels";
			this.numPriv.Enabled = false;
			this.numPriv.Location = new global::System.Drawing.Point(64, 18);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numPriv;
			int[] array = new int[4];
			array[0] = 1000000;
			numericUpDown.Maximum = new decimal(array);
			this.numPriv.Name = "numPriv";
			this.numPriv.Size = new global::System.Drawing.Size(67, 20);
			this.numPriv.TabIndex = 1;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numPriv;
			int[] array2 = new int[4];
			array2[0] = 123456;
			numericUpDown2.Value = new decimal(array2);
			this.chkPriv.AutoSize = true;
			this.chkPriv.Location = new global::System.Drawing.Point(6, 19);
			this.chkPriv.Name = "chkPriv";
			this.chkPriv.Size = new global::System.Drawing.Size(59, 17);
			this.chkPriv.TabIndex = 0;
			this.chkPriv.Text = "Private";
			this.chkPriv.UseVisualStyleBackColor = true;
			this.chkPriv.CheckedChanged += new global::System.EventHandler(this.chkPriv_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(162, 298);
			base.Controls.Add(this.grpTravel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Travel";
			this.Text = "Fast travels";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Travel_FormClosing);
			this.grpTravel.ResumeLayout(false);
			this.grpTravel.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numPriv).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000103 RID: 259
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.Button btnDage;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.Button btnEscherion;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.Button btnNulgath2;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.Button btnNulgath;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.Button btnSwindle;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.Button btnTaro;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.Button btnTwins;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.Button btnTercess;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.GroupBox grpTravel;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.NumericUpDown numPriv;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.CheckBox chkPriv;
	}
}
