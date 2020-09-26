using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Game;
using Grimoire.Game.Data;
using Newtonsoft.Json.Linq;

namespace Grimoire.Networking.Handlers
{
	public class HandlerGetQuests : IJsonMessageHandler
	{
		public string[] HandledCommands { get; } = new string[]
		{
			"getQuests"
		};

		public void Handle(JsonMessage message)
		{
			JToken dataObject = message.DataObject;
			Dictionary<int, Quest> dictionary;
			if (dataObject == null)
			{
				dictionary = null;
			}
			else
			{
				JToken jtoken = dataObject["quests"];
				dictionary = ((jtoken != null) ? jtoken.ToObject<Dictionary<int, Quest>>() : null);
			}
			Dictionary<int, Quest> dictionary2 = dictionary;
			if (dictionary2 != null && dictionary2.Count > 0)
			{
				Player.Quests.OnQuestsLoaded((from q in dictionary2
				select q.Value).ToList<Quest>());
			}
		}
	}
}
