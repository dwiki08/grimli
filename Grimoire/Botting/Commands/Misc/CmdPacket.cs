using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Networking;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdPacket : IBotCommand
    {
        public string Packet { get; set; }
        public int SpamTimes { get; set; } = 1;
        public bool ForClient { get; set; } = false;
        public int Delay { get; set; } = 2000;

        public async Task Execute(IBotEngine instance)
        {
            for(int i = 1; i <= SpamTimes; i++)
            {
                if (!instance.IsRunning || !Player.IsLoggedIn) break;
                if (ForClient)
                {
                    await Proxy.Instance.SendToClient(Packet);
                    await Task.Delay(Delay);
                }
                else
                {
                    await Proxy.Instance.SendToServer(Packet);
                    await Task.Delay(Delay);
                }
            }
        }

        public override string ToString()
        {
            return $"Send packet [{SpamTimes}x]: {Packet}";
        }
    }
}
