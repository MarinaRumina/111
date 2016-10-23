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

		public List<Product> FillProductsList(string category = null)
		{
			// Openning connection to DB
			System.Data.SqlClient.SqlConnection conn = DA.DataAccess.OpenConnection();
			System.Data.SqlClient.SqlCommand command = DA.DataAccess.getCommand(conn);
			
			System.Data.SqlClient.SqlDataReader reader;
			// read data
			if (category == null)
			{
				command.CommandText = "select * from [dbo].[PRODUCTSLIST1]";
				reader = command.ExecuteReader();
			}
			else
			{
				command.CommandText = "select * from [dbo].[PRODUCTSLIST1] where [CategoryURL] = '" + category + "';";
				reader = command.ExecuteReader();
			}
			
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					ProductsList.Add(new Models.Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetString(5)));
				}
			}
			else
			{
				ProductsList.Add(new Models.Product(0, "There is no products you are searching for.", "", 0, 0, ""));
			}
			reader.Close();

			conn.Close();

			return ProductsList;
		}
	}

}