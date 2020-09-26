using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Combat
{
    public class CmdRest : IBotCommand
    {
        public bool Full { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsActionAvailable(LockActions.Rest), () => instance.IsRunning && Player.IsLoggedIn);
            if (instance.Configuration.ExitCombatBeforeRest)
            {
                Player.MoveToCell(Player.Cell, Player.Pad);
                await instance.WaitUntil(() => Player.CurrentState != Player.State.InCombat);
            }

            Player.Rest();
            if (Full)
                await instance.WaitUntil(() => Player.Mana >= Player.ManaMax &&
                                               Player.Health >= Player.HealthMax);
        }

        public override string ToString()
        {
            return Full ? "Rest fully" : "Rest";
        }
    }
}
