using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grimoire.Botting.Commands.Item;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Combat
{
    public class CmdKillFor : IBotCommand
    {
        public string Monster { get; set; }
        public string MonId { get; set; }
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        public string Quantity { get; set; }
        public bool IsGetDrops { get; set; } = false;
        public int AfterKills { get; set; } = 1;
        public string QuestId { get; set; }
        public int DelayAfterKill { get; set; } = 500;

        private Configuration config;
        public async Task Execute(IBotEngine instance)
        {
            CmdKill kill = new CmdKill { Monster = Monster, MonId = MonId };

            int id;
            if (int.TryParse(QuestId, out id))
            {
                while (!Player.Quests.IsInProgress(id))
                {
                    Player.Quests.Accept(id);
                    await Task.Delay(1000);
                }
                while (instance.IsRunning && Player.IsLoggedIn && Player.IsAlive && !Player.Quests.CanComplete(id))
                {
                    await kill.Execute(instance);
                    await Task.Delay(DelayAfterKill);
                }
            } 
            else 
            {
                List<string> removedList = new List<string>();
                config = instance.Configuration;

                string[] itemsName = ItemName.Split(new char[] { ',' });

                string[] quantities = Quantity.Split(new char[] { ',' });

                if (IsGetDrops)
                {
                    foreach (string _itemName in itemsName)
                    {
                        if (config.Drops.Any((string d) => d.Equals(_itemName, StringComparison.OrdinalIgnoreCase)))
                        {
                            config.Drops.Remove(_itemName);
                            removedList.Add(_itemName);
                        }

                    }
                }

                if (ItemType == ItemType.Items)
                {
                    int times = 0;
                    bool flagItem = !Enumerable.Range(0, itemsName.Length).All(i => Player.Inventory.ContainsItem(itemsName[i], quantities[i]));
                    bool flagTempItem = !Enumerable.Range(0, itemsName.Length).All(i => Player.TempInventory.ContainsItem(itemsName[i], quantities[i]));
                    bool flagHunt;
                    if (ItemType == ItemType.Items)
                    {
                        flagHunt = flagItem;
                    }
                    else
                    {
                        flagHunt = flagTempItem;
                    }
                    while (instance.IsRunning && Player.IsLoggedIn && Player.IsAlive && flagHunt)
                    {
                        await kill.Execute(instance);
                        await Task.Delay(DelayAfterKill);
                        if (IsGetDrops && times >= AfterKills)
                        {
                            foreach (string _itemName in itemsName)
                            {
                                CmdGetDrop getDrop = new CmdGetDrop { ItemName = _itemName };
                                await getDrop.Execute(instance);
                            }
                            times = 0;
                        }
                        times++;
                    }
                }
                else
                {
                    while (instance.IsRunning && Player.IsLoggedIn && Player.IsAlive &&
                        !Player.TempInventory.ContainsItem(ItemName, Quantity))
                    {
                        await kill.Execute(instance);
                        await Task.Delay(DelayAfterKill);
                    }
                }

                if (IsGetDrops)
                {
                    foreach (string _removed in removedList)
                    {
                        if (!config.Drops.Contains(_removed)) config.Drops.Add(_removed);
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"KF {(int.TryParse(QuestId, out _) ? "quest" : (ItemType == ItemType.Items ? "items" : "tempitems") )}: {Monster} {(IsGetDrops ? $" get drops, {AfterKills}kills" : "")}";
        }
    }
}
