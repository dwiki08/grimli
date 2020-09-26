using System;
using System.Collections.Generic;
using Grimoire.Botting;
using Newtonsoft.Json.Linq;

namespace Grimoire.Networking.Handlers
{
	public class HandlerSkills : IJsonMessageHandler
	{
		public string[] HandledCommands { get; } = new string[]
		{
			"sAct"
		};

		public void Handle(JsonMessage message)
		{
			JToken jtoken = message.DataObject["actions"];
			JToken jtoken2 = (jtoken != null) ? jtoken["passive"] : null;
			if (jtoken2 != null)
			{
				foreach (JToken jtoken3 in ((IEnumerable<JToken>)jtoken2))
				{
					if (OptionsManager.InfiniteRange)
					{
						jtoken3["range"] = "200000";
						jtoken3["mp"] = "0";
					}
				}
			}
			JToken jtoken4 = (jtoken != null) ? jtoken["active"] : null;
			if (jtoken4 != null)
			{
				foreach (JToken jtoken5 in ((IEnumerable<JToken>)jtoken4))
				{
					if (OptionsManager.InfiniteRange)
					{
						jtoken5["range"] = "200000";
						jtoken5["mp"] = "0";
					}
				}
			}
		}
	}
}
