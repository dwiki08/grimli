using System;

namespace Grimoire.Networking
{
	// Token: 0x0200001C RID: 28
	public interface IXmlMessageHandler
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000141 RID: 321
		string[] HandledCommands { get; }

		// Token: 0x06000142 RID: 322
		void Handle(XmlMessage message);
	}
}
