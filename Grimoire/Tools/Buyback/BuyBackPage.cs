using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using HtmlAgilityPack;

namespace Grimoire.Tools.Buyback
{
	// Token: 0x0200001A RID: 26
	public class BuyBackPage
	{
		// Token: 0x0600013A RID: 314 RVA: 0x00010C1A File Offset: 0x0000EE1A
		public BuyBackPage(string html)
		{
			this._doc = new HtmlDocument();
			this._doc.LoadHtml(html);
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00010C3C File Offset: 0x0000EE3C
		public string EventArgument
		{
			get
			{
				string result;
				try
				{
					string value = this._doc.DocumentNode.SelectNodes("//input[@type]").First<HtmlNode>().Attributes["onclick"].Value;
					result = HttpUtility.UrlEncode(new Regex("BuyNow(\\$)\\d{1,2}", RegexOptions.IgnoreCase).Matches(value)[0].Value);
				}
				catch
				{
					result = string.Empty;
				}
				return result;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00010CB8 File Offset: 0x0000EEB8
		public string ViewState
		{
			get
			{
				string result;
				try
				{
					result = HttpUtility.UrlEncode(this._doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").Attributes["value"].Value);
				}
				catch
				{
					result = string.Empty;
				}
				return result;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00010D10 File Offset: 0x0000EF10
		public string ViewStateGenerator
		{
			get
			{
				string result;
				try
				{
					result = HttpUtility.UrlEncode(this._doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATEGENERATOR']").Attributes["value"].Value);
				}
				catch
				{
					result = string.Empty;
				}
				return result;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00010D68 File Offset: 0x0000EF68
		public string EventValidation
		{
			get
			{
				string result;
				try
				{
					result = HttpUtility.UrlEncode(this._doc.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").Attributes["value"].Value);
				}
				catch
				{
					result = string.Empty;
				}
				return result;
			}
		}

		// Token: 0x04000127 RID: 295
		private readonly HtmlDocument _doc;

		// Token: 0x04000128 RID: 296
		public const string EventTarget = "GridBuyBack";

		// Token: 0x04000129 RID: 297
		public const string Confirm = "YES%2c+GET+NOW+FOR+FREE";
	}
}
