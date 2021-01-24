using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grimoire.Networking;

namespace Grimoire.Tools
{
	public class Spammer
	{
		public static Spammer Instance { get; } = new Spammer();
		public string StopSpam { get; } = "STOP";

		private Spammer()
		{
		}

		public event Action<int> IndexChanged;

		public void Start(List<string> packets, int delay)
		{
			this._packets = packets;
			this._delay = delay;
			this._cancellationTokenSource = new CancellationTokenSource();
			Task.Run(new Func<Task>(this.Spam));
		}

		public void Stop()
		{
			this._cancellationTokenSource.Cancel(false);
		}

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
				int i = index++;
				if (this._packets[i].ToString().Equals(StopSpam))
				{
					Stop();
				}
				else
                {
					await Proxy.Instance.SendToServer(this._packets[i]);
					await Task.Delay(this._delay);
				}
			}
		}

		private List<string> _packets;

		private int _delay;

		private CancellationTokenSource _cancellationTokenSource;
	}
}
