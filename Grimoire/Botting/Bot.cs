using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.Tools;

namespace Grimoire.Botting
{
    public class Bot : IBotEngine
    {
        public event Action<bool> IsRunningChanged;
        public event Action<int> IndexChanged;
        public event Action<Configuration> ConfigurationChanged;

        private int _index;
        public int Index
        {
            get => _index;
            set => _index = value >= Configuration.Commands.Count ? 0 : value;
        }

        private Configuration _config;
        public Configuration Configuration
        {
            get => _config;
            set
            {
                if (value != _config)
                {
                    _config = value;
                    ConfigurationChanged?.Invoke(_config);
                }
            }
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                IsRunningChanged?.Invoke(_isRunning);
            }
        }

        private CancellationTokenSource ctsSkills;
        private CancellationTokenSource _ctsBot;

        private Stopwatch _questDelayCounter;
        private Stopwatch _boostDelayCounter;

        public void Start(Configuration config)
        {
            IsRunning = true;
            Configuration = config;
            Index = 0;
            _ctsBot = new CancellationTokenSource();
            _questDelayCounter = new Stopwatch();
            _boostDelayCounter = new Stopwatch();

            World.ItemDropped += OnItemDropped;

            Player.Quests.QuestsLoaded += OnQuestsLoaded;
            Player.Quests.QuestCompleted += OnQuestCompleted;
            _questDelayCounter.Start();
            this.LoadAllQuests();
            this.LoadBankItems();
            CheckBoosts();
            _boostDelayCounter.Start();
            OptionsManager.Start();
            Task.Factory.StartNew(Activate, _ctsBot.Token,
                TaskCreationOptions.LongRunning, TaskScheduler.Default);
            for (int i = 0; i < this.Configuration.Skills.Count; i++)
            {
                if (this.Configuration.Skills[i].Type == Skill.SkillType.Label &&
                    !BotData.SkillSet.ContainsKey(Configuration.Skills[i].Text.ToUpper()))
                {
                    BotData.SkillSet.Add(this.Configuration.Skills[i].Text.ToUpper(), i);
                }
            }

            dropV2();
        }

        public async void dropV2()
        {
            if (this.Configuration.EnablePickupV2)
            {
                List<string> listDrop = this.Configuration.Drops;
                int i = 0;
                while (IsRunning)
                {
                    if (i >= listDrop.Count - 1) i = 0;
                    string itemName = listDrop[i];
                    if (World.DropStack.Contains(itemName))
                    {
                        await World.DropStack.GetDrop(itemName);
                        await Task.Delay(this.Configuration.DropDelay);
                    }
                    i++;
                }
            }
        }

        public void Stop()
        {
            ctsSkills?.Cancel(false);
            _ctsBot?.Cancel(false);
            World.ItemDropped -= OnItemDropped;
            Player.Quests.QuestsLoaded -= OnQuestsLoaded;
            Player.Quests.QuestCompleted -= OnQuestCompleted;
            _questDelayCounter.Stop();
            _boostDelayCounter.Stop();
            OptionsManager.Stop();
            IsRunning = false;
        }

        private async Task Activate()
        {
            while (!_ctsBot.IsCancellationRequested)
            {
                if (Player.IsLoggedIn && !Player.IsAlive)
                {
                    World.SetSpawnPoint();
                    await this.WaitUntil(() => Player.IsAlive, () => IsRunning && Player.IsLoggedIn, -1);
                    Index = Configuration.RestartUponDeath ? 0 : Index - 1;
                }

                if (!Player.IsLoggedIn)
                {
                    if (Configuration.AutoRelogin)
                    {
                        bool infiniteRange = OptionsManager.InfiniteRange;
                        bool provoke = OptionsManager.ProvokeMonsters;
                        bool lagKiller = OptionsManager.LagKiller;
                        bool skipCutscene = OptionsManager.SkipCutscenes;
                        bool playerAnim = OptionsManager.DisableAnimations;
                        bool enemyMagnet = OptionsManager.EnemyMagnet;

                        OptionsManager.Stop();
                        await AutoRelogin.Login(Configuration.Server, Configuration.RelogDelay, _ctsBot, Configuration.RelogRetryUponFailure);
                        Index = 0;
                        this.LoadAllQuests();
                        this.LoadBankItems();


                        OptionsManager.InfiniteRange = infiniteRange;
                        OptionsManager.ProvokeMonsters = provoke;
                        OptionsManager.LagKiller = lagKiller;
                        OptionsManager.SkipCutscenes = skipCutscene;
                        OptionsManager.DisableAnimations = playerAnim;
                        OptionsManager.EnemyMagnet = enemyMagnet;

                        OptionsManager.Start();
                    }
                    else
                    {
                        Stop();
                        return;
                    }
                }

                if (_ctsBot.IsCancellationRequested)
                    return;

                if (Configuration.RestIfHp)
                    await RestHealth();

                if (_ctsBot.IsCancellationRequested)
                    return;

                if (Configuration.RestIfMp)
                    await RestMana();

                if (_ctsBot.IsCancellationRequested)
                    return;

                IndexChanged?.Invoke(Index);
                IBotCommand cmd = Configuration.Commands[Index];

                await cmd.Execute(this);

                if (_ctsBot.IsCancellationRequested)
                    return;

                if (Configuration.BotDelay > 0)
                    if (!Configuration.SkipDelayIndexIf || Configuration.SkipDelayIndexIf && cmd.RequiresDelay())
                        await Task.Delay(_config.BotDelay);

                if (_ctsBot.IsCancellationRequested)
                    return;

                if (Configuration.Quests.Count > 0)
                    await CheckQuests();

                if (Configuration.Boosts.Count > 0)
                    CheckBoosts();

                Index++;
            }
        }

