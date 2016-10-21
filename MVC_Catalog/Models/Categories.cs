using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_Catalog.Models
{
	public class Categories
	{
		public List<Category> CategoriesList { get; set; }

		public Categories()
		{
			CategoriesList = new List<Category>();

			this.FillCategories();
		}

		public List<Category> FillCategories()
		{
			// Openning connection to DB
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

			conn.ConnectionString = @"Data Source = MARINA-W-PC\SQLEXPRESS; Initial Catalog = Catalog_MVC_DB; User ID = sa; Password = 0525952710;";
			conn.Open();

			System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();//insert, update, delete
			command.CommandType = System.Data.CommandType.Text;
			command.Connection = conn;

			// read data
			command.CommandText = "select * from [dbo].[CATEGORIES]";
			System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();//one row
																				 //loop data

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					CategoriesList.Add(new Models.Category(reader.GetInt32(0), reader.GetString(1)));
				}
			}
			//else
			//{
			//	Console.WriteLine("No rows found.");
			//}
			reader.Close();

			conn.Close();

			#region Reading from CSV to an array
			//string[] arr_Categoies = System.IO.File.ReadAllLines(@"D:\Learning\MSDN_course\HomeWork\MVC\MVC_Catalog\MVC_Catalog\DA\Categories.txt");

			//foreach (string s in arr_Categoies)
			//{
			//	if (s != string.Empty)
			//	{
			//		CategoriesList.Add(new Models.Category(CategoriesList.Count(), s));
			//	}
			//} 
			#endregion

			return CategoriesList;
		}
	}

}