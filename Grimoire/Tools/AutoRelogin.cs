using System;
using System.Threading;
using System.Threading.Tasks;
using Grimoire.Botting;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.UI;

namespace Grimoire.Tools
{
	// Token: 0x0200000F RID: 15
	public static class AutoRelogin
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000EC RID: 236 RVA: 0x0000F6B5 File Offset: 0x0000D8B5
		public static bool IsTemporarilyKicked
		{
			get
			{
				return Flash.Call<bool>("IsTemporarilyKicked", new string[0]);
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000F6C7 File Offset: 0x0000D8C7
		public static void Login()
		{
			Flash.Call("Login", new string[0]);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000F6D9 File Offset: 0x0000D8D9
		public static bool ResetServers()
		{
			return Flash.Call<bool>("ResetServers", new string[0]);
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000EF RID: 239 RVA: 0x0000F6EB File Offset: 0x0000D8EB
		public static bool AreServersLoaded
		{
			get
			{
				return Flash.Call<bool>("AreServersLoaded", new string[0]);
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000F6FD File Offset: 0x0000D8FD
		public static void Connect(Server server)
		{
			Flash.Call("Connect", new string[]
			{
				server.Name
			});
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000F718 File Offset: 0x0000D918
		public static async Task Login(Server server, int relogDelay, CancellationTokenSource cts, bool ensureSuccess)
		{
			bool killLag = OptionsManager.LagKiller;
			bool disableAnims = OptionsManager.DisableAnimations;
			bool hidePlayers = OptionsManager.HidePlayers;
			if (killLag)
			{
				OptionsManager.LagKiller = false;
			}
			if (disableAnims)
			{
				OptionsManager.DisableAnimations = false;
			}
			if (hidePlayers)
			{
				OptionsManager.HidePlayers = false;
			}
			if (AutoRelogin.IsTemporarilyKicked)
			{
				await BotManager.Instance.ActiveBotEngine.WaitUntil(() => !AutoRelogin.IsTemporarilyKicked, () => !cts.IsCancellationRequested, 65);
			}
			if (!cts.IsCancellationRequested)
			{
				AutoRelogin.ResetServers();
				AutoRelogin.Login();
				await BotManager.Instance.ActiveBotEngine.WaitUntil(() => AutoRelogin.AreServersLoaded, () => !cts.IsCancellationRequested, 30);
				if (!cts.IsCancellationRequested)
				{
					AutoRelogin.Connect(server);
					await BotManager.Instance.ActiveBotEngine.WaitUntil(() => !World.IsMapLoading, () => !cts.IsCancellationRequested, 40);
					if (!cts.IsCancellationRequested)
					{
						await Task.Delay(relogDelay);
						if (ensureSuccess)
						{
							Task.Run(() => AutoRelogin.EnsureLoginSuccess(cts));
						}
						if (killLag)
						{
							OptionsManager.LagKiller = true;
						}
						if (disableAnims)
						{
							OptionsManager.DisableAnimations = true;
						}
						if (hidePlayers)
						{
							OptionsManager.HidePlayers = true;
						}
					}
				}
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000F778 File Offset: 0x0000D978
		private static async Task EnsureLoginSuccess(CancellationTokenSource cts)
		{
			for (int i = 0; i < 20; i++)
			{
				await Task.Delay(1000);
				if (cts.IsCancellationRequested)
				{
					return;
				}
				string map = Player.Map;
				if (!string.IsNullOrEmpty(map) && !map.Equals("name", StringComparison.OrdinalIgnoreCase) && !map.Equals("battleon", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
			}
			if (Player.Map.Equals("battleon", StringComparison.OrdinalIgnoreCase))
			{
				Player.Logout();
			}
		}
	}
}
