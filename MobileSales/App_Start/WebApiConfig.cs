using Microsoft.Data.Edm;
using MobileSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace MobileSales
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapODataRoute("odata", "odata", GetEdmModel());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=301869.
            config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
        public static IEdmModel GetEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Route>("Routes");
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<OrderDetails>("OrderDetails");
            builder.EntitySet<OrderDetailsDTO>("OrderDetailsDTO");
            builder.EntitySet<Product>("Products");
            builder.EntitySet<ProductType>("ProductTypes");

            builder.Namespace = "MobileSales.Models";
            return builder.GetEdmModel();
        }
    }
}
