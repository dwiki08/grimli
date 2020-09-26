using Grimoire.Networking;
using System.Collections.Generic;

namespace SkillsHack
{
    public class XtAttackHandler : IXtMessageHandler
    {
        public string[] HandledCommands { get; } = { "gar" };
        public List<string> ExceptionSkills { get; set; }
        public bool AutoDivide { get; set; }
        public string Password { get; set; }
        public string Log { get; set; }

        public void Handle(XtMessage message)
        {
            List<string> listTargetsType = new List<string>();
            listTargetsType = getBetweenList(message.Arguments[6], ">", ":");
            int targetsCount = message.Arguments[6].Split(',').Length;
            string skill = message.Arguments[6].Substring(1, 1);

            bool isSend = !ExceptionSkills.Contains(skill);
            bool flagMonOnly = !Password.Equals("dijehh") ? !listTargetsType.Contains("p") : true;

            if (isSend && flagMonOnly)
            {
                int multiply = 6;
                string result = "";

                if (AutoDivide && targetsCount > 1)
                {
                    multiply = 3;
                    List<string> listEnemyIds = new List<string>();
                    for (int i = 0; i < targetsCount; i++)
                    {
                        listEnemyIds.Add(message.Arguments[6].Split(',').GetValue(i).ToString().Substring(3));
                    }

                    List<string> newEnemyIds = new List<string>();
                    for (int i = 0; i <= multiply; i++)
                    {
                        for (int x = 0; x < listEnemyIds.Count; x++)
                        {
                            newEnemyIds.Add($"{listEnemyIds[x]}.0{i}");
                        }
                    }

                    for (int i = 0; i <= multiply; i++)
                    {
                        result += $"a{skill}>{newEnemyIds[i]}{(i != multiply ? "," : "")}";
                    }
                }
                else
                {
                    string enemyType = message.Arguments[6].Substring(3, 1);
                    string enemyId = message.Arguments[6].Split(',').GetValue(0).ToString().Substring(5);
                    string zero = "";
                    for (int i = 0; i <= multiply; i++)
                    {
                        result += $"a{skill}>{enemyType}:{enemyId}.0{i}{(i != multiply ? "," : "")}";
                        zero += "0";
                    }
                }

                message.Arguments[6] = result;
                Log = result;
            }

            /* 
               %xt%zm%gar%1%7%a4>p:123,a4>p:0123,a4>p:00123,a4>p:000123,a4>p:0000123%wvz%
                
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

        public static List<string> getBetweenList(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                List<string> skillList = new List<string>();
                int Start, End;
                int IndexStart = 0;

                for (int i = 0; i <= 6; i++)
                {
                    Start = strSource.IndexOf(strStart, IndexStart) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    IndexStart = Start;
                    skillList.Add(strSource.Substring(Start, End - Start));
                }

                return skillList;
            }
            return null;
        }
    }
}
