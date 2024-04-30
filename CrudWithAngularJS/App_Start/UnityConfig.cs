using System.Web.Mvc;
using CrudWithAngularJS.Data;
using CrudWithAngularJS.Repository;
using CrudWithAngularJS.Service;
using Unity;
using Unity.Mvc5;

namespace CrudWithAngularJS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<IDataFactory, DataFactory>();
			container.RegisterType<IProductRepository, ProductRepository>();
			container.RegisterType<IProductService, ProductService>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}