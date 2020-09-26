using System;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	// Token: 0x02000037 RID: 55
	public class Server
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00012DDF File Offset: 0x00010FDF
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00012DE7 File Offset: 0x00010FE7
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bOnline")]
		public bool IsOnline { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00012DF0 File Offset: 0x00010FF0
		// (set) Token: 0x06000282 RID: 642 RVA: 0x00012DF8 File Offset: 0x00010FF8
		[JsonProperty("bCount")]
		public int PlayerCount { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00012E01 File Offset: 0x00011001
		// (set) Token: 0x06000284 RID: 644 RVA: 0x00012E09 File Offset: 0x00011009
		[JsonProperty("sName")]
		public string Name { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00012E12 File Offset: 0x00011012
		// (set) Token: 0x06000286 RID: 646 RVA: 0x00012E1A File Offset: 0x0001101A
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bUpg")]
		public bool IsMemberOnly { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00012E23 File Offset: 0x00011023
		// (set) Token: 0x06000288 RID: 648 RVA: 0x00012E2B File Offset: 0x0001102B
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("iChat")]
		public bool IsChatRestricted { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00012E34 File Offset: 0x00011034
		// (set) Token: 0x0600028A RID: 650 RVA: 0x00012E3C File Offset: 0x0001103C
		[JsonProperty("iPort")]
		public int Port { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00012E45 File Offset: 0x00011045
		// (set) Token: 0x0600028C RID: 652 RVA: 0x00012E4D File Offset: 0x0001104D
		[JsonProperty("sIP")]
		public string Ip { get; set; }

		// Token: 0x0600028D RID: 653 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeIsOnline()
		{
			return false;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializePlayerCount()
		{
			return false;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeIsMemberOnly()
		{
			return false;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeIsChatRestricted()
		{
			return false;
		}
	}
}
