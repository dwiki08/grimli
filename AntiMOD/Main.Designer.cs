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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkModOnly = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numBeep = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLogs = new System.Windows.Forms.TextBox();
            this.btnModAction = new System.Windows.Forms.Button();
            this.chkStopBot = new System.Windows.Forms.CheckBox();
            this.chkLogout = new System.Windows.Forms.CheckBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBeep)).BeginInit();
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
            this.chkStart.Location = new System.Drawing.Point(20, 238);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(48, 17);
            this.chkStart.TabIndex = 0;
            this.chkStart.Text = "Start";
            this.chkStart.UseVisualStyleBackColor = true;
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLogout);
            this.groupBox1.Controls.Add(this.chkStopBot);
            this.groupBox1.Controls.Add(this.btnModAction);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numBeep);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbLogs);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 218);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // chkModOnly
            // 
            this.chkModOnly.AutoSize = true;
            this.chkModOnly.Checked = true;
            this.chkModOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModOnly.Location = new System.Drawing.Point(87, 238);
            this.chkModOnly.Name = "chkModOnly";
            this.chkModOnly.Size = new System.Drawing.Size(90, 17);
            this.chkModOnly.TabIndex = 8;
            this.chkModOnly.Text = "Log only Mod";
            this.chkModOnly.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Logs";
            // 
            // numBeep
            // 
            this.numBeep.Location = new System.Drawing.Point(5, 69);
            this.numBeep.Name = "numBeep";
            this.numBeep.Size = new System.Drawing.Size(50, 20);
            this.numBeep.TabIndex = 6;
            this.numBeep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "beep";
            // 
            // tbLogs
            // 
            this.tbLogs.Location = new System.Drawing.Point(6, 117);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.Size = new System.Drawing.Size(263, 95);
            this.tbLogs.TabIndex = 2;
            // 
            // btnModAction
            // 
            this.btnModAction.Location = new System.Drawing.Point(197, 23);
            this.btnModAction.Name = "btnModAction";
            this.btnModAction.Size = new System.Drawing.Size(72, 23);
            this.btnModAction.TabIndex = 9;
            this.btnModAction.Text = "Test Action";
            this.btnModAction.UseVisualStyleBackColor = true;
            this.btnModAction.Click += new System.EventHandler(this.btnModAction_Click);
            // 
            // chkStopBot
            // 
            this.chkStopBot.AutoSize = true;
            this.chkStopBot.Checked = true;
            this.chkStopBot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStopBot.Location = new System.Drawing.Point(6, 23);
            this.chkStopBot.Name = "chkStopBot";
            this.chkStopBot.Size = new System.Drawing.Size(67, 17);
            this.chkStopBot.TabIndex = 10;
            this.chkStopBot.Text = "Stop Bot";
            this.chkStopBot.UseVisualStyleBackColor = true;
            // 
            // chkLogout
            // 
            this.chkLogout.AutoSize = true;
            this.chkLogout.Checked = true;
            this.chkLogout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogout.Location = new System.Drawing.Point(6, 46);
            this.chkLogout.Name = "chkLogout";
            this.chkLogout.Size = new System.Drawing.Size(59, 17);
            this.chkLogout.TabIndex = 11;
            this.chkLogout.Text = "Logout";
            this.chkLogout.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(210, 234);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(72, 23);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 265);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkStart);
            this.Controls.Add(this.chkModOnly);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AntiMod";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBeep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radSkill_1;
        private System.Windows.Forms.RadioButton radSkill_2;
        private System.Windows.Forms.RadioButton radSkill_3;
        private System.Windows.Forms.RadioButton radSkill_4;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbLogs;
        private System.Windows.Forms.NumericUpDown numBeep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkModOnly;
        private System.Windows.Forms.Button btnModAction;
        private System.Windows.Forms.CheckBox chkLogout;
        private System.Windows.Forms.CheckBox chkStopBot;
        private System.Windows.Forms.Button btnClearLog;
    }
}