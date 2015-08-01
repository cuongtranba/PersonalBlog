using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DAL
{
    public class IocConfig: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new BlogContext()).As<DbContext>().InstancePerRequest();
        }
    }
}
