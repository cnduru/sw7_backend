using System;
using System.Collections.Generic;
using System.Data;

namespace Engine
{
	public class Account
	{
		private int _id;
		private string _userName;
		private string _password;
		private List<Player> _players;
		private List<Game> _hosting;

		public Account(DataRow row)
		{
			_id = row.Field<int> ("id");
			_userName = row.Field<string> ("username");
			_password = row.Field<string> ("password");
		}

		public Account (string userName, string password)
		{
			_id = 0;
			_userName = userName;
			_password = password;
		}

		//Accessors
		public int id {
			get { return _id; }
		}
		public string userName { 
			get { return _userName; }
		}
		public string password { 
			get { return _password; }
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

