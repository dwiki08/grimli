using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Botting;
using Grimoire.Game;
using Grimoire.Game.Data;
using Grimoire.UI;
using Newtonsoft.Json.Linq;

namespace Grimoire.Networking.Handlers
{
	public class HandlerDropItem : IJsonMessageHandler
	{
		public string[] HandledCommands { get; } = new string[]
		{
			"dropItem"
		};

		public void Handle(JsonMessage message)
		{
			JToken dataObject = message.DataObject;
			JToken jtoken = (dataObject != null) ? dataObject["items"] : null;
			if (jtoken != null)
			{
				InventoryItem item = jtoken.ToObject<Dictionary<int, InventoryItem>>().First<KeyValuePair<int, InventoryItem>>().Value;
				if (BotManager.Instance.ActiveBotEngine.IsRunning)
				{
					Configuration configuration = BotManager.Instance.ActiveBotEngine.Configuration;
					message.Send = (!configuration.EnableRejection || !configuration.Drops.All((string d) => !d.Equals(item.Name, StringComparison.OrdinalIgnoreCase)));
				}
				World.OnItemDropped(item);
			}
		}
	}
}
