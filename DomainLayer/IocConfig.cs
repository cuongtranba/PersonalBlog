using System.Linq;
using System.Reflection;
using Autofac;
using DomainLayer.Service;
using Module = Autofac.Module;

namespace DomainLayer
{
    public class IocConfig:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var allServices = Assembly.GetExecutingAssembly().GetTypes().Where(x => typeof(IService<>).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract); //get only concrete  class
            //foreach (var service in allServices)
            //{
            //    var allInterfaces = service.GetInterfaces();
            //    var helperInterface = allInterfaces.Except
            //            (allInterfaces.SelectMany(t => t.GetInterfaces())).First();

            //    if (helperInterface == null)
            //        continue;

            //    builder.RegisterType(service).As(new[] { helperInterface });
            //}

            builder.RegisterModule(new DAL.IocConfig());

            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
