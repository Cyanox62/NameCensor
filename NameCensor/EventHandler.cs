using Smod2.EventHandlers;
using Smod2.Events;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace NameCensor
{
	class EventHandler :IEventHandlerPlayerJoin, IEventHandlerWaitingForPlayers
	{
		private Plugin instance;
		private List<string> bList;

		public EventHandler(Plugin instance)
		{
			this.instance = instance;
		}

		private void LoadConfigs()
		{
			bList = instance.GetConfigList("nc_blacklist").ToList();
		}

		public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
		{
			LoadConfigs();
		}

		public void OnPlayerJoin(PlayerJoinEvent ev)
		{
			NicknameSync sync = ((GameObject)ev.Player.GetGameObject()).GetComponent<NicknameSync>();
			string name = sync.NetworkmyNick;
			foreach (string str in bList.Select(x => x = x.ToLower().Trim()))
			{
				for (int i = 0; i < Regex.Matches(name.ToLower(), str).Count; i++)
				{
					name = Regex.Replace(name, str, new string('-', str.Length), RegexOptions.IgnoreCase);
				}
			}
			sync.UpdateNickname(name);
		}
	}
}
