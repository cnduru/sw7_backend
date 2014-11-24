using System;

namespace Engine
{
	public class Location
	{
        private int _id, _gameID, _itemID;
        private double _locX, _locY;

		public Location (int id, int gameID, int itemID, int locX, int locY)
		{
            _id = id;
            _gameID = gameID;
            _itemID = itemID;
            _locX = locX;
            _locY = locY;
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

        public double locX
        {
            get { return _locX; }
        }

        public double locY
        {
            get { return _locY; }
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