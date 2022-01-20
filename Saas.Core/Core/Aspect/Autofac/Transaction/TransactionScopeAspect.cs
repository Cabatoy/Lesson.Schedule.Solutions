using System;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspect.Autfac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            TransactionScope transactionScope = new TransactionScope();
            try
            {
                invocation.Proceed();
                transactionScope.Complete();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                transactionScope.Dispose();
            }
        }
    }
}
