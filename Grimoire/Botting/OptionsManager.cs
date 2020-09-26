using System;
using System.Threading.Tasks;
using Grimoire.Game;
using Grimoire.Networking;
using Grimoire.Networking.Handlers;
using Grimoire.Tools;

namespace Grimoire.Botting
{
	public static class OptionsManager
	{
		public static bool IsRunning
		{
			get
			{
				return OptionsManager._isRunning;
			}
			private set
			{
				OptionsManager._isRunning = value;
				Action<bool> stateChanged = OptionsManager.StateChanged;
				if (stateChanged == null)
				{
					return;
				}
				stateChanged(value);
			}
		}
		public static event Action<bool> StateChanged;

		public static bool ProvokeMonsters { get; set; }

		public static bool EnemyMagnet { get; set; }
		public static bool LagKiller { get; set; }

		public static bool SkipCutscenes { get; set; }

		private static IJsonMessageHandler HandlerDisableAnimations { get; } = new HandlerAnimations();

		public static bool DisableAnimations
		{
			get
			{
				return OptionsManager._disableAnimations;
			}
			set
			{
				OptionsManager._disableAnimations = value;
				if (value)
				{
					Proxy.Instance.RegisterHandler(OptionsManager.HandlerDisableAnimations);
					return;
				}
				Proxy.Instance.UnregisterHandler(OptionsManager.HandlerDisableAnimations);
			}
		}
		private static IXtMessageHandler HandlerHidePlayers { get; } = new HandlerPlayers();

		public static bool HidePlayers
		{
			get
			{
				return OptionsManager._hidePlayers;
			}
			set
			{
				OptionsManager._hidePlayers = value;
				if (value)
				{
					Proxy.Instance.RegisterHandler(OptionsManager.HandlerHidePlayers);
					OptionsManager.DestroyPlayers();
					return;
				}
				Proxy.Instance.UnregisterHandler(OptionsManager.HandlerHidePlayers);
			}
		}

		public static IJsonMessageHandler HandlerRange { get; } = new HandlerSkills();

		public static bool InfiniteRange
		{
			get
			{
				return OptionsManager._infRange;
			}
			set
			{
                OptionsManager._infRange = value;
                if (value)
                {
                    Proxy.Instance.RegisterHandler(OptionsManager.HandlerRange);
                    OptionsManager.SetInfiniteRange();
                    return;
                }
                Proxy.Instance.UnregisterHandler(OptionsManager.HandlerRange);

                /*OptionsManager._infRange = value;
				if (value)
				{
					OptionsManager.SetInfiniteRange();
				}*/
			}
		}

		public static int WalkSpeed { get; set; } = 8;

		private static void SetInfiniteRange()
		{
			Flash.Call("SetInfiniteRange", new string[0]);
		}

		private static void SetProvokeMonsters()
		{
			Flash.Call("SetProvokeMonsters", new string[0]);
		}

		private static void SetEnemyMagnet()
		{
			Flash.Call("SetEnemyMagnet", new string[0]);
		}

		private static void SetLagKiller()
		{
			Flash.Call("SetLagKiller", new string[]
			{
				OptionsManager.LagKiller ? bool.TrueString : bool.FalseString
			});
		}

		public static void DestroyPlayers()
		{
			Flash.Call("DestroyPlayers", new string[0]);
		}

		private static void SetSkipCutscenes()
		{
			Flash.Call("SetSkipCutscenes", new string[0]);
		}

		public static void SetWalkSpeed()
		{
			Flash.Call("SetWalkSpeed", new string[]
			{
				OptionsManager.WalkSpeed.ToString()
			});
		}

		public static void Start()
		{
			if (!OptionsManager.IsRunning)
			{
				OptionsManager.ApplySettings();
			}
		}

		public static void Stop()
		{
			OptionsManager.IsRunning = false;
		}

		private static async Task ApplySettings()
		{
			OptionsManager.IsRunning = true;
			while (OptionsManager.IsRunning)
			{
				if (!Player.IsLoggedIn)
				{
					return;
				}
				if (OptionsManager.ProvokeMonsters)
				{
					OptionsManager.SetProvokeMonsters();
				}
				if (OptionsManager.EnemyMagnet)
				{
					OptionsManager.SetEnemyMagnet();
				}
				OptionsManager.SetWalkSpeed();
				OptionsManager.SetLagKiller();
				if (OptionsManager.SkipCutscenes)
				{
					OptionsManager.SetSkipCutscenes();
				}
				if(OptionsManager.InfiniteRange) Proxy.Instance.UnregisterHandler(OptionsManager.HandlerRange);
				await Task.Delay(1000);
			}
		}

		private static bool _isRunning;

		private static bool _disableAnimations;

		private static bool _hidePlayers;

		private static bool _infRange;
	}
}
