using System;
using Grimoire.Botting;

namespace Grimoire.Networking.Handlers
{
	public class HandlerPlayers : IXtMessageHandler
	{
		public string[] HandledCommands { get; } = new string[]
		{
			"retrieveUserData",
			"retrieveUserDatas"
		};

		public void Handle(XtMessage message)
		{
			if (OptionsManager.HidePlayers)
			{
				message.Send = false;
				OptionsManager.DestroyPlayers();
			}
		}
	}
}
