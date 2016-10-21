using System;
using System.Collections.Generic;
using System.Linq;


namespace MVC_Catalog.Models
{
	public class Products
	{

		public List<Product> ProductsList { get; set; }

		public Products()
		{
			ProductsList = new List<Product>();

			this.FillProductsList();
		}

		public Products(string id)
		{
			ProductsList = new List<Product>();

			this.FillProductsList(id);
		}

		public List<Product> FillProductsList()
		{
			// Openning connection to DB
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
			conn.ConnectionString = @"Data Source = MARINA-W-PC\SQLEXPRESS; Initial Catalog = Catalog_MVC_DB; User ID = sa; Password = 0525952710;";
			
			//not working: exception object not set to an instance
			//string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DB_Connection"].ToString();
			//conn.ConnectionString = connString;

			conn.Open();

			System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
			command.CommandType = System.Data.CommandType.Text;
			command.Connection = conn;

			// read data
			command.CommandText = "select * from [dbo].[PRODUCTSLIST]";
			System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					ProductsList.Add(new Models.Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetString(4)));
				}
			}
			//else
			//{
			//	Console.WriteLine("No rows found.");
			//}
			reader.Close();

			conn.Close();

			return ProductsList;
		}

		public List<Product> FillProductsList(string category)
		{
			// Openning connection to DB
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

			conn.ConnectionString = @"Data Source = MARINA-W-PC\SQLEXPRESS; Initial Catalog = Catalog_MVC_DB; User ID = sa; Password = 0525952710;";
			conn.Open();

			System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
			command.CommandType = System.Data.CommandType.Text;
			command.Connection = conn;
			System.Data.SqlClient.SqlDataReader reader;
			// read data
			if (category == null)
			{
				command.CommandText = "select * from [dbo].[PRODUCTSLIST]";
				reader = command.ExecuteReader();
			}
			else
			{
				command.CommandText = "select * from [dbo].[PRODUCTSLIST] where [CategoryID] = '" + category + "';";
				reader = command.ExecuteReader();
			}
			
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					ProductsList.Add(new Models.Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetString(4)));
				}
			}
			//else
			//{
			//	Console.WriteLine("No rows found.");
			//}
			reader.Close();

			conn.Close();

			return ProductsList;
		}
	}

}