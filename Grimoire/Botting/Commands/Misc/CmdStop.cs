using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdStop : IBotCommand
    {
        public Task Execute(IBotEngine instance)
        {
            instance.Stop();
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return "Stop bot";
        }
    }
}
