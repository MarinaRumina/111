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
		internal static void LoadDataToDB()
		{
			int CategoryId = 0;

			// Reading data from files	
			string[] arr_Products1 = System.IO.File.ReadAllLines(System.Configuration.ConfigurationManager.AppSettings["PRODUCTS_1"]);

			// Openning connection to DB
			System.Data.SqlClient.SqlConnection conn = DA.DataAccess.OpenConnection();
			System.Data.SqlClient.SqlCommand command = DA.DataAccess.getCommand(conn);

			// Cleanning DB Tables
			DA.DataAccess.CleanDB(command, "[dbo].[Categories]");
			DA.DataAccess.CleanDB(command, "[dbo].[ProductsList1]");
			
			// Filling DB from an arr_Products1
			foreach (string s in arr_Products1)
			{
				if (s != string.Empty)
				{
					// Splitting record line to fields
					string[] Record = s.Split(';');

					string categoryName = Record[3];
					string categoryURL = categoryName.Replace(" ", "");
					
					CategoryId = GetCategoryId(command, categoryName);

					// Checking Categories Table for existance of Category Name and receiving Id of the category if exists 
								
					if (CategoryId == 0) // First record in Categories Table or Category doesn't exist
					{
						SqlDataAdapter adapter = new SqlDataAdapter();
						adapter.InsertCommand = new SqlCommand("INSERT INTO [dbo].[Categories]([CategoryName])VALUES('" + categoryName + "'); SELECT id FROM [dbo].[Categories] WHERE id = SCOPE_IDENTITY();", conn);

						SqlDataReader reader = adapter.InsertCommand.ExecuteReader();

						while(reader.Read())
						{
							CategoryId = Convert.ToInt32(reader["id"]);
						}

						reader.Close();						
					}
					
					// Adding Product to Products Table
					command.CommandText = @"INSERT INTO [dbo].[ProductsList1] 
											([ProductName], [ProductDescript], [ProductPrice], [CategoryID], [CategoryURL])
											VALUES
											('" + Record[0] + "', '" + Record[1] + "', '" + Record[2] + "', '" + CategoryId + "', '" + categoryURL + "')";

					command.ExecuteNonQuery();
				}
			}

			conn.Close();
		}

		private static int GetCategoryId(SqlCommand command, string categoryName)
		{
			int id = 0;
			string sql = @"SELECT [id] FROM [dbo].[Categories] WHERE [CategoryName] = '" + categoryName + "';";

			SqlDataAdapter adapter = new SqlDataAdapter(sql, command.Connection);
			SqlDataReader reader = adapter.SelectCommand.ExecuteReader(); 
			while (reader.Read())
			{
				id = Convert.ToInt32(reader["id"].ToString());
			}
			reader.Close();

			return id;
		}	
	}
}