using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Map
{
    public class CmdMoveToCell : IBotCommand
    {
        public string Cell { get; set; }
        public string Pad { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            Player.MoveToCell(Cell, Pad);
            await Task.Delay(500);
        }

        public override string ToString()
        {
            return $"Move to cell: {Cell}, {Pad}";
        }
    }
}
