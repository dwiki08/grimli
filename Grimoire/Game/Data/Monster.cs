using System;
using Newtonsoft.Json;

namespace Grimoire.Game.Data
{
	public class Monster
	{
		[JsonProperty("sRace")]
		public string Race { get; set; }

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

		[JsonProperty("MonID")]
		public int Id { get; set; }

		[JsonProperty("iLvl")]
		public int Level { get; set; }

		[JsonProperty("intState")]
		public int State { get; set; }

		[JsonProperty("intHP")]
		public int Health { get; set; }

		[JsonProperty("intHPMax")]
		public int MaxHealth { get; set; }

		private string _name;
	}
}
