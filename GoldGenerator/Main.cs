using System;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Game;
using Grimoire.Game.Data;
using System.Threading.Tasks;

namespace ExamplePacketPlugin
{
    public partial class Main : Form
    {
        public static Main Instance { get; } = new Main();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private string start = "START";
        private string stop = "STOP";

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == start && tbPassword.Text == "dijeh123")
            {
                btnStart.Text = stop;
                while (btnStart.Text == stop)
                {
                    await Proxy.Instance.SendToServer("%xt%zm%getQuests%254652%3748%");
                    await Task.Delay(500);
                    await Proxy.Instance.SendToServer("%xt%zm%sellItem%254671%9131%1%1777757744%");
                    await Task.Delay(500);
                }
            }
            else
            {
                btnStart.Text = start;
            }
        }
    }
}
