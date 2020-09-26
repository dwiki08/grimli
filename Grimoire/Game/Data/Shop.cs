using System;
using System.Collections.Generic;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	// Token: 0x02000038 RID: 56
	public class Shop
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00012E56 File Offset: 0x00011056
		// (set) Token: 0x06000293 RID: 659 RVA: 0x00012E5E File Offset: 0x0001105E
		[JsonProperty("sName")]
		public string Name { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00012E67 File Offset: 0x00011067
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00012E6F File Offset: 0x0001106F
		[JsonProperty("ShopID")]
		public int Id { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00012E78 File Offset: 0x00011078
		// (set) Token: 0x06000297 RID: 663 RVA: 0x00012E80 File Offset: 0x00011080
		[JsonProperty("items")]
		public List<InventoryItem> Items { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00012E89 File Offset: 0x00011089
		// (set) Token: 0x06000299 RID: 665 RVA: 0x00012E91 File Offset: 0x00011091
		public string Location { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600029A RID: 666 RVA: 0x00012E9A File Offset: 0x0001109A
		public static bool IsShopLoaded
		{
			get
			{
				return Flash.Call<bool>("IsShopLoaded", new string[0]);
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00012EAC File Offset: 0x000110AC
		public static void BuyItem(string name)
		{
			Flash.Call("BuyItem", new string[]
			{
				name
			});
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00012EC2 File Offset: 0x000110C2
		public static void ResetShopInfo()
		{
			Flash.Call("ResetShopInfo", new string[0]);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00012ED4 File Offset: 0x000110D4
		public static void Load(int id)
		{
			Flash.Call("LoadShop", new string[]
			{
				id.ToString()
			});
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00012EF0 File Offset: 0x000110F0
		public static void SellItem(string name)
		{
			Flash.Call("SellItem", new string[]
			{
				name
			});
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00012F06 File Offset: 0x00011106
		public static void LoadHairShop(string id)
		{
			Flash.Call("LoadHairShop", new string[]
			{
				id
			});
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00012F1C File Offset: 0x0001111C
		public static void LoadHairShop(int id)
		{
			Flash.Call("LoadHairShop", new string[]
			{
				id.ToString()
			});
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00012F38 File Offset: 0x00011138
		public static void LoadArmorCustomizer()
		{
			Flash.Call("LoadArmorCustomizer", new string[0]);
		}
	}
}
