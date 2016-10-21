using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Catalog
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
				name: "Product List in Category",
				url: "{controller}/{action}/{category}",
				defaults: new { controller = "Products", action = "List", category = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
