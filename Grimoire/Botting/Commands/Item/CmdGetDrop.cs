using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Item
{
    public class CmdGetDrop : IBotCommand
    {
        public string ItemName { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await World.DropStack.GetDrop(ItemName);
        }

        public override string ToString()
        {
            return $"Get drop: {ItemName}";
        }
    }
}
