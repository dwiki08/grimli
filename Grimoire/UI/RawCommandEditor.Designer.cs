namespace Grimoire.UI
{
	// Token: 0x0200000C RID: 12
	public partial class RawCommandEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x0000DC44 File Offset: 0x0000BE44
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000DC64 File Offset: 0x0000BE64
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawCommandEditor));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(197, 166);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(116, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(12, 12);
            this.txtCmd.Multiline = true;
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtCmd.Size = new System.Drawing.Size(260, 148);
            this.txtCmd.TabIndex = 2;
            this.txtCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCmd_KeyDown);
            // 
            // RawCommandEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 201);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RawCommandEditor";
            this.Text = "Raw Command Editor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RawCommandEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x040000E9 RID: 233
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.TextBox txtCmd;
	}
}
