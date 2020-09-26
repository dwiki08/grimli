using System;
using System.Xml;

namespace Grimoire.Networking.Handlers
{
	// Token: 0x02000027 RID: 39
	public class HandlerPolicy : IXmlMessageHandler
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00011981 File Offset: 0x0000FB81
		public string[] HandledCommands { get; } = new string[]
		{
			"policy"
		};

		// Token: 0x06000180 RID: 384 RVA: 0x0001198C File Offset: 0x0000FB8C
		public void Handle(XmlMessage message)
		{
			XmlDocument body = message.Body;
			XmlElement xmlElement;
			if (body == null)
			{
				xmlElement = null;
			}
			else
			{
				XmlElement xmlElement2 = body["cross-domain-policy"];
				xmlElement = ((xmlElement2 != null) ? xmlElement2["allow-access-from"] : null);
			}
			XmlElement xmlElement3 = xmlElement;
			if (xmlElement3 != null)
			{
				xmlElement3.Attributes["to-ports"].Value = Proxy.Instance.ListenerPort.ToString();
			}
		}
	}
}
