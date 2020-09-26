using System;
using System.Linq;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Botting.Commands.Item
{
    public class CmdEquip : IBotCommand
    {
        public string ItemName { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsActionAvailable(LockActions.EquipItem));
            InventoryItem item =
                Player.Inventory.Items.FirstOrDefault(
                    i => i.Name.Equals(ItemName, StringComparison.OrdinalIgnoreCase) && i.IsEquippable);
            if (item != null)
            {
                Player.Equip(item.Id);
                await instance.WaitUntil(() => Player.Inventory.Items.FirstOrDefault(
                                          it => it.IsEquipped && it.Id == item.Id) != null);
            }
        }

        public override string ToString()
        {
            return $"Equip: {ItemName}";
        }
    }
}
