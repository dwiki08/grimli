using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
	// Token: 0x0200002F RID: 47
	public class Bank
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001CF RID: 463 RVA: 0x000123BB File Offset: 0x000105BB
		public List<InventoryItem> Items
		{
			get
			{
				return Flash.Call<List<InventoryItem>>("GetBankItems", new string[0]);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x000123CD File Offset: 0x000105CD
		public int AvailableSlots
		{
			get
			{
				return this.TotalSlots - this.UsedSlots;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000123DC File Offset: 0x000105DC
		public int UsedSlots
		{
			get
			{
				return Flash.Call<int>("UsedSlots", new string[0]);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x000123EE File Offset: 0x000105EE
		public int TotalSlots
		{
			get
			{
				return Flash.Call<int>("BankSlots", new string[0]);
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00012400 File Offset: 0x00010600
		public void TransferToBank(string itemName)
		{
			Flash.Call("TransferToBank", new string[]
			{
				itemName
			});
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00012416 File Offset: 0x00010616
		public void TransferFromBank(string itemName)
		{
			Flash.Call("TransferToInventory", new string[]
			{
				itemName
			});
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0001242C File Offset: 0x0001062C
		public void Swap(string invItemName, string bankItemName)
		{
			Flash.Call("BankSwap", new string[]
			{
				invItemName,
				bankItemName
			});
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00012448 File Offset: 0x00010648
		public bool ContainsItem(string itemName, string quantity = "*")
		{
			InventoryItem inventoryItem = this.Items.FirstOrDefault((InventoryItem i) => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
			return inventoryItem != null && (quantity == "*" || inventoryItem.Quantity >= int.Parse(quantity));
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0001249F File Offset: 0x0001069F
		public void Show()
		{
			Flash.Call("ShowBank", new string[0]);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000124B1 File Offset: 0x000106B1
		public void LoadItems()
		{
			Flash.Call("LoadBankItems", new string[0]);
		}
	}
}
