using System;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace Engine
{
	public class Player
	{
        private int _id, _owner, _gameID;
		private int? _teamID, _score;
		private double? _locX, _locY;
        private List<Item> _inventory;
		private List<StatusEffect> _statusEffects;

		public Player (DataRow row)
		{
			_id = row.Field<int> ("id"); 
			_owner = row.Field<int> ("owner");
			_gameID = row.Field<int> ("game_id");
			_teamID = row.Field<int?> ("team_id");
			_score = row.Field<int?> ("score");
			_locX = row.Field<double?> ("loc_x");
			_locY = row.Field<double?> ("loc_y");
		}

		public Player (int owner, int gameID, int? teamID=null)
		{
            // initialize variables
            _id = 0;
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
		public List<StatusEffect> statusEffects
		{
			get { return _statusEffects; }
			set { _statusEffects = value; }
		}

		public double? locX
		{
			get { return _locX; }
			set { _locX = value; }
		}

		public double? locY
		{
			get { return _locY; }
			set { _locY = value; }
		}

        public int gameID
        {
            get { return _gameID; }
        }

		public int? score
		{
			get { return _score; }
		}

        public int? teamID
        {
            get { return _teamID; }
        }
	}
}