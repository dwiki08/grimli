using System;

namespace Grimoire.Botting
{
	public interface IBotEngine
	{
		event Action<bool> IsRunningChanged;

		event Action<int> IndexChanged;

		event Action<Configuration> ConfigurationChanged;

		bool IsRunning { get; set; }

		int Index { get; set; }

		Configuration Configuration { get; set; }

		void Start(Configuration config);

		void Stop();
	}
}
