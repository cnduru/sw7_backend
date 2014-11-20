using System;
using System.Collections.Generic;

namespace Engine
{
	public class Account
	{
		public int id {
			get { return id; }
			set { id = value; }
		}
		public string userName { 
			get { return userName; }
			set { userName = value; }
		}
		public List<Player> players	{
			get { return players; }
			set { players = value; }
		}
		public List<Game> hosting {
			get { return hosting; }
			set { hosting = value; }
		}

		public Account (int _id, string _userName)
		{
			id = _id;
			userName = _userName;
		}
	}
}

