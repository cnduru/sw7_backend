using System;
using System.Collections.Generic;

namespace Engine
{
	public class Player
	{
        private int _id, _owner, _gameID, _teamID;
        private List<Item> _inventory;

		public Player (int id, int owner, int gameID, int teamID)
		{
            // initialize variables
            _id = id;
            _owner = owner;
            _gameID = gameID;
            _teamID = teamID;
            _inventory = new List<Item>();
		}

        //Accessors
        public int id
        {
            get { return _id; }
        }

        public int userName
        {
            get { return _owner; }
        }

        public List<Item> inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public int gameID
        {
            get { return _gameID; }
            set { _gameID = value; }
        }

        public int teamID
        {
            get { return teamID; }
            set { teamID = value; }
        }
	}
}

/*
  id serial PRIMARY KEY, 
  owner int NOT NULL REFERENCES account(id),
  game_id int NOT NULL REFERENCES game(id),
  team_id int REFERENCES team(id),
  score int*/