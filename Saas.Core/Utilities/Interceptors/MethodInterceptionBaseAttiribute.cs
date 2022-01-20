using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method , AllowMultiple = true, Inherited = true)]
    public class MethodInterceptionBaseAttiribute : Attribute, IInterceptor
    {
        public virtual void Intercept(IInvocation invocation)
        {

        }

        public int Priority { get; set; }

    }
}
