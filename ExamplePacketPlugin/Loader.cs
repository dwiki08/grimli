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

        public string Description => 
            "Steps : \r\n" +
            "1. check 'Intercept' \r\n" +
            "2. equip your class \r\n" +
            "3. change cooldown value \r\n" +
            "4. 'Generate' \r\n" +
            "4. 'Send' \r\n" +
            "5. in Packet Temperer, 'Send to Client'";
        private ToolStripItem menuItem;

        public void Load()
        {
            // Add an item to the main menu in Grimoire.
            menuItem = Grimoire.UI.Root.Instance.MenuMain.Items.Add("SkillsHack");
            menuItem.Click += MenuStripItem_Click;
        }

        public void Unload() // In this method you need to clean everything up
        {
            Proxy.Instance.UnregisterHandler(Main.Instance.XtNoManaHandler);
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
