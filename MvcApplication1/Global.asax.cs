using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using MvcApplication1.Interface;


namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Basket>().As<IBasket>();
            containerBuilder.RegisterType<Checkout>().As<ICheckout>();

            IContainer container = containerBuilder.Build();
            container.Resolve<ICheckout>();
            container.Resolve<IBasket>();


            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}