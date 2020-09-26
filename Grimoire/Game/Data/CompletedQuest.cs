using System;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	// Token: 0x02000030 RID: 48
	public class CompletedQuest
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001DA RID: 474 RVA: 0x000124C3 File Offset: 0x000106C3
		// (set) Token: 0x060001DB RID: 475 RVA: 0x000124CB File Offset: 0x000106CB
		[JsonProperty("QuestID")]
		public int Id { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001DC RID: 476 RVA: 0x000124D4 File Offset: 0x000106D4
		// (set) Token: 0x060001DD RID: 477 RVA: 0x000124DC File Offset: 0x000106DC
		[JsonProperty("sName")]
		public string Name { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001DE RID: 478 RVA: 0x000124E5 File Offset: 0x000106E5
		// (set) Token: 0x060001DF RID: 479 RVA: 0x000124ED File Offset: 0x000106ED
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bSuccess")]
		public bool Success { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x000124F6 File Offset: 0x000106F6
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x000124FE File Offset: 0x000106FE
		[JsonProperty("rewardObj")]
		public QuestReward Reward { get; set; }
	}
}
