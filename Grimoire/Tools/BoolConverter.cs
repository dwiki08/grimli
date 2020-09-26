using System;
using Newtonsoft.Json;

namespace Grimoire.Tools
{
	// Token: 0x02000010 RID: 16
	public class BoolConverter : JsonConverter
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x0000F7BD File Offset: 0x0000D9BD
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((bool)value) ? 1 : 0);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000F7D1 File Offset: 0x0000D9D1
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return reader.Value.ToString() == "1";
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000F7ED File Offset: 0x0000D9ED
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(bool);
		}
	}
}
