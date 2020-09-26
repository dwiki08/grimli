using System;
using System.Xml;

namespace Grimoire.Networking
{
	// Token: 0x0200001F RID: 31
	public class XmlMessage : Message
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00010EAA File Offset: 0x0000F0AA
		public XmlDocument Body { get; }

		// Token: 0x0600014F RID: 335 RVA: 0x00010EB4 File Offset: 0x0000F0B4
		public XmlMessage(string raw)
		{
			try
			{
				base.RawContent = raw;
				this.Body = new XmlDocument();
				this.Body.LoadXml(raw);
				string command;
				if (!raw.Contains("cross-domain-policy"))
				{
					XmlElement documentElement = this.Body.DocumentElement;
					if (documentElement == null)
					{
						command = null;
					}
					else
					{
						XmlElement xmlElement = documentElement["body"];
						if (xmlElement == null)
						{
							command = null;
						}
						else
						{
							XmlAttribute xmlAttribute = xmlElement.Attributes["action"];
							command = ((xmlAttribute != null) ? xmlAttribute.Value : null);
						}
					}
				}
				else
				{
					command = "policy";
				}
				base.Command = command;
			}
			catch (XmlException)
			{
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00010F54 File Offset: 0x0000F154
		public override string ToString()
		{
			return this.Body.OuterXml;
		}
	}
}
