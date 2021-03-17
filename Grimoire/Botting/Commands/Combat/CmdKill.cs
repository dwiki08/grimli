using System.Threading;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Networking;

namespace Grimoire.Botting.Commands.Combat
{
    public class CmdKill : IBotCommand
    {
        public string Monster { get; set; }
		public string MonId { get; set; }

        public async Task Execute(IBotEngine instance)
        {
            await instance.WaitUntil(() => World.IsMonsterAvailable(Monster), null, 3);

            if (instance.Configuration.WaitForSkills)
                await instance.WaitUntil(() => Player.AllSkillsAvailable);

            if (!instance.IsRunning || !Player.IsAlive || !Player.IsLoggedIn)
                return;

            Player.AttackMonster(Monster);
            
            if (instance.Configuration.Skills.Count > 0)
				Task.Run(() => UseSkillsSet(instance));

			await instance.WaitUntil(() => !Player.HasTarget, null, 360);
            Player.CancelTarget();

            _cts?.Cancel(false);
        }

		private CancellationTokenSource _cts;
        private int _skillIndex;
        private async Task UseSkills(IBotEngine instance)
        {
            _cts = new CancellationTokenSource();
            _skillIndex = 0;

            while (!_cts.IsCancellationRequested && Player.IsLoggedIn && Player.IsAlive)
            {
                Skill s = instance.Configuration.Skills[_skillIndex];

                if (s.Type == Skill.SkillType.Safe)
                {
                    if (s.IsSafeMp)
                    {
						if (s.SType == Skill.SafeType.LowerThan)
                        {
							if ((double)Player.Mana / Player.ManaMax * 100 <= s.SafeValue)
								Player.UseSkill(s.Index);
						} else if (s.SType == Skill.SafeType.GreaterThan)
                        {
							if ((double)Player.Mana / Player.ManaMax * 100 >= s.SafeValue)
								Player.UseSkill(s.Index);
						} else if (s.SType == Skill.SafeType.Equals)
						{
							if ((double)Player.Mana / Player.ManaMax * 100 == s.SafeValue)
								Player.UseSkill(s.Index);
						}
					}
                    else
                    {
						if (s.SType == Skill.SafeType.LowerThan)
						{
							if ((double)Player.Health / Player.HealthMax * 100 <= s.SafeValue)
								Player.UseSkill(s.Index);
						} else if (s.SType == Skill.SafeType.GreaterThan)
						{
							if ((double)Player.Health / Player.HealthMax * 100 >= s.SafeValue)
								Player.UseSkill(s.Index);
						}

						if (s.SType == Skill.SafeType.Equals)
						{
							if ((double)Player.Health / Player.HealthMax * 100 == s.SafeValue)
								Player.UseSkill(s.Index);
						}
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

		private int Index;
		private async Task UseSkillsSet(IBotEngine instance)
		{
			this._cts = new CancellationTokenSource();
			int ClassIndex = -1;
			bool flag = BotData.SkillSet != null && BotData.SkillSet.ContainsKey("[" + BotData.BotSkill + "]");
			if (flag)
			{
				ClassIndex = BotData.SkillSet["[" + BotData.BotSkill + "]"] + 1;
			}
			int Count = instance.Configuration.Skills.Count - 1;
			this.Index = ClassIndex;
			while (!this._cts.IsCancellationRequested)
			{
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
				if (this.Monster.ToLower() == "escherion" && World.IsMonsterAvailable("Staff of Inversion"))
				{
					Player.AttackMonster("Staff of Inversion");
				}
				if (this.Monster.ToLower() == "vath" && World.IsMonsterAvailable("Stalagbite"))
				{
					Player.AttackMonster("Stalagbite");
				}
				if (ClassIndex != -1)
				{
					//with label
					Skill s = instance.Configuration.Skills[this.Index];
					if (s.Type == Skill.SkillType.Label)
					{
						this.Index = ClassIndex;
						continue;
					}
					if (s.Type == Skill.SkillType.Safe)
					{
						if (s.IsSafeMp)
						{
							if (s.SType == Skill.SafeType.LowerThan)
							{
								if ((double)Player.Mana / Player.ManaMax * 100 <= s.SafeValue)
									Player.UseSkill(s.Index);
							}
							else if (s.SType == Skill.SafeType.GreaterThan)
							{
								if ((double)Player.Mana / Player.ManaMax * 100 >= s.SafeValue)
									Player.UseSkill(s.Index);
							}
							else if (s.SType == Skill.SafeType.Equals)
							{
								if ((double)Player.Mana / Player.ManaMax * 100 == s.SafeValue)
									Player.UseSkill(s.Index);
							}
						}
						else
                        {
							if (s.SType == Skill.SafeType.LowerThan)
							{
								if ((double)Player.Health / Player.HealthMax * 100 <= s.SafeValue)
									Player.UseSkill(s.Index);
							}
							else if (s.SType == Skill.SafeType.GreaterThan)
							{
								if ((double)Player.Health / Player.HealthMax * 100 >= s.SafeValue)
									Player.UseSkill(s.Index);
							}

							if (s.SType == Skill.SafeType.Equals)
							{
								if ((double)Player.Health / Player.HealthMax * 100 == s.SafeValue)
									Player.UseSkill(s.Index);
							}
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
							if (s.SType == Skill.SafeType.LowerThan)
							{
								if ((double)Player.Mana / Player.ManaMax * 100 <= s.SafeValue)
									Player.UseSkill(s.Index);
							}
							else if (s.SType == Skill.SafeType.GreaterThan)
							{
								if ((double)Player.Mana / Player.ManaMax * 100 >= s.SafeValue)
									Player.UseSkill(s.Index);
							}
							else if (s.SType == Skill.SafeType.Equals)
							{
								if ((double)Player.Mana / Player.ManaMax * 100 == s.SafeValue)
									Player.UseSkill(s.Index);
							}
						} else
                        {
							if (s.SType == Skill.SafeType.LowerThan)
							{
								if ((double)Player.Health / Player.HealthMax * 100 <= s.SafeValue)
									Player.UseSkill(s.Index);
							}
							else if (s.SType == Skill.SafeType.GreaterThan)
							{
								if ((double)Player.Health / Player.HealthMax * 100 >= s.SafeValue)
									Player.UseSkill(s.Index);
							}

							if (s.SType == Skill.SafeType.Equals)
							{
								if ((double)Player.Health / Player.HealthMax * 100 == s.SafeValue)
									Player.UseSkill(s.Index);
							}
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
				await Task.Delay(instance.Configuration.SkillDelay);
			}
			while (Player.HasTarget)
			{
				Player.CancelTarget();
				await Task.Delay(500);
			}
		}

		public override string ToString()
        {
            return $"Kill {Monster}";
        }
    }
}
