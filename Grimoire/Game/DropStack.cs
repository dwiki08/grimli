using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Grimoire.Game.Data;
using Grimoire.Networking;

namespace Grimoire.Game
{
	public class DropStack : IReadOnlyList<InventoryItem>, IReadOnlyCollection<InventoryItem>, IEnumerable<InventoryItem>, IEnumerable
	{
		public DropStack()
		{
			World.ItemDropped += this.OnItemDropped;
		}

		public int Count
		{
			get
			{
				return this._drops.Count;
			}
		}

		public InventoryItem this[int index]
		{
			get
			{
				if (index >= this._drops.Count)
				{
					return null;
				}
				return this._drops[index];
			}
		}

		public IEnumerator<InventoryItem> GetEnumerator()
		{
			return this._drops.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		private void OnItemDropped(InventoryItem item)
		{
			if (this._drops.All((InventoryItem d) => d.Id != item.Id))
			{
				this._drops.Add(item);
			}
		}

		public async Task<bool> GetDrop(InventoryItem item)
		{
			return await this.GetDrop(item.Id);
		}

		public async Task<bool> GetDrop(string itemName)
		{
			InventoryItem inventoryItem = this._drops.FirstOrDefault((InventoryItem d) => d.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
			bool flag = inventoryItem != null;
			if (flag)
			{
				flag = await this.GetDrop(inventoryItem.Id);
			}
			return flag;
		}

		public async Task<bool> GetDrop(int itemId)
		{
			if (this.Contains(itemId))
			{
				this._cooldown.RemoveAll((KeyValuePair<int, Stopwatch> c) => c.Value.ElapsedMilliseconds >= 3000L);
				if (!this.IsCoolingDown(itemId))
				{
					await Proxy.Instance.SendToServer(string.Format("%xt%zm%getDrop%{0}%{1}%", World.RoomId, itemId));
					this._cooldown.Add(new KeyValuePair<int, Stopwatch>(itemId, Stopwatch.StartNew()));
					this._drops.RemoveAll((InventoryItem d) => d.Id == itemId);
					return true;
				}
			}
			return false;
		}

		public void Clear()
		{
			this._drops.Clear();
			this._cooldown.Clear();
		}

		private bool IsCoolingDown(int itemId)
		{
			KeyValuePair<int, Stopwatch> keyValuePair = this._cooldown.FirstOrDefault((KeyValuePair<int, Stopwatch> i) => i.Key == itemId);
			return keyValuePair.Key != 0 && (int)keyValuePair.Value.ElapsedMilliseconds < 3000;
		}

		public bool Contains(InventoryItem item)
		{
			return this.Contains(item.Id);
		}

		public bool Contains(int itemId)
		{
			return this._drops.FirstOrDefault((InventoryItem d) => d.Id == itemId) != null;
		}

		public bool Contains(string itemName)
		{
			return this._drops.FirstOrDefault((InventoryItem d) => d.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase)) != null;
		}

		private readonly List<InventoryItem> _drops = new List<InventoryItem>();

		private readonly List<KeyValuePair<int, Stopwatch>> _cooldown = new List<KeyValuePair<int, Stopwatch>>();
	}
}
