using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_Catalog.DA	
{
	public class StartupDB_Load
	{
		public static void LoadCategories()
		{
			// Reading data from TXT
			string[] arr_Categoies = System.IO.File.ReadAllLines(@"D:\Learning\MSDN_course\HomeWork\MVC\MVC_Catalog\MVC_Catalog\DA\Categories.txt");
			//string[] arr_Categoies = System.IO.File.ReadAllLines(System.Configuration.ConfigurationManager.AppSettings["CATEGORIES"]); - not working

			// Openning connection to DB
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
			
			conn.ConnectionString = @"Data Source = MARINA-W-PC\SQLEXPRESS; Initial Catalog = Catalog_MVC_DB; User ID = sa; Password = 0525952710;";
			conn.Open();

			System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();//insert, update, delete
			command.CommandType = System.Data.CommandType.Text;
			command.Connection = conn;

			// Cleanning DB
			//command.CommandText = @"DELETE FROM [dbo].[Categories]"; // cleans all fields but not an Ids
			command.CommandText = @"TRUNCATE TABLE [dbo].[Categories]"; //cleans all fields including Ids
			command.ExecuteNonQuery();

			// Filling DB from an arr_Categories
			foreach (string s in arr_Categoies)
			{
				if (s != string.Empty)
				{
					command.CommandText = @"INSERT INTO[dbo].[Categories] ([CategoryName])VALUES('" + s + "')";
					command.ExecuteNonQuery();
				}
			}
			conn.Close();

			#region USING - not working - the connection is closed...
			//using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
			//{
			//	conn.ConnectionString = @"Data Source = MARINA-W-PC\SQLEXPRESS; Initial Catalog = Catalog_MVC_DB; User ID = sa; Password = 0525952710;";
			//	System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();//insert, update, delete
			//	command.CommandType = System.Data.CommandType.Text;
			//	command.Connection = conn;

			//	command.CommandText = @"DELETE FROM [dbo].[Categories]";

			//	//not working - the connection is closed...
			//	command.ExecuteNonQuery();

			//	foreach (string s in arr_Categoies)
			//	{
			//		if (s != string.Empty)
			//		{
			//			command.CommandText = @"INSERT INTO[dbo].[Categories] ([CategoryName])VALUES('" + s + "')";
			//			command.ExecuteNonQuery();
			//		}
			//	}
			//} 
			#endregion

		}

		public static void LoadProducts()
		{
			// Reading data from CSV
			string[] arr_Products = System.IO.File.ReadAllLines(@"D:\Learning\MSDN_course\HomeWork\MVC\MVC_Catalog\MVC_Catalog\DA\Products.csv");


			// Openning connection to DB
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

			conn.ConnectionString = @"Data Source = MARINA-W-PC\SQLEXPRESS; Initial Catalog = Catalog_MVC_DB; User ID = sa; Password = 0525952710;";
			conn.Open();

			System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
			command.CommandType = System.Data.CommandType.Text;
			command.Connection = conn;

			// Cleanning DB
			//command.CommandText = @"DELETE FROM [dbo].[ProductsList]"; // cleans all fields but not an Ids
			command.CommandText = @"TRUNCATE TABLE [dbo].[ProductsList]";  //cleans all fields including Ids
			command.ExecuteNonQuery();
			command.ExecuteNonQuery();

			// Filling DB from an arr_Categories
			foreach (string s in arr_Products)
			{
				if (s != string.Empty)
				{
					string[] Record = s.Split(';');
					command.CommandText = @"INSERT INTO[dbo].[ProductsList] 
											([ProductName], [ProductDescript], [ProductPrice], [CategoryID])
											VALUES
											('" + Record[0] + "', '" + Record[1] + "', " + Record[2] + ", '" + Record[3] + "')";
					command.ExecuteNonQuery();
				}
			}

			conn.Close();
		}
	}
}