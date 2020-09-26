using System;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using AxShockwaveFlashObjects;
using Grimoire.Game.Data;
using Grimoire.Networking;
using Grimoire.UI;
using Newtonsoft.Json;

namespace Grimoire.Tools
{
	// Token: 0x02000011 RID: 17
	public static class Flash
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000F7 RID: 247 RVA: 0x0000F808 File Offset: 0x0000DA08
		// (remove) Token: 0x060000F8 RID: 248 RVA: 0x0000F83C File Offset: 0x0000DA3C
		public static event Action<int> SwfLoadProgress;

		// Token: 0x060000F9 RID: 249 RVA: 0x0000F870 File Offset: 0x0000DA70
		public static void ProcessFlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
		{
			XElement xelement = XElement.Parse(e.request);
			XAttribute xattribute = xelement.Attribute("name");
			string a = (xattribute != null) ? xattribute.Value : null;
			XElement xelement2 = xelement.Element("arguments");
			string text = (xelement2 != null) ? xelement2.Value : null;
			if (!(a == "progress"))
			{
				if (!(a == "modifyServers"))
				{
					return;
				}
				Root.Instance.Client.SetReturnValue("<string>" + Flash.ModifyServerList(text.Trim()) + "</string>");
				return;
			}
			else
			{
				Action<int> swfLoadProgress = Flash.SwfLoadProgress;
				if (swfLoadProgress == null)
				{
					return;
				}
				swfLoadProgress(int.Parse(text));
				return;
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000F91B File Offset: 0x0000DB1B
		public static T Call<T>(string function, params string[] args)
		{
			return Flash.TryDeserialize<T>(Flash.GetResponse(Flash.BuildRequest(function, args)));
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000F92E File Offset: 0x0000DB2E
		public static void Call(string function, params string[] args)
		{
			Flash.Call<string>(function, args);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000F938 File Offset: 0x0000DB38
		private static string BuildRequest(string method, params string[] args)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<invoke name=\"" + method + "\" returntype=\"xml\">");
			if (args != null && args.Length != 0)
			{
				stringBuilder.Append("<arguments>");
				foreach (string str in args)
				{
					stringBuilder.Append("<string>" + str + "</string>");
				}
				stringBuilder.Append("</arguments>");
			}
			stringBuilder.Append("</invoke>");
			return stringBuilder.ToString();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000F9C0 File Offset: 0x0000DBC0
		private static string GetResponse(string request)
		{
			string result;
			try
			{
				XNode firstNode = XElement.Parse(Root.Instance.Client.CallFunction(request)).FirstNode;
				result = HttpUtility.HtmlDecode(((firstNode != null) ? firstNode.ToString() : null) ?? string.Empty);
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000FA20 File Offset: 0x0000DC20
		private static T TryDeserialize<T>(string str)
		{
			T result;
			try
			{
				result = JsonConvert.DeserializeObject<T>(str);
			}
			catch
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000FA54 File Offset: 0x0000DC54
		private static string ModifyServerList(string xml)
		{
			if (!xml.StartsWith("<login") || !xml.EndsWith("</login>"))
			{
				return xml;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlElement xmlElement = xmlDocument["login"];
			Server[] array = new Server[xmlElement.ChildNodes.Count];
			for (int i = 0; i < xmlElement.ChildNodes.Count; i++)
			{
				XmlElement xmlElement2 = (XmlElement)xmlElement.ChildNodes[i];
				XmlAttribute xmlAttribute = xmlElement2.Attributes["sIP"];
				xmlElement2.Attributes.Append(xmlDocument.CreateAttribute("RealAddress")).Value = xmlAttribute.Value;
				xmlElement2.Attributes["iPort"].Value = Proxy.Instance.ListenerPort.ToString();
				xmlAttribute.Value = "127.0.0.1";
				array[i] = new Server
				{
					IsChatRestricted = (xmlElement2.Attributes["iChat"].Value == "0"),
					PlayerCount = int.Parse(xmlElement2.Attributes["iCount"].Value),
					IsMemberOnly = (xmlElement2.Attributes["bUpg"].Value == "1"),
					IsOnline = (xmlElement2.Attributes["bOnline"].Value == "1"),
					Name = xmlElement2.Attributes["sName"].Value,
					Port = int.Parse(xmlElement2.Attributes["iPort"].Value)
				};
			}
			BotManager.Instance.OnServersLoaded(array);
			return xmlDocument.OuterXml;
		}
	}
}
