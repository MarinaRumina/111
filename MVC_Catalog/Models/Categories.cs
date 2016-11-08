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
			System.Data.SqlClient.SqlConnection conn = DA.DataAccess.OpenConnection();
			System.Data.SqlClient.SqlCommand command = DA.DataAccess.getCommand(conn);

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