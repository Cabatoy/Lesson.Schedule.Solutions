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

            if (IsAsyncMethod(invocation.Method))
            {
                InterceptAsync(invocation);
            }
            else
            {
                InterceptSync(invocation);
            }
        }
        private void InterceptAsync(IInvocation invocation)
        {
            //Before method execution
          

            //Calling the actual method, but execution has not been finished yet
            invocation.Proceed();

            //We should wait for finishing of the method execution
            ((Task)invocation.ReturnValue)
                .ContinueWith(task =>
                {
                    //After method execution
                   
                    //Logger.InfoFormat(
                    //    "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                    //    invocation.MethodInvocationTarget.Name,
                    //    stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                    //    );
                });
        }

        private void InterceptSync(IInvocation invocation)
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
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            );
        }
    }









}
