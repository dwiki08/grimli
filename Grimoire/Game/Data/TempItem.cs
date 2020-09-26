using System;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	// Token: 0x0200003C RID: 60
	public class TempItem
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002BF RID: 703 RVA: 0x00013087 File Offset: 0x00011287
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x0001308F File Offset: 0x0001128F
		[JsonProperty("sName")]
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

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x000130A3 File Offset: 0x000112A3
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x000130AB File Offset: 0x000112AB
		[JsonProperty("sDesc")]
		public string Description { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x000130B4 File Offset: 0x000112B4
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x000130BC File Offset: 0x000112BC
		[JsonProperty("ItemID")]
		public int Id { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x000130C5 File Offset: 0x000112C5
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x000130CD File Offset: 0x000112CD
		[JsonProperty("iLvl")]
		public int Level { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x000130D6 File Offset: 0x000112D6
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x000130DE File Offset: 0x000112DE
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bCoins")]
		public bool IsAcItem { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x000130E7 File Offset: 0x000112E7
		// (set) Token: 0x060002CA RID: 714 RVA: 0x000130EF File Offset: 0x000112EF
		[JsonProperty("sLink")]
		public string Link { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002CB RID: 715 RVA: 0x000130F8 File Offset: 0x000112F8
		// (set) Token: 0x060002CC RID: 716 RVA: 0x00013100 File Offset: 0x00011300
		[JsonProperty("iQty")]
		public int Quantity { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00013109 File Offset: 0x00011309
		// (set) Token: 0x060002CE RID: 718 RVA: 0x00013111 File Offset: 0x00011311
		[JsonProperty("sType")]
		public string Type { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002CF RID: 719 RVA: 0x0001311A File Offset: 0x0001131A
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x00013122 File Offset: 0x00011322
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bUpg")]
		public bool IsMemberOnly { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x0001312B File Offset: 0x0001132B
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x00013133 File Offset: 0x00011333
		[JsonProperty("iCost")]
		public int Cost { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x0001313C File Offset: 0x0001133C
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x00013144 File Offset: 0x00011344
		[JsonProperty("iStk")]
		public int MaxStack { get; set; }

		// Token: 0x060002D5 RID: 725 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeDescription()
		{
			return false;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeLevel()
		{
			return false;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeIsAcItem()
		{
			return false;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeLink()
		{
			return false;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeType()
		{
			return false;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeIsMemberOnly()
		{
			return false;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeCost()
		{
			return false;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeMaxStack()
		{
			return false;
		}

		// Token: 0x040001AD RID: 429
		private string _name;
	}
}
