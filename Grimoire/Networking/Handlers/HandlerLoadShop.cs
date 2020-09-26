using System;
using Grimoire.Game;
using Grimoire.Game.Data;
using Newtonsoft.Json.Linq;

namespace Grimoire.Networking.Handlers
{
	public class HandlerLoadShop : IJsonMessageHandler
	{
		public string[] HandledCommands { get; } = new string[]
		{
			"loadShop"
		};

		public void Handle(JsonMessage message)
		{
			JToken jtoken = message.DataObject["shopinfo"];
			if (jtoken != null)
			{
				World.OnShopLoaded(jtoken.ToObject<ShopInfo>());
			}
		}
	}
}
