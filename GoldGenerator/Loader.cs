﻿using System;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Tools.Plugins;

namespace ExamplePacketPlugin
{
    [GrimoirePluginEntry]
    public class Loader : IGrimoirePlugin
    {
        public string Author => "Froztt13";

        public string Description => "Gold generator \r\nby Froztt13";

        private ToolStripItem menuItem;

        public void Load()
        {
            // Add an item to the main menu in Grimoire.
            menuItem = Grimoire.UI.Root.Instance.MenuMain.Items.Add("Gold generator");
            menuItem.Click += MenuStripItem_Click;
        }

        public void Unload() // In this method you need to clean everything up
        {
            menuItem.Click -= MenuStripItem_Click;
            Grimoire.UI.Root.Instance.MenuMain.Items.Remove(menuItem);
            Main.Instance.Dispose();
        }

        private void MenuStripItem_Click(object sender, EventArgs e)
        {
            if (Main.Instance.Visible)
            {
                Main.Instance.Hide();
            }
            else
            {
                Main.Instance.Show();
                Main.Instance.BringToFront();
            }
        }
    }
}
