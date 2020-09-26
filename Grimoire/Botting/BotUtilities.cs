using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grimoire.Botting.Commands.Item;
using Grimoire.Botting.Commands.Misc;
using Grimoire.Botting.Commands.Misc.Statements;
using Grimoire.Botting.Commands.Quest;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Botting
{
	public static class BotUtilities
	{
		public static async Task WaitUntil(this IBotEngine instance, Func<bool> condition, Func<bool> prerequisite = null, int timeoutInSec = 15)
		{
			int iterations = 0;
			while ((prerequisite ?? (() => instance.IsRunning && Player.IsLoggedIn && Player.IsAlive))() && !condition() && (iterations < timeoutInSec || timeoutInSec == -1))
			{
				await Task.Delay(1000);
				iterations++;
			}
		}

		public static bool RequiresDelay(this IBotCommand cmd)
		{
			return !(cmd is StatementCommand) && !(cmd is CmdIndex) && !(cmd is CmdLabel) && !(cmd is CmdGotoLabel);
		}

		public static void LoadAllQuests(this IBotEngine instance)
		{
			List<int> list = new List<int>();
			foreach (IBotCommand botCommand in instance.Configuration.Commands)
			{
				if (botCommand != null)
				{
					CmdAcceptQuest cmdAcceptQuest;
					if ((cmdAcceptQuest = (botCommand as CmdAcceptQuest)) == null)
					{
						CmdCompleteQuest cmdCompleteQuest;
						if ((cmdCompleteQuest = (botCommand as CmdCompleteQuest)) != null)
						{
							CmdCompleteQuest cmdCompleteQuest2 = cmdCompleteQuest;
							list.Add(cmdCompleteQuest2.Quest.Id);
						}
					}
					else
					{
						CmdAcceptQuest cmdAcceptQuest2 = cmdAcceptQuest;
						list.Add(cmdAcceptQuest2.Quest.Id);
					}
				}
			}
			list.AddRange(from q in instance.Configuration.Quests
			select q.Id);
			if (list.Count > 0)
			{
				Player.Quests.Get(list);
			}
		}

		public static void LoadBankItems(this IBotEngine instance)
		{
			if (instance.Configuration.Commands.Any((IBotCommand c) => c is CmdBankSwap || c is CmdBankTransfer))
			{
				Player.Bank.LoadItems();
			}
		}
	}
}
