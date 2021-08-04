using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimoire.Networking;

namespace SkillsHack
{
    class JsonHandler : IJsonMessageHandler
    {
        public string[] HandledCommands { get; } = { "ct" };

        public void Handle(JsonMessage message)
        {

        }
    }
}
