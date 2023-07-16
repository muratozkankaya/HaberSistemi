﻿using Autofac;
using Autofac.Integration.Mvc;
using HaberSistemi.Core.Infrastructure;
using HaberSistemi.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSistemi.admin.Class
{
    public class BootStrapper
    {
        public static void RunConfig()
        {
            BuildAutoFac();
        }
        public static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HaberRepository>().As < IHaberRepository>();
            builder.RegisterType<ResimRepository>().As<IResimRepository>();
            builder.RegisterType<KullaniciRepository>().As<IKullaniciRepository>();
            builder.RegisterType<RolRepository>().As<IRolRepository>(); 
            builder.RegisterType<KategoriRepository>().As<IKategoriRepository>();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}