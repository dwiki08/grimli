using Grimoire.Networking;
using System.Collections.Generic;

namespace SkillsHack
{
    public class XtNoManaHandler : IXtMessageHandler
    {
        public string[] HandledCommands { get; } = { "gar" };
        public string Log { get; set; }

        public void Handle(XtMessage message)
        {
            string[] _listTargets = message.Arguments[6].Split(',');
            string result = "";
            if (_listTargets.Length > 1)
            {
                List<string> listTargets = new List<string>();
                listTargets.AddRange(_listTargets);
                listTargets.Add(listTargets[0]);
                listTargets.RemoveAt(0);

                for (int i = 0; i < listTargets.Count; i++)
                {
                    result += listTargets[i] + (i < listTargets.Count ? "," : "");
                }

                message.Arguments[6] = result;
                Log = result;
            }
        }

        /* 
           %xt%zm%gar%1%7%a4>p:123,a4>p:123,a4>p:123,a4>p:123,a4>p:123%wvz%

           0 = 
           1 = xt
           2 = zm
           3 = gar
           4 = 1
           5 = 1
           6 = a1>p:123,a1>p:0123....
           7 = 
           8 = 

        */
    }
}

