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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Travel));
            this.btnDage = new System.Windows.Forms.Button();
            this.btnEscherion = new System.Windows.Forms.Button();
            this.btnNulgath2 = new System.Windows.Forms.Button();
            this.btnNulgath = new System.Windows.Forms.Button();
            this.btnSwindle = new System.Windows.Forms.Button();
            this.btnTaro = new System.Windows.Forms.Button();
            this.btnTwins = new System.Windows.Forms.Button();
            this.btnTercess = new System.Windows.Forms.Button();
            this.grpTravel = new System.Windows.Forms.GroupBox();
            this.numPriv = new System.Windows.Forms.NumericUpDown();
            this.chkPriv = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grpTravel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDage
            // 
            this.btnDage.Location = new System.Drawing.Point(6, 247);
            this.btnDage.Name = "btnDage";
            this.btnDage.Size = new System.Drawing.Size(125, 23);
            this.btnDage.TabIndex = 0;
            this.btnDage.Text = "Dage";
            this.btnDage.UseVisualStyleBackColor = true;
            this.btnDage.Click += new System.EventHandler(this.btnDage_Click);
            // 
            // btnEscherion
            // 
            this.btnEscherion.Location = new System.Drawing.Point(6, 218);
            this.btnEscherion.Name = "btnEscherion";
            this.btnEscherion.Size = new System.Drawing.Size(125, 23);
            this.btnEscherion.TabIndex = 1;
            this.btnEscherion.Text = "Escherion";
            this.btnEscherion.UseVisualStyleBackColor = true;
            this.btnEscherion.Click += new System.EventHandler(this.btnEscherion_Click);
            // 
            // btnNulgath2
            // 
            this.btnNulgath2.Location = new System.Drawing.Point(6, 189);
            this.btnNulgath2.Name = "btnNulgath2";
            this.btnNulgath2.Size = new System.Drawing.Size(125, 23);
            this.btnNulgath2.TabIndex = 2;
            this.btnNulgath2.Text = "Nulgath 2 (tercess)";
            this.btnNulgath2.UseVisualStyleBackColor = true;
            this.btnNulgath2.Click += new System.EventHandler(this.btnNulgath2_Click);
            // 
            // btnNulgath
            // 
            this.btnNulgath.Location = new System.Drawing.Point(6, 160);
            this.btnNulgath.Name = "btnNulgath";
            this.btnNulgath.Size = new System.Drawing.Size(125, 23);
            this.btnNulgath.TabIndex = 3;
            this.btnNulgath.Text = "Nulgath (tercess)";
            this.btnNulgath.UseVisualStyleBackColor = true;
            this.btnNulgath.Click += new System.EventHandler(this.btnNulgath_Click);
            // 
            // btnSwindle
            // 
            this.btnSwindle.Location = new System.Drawing.Point(6, 131);
            this.btnSwindle.Name = "btnSwindle";
            this.btnSwindle.Size = new System.Drawing.Size(125, 23);
            this.btnSwindle.TabIndex = 4;
            this.btnSwindle.Text = "Swindle";
            this.btnSwindle.UseVisualStyleBackColor = true;
            this.btnSwindle.Click += new System.EventHandler(this.btnSwindle_Click);
            // 
            // btnTaro
            // 
            this.btnTaro.Location = new System.Drawing.Point(6, 102);
            this.btnTaro.Name = "btnTaro";
            this.btnTaro.Size = new System.Drawing.Size(125, 23);
            this.btnTaro.TabIndex = 5;
            this.btnTaro.Text = "Taro";
            this.btnTaro.UseVisualStyleBackColor = true;
            this.btnTaro.Click += new System.EventHandler(this.btnTaro_Click);
            // 
            // btnTwins
            // 
            this.btnTwins.Location = new System.Drawing.Point(6, 73);
            this.btnTwins.Name = "btnTwins";
            this.btnTwins.Size = new System.Drawing.Size(125, 23);
            this.btnTwins.TabIndex = 6;
            this.btnTwins.Text = "Twins";
            this.btnTwins.UseVisualStyleBackColor = true;
            this.btnTwins.Click += new System.EventHandler(this.btnTwins_Click);
            // 
            // btnTercess
            // 
            this.btnTercess.Location = new System.Drawing.Point(6, 44);
            this.btnTercess.Name = "btnTercess";
            this.btnTercess.Size = new System.Drawing.Size(125, 23);
            this.btnTercess.TabIndex = 7;
            this.btnTercess.Text = "Tercessuinotlim";
            this.btnTercess.UseVisualStyleBackColor = true;
            this.btnTercess.Click += new System.EventHandler(this.btnTercess_Click);
            // 
            // grpTravel
            // 
            this.grpTravel.Controls.Add(this.button1);
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
            this.grpTravel.Location = new System.Drawing.Point(13, 13);
            this.grpTravel.Name = "grpTravel";
            this.grpTravel.Size = new System.Drawing.Size(138, 309);
            this.grpTravel.TabIndex = 8;
            this.grpTravel.TabStop = false;
            this.grpTravel.Text = "Fast travels";
            // 
            // numPriv
            // 
            this.numPriv.Enabled = false;
            this.numPriv.Location = new System.Drawing.Point(64, 18);
            this.numPriv.Name = "numPriv";
            this.numPriv.Size = new System.Drawing.Size(67, 20);
            this.numPriv.TabIndex = 1;
            // 
            // chkPriv
            // 
            this.chkPriv.AutoSize = true;
            this.chkPriv.Location = new System.Drawing.Point(6, 19);
            this.chkPriv.Name = "chkPriv";
            this.chkPriv.Size = new System.Drawing.Size(59, 17);
            this.chkPriv.TabIndex = 0;
            this.chkPriv.Text = "Private";
            this.chkPriv.UseVisualStyleBackColor = true;
            this.chkPriv.CheckedChanged += new System.EventHandler(this.chkPriv_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Klunk Shop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Travel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(162, 334);
            this.Controls.Add(this.grpTravel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Travel";
            this.Text = "Fast travels";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Travel_FormClosing);
            this.grpTravel.ResumeLayout(false);
            this.grpTravel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriv)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button button1;
    }
}
