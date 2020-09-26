using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
	// Token: 0x0200003B RID: 59
	public class TempInventory
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002BC RID: 700 RVA: 0x0001301B File Offset: 0x0001121B
		public List<TempItem> Items
		{
			get
			{
				return Flash.Call<List<TempItem>>("GetTempItems", new string[0]);
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00013030 File Offset: 0x00011230
		public bool ContainsItem(string name, string qty)
		{
			TempItem tempItem = this.Items.FirstOrDefault((TempItem i) => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
			return tempItem != null && (qty == "*" || tempItem.Quantity >= int.Parse(qty));
		}
	}
}
