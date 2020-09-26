using System;
using System.Linq;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Botting.Commands.Item
{
    public class CmdBuy : IBotCommand
    {
        public int ShopId { get; set; }
        public string ItemName { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsActionAvailable(LockActions.BuyItem));
            Shop.ResetShopInfo();
            Shop.Load(ShopId);
            await instance.WaitUntil(() => Shop.IsShopLoaded);

            InventoryItem i =
                Player.Inventory.Items.FirstOrDefault(
                    item => item.Name.Equals(ItemName, StringComparison.OrdinalIgnoreCase));

            if (i != null)
            {
                Shop.BuyItem(ItemName);
                await instance.WaitUntil(() => Player.Inventory.Items
                                                   .FirstOrDefault(it => it.Name.Equals(ItemName,
                                                       StringComparison.OrdinalIgnoreCase))
                                                   .Quantity != i.Quantity);
            }
            else
            {
                Shop.BuyItem(ItemName);
                await instance.WaitUntil(
                    () => Player.Inventory.Items.FirstOrDefault(
                              it => it.Name.Equals(ItemName, StringComparison.OrdinalIgnoreCase)) != null);
            }
        }

        public override string ToString()
        {
            return $"Buy item: {ItemName}";
        }
    }
}
