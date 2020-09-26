using System;
using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Combat
{
	public class CmdSkillSet : IBotCommand
	{
		public string Name { get; set; }

		public Task Execute(IBotEngine instance)
		{
			BotData.BotState = BotData.State.Combat;
			BotData.BotSkill = this.Name;
			return Task.FromResult<object>(null);
		}

		public override string ToString()
		{
			return "Skill Set: " + this.Name;
		}
	}
}
