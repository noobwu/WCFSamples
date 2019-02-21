using System.Web.Mvc;
using System.Web.Routing;
using Artech.VideoMall.Common.Extensions;
using System.Reflection;
namespace Artech.VideoMall
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{id}", 
                new { controller = "Products", action = "Index", id = UrlParameter.Optional } 
            );
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


            ControllerBuilder.Current.SetControllerFactory(new ServiceLocatableControllerFactory());
            ExtendedController.RegisterExceptionPolicy("WebUI");
        }
    }
}