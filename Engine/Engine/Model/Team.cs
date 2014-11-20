using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

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
        }

        public int score
        {
            get { return _score; }
            set { _score = value; }
        }

		public List<Player> teamMembers
		{
			get { return _teamMembers; }
		}
	}
}

