using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Saas.Core.Utilities.Interceptors
{
    public abstract class MethodInterception :MethodInterceptionBaseAttiribute
    {

        protected virtual void OnBefore(IInvocation invocation)
        {


        }

        protected virtual void OnAfter(IInvocation invocation)
        {


        }
        protected virtual void OnException(IInvocation invocation,Exception e)
        {


        }
        protected virtual void OnSuccess(IInvocation invocation)
        {


        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); //operasyonu calistir
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation,e);
                throw;
            }
            finally
            {
                if (isSuccess)
                    OnSuccess(invocation);
            }
            OnAfter(invocation);
        }
       
        private static bool IsAsyncMethod(MethodInfo method)
        {//invocation.Method)
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            );
        }
    }









}
