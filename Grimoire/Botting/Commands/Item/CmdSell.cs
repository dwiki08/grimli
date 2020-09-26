using System;
using System.Linq;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Botting.Commands.Item
{
    public class CmdSell : IBotCommand
    {
        public string ItemName { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsActionAvailable(LockActions.SellItem));
            InventoryItem item =
                Player.Inventory.Items.FirstOrDefault(
                    i => i.Name.Equals(ItemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                Shop.SellItem(ItemName);
                await instance.WaitUntil(() => !Player.Inventory.ContainsItem(item.Name, item.Quantity));
            }
        }

        public override string ToString()
        {
            return $"Sell: {ItemName}";
        }
    }
}
