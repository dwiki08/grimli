using System;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Botting.Commands.Combat
{
	public class CmdUseSkill : IBotCommand
	{
		public Skill Skill { get; set; }

		public bool Wait { get; set; }

		private int _skillIndex;
		public async Task Execute(IBotEngine instance)
		{
			Skill s = instance.Configuration.Skills[_skillIndex];

			bool wait = Wait;
			if (wait)
			{
				await Task.Delay(Player.SkillAvailable(Skill.Index));
			}
			Player.UseSkill(Skill.Index);
		}

		public override string ToString()
		{
			return "UseSkill [" + Skill.Index + "] " + Skill.GetSkillName(Skill.Index);
		}
	}
}
