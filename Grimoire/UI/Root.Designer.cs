namespace Grimoire.UI
{
	public partial class Root : global::System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Root));
            this.nTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbPads = new System.Windows.Forms.ComboBox();
            this.cbCells = new System.Windows.Forms.ComboBox();
            this.btnBank = new System.Windows.Forms.Button();
            this.prgLoader = new System.Windows.Forms.ProgressBar();
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.botToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastTravelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadersgrabbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snifferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spammerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tampererToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numFPS = new System.Windows.Forms.NumericUpDown();
            this.btnFPS = new System.Windows.Forms.Button();
            this.flashPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.chkAttack = new System.Windows.Forms.CheckBox();
            this.MenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // nTray
            // 
            this.nTray.Text = "Grimoire";
            this.nTray.Visible = true;
            // 
            // cbPads
            // 
            this.cbPads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPads.FormattingEnabled = true;
            this.cbPads.Items.AddRange(new object[] {
            "Center",
            "Spawn",
            "Left",
            "Right",
            "Top",
            "Bottom",
            "Up",
            "Down"});
            this.cbPads.Location = new System.Drawing.Point(658, 2);
            this.cbPads.Name = "cbPads";
            this.cbPads.Size = new System.Drawing.Size(91, 21);
            this.cbPads.TabIndex = 17;
            this.cbPads.SelectedIndexChanged += new System.EventHandler(this.cbPads_SelectedIndexChanged);
            // 
            // cbCells
            // 
            this.cbCells.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCells.FormattingEnabled = true;
            this.cbCells.Location = new System.Drawing.Point(755, 2);
            this.cbCells.Name = "cbCells";
            this.cbCells.Size = new System.Drawing.Size(122, 21);
            this.cbCells.TabIndex = 18;
            this.cbCells.SelectedIndexChanged += new System.EventHandler(this.cbCells_SelectedIndexChanged);
            this.cbCells.Click += new System.EventHandler(this.cbCells_Click);
            // 
            // btnBank
            // 
            this.btnBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBank.Location = new System.Drawing.Point(882, 1);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(75, 23);
            this.btnBank.TabIndex = 20;
            this.btnBank.Text = "Bank";
            this.btnBank.UseVisualStyleBackColor = true;
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // prgLoader
            // 
            this.prgLoader.Location = new System.Drawing.Point(12, 276);
            this.prgLoader.Name = "prgLoader";
            this.prgLoader.Size = new System.Drawing.Size(936, 23);
            this.prgLoader.TabIndex = 21;
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.packetsToolStripMenuItem});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(960, 24);
            this.MenuMain.TabIndex = 22;
            this.MenuMain.Text = "menuStrip";
            // 
            // botToolStripMenuItem
            // 
            this.botToolStripMenuItem.Name = "botToolStripMenuItem";
            this.botToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.botToolStripMenuItem.Text = "Bot";
            this.botToolStripMenuItem.Click += new System.EventHandler(this.botToolStripMenuItem_Click_1);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastTravelsToolStripMenuItem,
            this.loadersgrabbersToolStripMenuItem,
            this.hotkeysToolStripMenuItem,
            this.pluginManagerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // fastTravelsToolStripMenuItem
            // 
            this.fastTravelsToolStripMenuItem.Name = "fastTravelsToolStripMenuItem";
            this.fastTravelsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.fastTravelsToolStripMenuItem.Text = "Fast travels";
            this.fastTravelsToolStripMenuItem.Click += new System.EventHandler(this.fastTravelsToolStripMenuItem_Click);
            // 
            // loadersgrabbersToolStripMenuItem
            // 
            this.loadersgrabbersToolStripMenuItem.Name = "loadersgrabbersToolStripMenuItem";
            this.loadersgrabbersToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadersgrabbersToolStripMenuItem.Text = "Loaders/grabbers";
            this.loadersgrabbersToolStripMenuItem.Click += new System.EventHandler(this.loadersgrabbersToolStripMenuItem_Click);
            // 
            // hotkeysToolStripMenuItem
            // 
            this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
            this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.hotkeysToolStripMenuItem.Text = "Hotkeys";
            this.hotkeysToolStripMenuItem.Click += new System.EventHandler(this.hotkeysToolStripMenuItem_Click);
            // 
            // pluginManagerToolStripMenuItem
            // 
            this.pluginManagerToolStripMenuItem.Name = "pluginManagerToolStripMenuItem";
            this.pluginManagerToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.pluginManagerToolStripMenuItem.Text = "Plugin manager";
            this.pluginManagerToolStripMenuItem.Click += new System.EventHandler(this.pluginManagerToolStripMenuItem_Click);
            // 
            // packetsToolStripMenuItem
            // 
            this.packetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snifferToolStripMenuItem,
            this.spammerToolStripMenuItem,
            this.tampererToolStripMenuItem});
            this.packetsToolStripMenuItem.Name = "packetsToolStripMenuItem";
            this.packetsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.packetsToolStripMenuItem.Text = "Packets";
            // 
            // snifferToolStripMenuItem
            // 
            this.snifferToolStripMenuItem.Name = "snifferToolStripMenuItem";
            this.snifferToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.snifferToolStripMenuItem.Text = "Sniffer";
            this.snifferToolStripMenuItem.Click += new System.EventHandler(this.snifferToolStripMenuItem_Click);
            // 
            // spammerToolStripMenuItem
            // 
            this.spammerToolStripMenuItem.Name = "spammerToolStripMenuItem";
            this.spammerToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.spammerToolStripMenuItem.Text = "Spammer";
            this.spammerToolStripMenuItem.Click += new System.EventHandler(this.spammerToolStripMenuItem_Click);
            // 
            // tampererToolStripMenuItem
            // 
            this.tampererToolStripMenuItem.Name = "tampererToolStripMenuItem";
            this.tampererToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.tampererToolStripMenuItem.Text = "Tamperer";
            this.tampererToolStripMenuItem.Click += new System.EventHandler(this.tampererToolStripMenuItem_Click);
            // 
            // numFPS
            // 
            this.numFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numFPS.Location = new System.Drawing.Point(609, 2);
            this.numFPS.Name = "numFPS";
            this.numFPS.Size = new System.Drawing.Size(43, 20);
            this.numFPS.TabIndex = 23;
            this.numFPS.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnFPS
            // 
            this.btnFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFPS.Location = new System.Drawing.Point(546, 1);
            this.btnFPS.Name = "btnFPS";
            this.btnFPS.Size = new System.Drawing.Size(57, 23);
            this.btnFPS.TabIndex = 24;
            this.btnFPS.Text = "Set FPS";
            this.btnFPS.UseVisualStyleBackColor = true;
            this.btnFPS.Click += new System.EventHandler(this.btnFPS_Click);
            // 
            // flashPlayer
            // 
            this.flashPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flashPlayer.Enabled = true;
            this.flashPlayer.Location = new System.Drawing.Point(0, 25);
            this.flashPlayer.Name = "flashPlayer";
            this.flashPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flashPlayer.OcxState")));
            this.flashPlayer.Size = new System.Drawing.Size(960, 550);
            this.flashPlayer.TabIndex = 2;
            this.flashPlayer.Visible = false;
            // 
            // chkAttack
            // 
            this.chkAttack.AutoSize = true;
            this.chkAttack.Location = new System.Drawing.Point(448, 4);
            this.chkAttack.Name = "chkAttack";
            this.chkAttack.Size = new System.Drawing.Size(82, 17);
            this.chkAttack.TabIndex = 25;
            this.chkAttack.Text = "Auto Attack";
            this.chkAttack.UseVisualStyleBackColor = true;
            this.chkAttack.Visible = false;
            this.chkAttack.CheckedChanged += new System.EventHandler(this.chkAttack_CheckedChangedAsync);
            // 
            // Root
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 575);
            this.Controls.Add(this.chkAttack);
            this.Controls.Add(this.btnFPS);
            this.Controls.Add(this.numFPS);
            this.Controls.Add(this.prgLoader);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.cbCells);
            this.Controls.Add(this.cbPads);
            this.Controls.Add(this.flashPlayer);
            this.Controls.Add(this.MenuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Root";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grimoire 3.8Li";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Root_FormClosing);
            this.Load += new System.EventHandler(this.Root_Load);
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.NotifyIcon nTray;

		private global::AxShockwaveFlashObjects.AxShockwaveFlash flashPlayer;

		private global::System.Windows.Forms.ComboBox cbPads;

		private global::System.Windows.Forms.ComboBox cbCells;

		private global::System.Windows.Forms.Button btnBank;

		private global::System.Windows.Forms.ProgressBar prgLoader;

		private global::System.Windows.Forms.ToolStripMenuItem botToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem fastTravelsToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem loadersgrabbersToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem hotkeysToolStripMenuItem;

		public global::System.Windows.Forms.MenuStrip MenuMain;

		private global::System.Windows.Forms.ToolStripMenuItem pluginManagerToolStripMenuItem;

		private global::System.Windows.Forms.NumericUpDown numFPS;

		private global::System.Windows.Forms.Button btnFPS;

		private global::System.Windows.Forms.ToolStripMenuItem packetsToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem snifferToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem spammerToolStripMenuItem;

		private global::System.Windows.Forms.ToolStripMenuItem tampererToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkAttack;
    }
}
