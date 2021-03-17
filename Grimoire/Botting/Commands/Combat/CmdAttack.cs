using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Networking;

namespace Grimoire.Botting.Commands.Combat
{
    public class CmdAttack : IBotCommand
    {
        public string Monster { get; set; }
        public string MonId { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            Player.AttackMonster(this.Monster);
            if (instance.Configuration.Skills.Count > 0)
                Task.Run(() => UseSkillsSet(instance));

            /*Random rnd = new Random();
            List<Skill> ls = instance.Configuration.Skills;
            int i = rnd.Next(0, ls.Count - 1);
            if (instance.Configuration.Skills.Count > 0)
                await Task.Run(() => Player.UseSkill(ls[i].Index));*/

        }

        public override string ToString()
        {
            return "Attack " + this.Monster;
        }

        private async void useSkill(string skill, string monId)
        {
            if (!MonId.Equals(""))
            {
                //%xt%zm%gar%1%0%a1>m:1%wvz%
                await Proxy.Instance.SendToServer("%xt%zm%gar%1%0%a" + skill + ">m:" + monId + "%wvz%");
                await Task.Delay(1000);
            }
            else
            {
                Player.UseSkill(skill);
            }
        }

        private int _skillIndex;
        private int Index;
        private async Task UseSkillsSet(IBotEngine instance)
        {
            int ClassIndex = -1;
            bool flag = BotData.SkillSet != null && BotData.SkillSet.ContainsKey("[" + BotData.BotSkill + "]");
            if (flag)
            {
                ClassIndex = BotData.SkillSet["[" + BotData.BotSkill + "]"] + 1;
            }
            int Count = instance.Configuration.Skills.Count - 1;
            this.Index = ClassIndex;
            bool flag2 = !Player.IsLoggedIn || !Player.IsAlive;
            if (flag2)
            {
                while (Player.HasTarget)
                {
                    Player.CancelTarget();
                    await Task.Delay(500);
                }
                return;
            }
            if (ClassIndex != -1)
            {
                //with label
                Skill s = instance.Configuration.Skills[this.Index];
                if (s.Type == Skill.SkillType.Label)
                {
                    this.Index = ClassIndex;
                }
                if (s.Type == Skill.SkillType.Safe)
                {
                    if (s.IsSafeMp)
                    {
                        if ((double)Player.Mana / (double)Player.ManaMax * 100.0 <= (double)s.SafeValue)
                        {
                            Player.UseSkill(s.Index);
                        }
                    }
                    else if ((double)Player.Health / (double)Player.HealthMax * 100.0 <= (double)s.SafeValue)
                    {
                        Player.UseSkill(s.Index);
                    }
                }
                else
                {
                    Player.UseSkill(s.Index);
                }
                int index;
                if (this.Index < Count)
                {
                    int num3 = this.Index + 1;
                    this.Index = num3;
                    index = num3;
                }
                else
                {
                    index = ClassIndex;
                }
                this.Index = index;
                s = null;
            }
            else
            {
                //non label
                Skill s = instance.Configuration.Skills[_skillIndex];
                if (s.Type == Skill.SkillType.Safe)
                {
                    if (s.IsSafeMp)
                    {
                        if ((double)Player.Mana / (double)Player.ManaMax * 100.0 <= (double)s.SafeValue)
                        {
                            Player.UseSkill(s.Index);
                        }
                    }
                    else if ((double)Player.Health / (double)Player.HealthMax * 100.0 <= (double)s.SafeValue)
                    {
                        Player.UseSkill(s.Index);
                    }
                }
                else
                {
                    Player.UseSkill(s.Index);
                }

                int count = instance.Configuration.Skills.Count - 1;

                _skillIndex = _skillIndex >= count ? 0 : ++_skillIndex;
            }
            await Task.Delay(instance.Configuration.SkillDelay);
        }

    }
}
