using System;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace Engine
{
	public class StatusEffect
	{
		private int _id, _playerID, _effect;
		private int? _value;
		private DateTime? _end;

		StatusEffect (DataRow row)
		{
			_id = row.Field<int> ("id");
			_playerID = row.Field<int> ("player_id");
			_effect = row.Field<int> ("effect");
			_value = row.Field<int?> ("effect_value");
			_end = row.Field<DateTime?> ("end_time");
		}

		public StatusEffect (int id, int playerID, int effect, int? value, DateTime? end)
		{
			_id = id;
			_playerID = playerID;
			_effect = effect;
			_value = value;
			_end = end;
		}

		public int? value { 
			get { return _value; }
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
		public DateTime? endTime {
			get { return _end; }
		}
	}
}