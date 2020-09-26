using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Map
{
    public class CmdWalk : IBotCommand
    {
        public string X { get; set; }
        public string Y { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            Player.WalkToPoint(X, Y);
            await instance.WaitUntil(() =>
            {
                float[] pos = Player.Position;
                return pos[0].ToString() == X && pos[1].ToString() == Y;
            });
        }

        public override string ToString()
        {
            return $"Walk to: {X}, {Y}";
        }
    }
}
