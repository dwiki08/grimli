using System;
using System.Collections.Generic;
using System.Linq;
using Grimoire.Tools;

namespace Grimoire.Game.Data
{
	public class Quests
	{
		public event Action<List<Quest>> QuestsLoaded;

		public event Action<CompletedQuest> QuestCompleted;

		public void OnQuestsLoaded(List<Quest> quests)
		{
			Action<List<Quest>> questsLoaded = this.QuestsLoaded;
			if (questsLoaded == null)
			{
				return;
			}
			questsLoaded(quests);
		}

		public void OnQuestCompleted(CompletedQuest quest)
		{
			Action<CompletedQuest> questCompleted = this.QuestCompleted;
			if (questCompleted == null)
			{
				return;
			}
			questCompleted(quest);
		}

		public List<Quest> QuestTree
		{
			get
			{
				return Flash.Call<List<Quest>>("GetQuestTree", new string[0]);
			}
		}

		public List<Quest> AcceptedQuests
		{
			get
			{
				return (from q in this.QuestTree
				where q.IsInProgress
				select q).ToList<Quest>();
			}
		}

		public List<Quest> UnacceptedQuests
		{
			get
			{
				return (from q in this.QuestTree
				where !q.IsInProgress
				select q).ToList<Quest>();
			}
		}

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

		public void Accept(string questId)
		{
			Flash.Call("Accept", new string[]
			{
				questId
			});
		}

		public void Complete(int questId)
		{
			Flash.Call("Complete", new string[]
			{
				questId.ToString()
			});
		}

		public void Complete(string questId)
		{
			Flash.Call("Complete", new string[]
			{
				questId
			});
		}

		public void Complete(string questId, string itemId)
		{
			Flash.Call("Complete", new string[]
			{
				itemId,
				bool.TrueString
			});
		}

		public void Load(int id)
		{
			Flash.Call("LoadQuest", new string[]
			{
				id.ToString()
			});
		}

		public void Load(List<int> ids)
		{
			Flash.Call("LoadQuests", new string[]
			{
				string.Join<int>(",", ids)
			});
		}

		public void Get(List<int> ids)
		{
			string function = "GetQuests";
			string[] array = new string[1];
			array[0] = string.Join(",", from i in ids
			select i.ToString());
			Flash.Call(function, array);
		}

		public bool IsInProgress(int id)
		{
			return Flash.Call<bool>("IsInProgress", new string[]
			{
				id.ToString()
			});
		}

		public bool IsInProgress(string id)
		{
			return Flash.Call<bool>("IsInProgress", new string[]
			{
				id
			});
		}

		public bool CanComplete(int id)
		{
			return Flash.Call<bool>("CanComplete", new string[]
			{
				id.ToString()
			});
		}

		public bool CanComplete(string id)
		{
			return Flash.Call<bool>("CanComplete", new string[]
			{
				id
			});
		}
	}
}
