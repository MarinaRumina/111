﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Catalog.Models
{
	public class Product
	{
		public int ID { get; set; }
		public string ProductName { get; set; }
		public string ProductDescript { get; set; }
		public decimal ProductPrice { get; set; }
		public string CategoryID { get; set; }

		public Product(int id, string name, string descript, decimal price, string categoryID)
		{
			ID = id;
			ProductName = name;
			ProductDescript = descript;
			ProductPrice = price;
			CategoryID = categoryID;
		}
	}

}