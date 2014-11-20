using System;
using System.Collections.Generic;

namespace Engine
{
	public class Account
	{
		private int _id;
		private string _userName;
		private List<Player> _players;
		private List<Game> _hosting;

		public Account (int id, string userName)
		{
			_id = id;
			_userName = userName;
		}

		//Accessors
		public int id {
			get { return _id; }
		}
		public string userName { 
			get { return _userName; }
		}
		public List<Player> players	{
			get { return _players; }
			set { _players = value; }
		}
		public List<Game> hosting {
			get { return _hosting; }
			set { _hosting = value; }
		}
	}
}

