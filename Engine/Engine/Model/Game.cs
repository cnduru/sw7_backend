using System;
using System.Collections.Generic;
using System.Data;


namespace Engine
{
	public class Game
	{
		private int _id, _hostID, _visibility;
		private string _alias;
		private DateTime _created, _start, _end;
		private double _boundaryNWX, _boundaryNWY, _boundarySEX, _boundarySEY;

		private List<Team> _teams;
		private List<Player> _players;
		private List<Location> _locations;

		public Game (DataRow row)
		{
			_id = row.Field<int> ("id");
			_hostID = row.Field<int> ("host_id");
			_visibility = row.Field<int> ("visibility");
			_alias = row.Field<string> ("alias");
			_created = row.Field<DateTime> ("create_time");
			_start = row.Field<DateTime> ("start_time");
			_end = row.Field<DateTime> ("end_time");
			_boundaryNWX = row.Field<double> ("boundary_nw_x");
			_boundaryNWY = row.Field<double> ("boundary_nw_y");
			_boundarySEX = row.Field<double> ("boundary_se_x");
			_boundarySEY = row.Field<double> ("boundary_se_y");
		}

		public Game (int hostID, int visibility, string alias,
				 	 DateTime created, DateTime start, DateTime end,
				 	 double nwx, double nwy, double sex, double sey)
		{
			_id = 0;
			_hostID = hostID;
			_visibility = visibility;
			_alias = alias;
			_created = created;
			_start = start;
			_end = end;
			_boundaryNWX = nwx;
			_boundaryNWY = nwy;
			_boundarySEX = sex;
			_boundarySEY = sey;
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
			set { _visibility = value; }
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
		public double nwx {
			get { return _boundaryNWX; }
		}
		public double nwy {
			get { return _boundaryNWY; }
		}
		public double sex {
			get { return _boundarySEX; }
		}
		public double sey {
			get { return _boundarySEY; }
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

