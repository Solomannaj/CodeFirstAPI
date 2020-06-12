using CodeFirstAPI.Classes;
using CodeFirstAPI.Interfaces;
using CodeFirstEntity.Classes;
using CodeFirstEntity.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;


namespace CodeFirstAPI
{
    public static class WebApiConfig
    {
        public static Container _Container {get;set;}
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            _Container = InitializeDependancyContainer();
        }

        public static Container InitializeDependancyContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            RegisterDependencies(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }

        private static void RegisterDependencies(Container container)
        {
            SqlConnection con = new SqlConnection(@"Data Source=B283LCOK\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True");
            EmployeeDL empdl = new EmployeeDL(con);
            container.Register<IEmployeeBL, EmployeeBL>(Lifestyle.Scoped);
            container.Register<IEmployeeDL> (() => new EmployeeDL(con), Lifestyle.Scoped);
        }
    }
}
