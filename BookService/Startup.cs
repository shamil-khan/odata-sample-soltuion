using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

using BookService.Models;
using Owin;
using Microsoft.OData.Edm;

namespace BookService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Set up server configuration
            var config = new HttpConfiguration();
            config.MapODataServiceRoute(routeName: "BookService", routePrefix: "", model: GetEdmModel());
            appBuilder.UseWebApi(config);
        }

        private IEdmModel GetEdmModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntityType<Comment>();
            modelBuilder.EntitySet<Author>("Authors");
            modelBuilder.EntitySet<Book>("Books");
            return modelBuilder.GetEdmModel();
        }
    }
}
