using System.Threading;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;

namespace Grimoire.Botting.Commands.Combat
{
    public class CmdSkill : IBotCommand
    {
        public int SelectedSkill { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            if (instance.Configuration.Skills.Count > 0)
                Task.Run(() => UseSkills(instance));
        }

        private CancellationTokenSource _cts;
        private int _skillIndex;
        private async Task UseSkills(IBotEngine instance)
        {
            _cts = new CancellationTokenSource();
            _skillIndex = 0;

            while (Player.IsLoggedIn && Player.IsAlive)
            {
                Skill s = instance.Configuration.Skills[_skillIndex];

                if (s.Type == Skill.SkillType.Safe)
                {
                    if (s.IsSafeMp)
                    {
                        if ((double)Player.Mana / Player.ManaMax * 100 <= s.SafeValue)
                            Player.UseSkill(s.Index);
                    }
                    else
                    {
                        if ((double)Player.Health / Player.HealthMax * 100 <= s.SafeValue)
                            Player.UseSkill(s.Index);
                    }
                }
                else
                {
                    Player.UseSkill(s.Index);
                }

                int count = instance.Configuration.Skills.Count - 1;

                _skillIndex = _skillIndex >= count ? 0 : ++_skillIndex;
                await Task.Delay(instance.Configuration.SkillDelay);
            }
        }

        public override string ToString()
        {
            return $"UseSkill {SelectedSkill}";
        }
    }
}
