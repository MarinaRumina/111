using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Catalog.Models
{
	public class Category
	{
		public int ID { get; set; }
		public string CategoryName { get; set; }

	   
		public Category(int id, string categoryName)
		{
			ID = id;
			CategoryName = categoryName;
		}

		public Category(){	}

	}   
	
}