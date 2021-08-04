using System.Linq;
using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Quest
{
    public class CmdAcceptQuest : IBotCommand
    {
        public Game.Data.Quest Quest { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => Player.Quests.QuestTree.Any(q => q.Id == Quest.Id));
            await instance.WaitUntil(() => World.IsActionAvailable(LockActions.AcceptQuest));
            while (!Player.Quests.IsInProgress(Quest.Id) && Player.IsLoggedIn && instance.IsRunning)
            {
                await Task.Delay(1000);
                Quest.Accept();
            }
            //await instance.WaitUntil(() => Player.Quests.IsInProgress(Quest.Id));
        }

        public override string ToString()
        {
            return $"Accept quest: {Quest.Id}";
        }
    }
}
