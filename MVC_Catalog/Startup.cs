using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Catalog.Startup))]
namespace MVC_Catalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
