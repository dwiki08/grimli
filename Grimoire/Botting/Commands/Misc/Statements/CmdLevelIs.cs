﻿using System.Threading.Tasks;
using Grimoire.Game;

namespace Grimoire.Botting.Commands.Misc.Statements
{
    public class CmdLevelIs : StatementCommand, IBotCommand
    {
        public CmdLevelIs()
        {
            Tag = "This player";
            Text = "Level is";
        }

        public Task Execute(IBotEngine instance)
        {
            if (Player.Level != int.Parse(Value1))
                instance.Index++;
            return Task.FromResult<object>(null);
        }

        public override string ToString()
        {
            return $"Level is: {Value1}";
        }
    }
}
