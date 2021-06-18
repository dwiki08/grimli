using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using HtmlAgilityPack;

namespace Grimoire.Tools.Buyback
{
	public class BuyBackPage
	{
		public BuyBackPage(string html)
		{
			this._doc = new HtmlDocument();
			this._doc.LoadHtml(html);
		}

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

		private readonly HtmlDocument _doc;

		public const string EventTarget = "GridBuyBack";

		public const string Confirm = "YES%2c+GET+NOW+FOR+FREE";
	}
}
