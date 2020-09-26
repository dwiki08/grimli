using System;
using System.Threading.Tasks;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdGotoLabel : IBotCommand
    {
        public string Label { get; set; }

        public Task Execute(IBotEngine instance)
        {
            int i = instance.Configuration.Commands
                .FindIndex(c => c is CmdLabel && ((CmdLabel)c).Name.Equals(
                    Label, StringComparison.OrdinalIgnoreCase));
            if (i > -1)
                instance.Index = i;
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return $"Goto label: {Label}";
        }
    }
}
