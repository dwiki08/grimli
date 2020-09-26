using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Grimoire.Networking
{
	public class JsonMessage : Message
	{
		public JToken Object { get; }

		public JToken DataObject
		{
			get
			{
				JToken @object = this.Object;
				if (@object == null)
				{
					return null;
				}
				JToken jtoken = @object["b"];
				if (jtoken == null)
				{
					return null;
				}
				return jtoken["o"];
			}
		}

		public JsonMessage(string raw)
		{
			try
			{
				base.RawContent = raw;
				this.Object = JObject.Parse(raw);
				JToken dataObject = this.DataObject;
				string command;
				if (dataObject == null)
				{
					command = null;
				}
				else
				{
					JToken jtoken = dataObject["cmd"];
					command = ((jtoken != null) ? jtoken.Value<string>() : null);
				}
				base.Command = command;
			}
			catch (JsonReaderException)
			{
			}
		}

		public override string ToString()
		{
			return this.Object.ToString(Formatting.None, new JsonConverter[0]);
		}
	}
}
