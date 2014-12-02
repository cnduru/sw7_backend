using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Data;

namespace Engine
{
	public class Team
	{
        private int _id, _score;
        private List<Player> _teamMembers;

		public Team (DataRow row)
		{
			_id = row.Field<int> ("id");
			_score = row.Field<int> ("score");
		}

		public Team (int id, int score)
		{
            _id = id;
			_score = score;
		}

        public int id
        {
            get { return _id; }
        }

        public int score
        {
            get { return _score; }
        }

		public List<Player> teamMembers
		{
			get { return _teamMembers; }
		}
	}
}

