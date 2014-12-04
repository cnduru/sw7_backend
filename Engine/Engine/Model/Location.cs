using System;
using System.Data;

namespace Engine
{
	public class Location
	{
        private int _id, _gameID, _itemID;
		private int? _teamID;
		private double _lat, _lng;

		public Location (DataRow row)
		{
			_id = row.Field<int> ("id");
			_gameID = row.Field<int> ("game_id");
			_itemID = row.Field<int> ("item_id");
			_teamID = row.Field<int> ("team_id");
			_lat = row.Field<double> ("loc_x");
			_lng = row.Field<double> ("loc_y");
		}

		public Location (int id, int gameID, int itemID, int? teamID , double lat, double lng)
		{
            _id = id;
            _gameID = gameID;
            _itemID = itemID;
			_teamID = teamID;
            _lat = lat;
            _lng = lng;
		}
        
        public int id
        {
            get { return _id; }
        }

        public int gameID
        {
            get { return _gameID; }
        }

        public int itemID
        {
            get { return _itemID; }
        }

        public double lat
        {
            get { return _lat; }
        }

        public double lng
        {
            get { return _lng; }
        }
		public int? teamID
		{
			get { return _teamID; }
		}
	}
}

/*

  id serial PRIMARY KEY, 
  game_id int NOT NULL REFERENCES game(id),
  item_id int NOT NULL REFERENCES item(id),
  loc_x float NOT NULL,
  loc_y float NOT NULL,
  team_id int REFERENCES team(id)
*/