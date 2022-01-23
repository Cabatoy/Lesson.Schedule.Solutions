﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Saas.Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //.net coreun tum servislerini cagirabiliriz.
        public static IServiceProvider ServiceProvider {get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }



    }
}
