using System;

namespace Grimoire.Networking
{
	// Token: 0x0200001E RID: 30
	public class Message
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00010E68 File Offset: 0x0000F068
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00010E70 File Offset: 0x0000F070
		public string RawContent { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00010E79 File Offset: 0x0000F079
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00010E81 File Offset: 0x0000F081
		public string Command { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00010E8A File Offset: 0x0000F08A
		// (set) Token: 0x0600014C RID: 332 RVA: 0x00010E92 File Offset: 0x0000F092
		public bool Send { get; set; } = true;
	}
}
