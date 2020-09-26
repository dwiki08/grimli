using System;

namespace Grimoire.Networking
{
	// Token: 0x0200001B RID: 27
	public interface IJsonMessageHandler
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600013F RID: 319
		string[] HandledCommands { get; }

		// Token: 0x06000140 RID: 320
		void Handle(JsonMessage message);
	}
}
