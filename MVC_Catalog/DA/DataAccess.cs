using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Catalog.DA
{
	public class DataAccess
	{
		internal static SqlConnection OpenConnection()
		{
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
			conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
			conn.Open();

			return conn;
		}

		internal static SqlCommand getCommand(SqlConnection conn)
		{
			System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();//insert, update, delete
			command.CommandType = System.Data.CommandType.Text;
			command.Connection = conn;

			return command;
		}

		internal static void CleanDB(SqlCommand command, string v)
		{
			command.CommandText = @"TRUNCATE TABLE " + v; //cleans all fields including Ids
			command.ExecuteNonQuery();
		}
	}
}