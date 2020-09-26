using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Tools.Buyback;

namespace Grimoire.Botting.Commands.Item
{
    public class CmdBuyBack : IBotCommand
    {
        public string ItemName { get; set; }
        public int PageNumberCap { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            if (!Player.Inventory.ContainsItem(ItemName, "*"))
            {
                try
                {
                    await Task.Run(async () =>
                    {
                        using (AutoBuyBack abb = new AutoBuyBack())
                            await abb.Perform(ItemName, PageNumberCap);
                    });
                    Player.Logout();
                }
                catch
                {
                }
            }
        }

        public override string ToString()
        {
            return $"Buy back: {ItemName}";
        }
    }
}
