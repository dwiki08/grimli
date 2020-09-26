using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
	// Token: 0x02000036 RID: 54
	public class Quests
	{
		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000268 RID: 616 RVA: 0x00012AC4 File Offset: 0x00010CC4
		// (remove) Token: 0x06000269 RID: 617 RVA: 0x00012AFC File Offset: 0x00010CFC
		public event Action<List<Quest>> QuestsLoaded;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600026A RID: 618 RVA: 0x00012B34 File Offset: 0x00010D34
		// (remove) Token: 0x0600026B RID: 619 RVA: 0x00012B6C File Offset: 0x00010D6C
		public event Action<CompletedQuest> QuestCompleted;

		// Token: 0x0600026C RID: 620 RVA: 0x00012BA1 File Offset: 0x00010DA1
		public void OnQuestsLoaded(List<Quest> quests)
		{
			Action<List<Quest>> questsLoaded = this.QuestsLoaded;
			if (questsLoaded == null)
			{
				return;
			}
			questsLoaded(quests);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00012BB4 File Offset: 0x00010DB4
		public void OnQuestCompleted(CompletedQuest quest)
		{
			Action<CompletedQuest> questCompleted = this.QuestCompleted;
			if (questCompleted == null)
			{
				return;
			}
			questCompleted(quest);
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00012BC7 File Offset: 0x00010DC7
		public List<Quest> QuestTree
		{
			get
			{
				return Flash.Call<List<Quest>>("GetQuestTree", new string[0]);
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00012BD9 File Offset: 0x00010DD9
		public List<Quest> AcceptedQuests
		{
			get
			{
				return (from q in this.QuestTree
				where q.IsInProgress
				select q).ToList<Quest>();
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00012C0A File Offset: 0x00010E0A
		public List<Quest> UnacceptedQuests
		{
			get
			{
				return (from q in this.QuestTree
				where !q.IsInProgress
				select q).ToList<Quest>();
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000271 RID: 625 RVA: 0x00012C3B File Offset: 0x00010E3B
		public List<Quest> CompletedQuests
		{
			get
			{
				return (from q in this.QuestTree
				where q.CanComplete
				select q).ToList<Quest>();
			}
		}

		public void Accept(int questId)
		{
			Flash.Call("Accept", new string[]
			{
				questId.ToString()
			});
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00012C88 File Offset: 0x00010E88
		public void Accept(string questId)
		{
			Flash.Call("Accept", new string[]
			{
				questId
			});
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00012C9E File Offset: 0x00010E9E
		public void Complete(int questId)
		{
			Flash.Call("Complete", new string[]
			{
				questId.ToString()
			});
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00012CBA File Offset: 0x00010EBA
		public void Complete(string questId)
		{
			Flash.Call("Complete", new string[]
			{
				questId
			});
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00012CD0 File Offset: 0x00010ED0
		public void Complete(string questId, string itemId)
		{
			Flash.Call("Complete", new string[]
			{
				itemId,
				bool.TrueString
			});
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00012CEE File Offset: 0x00010EEE
		public void Load(int id)
		{
			Flash.Call("LoadQuest", new string[]
			{
				id.ToString()
			});
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00012D0A File Offset: 0x00010F0A
		public void Load(List<int> ids)
		{
			Flash.Call("LoadQuests", new string[]
			{
				string.Join<int>(",", ids)
			});
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00012D2C File Offset: 0x00010F2C
		public void Get(List<int> ids)
		{
			string function = "GetQuests";
			string[] array = new string[1];
			array[0] = string.Join(",", from i in ids
			select i.ToString());
			Flash.Call(function, array);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00012D7B File Offset: 0x00010F7B
		public bool IsInProgress(int id)
		{
			return Flash.Call<bool>("IsInProgress", new string[]
			{
				id.ToString()
			});
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00012D97 File Offset: 0x00010F97
		public bool IsInProgress(string id)
		{
			return Flash.Call<bool>("IsInProgress", new string[]
			{
				id
			});
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00012DAD File Offset: 0x00010FAD
		public bool CanComplete(int id)
		{
			return Flash.Call<bool>("CanComplete", new string[]
			{
				id.ToString()
			});
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00012DC9 File Offset: 0x00010FC9
		public bool CanComplete(string id)
		{
			return Flash.Call<bool>("CanComplete", new string[]
			{
				id
			});
		}
	}
}
