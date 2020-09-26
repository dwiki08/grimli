using System;

namespace Grimoire.Networking
{
	// Token: 0x02000020 RID: 32
	public class XtMessage : Message
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000151 RID: 337 RVA: 0x00010F61 File Offset: 0x0000F161
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00010F69 File Offset: 0x0000F169
		public string[] Arguments { get; set; }

		// Token: 0x06000153 RID: 339 RVA: 0x00010F74 File Offset: 0x0000F174
		public XtMessage(string raw)
		{
			if (raw != null)
			{
				base.RawContent = raw;
				if ((this.Arguments = raw.Split(new char[]
				{
					'%'
				})).Length >= 4)
				{
					base.Command = ((this.Arguments[2] == "zm") ? ((this.Arguments[3] == "cmd") ? this.Arguments[5] : this.Arguments[3]) : this.Arguments[2]);
				}
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00010FFA File Offset: 0x0000F1FA
		public override string ToString()
		{
			return string.Join("%", this.Arguments);
		}
	}
}
