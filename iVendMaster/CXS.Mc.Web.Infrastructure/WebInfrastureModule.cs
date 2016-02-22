using Autofac;
using CXS.Mc.Web.Infrastructure.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CXS.Mc.Web.Infrastructure
{
    public class WebInfrastureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PagesService>()
                .As<IPagesService>()
                .SingleInstance();
        }
    }
}
