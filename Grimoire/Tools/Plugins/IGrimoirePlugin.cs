using System;

namespace Grimoire.Tools.Plugins
{
	// Token: 0x02000018 RID: 24
	public interface IGrimoirePlugin
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600012E RID: 302
		string Author { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600012F RID: 303
		string Description { get; }

		// Token: 0x06000130 RID: 304
		void Load();

		// Token: 0x06000131 RID: 305
		void Unload();
	}
}
