using System;
using Grimoire.Game.Data;
using Grimoire.Tools;

namespace Grimoire.Game
{
	public static class Player
	{
		public static Bank Bank { get; } = new Bank();

		public static Inventory Inventory { get; } = new Inventory();

		public static TempInventory TempInventory { get; } = new TempInventory();

		public static Quests Quests { get; } = new Quests();

		public static bool IsLoggedIn
		{
			get
			{
				return Flash.Call<bool>("IsLoggedIn", new string[0]);
			}
		}

		public static string Cell
		{
			get
			{
				return Flash.Call<string>("Cell", new string[0]);
			}
		}

		public static string Pad
		{
			get
			{
				return Flash.Call<string>("Pad", new string[0]);
			}
		}

		public static Player.State CurrentState
		{
			get
			{
				return (Player.State)Flash.Call<int>("State", new string[0]);
			}
		}

		public static int Health
		{
			get
			{
				return Flash.Call<int>("Health", new string[0]);
			}
		}

		public static int HealthMax
		{
			get
			{
				return Flash.Call<int>("HealthMax", new string[0]);
			}
		}

		public static bool IsAlive
		{
			get
			{
				return Player.Health > 0;
			}
		}

		public static int Mana
		{
			get
			{
				return Flash.Call<int>("Mana", new string[0]);
			}
		}

		public static int ManaMax
		{
			get
			{
				return Flash.Call<int>("ManaMax", new string[0]);
			}
		}

		public static string Map
		{
			get
			{
				return Flash.Call<string>("Map", new string[0]);
			}
		}

		public static int Level
		{
			get
			{
				return Flash.Call<int>("Level", new string[0]);
			}
		}

		public static int Gold
		{
			get
			{
				return Flash.Call<int>("Gold", new string[0]);
			}
		}

		public static bool HasTarget
		{
			get
			{
				return Flash.Call<bool>("HasTarget", new string[0]);
			}
		}

		public static bool AllSkillsAvailable
		{
			get
			{
				return Flash.Call<bool>("AllSkillsAvailable", new string[0]);
			}
		}
		public static int SkillAvailable(string index)
		{
			return Flash.Call<int>("SkillAvailable", new string[]
			{
				index
			});
		}

		public static bool IsAfk
		{
			get
			{
				return Flash.Call<bool>("IsAfk", new string[0]);
			}
		}

		public static float[] Position
		{
			get
			{
				return Flash.Call<float[]>("Position", new string[0]);
			}
		}

		public static void WalkToPoint(string x, string y)
		{
			Flash.Call("WalkToPoint", new string[]
			{
				x,
				y
			});
		}

		public static void CancelTarget()
		{
			Flash.Call("CancelTarget", new string[0]);
		}

		public static void AttackMonster(string name)
		{
			Flash.Call("AttackMonster", new string[]
			{
				name
			});
		}

		public static void MoveToCell(string cell, string pad = "Spawn")
		{
			Flash.Call("Jump", new string[]
			{
				cell,
				pad
			});
		}

		public static void Rest()
		{
			Flash.Call("Rest", new string[0]);
		}

		public static void JoinMap(string map, string cell = "Enter", string pad = "Spawn")
		{
			Flash.Call("Join", new string[]
			{
				map,
				cell,
				pad
			});
		}

		public static void Equip(string id)
		{
			Flash.Call("Equip", new string[]
			{
				id
			});
		}

		public static void Equip(int id)
		{
			Flash.Call("Equip", new string[]
			{
				id.ToString()
			});
		}

		public static void GotoPlayer(string name)
		{
			Flash.Call("GoTo", new string[]
			{
				name
			});
		}

		public static bool HasActiveBoost(string name)
		{
			return Flash.Call<bool>("HasActiveBoost", new string[]
			{
				name
			});
		}

		public static void UseBoost(string id)
		{
			Flash.Call("UseBoost", new string[]
			{
				id
			});
		}

		public static void UseBoost(int id)
		{
			Flash.Call("UseBoost", new string[]
			{
				id.ToString()
			});
		}

		public static void UseSkill(string index)
		{
			Flash.Call("UseSkill", new string[]
			{
				index
			});
		}

		public static void GetMapItem(string id)
		{
			Flash.Call("GetMapItem", new string[]
			{
				id
			});
		}

		public static void GetMapItem(int id)
		{
			Flash.Call("GetMapItem", new string[]
			{
				id.ToString()
			});
		}

		public static void GoToPlayer(string name)
		{
			Flash.Call("GoTo", new string[]
			{
				name
			});
		}

		public static void Logout()
		{
			Flash.Call("Logout", new string[0]);
		}

		public enum State
		{
			Dead,
			Idle,
			InCombat
		}
	}
}
