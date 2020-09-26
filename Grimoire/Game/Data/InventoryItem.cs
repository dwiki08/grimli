using System;
using System.Linq;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	// Token: 0x02000032 RID: 50
	public class InventoryItem
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001EA RID: 490 RVA: 0x000125E7 File Offset: 0x000107E7
		// (set) Token: 0x060001EB RID: 491 RVA: 0x000125EF File Offset: 0x000107EF
		[JsonProperty("iQty")]
		public int Quantity { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001EC RID: 492 RVA: 0x000125F8 File Offset: 0x000107F8
		// (set) Token: 0x060001ED RID: 493 RVA: 0x00012600 File Offset: 0x00010800
		[JsonProperty("sDesc")]
		public string Description { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00012609 File Offset: 0x00010809
		// (set) Token: 0x060001EF RID: 495 RVA: 0x00012611 File Offset: 0x00010811
		[JsonProperty("iStk")]
		public int MaxStack { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0001261A File Offset: 0x0001081A
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x00012622 File Offset: 0x00010822
		[JsonProperty("iLvl")]
		public int Level { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x0001262B File Offset: 0x0001082B
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x00012633 File Offset: 0x00010833
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bCoins")]
		public bool IsAcItem { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x0001263C File Offset: 0x0001083C
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x00012644 File Offset: 0x00010844
		public int CharItemId { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x0001264D File Offset: 0x0001084D
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x00012655 File Offset: 0x00010855
		[JsonProperty("sLink")]
		public string Link { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x0001265E File Offset: 0x0001085E
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x00012666 File Offset: 0x00010866
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bEquip")]
		public bool IsEquipped { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001FA RID: 506 RVA: 0x0001266F File Offset: 0x0001086F
		// (set) Token: 0x060001FB RID: 507 RVA: 0x00012677 File Offset: 0x00010877
		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bUpg")]
		public bool IsMemberOnly { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00012680 File Offset: 0x00010880
		// (set) Token: 0x060001FD RID: 509 RVA: 0x00012688 File Offset: 0x00010888
		[JsonProperty("iCost")]
		public int Cost { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00012691 File Offset: 0x00010891
		// (set) Token: 0x060001FF RID: 511 RVA: 0x00012699 File Offset: 0x00010899
		[JsonProperty("sType")]
		public string Category { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000200 RID: 512 RVA: 0x000126A2 File Offset: 0x000108A2
		// (set) Token: 0x06000201 RID: 513 RVA: 0x000126AA File Offset: 0x000108AA
		[JsonProperty("ItemID")]
		public int Id { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000202 RID: 514 RVA: 0x000126B3 File Offset: 0x000108B3
		// (set) Token: 0x06000203 RID: 515 RVA: 0x000126F0 File Offset: 0x000108F0
		[JsonProperty("sName")]
		public string Name
		{
			get
			{
				if (string.IsNullOrEmpty(this._name))
				{
					InventoryItem inventoryItem = World.ItemTree.FirstOrDefault((InventoryItem i) => i.Id == this.Id);
					this._name = ((inventoryItem != null) ? inventoryItem.Name : null);
				}
				return this._name;
			}
			set
			{
				this._name = ((value != null) ? value.Trim() : null);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000204 RID: 516 RVA: 0x00012704 File Offset: 0x00010904
		// (set) Token: 0x06000205 RID: 517 RVA: 0x0001270C File Offset: 0x0001090C
		[JsonProperty("ShopItemID")]
		public int ShopItemId { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00012715 File Offset: 0x00010915
		// (set) Token: 0x06000207 RID: 519 RVA: 0x0001271D File Offset: 0x0001091D
		public string DropChance { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00012726 File Offset: 0x00010926
		public bool IsEquippable
		{
			get
			{
				return InventoryItem.EquippableCategories.Contains(this.Category);
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeDescription()
		{
			return false;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeMaxStack()
		{
			return false;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeLevel()
		{
			return false;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeIsAcItem()
		{
			return false;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeLink()
		{
			return false;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeIsEquipped()
		{
			return false;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeIsMemberOnly()
		{
			return false;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeCost()
		{
			return false;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeCategory()
		{
			return false;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeShopItemId()
		{
			return false;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00012738 File Offset: 0x00010938
		public bool ShouldSerializeDropChance()
		{
			return false;
		}

		// Token: 0x04000174 RID: 372
		private string _name;

		// Token: 0x04000177 RID: 375
		public static readonly string[] EquippableCategories = new string[]
		{
			"Sword",
			"Axe",
			"Dagger",
			"Gun",
			"Bow",
			"Mace",
			"Polearm",
			"Staff",
			"Wand",
			"Class",
			"Armor",
			"Helm",
			"Cape"
		};
	}
}
