﻿using System;
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

        public int GetID()
        {          
            return Gid;
        }          
                   
        public int GetOwner()
        {          
            return _owner;
        }          
                   
        public int GetGameID()
        {          
            return _gameID;
        }          
                   
        public int GetTeamID()
        {
            return _teamID;
        }

        public List<Item> AddToInventory(Item)
        {
            _inventory.Add(Item);
        }

	}
}

/*
  id serial PRIMARY KEY, 
  owner int NOT NULL REFERENCES account(id),
  game_id int NOT NULL REFERENCES game(id),
  team_id int REFERENCES team(id),
  score int*/