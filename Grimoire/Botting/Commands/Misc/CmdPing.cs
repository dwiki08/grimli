using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grimoire.Botting.Commands.Misc
{
    class CmdPing : IBotCommand
    {
        public bool PopMsg { get; set; } = false;
        public async Task Execute(IBotEngine instance)
        {
            for (int i = 0; i < 10; i++)
                Console.Beep();
            if (PopMsg) MessageBox.Show($"Your ping !");
        }

        public override string ToString()
        {
            return $"Ping: 10x beep {(PopMsg ? "and pop msg" : "")}";
        }
    }
}
