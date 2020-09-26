using System;
using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdMapIsNot : StatementCommand, IBotCommand
    {
        public CmdMapIsNot()
        {
            Tag = "Map";
            Text = "Map is not";
        }

        public Task Execute(IBotEngine instance)
        {
            string map = Value1.Contains("-") ?
                Value1.Split('-')[0] : Value1;
            if (map.Equals(Player.Map, StringComparison.OrdinalIgnoreCase))
                instance.Index++;
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return $"Map is not: {Value1}";
        }
    }
}
