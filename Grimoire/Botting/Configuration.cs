using System.Collections.Generic;
using Grimoire.Game.Data;

namespace Grimoire.Botting
{
    public class Configuration
    {
        public List<IBotCommand> Commands { get; set; } = new List<IBotCommand>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Quest> Quests { get; set; } = new List<Quest>();
        public string Author { get; set; }
        public string Description { get; set; }
        public List<InventoryItem> Boosts { get; set; } = new List<InventoryItem>();
        public List<string> Drops { get; set; } = new List<string>();
        public Server Server { get; set; }
        public int SkillDelay { get; set; }
        public bool ExitCombatBeforeRest { get; set; }
        public bool ExitCombatBeforeQuest { get; set; }
        public int DropDelay { get; set; }
        public bool CustomPickup { get; set; }
        public bool EnablePickupAll { get; set; }
        public bool EnablePickup { get; set; }
        public bool EnableRejection { get; set; }
        public bool AutoRelogin { get; set; }
        public int RelogDelay { get; set; }
        public bool RelogRetryUponFailure { get; set; }
        public int BotDelay { get; set; }
        public bool WaitForSkills { get; set; }
        public bool SkipDelayIndexIf { get; set; }
        public bool InfiniteAttackRange { get; set; }
        public bool ProvokeMonsters { get; set; }
        public bool EnemyMagnet { get; set; }
        public bool LagKiller { get; set; }
        public bool HidePlayers { get; set; }
        public bool SkipCutscenes { get; set; }
        public bool DisableAnimations { get; set; }
        public bool AntiCounter { get; set; }
        public int WalkSpeed { get; set; }
        public List<string> NotifyUponDrop { get; set; } = new List<string>();
        public bool RestIfMp { get; set; }
        public bool RestIfHp { get; set; }
        public int RestMp { get; set; }
        public int RestHp { get; set; }
        public bool RestartUponDeath { get; set; }
        public bool PopNotify { get; set; }
        public List<string> Items { get; set; }
    }
}
