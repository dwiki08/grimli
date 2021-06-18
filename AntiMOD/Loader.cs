using System;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Tools.Plugins;

namespace ExamplePacketPlugin
{
    [GrimoirePluginEntry]
    public class Loader : IGrimoirePlugin
    {
        public string Author => "Froztt13";

        public string Description => "When you meet staff/mod in your map cell" +
            "\r\n \r\n" +
            "NET Framework 4.5.2" +
            "\r\n" +
            "Json.NET 13.0.1";
        private ToolStripItem menuItem;

        public void Load()
        {
            // Add an item to the main menu in Grimoire.
            menuItem = Grimoire.UI.Root.Instance.MenuMain.Items.Add("AntiMod");
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