        private async Task RestHealth()
        {
            if ((double)Player.Health / Player.HealthMax <= (double)Configuration.RestHp / 100)
            {
                if (Configuration.ExitCombatBeforeRest)
                {
                    Player.MoveToCell(Player.Cell, Player.Pad);
                    await Task.Delay(500);
                }
                Player.Rest();
                await this.WaitUntil(() => Player.Health >= Player.HealthMax);
            }
        }

        private async Task RestMana()
        {
            if ((double)Player.Mana / Player.ManaMax <= (double)Configuration.RestMp / 100)
            {
                if (Configuration.ExitCombatBeforeRest)
                {
                    Player.MoveToCell(Player.Cell, Player.Pad);
                    await Task.Delay(500);
                }
                Player.Rest();
                await this.WaitUntil(() => Player.Mana >= Player.ManaMax);
            }
        }

        private void CheckBoosts()
        {
            if (_boostDelayCounter.ElapsedMilliseconds >= 10000)
            {
                foreach (InventoryItem boost in Configuration.Boosts)
                    if (!Player.HasActiveBoost(boost.Name))
                        Player.UseBoost(boost.Id);
                _boostDelayCounter.Restart();
            }
        }

        private async Task CheckQuests()
        {
            if (World.IsActionAvailable(LockActions.TryQuestComplete))
            {
                if (_questDelayCounter.ElapsedMilliseconds >= 3000)
                {
                    Quest quest = Configuration.Quests.FirstOrDefault(q => q.CanComplete);
                    if (quest != null)
                    {
                        bool provokeMons = this.Configuration.ProvokeMonsters;
                        if (_config.ExitCombatBeforeQuest)
                        {
                            if (provokeMons) this.Configuration.ProvokeMonsters = false;
                            Player.MoveToCell(Player.Cell, Player.Pad);
                            await this.WaitUntil(() => Player.CurrentState != Player.State.InCombat);
                            await Task.Delay(1000);
                        }
                        quest.Complete();
                        this.Configuration.ProvokeMonsters = provokeMons;
                        _questDelayCounter.Restart();
                    }
                }
            }
        }

        private void OnItemDroppedOld(InventoryItem drop)
        {
            NotifyDrop(drop);

            bool isInWhitelist =
                Configuration.Drops.Any(d =>
                    d.Equals(drop.Name, StringComparison.OrdinalIgnoreCase));

            if (Configuration.EnablePickup && isInWhitelist)
                World.DropStack.GetDrop(drop.Id);
        }

        private async void OnItemDropped(InventoryItem drop)
        {
            this.NotifyDrop(drop);
            bool whitelisted = this.Configuration.Drops.Any((string d) => d.Equals(drop.Name, StringComparison.OrdinalIgnoreCase));
            bool enablePickup = this.Configuration.EnablePickup;

            if (this.Configuration.EnablePickup)
            {
                bool isInWhitelist =
                    Configuration.Drops.Any(d =>
                        d.Equals(drop.Name, StringComparison.OrdinalIgnoreCase));

                if (isInWhitelist)
                    await World.DropStack.GetDrop(drop.Id);
            }
            else
            {
                if (this.Configuration.EnablePickupAll)
                {
                    //pickup all items 
                    await Task.Delay(Configuration.DropDelay);
                    await World.DropStack.GetDrop(drop.Id);
                    await this.WaitUntil(() => !World.DropStack.Contains(drop.Id), null, 4);
                }

                /*if (this.Configuration.EnablePickupV2)
                {
                    //pickup whitelisted items only
                    busy = true;
                    if (whitelisted && enablePickup)
                    {
                        await Task.Delay(this.Configuration.DropDelay);
                        await World.DropStack.GetDrop(drop.Id);
                        await this.WaitUntil(() => !World.DropStack.Contains(drop.Id), null, 4);
                    }
                    busy = false;
                    if (queue > 0)
                    {
                        queue--;
                        OnItemDropped(drop);
                    }
                }*/
            }
        }

        private async void NotifyDrop(InventoryItem drop)
        {
            if (Configuration.NotifyUponDrop.Count > 0)
                if (Configuration.NotifyUponDrop.Any(d => d.Equals(drop.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    //if(Configuration.PopNotify) MessageBox.Show($"{drop.Name} has dropped.");
                    for (int i = 0; i < 10; i++)
                        Console.Beep();
                }
        }

        private void OnQuestsLoaded(List<Quest> quests)
        {
            List<Quest> qs =
                quests.Where(q => Configuration.Quests.Any(qq => qq.Id == q.Id)).ToList();

            int len = qs.Count;

            if (qs.Count > 0)
            {
                if (len == 1) qs[0].Accept();
                else // Accepting multiple quests instantly causes a disconnection
                {
                    for (int i = 0; i < len; i++)
                    {
                        int ii = i;
                        Task.Run(async () =>
                        {
                            await Task.Delay(1000 * ii);
                            qs[ii].Accept();
                        });
                    }
                }
            }
        }

        private void OnQuestCompleted(CompletedQuest quest)
        {
            Configuration.Quests.FirstOrDefault(q => q.Id == quest.Id)?.Accept();
        }
    }
}
