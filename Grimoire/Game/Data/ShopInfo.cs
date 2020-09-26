using System;
using System.Collections.Generic;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	// Token: 0x02000039 RID: 57
	public class ShopInfo
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x00012F4A File Offset: 0x0001114A
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x00012F52 File Offset: 0x00011152
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bUpgrd")]
		public bool IsMemberOnly { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00012F5B File Offset: 0x0001115B
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x00012F63 File Offset: 0x00011163
		[JsonProperty("items")]
		public List<InventoryItem> Items { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00012F6C File Offset: 0x0001116C
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x00012F74 File Offset: 0x00011174
		[JsonProperty("ShopID")]
		public int Id { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x00012F7D File Offset: 0x0001117D
		// (set) Token: 0x060002AA RID: 682 RVA: 0x00012F85 File Offset: 0x00011185
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bStaff")]
		public bool IsStaffOnly { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002AB RID: 683 RVA: 0x00012F8E File Offset: 0x0001118E
		// (set) Token: 0x060002AC RID: 684 RVA: 0x00012F96 File Offset: 0x00011196
		[JsonProperty("sName")]
		public string Name { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002AD RID: 685 RVA: 0x00012F9F File Offset: 0x0001119F
		// (set) Token: 0x060002AE RID: 686 RVA: 0x00012FA7 File Offset: 0x000111A7
		public string Location { get; set; }
	}
}
