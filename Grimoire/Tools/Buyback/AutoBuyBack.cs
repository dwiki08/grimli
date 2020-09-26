using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Grimoire.Tools.Buyback
{
	// Token: 0x02000019 RID: 25
	public class AutoBuyBack : IDisposable
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00010A40 File Offset: 0x0000EC40
		protected internal string Username
		{
			get
			{
				return Flash.Call<string>("GetUsername", new string[0]);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00010A52 File Offset: 0x0000EC52
		protected internal string Password
		{
			get
			{
				return Flash.Call<string>("GetPassword", new string[0]);
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00010A64 File Offset: 0x0000EC64
		public AutoBuyBack()
		{
			this._client = new HttpClient(new HttpClientHandler
			{
				AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate),
				CookieContainer = new CookieContainer()
			})
			{
				BaseAddress = new Uri("https://www.aq.com/acct/")
			};
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00010AA0 File Offset: 0x0000ECA0
		public async Task Perform(string item, int pageCap)
		{
			if (!string.IsNullOrEmpty(this.Username) && !string.IsNullOrEmpty(this.Password))
			{
				string lastRequestedPage;
				if (!string.IsNullOrEmpty(lastRequestedPage = await this.SendPost(string.Empty, string.Concat(new string[]
				{
					"uuu=",
					this.Username,
					"&pps=",
					this.Password,
					"&submit="
				}))))
				{
					string[] array;
					if ((array = await this.GetItemHtml(lastRequestedPage, item, pageCap)).Length >= 2)
					{
						BuyBackPage buyBackPage = new BuyBackPage(array[0]);
						BuyBackPage buyBackPage2 = new BuyBackPage(array[1]);
						string postData = string.Concat(new string[]
						{
							"__EVENTTARGET=GridBuyBack&__EVENTARGUMENT=",
							buyBackPage.EventArgument,
							"&__VIEWSTATE=",
							buyBackPage2.ViewState,
							"&__VIEWSTATEGENERATOR=",
							buyBackPage2.ViewStateGenerator,
							"&__VIEWSTATEENCRYPTED=&__EVENTVALIDATION=",
							buyBackPage2.EventValidation
						});
						string html;
						if (!string.IsNullOrEmpty(html = await this.SendPost("inventory.aspx?tab=buyback", postData)))
						{
							BuyBackPage buyBackPage3 = new BuyBackPage(html);
							string postData2 = string.Concat(new string[]
							{
								"__VIEWSTATE=",
								buyBackPage3.ViewState,
								"&__VIEWSTATEGENERATOR=",
								buyBackPage3.ViewStateGenerator,
								"&__VIEWSTATEENCRYPTED=&__EVENTVALIDATION=",
								buyBackPage3.EventValidation,
								"&btnConfirmYes=YES%2c+GET+NOW+FOR+FREE"
							});
							await this.SendPost("inventory.aspx?tab=buyback", postData2);
						}
					}
				}
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00010AF8 File Offset: 0x0000ECF8
		private async Task<string[]> GetItemHtml(string lastRequestedPage, string item, int cap)
		{
			string[] ret = new string[2];
			for (int i = 1; i <= cap; i++)
			{
				BuyBackPage buyBackPage = new BuyBackPage(lastRequestedPage);
				string postData = string.Concat(new string[]
				{
					string.Format("__EVENTTARGET={0}&__EVENTARGUMENT=Page%24{1}&", "GridBuyBack", i),
					"__VIEWSTATE=",
					buyBackPage.ViewState,
					"&__VIEWSTATEGENERATOR=",
					buyBackPage.ViewStateGenerator,
					"&__VIEWSTATEENCRYPTED=&__EVENTVALIDATION=",
					buyBackPage.EventValidation
				});
				string text = await this.SendPost("inventory.aspx?tab=buyback", postData);
				lastRequestedPage = text;
				foreach (string text2 in text.Split(new char[]
				{
					'\n'
				}))
				{
					if (text2.IndexOf(item, StringComparison.OrdinalIgnoreCase) > -1)
					{
						ret[0] = text2;
						ret[1] = text;
						return ret;
					}
				}
			}
			return ret;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00010B58 File Offset: 0x0000ED58
		private async Task<string> SendPost(string url, string postData)
		{
			string result;
			try
			{
				result = HttpUtility.HtmlDecode(await this._client.PostAsync(url, new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")).Result.Content.ReadAsStringAsync());
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00010BB0 File Offset: 0x0000EDB0
		private async Task<string> SendGet(string url)
		{
			string result;
			try
			{
				result = HttpUtility.HtmlDecode(await this._client.GetStringAsync(url));
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00010BFD File Offset: 0x0000EDFD
		public void Dispose()
		{
			this.SendGet("logout.aspx").Wait();
			this._client.Dispose();
		}

		// Token: 0x04000125 RID: 293
		private const string UrlBuyBack = "inventory.aspx?tab=buyback";

		// Token: 0x04000126 RID: 294
		private readonly HttpClient _client;
	}
}
