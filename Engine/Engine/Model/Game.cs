using System;
using System.Collections.Generic;


namespace Engine
{
	public class Game
	{
		private int _id, _hostID, _visibility;
		private string _alias;
		private DateTime _created, _start, _end;
		private double _boundaryX, _boundaryY;

		private List<Team> _teams;
		private List<Player> _players;
		private List<Location> _locations;

		public Game (int id, int hostID, int visibility, string alias,
				 	 DateTime created, DateTime start, DateTime end,
				 	 double x, double y)
		{
			_id = id;
			_hostID = hostID;
			_visibility = visibility;
			_alias = alias;
			_created = created;
			_start = start;
			_end = end;
			_boundaryX = x;
			_boundaryY = y;
		}

		public int id
		{
			get { return _id; }
		}
		public int hostID
		{
			get { return _hostID; }
		}
		public int visibility {
			get { return _visibility; }
		}
		public string alias {
			get { return _alias; }
		}
		public DateTime created {
			get { return _created; }
		}
		public DateTime start {
			get { return _start; }
		}
		public DateTime end {
			get { return _end; }
		}
		public double x {
			get { return _boundaryX; }
		}
		public double y {
			get { return _boundaryY; }
		}
		public List<Team> teams {
			get { return _teams; }
			set { _teams = value; }
		}
		public List<Player> players {
			get { return _players; }
			set { _players = value; }
		}
		public List<Location> locations {
			get { return _locations; }
			set { _locations = value; }
		}
	}
}

