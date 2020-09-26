using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grimoire.Networking;

namespace Grimoire.Tools
{
	// Token: 0x02000015 RID: 21
	public class Spammer
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00010700 File Offset: 0x0000E900
		public static Spammer Instance { get; } = new Spammer();

		// Token: 0x0600011C RID: 284 RVA: 0x00002128 File Offset: 0x00000328
		private Spammer()
		{
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600011D RID: 285 RVA: 0x00010708 File Offset: 0x0000E908
		// (remove) Token: 0x0600011E RID: 286 RVA: 0x00010740 File Offset: 0x0000E940
		public event Action<int> IndexChanged;

		// Token: 0x0600011F RID: 287 RVA: 0x00010775 File Offset: 0x0000E975
		public void Start(List<string> packets, int delay)
		{
			this._packets = packets;
			this._delay = delay;
			this._cancellationTokenSource = new CancellationTokenSource();
			Task.Run(new Func<Task>(this.Spam));
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000107A2 File Offset: 0x0000E9A2
		public void Stop()
		{
			this._cancellationTokenSource.Cancel(false);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000107B0 File Offset: 0x0000E9B0
		private async Task Spam()
		{
			int index = 0;
			while (!this._cancellationTokenSource.IsCancellationRequested)
			{
				if (index >= this._packets.Count)
				{
					index = 0;
				}
				Action<int> indexChanged = this.IndexChanged;
				if (indexChanged != null)
				{
					indexChanged(index);
				}
				await Proxy.Instance.SendToServer(this._packets[index++]);
				await Task.Delay(this._delay);
			}
		}

		// Token: 0x0400011D RID: 285
		private List<string> _packets;

		// Token: 0x0400011E RID: 286
		private int _delay;

		// Token: 0x0400011F RID: 287
		private CancellationTokenSource _cancellationTokenSource;
	}
}
