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
        public int Delay { get; set; } = 1000;

        public async Task Execute(IBotEngine instance)
        {
            for(int i = 1; i <= SpamTimes; i++)
            {
                if (!instance.IsRunning || !Player.IsLoggedIn) break;
                if (ForClient)
                {
                    string packet = Packet;
                    if (packet.Split(' ')[0] == "Level")
                    {
                        packet = "{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"cmd\":\"levelUp\",\"intExpToLevel\":\"200000\",\"intLevel\":" + packet.Split(' ')[1] + "}}}";
                    }

                    await Proxy.Instance.SendToClient(packet);
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
            string text = ForClient ? "To client" : "To server";
            return $"{text} [{SpamTimes}x]: {Packet}";
        }
    }
}
