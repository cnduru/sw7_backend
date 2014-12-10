using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using Microsoft.Win32.SafeHandles;
using System.Configuration;
using System.Device.Location;


namespace Engine
{
	public class DBController
	{
		private DataSet ds = new DataSet();
		private DataTable dt = new DataTable();
		private NpgsqlConnection conn;

		private static string dbHost = "localhost";
		private static string dbName = "CornfieldDB";
		private static string dbUser = "cornfield";
		private static string dbPass = "cornfield";

		public DBController()
		{
			string connstring = String.Format (
				"Server={0};User Id={1};Password={2};Database={3};", 
				dbHost, dbUser, dbPass, dbName);
			conn = new NpgsqlConnection(connstring);
			conn.Open();
		}

		public void Close()
		{
			conn.Close ();
		}

		private DataRowCollection Query(string sql)
		{
			try 
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
				ds.Reset();
				da.Fill(ds);
				dt = ds.Tables[0];

				return dt.Rows;
			}
			catch (Exception e)
			{
				Console.WriteLine (e.ToString());
				return null;
			}
		}

		public List<Game> GetActiveGames()
		{
			string sql = "SELECT * FROM game WHERE game.visibility > 0;";

			List<Game> res = new List<Game>();
			foreach (DataRow row in Query(sql))
			{
				res.Add (new Game (row));
			}
			return res;
		}

		public List<Game> GetGames(int accountID)
		{
			string sql = String.Format (@"SELECT game.* FROM player, game
                           WHERE game.id = player.game_id AND player.owner = {0};", accountID);

			List<Game> res = new List<Game>();
			foreach (DataRow row in Query(sql))
			{
				res.Add (new Game (row));
			}
			return res;
		}
		public Game GetGame(int gameID)
		{
			string sql = String.Format (@"SELECT * FROM game
                           WHERE game.id = {0};", gameID);

			return new Game (Query (sql) [0]);
		}

		public List<Player> GetPlayers(int gameID)
		{
			string sql = String.Format (@"SELECT * FROM player
                           WHERE player.game_id = {0}", gameID);

			List<Player> res = new List<Player>();
			foreach (DataRow row in Query(sql))
			{
				res.Add (new Player (row));
			}
			return res;
		}

		public Account GetAccount(string name)
		{
			string sql = String.Format (@"SELECT * FROM account 
				WHERE account.username = '{0}';", name); //TODO SQL INJECTION

			DataRowCollection res = Query (sql);
			if (res.Count == 1)
				return new Account (res [0]);
			else
				return null;
		}

		public Player GetPlayer(int accountID, int gameID)
		{
			string sql = String.Format ("SELECT * FROM player " +
										"WHERE player.owner = {0} " +
										"AND player.game_id = {1};",
			                            accountID, gameID); 
			DataRowCollection res = Query (sql);
			if (res.Count == 1)
				return new Player (res [0]);
			else
				return null;
		}

		//UPDATES
		public bool AddLocations(List<Location> lst)
		{
			List<string> data = new List<string> ();
			foreach (Location l in lst) 
			{
				data.Add (String.Format ("('{0}','{1}','{2}','{3}','{4}')",
					l.gameID.ToString (), l.itemID.ToString (), l.lat.ToString (),
					l.lng.ToString (), l.teamID.ToString ()));
			}

			string sql = String.Format ("INSERT INTO location (game_id, item_id, loc_x, loc_y, team_id) "
			             + "VALUES {0} ;", String.Join (",", data));

			NpgsqlCommand command = new NpgsqlCommand(sql, conn);
			return command.ExecuteNonQuery() > 0;
		}

		public bool InvitePlayer(int accountID, int gameID)
		{
			if (GetPlayer (accountID, gameID) != null)
				return false;
			
			string sql = String.Format ("INSERT INTO player (owner, game_id) "+
			                            "VALUES ({0},{1})", accountID, gameID);

			NpgsqlCommand command = new NpgsqlCommand(sql, conn);
			return command.ExecuteNonQuery () > 0;  //True if rows where affected
		}

		public bool LeaveGame(int userID, int gameID)
		{
			string sql = String.Format ("DELETE FROM player "
			             + "WHERE owner={0} AND game_id={1};", 
				             userID, gameID);

			NpgsqlCommand command = new NpgsqlCommand(sql, conn);
			return command.ExecuteNonQuery () > 0;  //True if rows where affected
		}

		public bool UpdatePlayerLocation (int userID, int gameID, GeoCoordinate loc)
		{
			string sql = String.Format ("UPDATE player "
			             + "SET loc_x = {0}, loc_y = {1} "
			             + "WHERE owner={2} AND game_id = {3};", 
				             loc.Latitude, loc.Longitude, userID, gameID);

			NpgsqlCommand command = new NpgsqlCommand(sql, conn);
			return command.ExecuteNonQuery () > 0;  //True if rows where affected
		}

		public int NewGame(Game g)
		{
			string sql = String.Format("INSERT INTO game (host_id, alias, create_time, start_time, end_time, visibility, " +
														 "boundary_nw_x, boundary_nw_y, boundary_se_x, boundary_se_y) " +
			                           " VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9});",
			                           g.hostID, g.alias, g.created, g.start, g.end, g.visibility, g.nwx, g.nwy, g.sex, g.sey);

			NpgsqlCommand command = new NpgsqlCommand(sql, conn);

			if (command.ExecuteNonQuery () == 0)
				return -1;
			else
				return Convert.ToInt32(command.LastInsertedOID);
		}
		public int AddStatusEffect(StatusEffect se)
		{
			string sql = "INSERT INTO status_effect " +
				"(player_id, effect, effect_value, end_time) " +
				"VALUES (@player_id, @effect, @value, @end_time)";

			NpgsqlCommand command = new NpgsqlCommand(sql, conn);
			command.Parameters.Add("@player_id", se.playerID );
			command.Parameters.Add("@effect", se.effect);
			command.Parameters.Add("@value", se.value);
			command.Parameters.Add("@end_time", se.endTime);

			if (command.ExecuteNonQuery () == 0)
				return -1;
			else
				return Convert.ToInt32(command.LastInsertedOID);
		}

	}
}

/*
namespace PostgreSQLTEst
{
	public partial class Form1 : Form
	{
		private DataSet ds = new DataSet();
		private DataTable dt = new DataTable();
		public Form1()
		{    
			InitializeComponent();    
		}
		private void llOpenConnAndSelect_LinkClicked(object sender, 
			LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				// PostgeSQL-style connection string
				string connstring = String.Format("Server={0};Port={1};" + 
					"User Id={2};Password={3};Database={4};",
					tbHost.Text, tbPort.Text, tbUser.Text, 
					tbPass.Text, tbDataBaseName.Text );
				// Making connection with Npgsql provider
				NpgsqlConnection conn = new NpgsqlConnection(connstring);
				conn.Open();
				// quite complex sql statement
				string sql = "SELECT * FROM simple_table";
				// data adapter making request from our connection
				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
				// i always reset DataSet before i do
				// something with it.... i don't know why :-)
				ds.Reset();
				// filling DataSet with result from NpgsqlDataAdapter
				da.Fill(ds);
				// since it C# DataSet can handle multiple tables, we will select first
				dt = ds.Tables[0];
				// connect grid to DataTable
				dataGridView1.DataSource = dt;
				// since we only showing the result we don't need connection anymore
				conn.Close();
			}
			catch (Exception msg)
			{
				// something went wrong, and you wanna know why
				MessageBox.Show(msg.ToString());
				throw;
			}
		}
	}
}

*/