using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdIndex : IBotCommand
    {
        public enum IndexCommand
        {
            Up,
            Down,
            Goto
        }

        public IndexCommand Type { get; set; }
        public int Index { get; set; }

        public Task Execute(IBotEngine instance)
        {
            switch (Type)
            {
                case IndexCommand.Down:
                    int down = Index - 1;

                    if (down > 0)
                    {
                        int check = instance.Index += down;
                        if (check < instance.Configuration.Commands.Count)
                            instance.Index = check;
                    }
                    break;

                case IndexCommand.Up:
                    int up = Index + 1;

                    if (up > 0)
                    {
                        int check = instance.Index -= up;
                        if (check > -1)
                            instance.Index = check;
                    }
                    break;
            }
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            switch (Type)
            {
                case IndexCommand.Down:
                    return $"Index down: {Index}";
                case IndexCommand.Up:
                    return $"Index up: {Index}";
                default:
                    return $"Goto index: {Index}";
            }
        }
    }
}
