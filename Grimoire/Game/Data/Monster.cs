using System;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	// Token: 0x02000033 RID: 51
	public class Monster
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000217 RID: 535 RVA: 0x000127D1 File Offset: 0x000109D1
		// (set) Token: 0x06000218 RID: 536 RVA: 0x000127D9 File Offset: 0x000109D9
		[JsonProperty("sRace")]
		public string Race { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000219 RID: 537 RVA: 0x000127E2 File Offset: 0x000109E2
		// (set) Token: 0x0600021A RID: 538 RVA: 0x000127EA File Offset: 0x000109EA
		[JsonProperty("strMonName")]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = ((value != null) ? value.Trim() : null);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600021B RID: 539 RVA: 0x000127FE File Offset: 0x000109FE
		// (set) Token: 0x0600021C RID: 540 RVA: 0x00012806 File Offset: 0x00010A06
		[JsonProperty("MonID")]
		public int Id { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0001280F File Offset: 0x00010A0F
		// (set) Token: 0x0600021E RID: 542 RVA: 0x00012817 File Offset: 0x00010A17
		[JsonProperty("iLvl")]
		public int Level { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00012820 File Offset: 0x00010A20
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00012828 File Offset: 0x00010A28
		[JsonProperty("intState")]
		public int State { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00012831 File Offset: 0x00010A31
		// (set) Token: 0x06000222 RID: 546 RVA: 0x00012839 File Offset: 0x00010A39
		[JsonProperty("intHP")]
		public int Health { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000223 RID: 547 RVA: 0x00012842 File Offset: 0x00010A42
		// (set) Token: 0x06000224 RID: 548 RVA: 0x0001284A File Offset: 0x00010A4A
		[JsonProperty("intHPMax")]
		public int MaxHealth { get; set; }

		// Token: 0x04000179 RID: 377
		private string _name;
	}
}
