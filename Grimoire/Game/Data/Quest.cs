using System;
using System.Collections.Generic;
using Grimoire.Tools;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	public class Quest
	{
		[JsonProperty("sFaction")]
		public string Faction { get; set; }

		[JsonProperty("iClass")]
		public int ClassPointsReward { get; set; }

		[JsonProperty("sDesc")]
		public string Description { get; set; }

		[JsonProperty("iReqRep")]
		public int RequiredReputation { get; set; }

		[JsonProperty("iRep")]
		public int ReputationReward { get; set; }

		[JsonProperty("iLvl")]
		public int Level { get; set; }

		public List<InventoryItem> RequiredItems { get; set; }

		[JsonProperty("iGold")]
		public int GoldReward { get; set; }

		[JsonProperty("iReqCP")]
		public int RequiredClassPoints { get; set; }

		[JsonProperty("QuestID")]
		public int Id { get; set; }

		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bOnce")]
		public bool IsNotRepeatable { get; set; }

		[JsonProperty("iExp")]
		public int ExperienceReward { get; set; }

		public List<InventoryItem> Rewards { get; set; }

		[JsonProperty("sName")]
		public string Name { get; set; }

		[JsonConverter(typeof(BoolConverter))]
		[JsonProperty("bUpg")]
		public bool IsMemberOnly { get; set; }

		[JsonProperty("FactionID")]
		public int FactionId { get; set; }

		public string ItemId { get; set; }

		public string Text { get; set; }

		public void Accept()
		{
			Flash.Call("Accept", new string[]
			{
				this.Id.ToString()
			});
		}

		public void Complete()
		{
			if (!string.IsNullOrEmpty(this.ItemId))
			{
				Flash.Call("Complete", new string[]
				{
					this.Id.ToString(),
					this.ItemId
				});
				return;
			}
			Flash.Call("Complete", new string[]
			{
				this.Id.ToString()
			});
		}

		public bool IsInProgress
		{
			get
			{
				return Flash.Call<bool>("IsInProgress", new string[]
				{
					this.Id.ToString()
				});
			}
		}

		public bool CanComplete
		{
			get
			{
				return Flash.Call<bool>("CanComplete", new string[]
				{
					this.Id.ToString()
				});
			}
		}

		public bool ShouldSerializeFaction()
		{
			return false;
		}

		public bool ShouldSerializeClassPointsReward()
		{
			return false;
		}

		public bool ShouldSerializeDescription()
		{
			return false;
		}

		public bool ShouldSerializeRequiredReputation()
		{
			return false;
		}

		public bool ShouldSerializeReputationReward()
		{
			return false;
		}

		public bool ShouldSerializeLevel()
		{
			return false;
		}

		public bool ShouldSerializeGoldReward()
		{
			return false;
		}

		public bool ShouldSerializeRequiredClassPoints()
		{
			return false;
		}

		public bool ShouldSerializeIsNotRepeatable()
		{
			return false;
		}

		public bool ShouldSerializeExperienceReward()
		{
			return false;
		}

		public bool ShouldSerializeRewards()
		{
			return false;
		}

		public bool ShouldSerializeName()
		{
			return false;
		}

		public bool ShouldSerializeIsMemberOnly()
		{
			return false;
		}

		public bool ShouldSerializeFactionId()
		{
			return false;
		}

		public bool ShouldSerializeIsInProgress()
		{
			return false;
		}

		public bool ShouldSerializeCanComplete()
		{
			return false;
		}
	}
}
