using System;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	// Token: 0x02000035 RID: 53
	public class QuestReward
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00012A7E File Offset: 0x00010C7E
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00012A86 File Offset: 0x00010C86
		[JsonProperty("iCP")]
		public int ClassPoints { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00012A8F File Offset: 0x00010C8F
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00012A97 File Offset: 0x00010C97
		[JsonProperty("intGold")]
		public int Gold { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00012AA0 File Offset: 0x00010CA0
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00012AA8 File Offset: 0x00010CA8
		[JsonProperty("intExp")]
		public int Experience { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00012AB1 File Offset: 0x00010CB1
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00012AB9 File Offset: 0x00010CB9
		[JsonProperty("typ")]
		public string Type { get; set; }
	}
}
