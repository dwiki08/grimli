using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Tools;
using Grimoire.Tools.Plugins;
using Grimoire.UI;

namespace Grimoire
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string PluginsPath { get; private set; }
        public static Tools.Plugins.PluginManager PluginsManager { get; private set; }

        [STAThread]
        private static void Main()
        {
            Program.TryCreateDirectory(Program.PluginsPath = Path.Combine(Application.StartupPath, "Plugins"));
            int listenerPort;
            if (Program.FindAvailablePort(out listenerPort))
            {
                if (FindAvailablePort(out int port))
                    Proxy.Instance.ListenerPort = port;
                else return;

                //Proxy.Instance.ListenerPort = listenerPort;
                Program.PluginsManager = new Tools.Plugins.PluginManager();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                BotManager.Instance.Load += Program.OnMainFormLoaded;
                //Program.PluginsManager.UnloadAll();
                Application.Run(new Root());
                Proxy.Instance.Stop(true);

            }
        }

        private static void OnMainFormLoaded(object sender, EventArgs e)
        {
            ((Form)sender).Load -= Program.OnMainFormLoaded;
            Program.PluginsManager.LoadRange(Directory.GetFiles(Program.PluginsPath));
        }

        private static void TryCreateDirectory(string dir)
        {
            try
            {
                Directory.CreateDirectory(dir);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(string.Format("Failed to create directory: {0}\nAccess denied", dir));
            }
            catch (PathTooLongException)
            {
                MessageBox.Show(string.Format("Failed to create directory: {0}\nThe specified path is too long.", dir) + "Try moving the Grimoire directory out of the current directory");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed to create directory {0}\n{1}", dir, ex.Message));
            }
        }


        private static bool FindAvailablePort(out int port)
        {
            Random random = new Random();
            IPGlobalProperties ipProps = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] conns;
            IPEndPoint[] listeners;

            try
            {
                conns = ipProps.GetActiveTcpConnections();
                listeners = ipProps.GetActiveTcpListeners();
            }
            catch (NetworkInformationException)
            {
                port = 0;
                return false;
            }

            while (true)
            {
                int randPort = random.Next(1001, 65535);

                var conn = conns.FirstOrDefault(c => c.LocalEndPoint.Port == randPort);
                var lis = listeners.FirstOrDefault(l => l.Port == randPort);

                if (conn == null && lis == null)
                {
                    port = randPort;
                    return true;
                }
            }
        }
    }
}
