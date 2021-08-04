namespace ExamplePacketPlugin
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.radSkill_1 = new System.Windows.Forms.RadioButton();
            this.radSkill_2 = new System.Windows.Forms.RadioButton();
            this.radSkill_3 = new System.Windows.Forms.RadioButton();
            this.radSkill_4 = new System.Windows.Forms.RadioButton();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.chkStart2 = new System.Windows.Forms.CheckBox();
            this.tbMap = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // radSkill_1
            // 
            this.radSkill_1.Location = new System.Drawing.Point(0, 0);
            this.radSkill_1.Name = "radSkill_1";
            this.radSkill_1.Size = new System.Drawing.Size(104, 24);
            this.radSkill_1.TabIndex = 0;
            // 
            // radSkill_2
            // 
            this.radSkill_2.Location = new System.Drawing.Point(0, 0);
            this.radSkill_2.Name = "radSkill_2";
            this.radSkill_2.Size = new System.Drawing.Size(104, 24);
            this.radSkill_2.TabIndex = 0;
            // 
            // radSkill_3
            // 
            this.radSkill_3.Location = new System.Drawing.Point(0, 0);
            this.radSkill_3.Name = "radSkill_3";
            this.radSkill_3.Size = new System.Drawing.Size(104, 24);
            this.radSkill_3.TabIndex = 0;
            // 
            // radSkill_4
            // 
            this.radSkill_4.Location = new System.Drawing.Point(0, 0);
            this.radSkill_4.Name = "radSkill_4";
            this.radSkill_4.Size = new System.Drawing.Size(104, 24);
            this.radSkill_4.TabIndex = 0;
            // 
            // chkStart
            // 
            this.chkStart.AutoSize = true;
            this.chkStart.Location = new System.Drawing.Point(27, 51);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(48, 17);
            this.chkStart.TabIndex = 0;
            this.chkStart.Text = "Start";
            this.chkStart.UseVisualStyleBackColor = true;
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // chkStart2
            // 
            this.chkStart2.AutoSize = true;
            this.chkStart2.Location = new System.Drawing.Point(27, 92);
            this.chkStart2.Name = "chkStart2";
            this.chkStart2.Size = new System.Drawing.Size(57, 17);
            this.chkStart2.TabIndex = 1;
            this.chkStart2.Text = "Start 2";
            this.chkStart2.UseVisualStyleBackColor = true;
            this.chkStart2.CheckedChanged += new System.EventHandler(this.chkStart2_CheckedChanged);
            // 
            // tbMap
            // 
            this.tbMap.Location = new System.Drawing.Point(27, 25);
            this.tbMap.Name = "tbMap";
            this.tbMap.Size = new System.Drawing.Size(150, 20);
            this.tbMap.TabIndex = 2;
            this.tbMap.Text = "ultraengineer-9099";
            this.tbMap.UseWaitCursor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 121);
            this.Controls.Add(this.tbMap);
            this.Controls.Add(this.chkStart2);
            this.Controls.Add(this.chkStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultra Engineer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radSkill_1;
        private System.Windows.Forms.RadioButton radSkill_2;
        private System.Windows.Forms.RadioButton radSkill_3;
        private System.Windows.Forms.RadioButton radSkill_4;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.CheckBox chkStart2;
        private System.Windows.Forms.TextBox tbMap;
    }
}