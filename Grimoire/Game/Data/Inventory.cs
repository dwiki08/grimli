using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
	// Token: 0x02000031 RID: 49
	public class Inventory
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00012507 File Offset: 0x00010707
		public List<InventoryItem> Items
		{
			get
			{
				return Flash.Call<List<InventoryItem>>("GetInventoryItems", new string[0]);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00012519 File Offset: 0x00010719
		public int MaxSlots
		{
			get
			{
				return Flash.Call<int>("InventorySlots", new string[0]);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0001252B File Offset: 0x0001072B
		public int UsedSlots
		{
			get
			{
				return Flash.Call<int>("UsedInventorySlots", new string[0]);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0001253D File Offset: 0x0001073D
		public int AvailableSlots
		{
			get
			{
				return this.MaxSlots - this.UsedSlots;
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0001254C File Offset: 0x0001074C
		public bool ContainsItem(string name, string quantity)
		{
			InventoryItem inventoryItem = this.Items.FirstOrDefault((InventoryItem i) => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
			return inventoryItem != null && (quantity == "*" || inventoryItem.Quantity >= int.Parse(quantity));
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000125A4 File Offset: 0x000107A4
		public bool ContainsItem(string name, int quantity)
		{
			InventoryItem inventoryItem = this.Items.FirstOrDefault((InventoryItem i) => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
			return inventoryItem != null && inventoryItem.Quantity >= quantity;
		}
	}
}
