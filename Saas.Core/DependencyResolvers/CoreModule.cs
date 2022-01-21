using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Saas.Core.CrossCuttingConcerns.Caching;
using Saas.Core.CrossCuttingConcerns.Caching.Microsoft;
using Saas.Core.Utilities.IoC;

namespace Saas.Core.DependencyResolvers
{
    public class CoreModule :ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager,MemoryCacheManager>();
            //services.AddSingleton<ICacheManager, RedisCacheManager>();
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
            //services.AddSingleton<>()
        }
    }
}
