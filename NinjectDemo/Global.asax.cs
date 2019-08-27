using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using NinjectDemo.Controllers;
using NinjectDemo.Models;

namespace NinjectDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<HomeController>().InstancePerDependency();

            builder.RegisterType<MinimumDiscountHelper>().As<IDiscountHelper>();
            builder.RegisterType<LinqValueCalculator>().As<IValueCalculator>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
