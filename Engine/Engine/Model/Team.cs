using System;
using System.Collections.Generic;

namespace Engine
{
	public class Team
	{
        private int _id, _score;
        private List<Player> _teamMembers;

		public Team (int id)
		{
            _id = id;
            _teamMembers = new List<Player>();
		}

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int score
        {
            get { return _score; }
            set { _score = value; }
        }
	}
}

