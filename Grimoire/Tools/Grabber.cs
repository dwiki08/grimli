using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Tools
{
	public static class Grabber
	{

		public static List<String> GetQuestRewards (int idQuest)
		{
			List<String> listItem = new List<string>();

			List<Quest> questTree = Player.Quests.QuestTree;
			foreach (Quest q in questTree)
            {
				if (q.Id == idQuest)
                {
					foreach (InventoryItem item in q.Rewards)
                    {
						listItem.Add(item.Name);
					}
				}
            }

			return listItem;
		}

		public static List<String> GetQuestRequirment(int idQuest)
		{
			List<String> listItem = new List<string>();

			List<Quest> questTree = Player.Quests.QuestTree;
			foreach (Quest q in questTree)
			{
				if (q.Id == idQuest)
				{
					foreach (InventoryItem item in q.RequiredItems)
					{
						listItem.Add(item.Name);
					}
				}
			}

			return listItem;
		}


		public static void GrabQuests(TreeView tree)
		{
			List<Quest> questTree = Player.Quests.QuestTree;
			List<Quest> list;
			if (questTree == null)
			{
				list = null;
			}
			else
			{
				list = (from q in questTree
				orderby q.Name
				select q).ToList<Quest>();
			}
			List<Quest> list2 = list;
			if (list2 != null && list2.Count > 0)
			{
				foreach (Quest quest in list2)
				{
					TreeNode treeNode = tree.Nodes.Add(quest.Name);
					treeNode.Nodes.Add(string.Format("ID: {0}", quest.Id));
					List<InventoryItem> requiredItems = quest.RequiredItems;
					if (requiredItems != null && requiredItems.Count > 0)
					{
						TreeNode treeNode2 = treeNode.Nodes.Add("Required items");
						foreach (InventoryItem inventoryItem in quest.RequiredItems)
						{
							TreeNode treeNode3 = treeNode2.Nodes.Add(inventoryItem.Name);
							treeNode3.Nodes.Add(string.Format("ID: {0}", inventoryItem.Id));
							treeNode3.Nodes.Add(string.Format("Quantity: {0}", inventoryItem.Quantity));
						}
					}
					List<InventoryItem> rewards = quest.Rewards;
					if (rewards != null && rewards.Count > 0)
					{
						TreeNode treeNode4 = treeNode.Nodes.Add("Rewards");
						foreach (InventoryItem inventoryItem2 in quest.Rewards)
						{
							TreeNode treeNode5 = treeNode4.Nodes.Add(inventoryItem2.Name);
							treeNode5.Nodes.Add(string.Format("ID: {0}", inventoryItem2.Id));
							treeNode5.Nodes.Add(string.Format("Quantity: {0}", inventoryItem2.Quantity));
							treeNode5.Nodes.Add("Drop chance: " + inventoryItem2.DropChance);
						}
					}
				}
			}
		}

		public static void GrabShopItems(TreeView tree)
		{
			List<ShopInfo> loadedShops = World.LoadedShops;
			List<ShopInfo> list;
			if (loadedShops == null)
			{
				list = null;
			}
			else
			{
				list = (from s in loadedShops
				orderby s.Name
				select s).ToList<ShopInfo>();
			}
			List<ShopInfo> list2 = list;
			if (list2 != null && list2.Count > 0)
			{
				foreach (ShopInfo shopInfo in list2)
				{
					TreeNode treeNode = tree.Nodes.Add(shopInfo.Name);
					treeNode.Nodes.Add(string.Format("ID: {0}", shopInfo.Id));
					treeNode.Nodes.Add("Location: " + shopInfo.Location);
					List<InventoryItem> items = shopInfo.Items;
					if (items != null && items.Count > 0)
					{
						TreeNode treeNode2 = treeNode.Nodes.Add("Items");
						foreach (InventoryItem inventoryItem in shopInfo.Items)
						{
							TreeNode treeNode3 = treeNode2.Nodes.Add(inventoryItem.Name);
							treeNode3.Nodes.Add(string.Format("Shop item ID: {0}", inventoryItem.ShopItemId));
							treeNode3.Nodes.Add(string.Format("ID: {0}", inventoryItem.Id));
							treeNode3.Nodes.Add(string.Format("Cost: {0} {1}", inventoryItem.Cost, inventoryItem.IsAcItem ? "AC" : "Gold"));
							treeNode3.Nodes.Add("Category: " + inventoryItem.Category);
						}
					}
				}
			}
		}

		public static void GrabQuestIds(TreeView tree)
		{
			List<Quest> questTree = Player.Quests.QuestTree;
			List<Quest> list;
			if (questTree == null)
			{
				list = null;
			}
			else
			{
				list = (from q in questTree
				orderby q.Name
				select q).ToList<Quest>();
			}
			List<Quest> list2 = list;
			if (list2 != null && list2.Count > 0)
			{
				foreach (Quest quest in list2)
				{
					tree.Nodes.Add(string.Format("{0} - {1}", quest.Id, quest.Name));
				}
			}
		}

		public static void GrabInventoryItems(TreeView tree)
		{
			Grabber.GrabItems(tree, true);
		}

		public static void GrabBankItems(TreeView tree)
		{
			Grabber.GrabItems(tree, false);
		}

		private static void GrabItems(TreeView tree, bool inventory)
		{
			List<InventoryItem> list = inventory ? Player.Inventory.Items : Player.Bank.Items;
			List<InventoryItem> list2;
			if (list == null)
			{
				list2 = null;
			}
			else
			{
				list2 = (from i in list
				orderby i.Name
				select i).ToList<InventoryItem>();
			}
			List<InventoryItem> list3 = list2;
			if (list3 != null && list3.Count > 0)
			{
				foreach (InventoryItem inventoryItem in list3)
				{
					TreeNode treeNode = tree.Nodes.Add(inventoryItem.Name);
					treeNode.Nodes.Add(string.Format("ID: {0}", inventoryItem.Id));
					treeNode.Nodes.Add(string.Format("Char item id: {0}", inventoryItem.CharItemId));
					treeNode.Nodes.Add(string.Format("Quantity: {0}", inventoryItem.Quantity));
					treeNode.Nodes.Add(string.Format("AC tagged: {0}", inventoryItem.IsAcItem));
					treeNode.Nodes.Add("Category: " + inventoryItem.Category);
					treeNode.Nodes.Add(string.Format("Max stack: {0}", inventoryItem.MaxStack));
				}
			}
		}

		public static void GrabTempItems(TreeView tree)
		{
			List<TempItem> items = Player.TempInventory.Items;
			List<TempItem> list;
			if (items == null)
			{
				list = null;
			}
			else
			{
				list = (from i in items
				orderby i.Name
				select i).ToList<TempItem>();
			}
			List<TempItem> list2 = list;
			if (list2 != null && list2.Count > 0)
			{
				foreach (TempItem tempItem in list2)
				{
					TreeNode treeNode = tree.Nodes.Add(tempItem.Name);
					treeNode.Nodes.Add(string.Format("ID: {0}", tempItem.Id));
					treeNode.Nodes.Add(string.Format("Quantity: {0}", tempItem.Quantity));
				}
			}
		}

		public static void GrabMonsters(TreeView tree)
		{
			List<Monster> availableMonsters = World.AvailableMonsters;
			List<Monster> list;
			if (availableMonsters == null)
			{
				list = null;
			}
			else
			{
				list = (from m in availableMonsters
				group m by m.Name into x
				select x.First<Monster>()).ToList<Monster>();
			}
			List<Monster> list2 = list;
			if (list2 != null && list2.Count > 0)
			{
				foreach (Monster monster in list2)
				{
					TreeNode treeNode = tree.Nodes.Add(monster.Name);
					treeNode.Nodes.Add(string.Format("ID: {0}", monster.Id));
					treeNode.Nodes.Add("Race: " + monster.Race);
					treeNode.Nodes.Add(string.Format("Level: {0}", monster.Level));
					treeNode.Nodes.Add(string.Format("Health: {0}", monster.Health));
					treeNode.Nodes.Add(string.Format("Max health: {0}", monster.MaxHealth));
				}
			}
		}
	}
}
