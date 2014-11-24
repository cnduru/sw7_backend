﻿using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;


namespace Engine
{
	public static class DBController
	{
		private static DataSet ds = new DataSet();
		private static DataTable dt = new DataTable();

		private static string dbHost = "localhost";
		private static string dbName = "cornfielddb";
		private static string dbUser = "cornfield";
		private static string dbPass = "cornfield";

		public static List<Game> getGames(int accountID)
		{
			string connstring = String.Format (
				                    "Server={0};User Id={1};Password={2};Database={3};", 
				                    dbHost, dbUser, dbPass, dbName);
			NpgsqlConnection conn = new NpgsqlConnection(connstring);
			conn.Open();
			string sql = String.Format (@"SELECT game.* FROM player, game
                           WHERE game.id = player.game_id AND player.owner = {0};", accountID);

			NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
			ds.Reset();
			da.Fill(ds);
			dt = ds.Tables[0];
			foreach (DataRow row in dt.Rows)
			{
				Console.WriteLine(row.Field<int>(0));
			}

			conn.Close();
			return null;
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