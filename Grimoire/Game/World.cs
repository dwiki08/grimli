using System;
using System.Collections.Generic;
using Grimoire.Game.Data;
using Grimoire.Tools;

namespace Grimoire.Game
{
	public static class World
	{
		public static event Action<InventoryItem> ItemDropped;

		public static event Action<ShopInfo> ShopLoaded;

		public static void OnItemDropped(InventoryItem drop)
		{
			Action<InventoryItem> itemDropped = World.ItemDropped;
			if (itemDropped == null)
			{
				return;
			}
			itemDropped(drop);
		}

		public static void OnShopLoaded(ShopInfo shopInfo)
		{
			Action<ShopInfo> shopLoaded = World.ShopLoaded;
			if (shopLoaded != null)
			{
				shopLoaded(shopInfo);
			}
			World.LoadedShops.Add(shopInfo);
		}

		public static List<Monster> AvailableMonsters
		{
			get
			{
				return Flash.Call<List<Monster>>("GetMonstersInCell", new string[0]);
			}
		}

		public static bool IsMapLoading
		{
			get
			{
				return !Flash.Call<bool>("MapLoadComplete", new string[0]);
			}
		}

		public static List<string> PlayersInMap
		{
			get
			{
				return Flash.Call<List<string>>("PlayersInMap", new string[0]);
			}
		}

		public static List<InventoryItem> ItemTree
		{
			get
			{
				return Flash.Call<List<InventoryItem>>("GetItemTree", new string[0]);
			}
		}

		public static bool IsActionAvailable(LockActions action)
		{
			return Flash.Call<bool>("IsActionAvailable", new string[]
			{
				World.LockedActions[action]
			});
		}

		public static void SetSpawnPoint()
		{
			Flash.Call("SetSpawnPoint", new string[0]);
		}

		public static bool IsMonsterAvailable(string name)
		{
			return Flash.Call<bool>("IsMonsterAvailable", new string[]
			{
				name
			});
		}

		public static string[] Cells
		{
			get
			{
				return Flash.Call<string[]>("GetCells", new string[0]);
			}
		}

		public static int RoomId
		{
			get
			{
				return Flash.Call<int>("RoomId", new string[0]);
			}
		}

		public static List<ShopInfo> LoadedShops = new List<ShopInfo>();

		public static DropStack DropStack = new DropStack();

		private static readonly Dictionary<LockActions, string> LockedActions = new Dictionary<LockActions, string>(14)
		{
			{
				LockActions.LoadShop,
				"loadShop"
			},
			{
				LockActions.LoadEnhShop,
				"loadEnhShop"
			},
			{
				LockActions.LoadHairShop,
				"loadHairShop"
			},
			{
				LockActions.EquipItem,
				"equipItem"
			},
			{
				LockActions.UnequipItem,
				"unequipItem"
			},
			{
				LockActions.BuyItem,
				"buyItem"
			},
			{
				LockActions.SellItem,
				"sellItem"
			},
			{
				LockActions.GetMapItem,
				"getMapItem"
			},
			{
				LockActions.TryQuestComplete,
				"tryQuestComplete"
			},
			{
				LockActions.AcceptQuest,
				"acceptQuest"
			},
			{
				LockActions.DoIA,
				"doIA"
			},
			{
				LockActions.Rest,
				"rest"
			},
			{
				LockActions.Who,
				"who"
			},
			{
				LockActions.Transfer,
				"tfer"
			}
		};

		public static List<Monster> VisibleMonsters = Flash.Call<List<Monster>>("GetVisibleMonstersInCell", new string[0]);
	}
}
