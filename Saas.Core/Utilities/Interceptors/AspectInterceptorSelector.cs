using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Aspect.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttiribute>(true).ToList();
            var methodAttribute =
                type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttiribute>(true);
            classAttribute.AddRange(methodAttribute);
            classAttribute.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));
            //  classAttribute.Add(new ExceptionLogAspect(typeof(FileLogger)));
            return classAttribute.OrderBy(x => x.Priority).ToArray();
        }
    }
}
