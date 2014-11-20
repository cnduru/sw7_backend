using System;
using System.Collections.Generic;

namespace Engine
{
	public class Account
	{
		public int id {
			get { return id; }
		}
		public string userName { 
			get { return userName; }
		}
		public List<Player> players	{
			get { return players; }
			set { players = value; }
		}
		public List<Game> hosting {
			get { return hosting; }
			set { hosting = value; }
		}

		public Account (int id, string userName)
		{
			id = id;
			userName = userName;
		}
	}
}

