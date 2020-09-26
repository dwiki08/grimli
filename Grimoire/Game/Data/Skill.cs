using System;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
	public class Skill
	{
		public string Text { get; set; }

		public Skill.SkillType Type { get; set; }

		public string Index { get; set; }

		public int SafeHealth { get; set; }

		public bool SafeMp { get; set; }

		public static string GetSkillName(string index)
		{
			return Flash.Call<string>("GetSkillName", new string[]
			{
				index
			});
		}

		public enum SkillType
		{
			Normal,
			Safe,
			Label
		}
	}
}
