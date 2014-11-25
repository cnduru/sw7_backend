using System;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace Engine
{
	class StatusEffect
	{
		private int _id, _playerID, _effect;
		private DateTime _end;

		StatusEffect (DataRow row)
		{
			_id = row.Field<int> ("id");
			_playerID = row.Field<int> ("player_id");
			_effect = row.Field<int> ("effect");
			_end = row.Field<DateTime> ("end_time");
		}

		StatusEffect (int id, int playerID, int effect, DateTime end)
		{
			id = id;
			_playerID = playerID;
			_effect = effect;
			_end = end;
		}

		public int id {
			get { return _id; }
		}
		public int playerID {
			get { return _playerID; }
		}
		public int effect {
			get { return _effect; }
		}
		public DateTime endTime {
			get { return _end; }
		}


	}

}