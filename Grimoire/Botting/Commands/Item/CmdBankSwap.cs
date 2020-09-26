using System;
using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Item
{
    public class CmdBankSwap : IBotCommand
    {
        public string BankItemName { get; set; }
        public string InventoryItemName { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            bool CanExecute() => Player.Bank.ContainsItem(BankItemName) && Player.Inventory.ContainsItem(InventoryItemName, "*");

            if (CanExecute())
            {
                Player.Bank.Swap(InventoryItemName, BankItemName);
                await instance.WaitUntil(() => !CanExecute());
            }
        }

        public override string ToString()
        {
            return $"Bank swap {{{BankItemName}, {InventoryItemName}}}";
        }
    }
}
