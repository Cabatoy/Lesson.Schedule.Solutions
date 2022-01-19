using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspect.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;
        


        public CacheAspect(int duration = 60)//dakika
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation?.Method?.ReflectedType?.FullName}.{invocation?.Method?.Name}");
            var argument = invocation?.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", argument.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                //invocation.ReturnValue = _cacheManager.Get(key);
                //return;
                if (invocation != null) 
                {
                    invocation.ReturnValue = _cacheManager.Get(key);
                    return;
                }
            }
            //invocation.Proceed();
            //_cacheManager.Add(key, invocation.ReturnValue, _duration);
            if (invocation != null)
            {
                invocation.Proceed();
                _cacheManager.Add(key, invocation.ReturnValue, _duration);
            }
        }

       
    }
}
