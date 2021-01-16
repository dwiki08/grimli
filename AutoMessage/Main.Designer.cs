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
            this.radWorld = new System.Windows.Forms.RadioButton();
            this.radWhisper = new System.Windows.Forms.RadioButton();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.txtMessager = new System.Windows.Forms.TextBox();
            this.labMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTrigger = new System.Windows.Forms.TextBox();
            this.chkAutoRep = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbListTR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNickException = new System.Windows.Forms.TextBox();
            this.tbNickExceptiona = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numMaxResp = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResp)).BeginInit();
            this.SuspendLayout();
            // 
            // radWorld
            // 
            this.radWorld.AutoSize = true;
            this.radWorld.Checked = true;
            this.radWorld.Location = new System.Drawing.Point(101, 34);
            this.radWorld.Name = "radWorld";
            this.radWorld.Size = new System.Drawing.Size(53, 17);
            this.radWorld.TabIndex = 2;
            this.radWorld.TabStop = true;
            this.radWorld.Text = "World";
            this.radWorld.UseVisualStyleBackColor = true;
            // 
            // radWhisper
            // 
            this.radWhisper.AutoSize = true;
            this.radWhisper.Location = new System.Drawing.Point(170, 34);
            this.radWhisper.Name = "radWhisper";
            this.radWhisper.Size = new System.Drawing.Size(64, 17);
            this.radWhisper.TabIndex = 3;
            this.radWhisper.Text = "Whisper";
            this.radWhisper.UseVisualStyleBackColor = true;
            // 
            // chkStart
            // 
            this.chkStart.AutoSize = true;
            this.chkStart.Location = new System.Drawing.Point(252, 34);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(48, 17);
            this.chkStart.TabIndex = 4;
            this.chkStart.Text = "Start";
            this.chkStart.UseVisualStyleBackColor = true;
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // txtMessager
            // 
            this.txtMessager.Location = new System.Drawing.Point(16, 57);
            this.txtMessager.Multiline = true;
            this.txtMessager.Name = "txtMessager";
            this.txtMessager.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessager.Size = new System.Drawing.Size(286, 67);
            this.txtMessager.TabIndex = 6;
            this.txtMessager.Text = "{GUEST}, Selamat datang di Indomaret :)";
            // 
            // labMsg
            // 
            this.labMsg.Location = new System.Drawing.Point(13, 9);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(232, 29);
            this.labMsg.TabIndex = 1;
            this.labMsg.Text = "Auto message to player who join the room.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Auto response chat.";
            // 
            // tbTrigger
            // 
            this.tbTrigger.Location = new System.Drawing.Point(63, 237);
            this.tbTrigger.Multiline = true;
            this.tbTrigger.Name = "tbTrigger";
            this.tbTrigger.Size = new System.Drawing.Size(235, 40);
            this.tbTrigger.TabIndex = 8;
            this.tbTrigger.Text = "hi";
            // 
            // chkAutoRep
            // 
            this.chkAutoRep.AutoSize = true;
            this.chkAutoRep.Location = new System.Drawing.Point(247, 214);
            this.chkAutoRep.Name = "chkAutoRep";
            this.chkAutoRep.Size = new System.Drawing.Size(48, 17);
            this.chkAutoRep.TabIndex = 9;
            this.chkAutoRep.Text = "Start";
            this.chkAutoRep.UseVisualStyleBackColor = true;
            this.chkAutoRep.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "trigger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "response";
            // 
            // tbResponse
            // 
            this.tbResponse.Location = new System.Drawing.Point(63, 286);
            this.tbResponse.Multiline = true;
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.Size = new System.Drawing.Size(235, 39);
            this.tbResponse.TabIndex = 12;
            this.tbResponse.Text = "Hai juga {GUEST}  :)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-10, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(225, 331);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbListTR
            // 
            this.tbListTR.Location = new System.Drawing.Point(14, 363);
            this.tbListTR.Multiline = true;
            this.tbListTR.Name = "tbListTR";
            this.tbListTR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbListTR.Size = new System.Drawing.Size(286, 91);
            this.tbListTR.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "List trigger-response";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "blacklist";
            // 
            // tbNickException
            // 
            this.tbNickException.Location = new System.Drawing.Point(63, 462);
            this.tbNickException.Multiline = true;
            this.tbNickException.Name = "tbNickException";
            this.tbNickException.Size = new System.Drawing.Size(237, 42);
            this.tbNickException.TabIndex = 18;
            this.tbNickException.Text = "nick1;nick2;";
            // 
            // tbNickExceptiona
            // 
            this.tbNickExceptiona.Location = new System.Drawing.Point(63, 130);
            this.tbNickExceptiona.Multiline = true;
            this.tbNickExceptiona.Name = "tbNickExceptiona";
            this.tbNickExceptiona.Size = new System.Drawing.Size(239, 42);
            this.tbNickExceptiona.TabIndex = 20;
            this.tbNickExceptiona.Text = "nick1;nick2;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "blacklist";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-10, 516);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(343, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 533);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Auto add to blacklist after ";
            // 
            // numMaxResp
            // 
            this.numMaxResp.Location = new System.Drawing.Point(151, 534);
            this.numMaxResp.Name = "numMaxResp";
            this.numMaxResp.Size = new System.Drawing.Size(51, 20);
            this.numMaxResp.TabIndex = 23;
            this.numMaxResp.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "response";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 566);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numMaxResp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbNickExceptiona);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbNickException);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbListTR);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbResponse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkAutoRep);
            this.Controls.Add(this.tbTrigger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessager);
            this.Controls.Add(this.chkStart);
            this.Controls.Add(this.radWhisper);
            this.Controls.Add(this.radWorld);
            this.Controls.Add(this.labMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoMessage";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radWorld;
        private System.Windows.Forms.RadioButton radWhisper;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.TextBox txtMessager;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTrigger;
        private System.Windows.Forms.CheckBox chkAutoRep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbResponse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbListTR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNickException;
        private System.Windows.Forms.TextBox tbNickExceptiona;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numMaxResp;
        private System.Windows.Forms.Label label10;
    }
}