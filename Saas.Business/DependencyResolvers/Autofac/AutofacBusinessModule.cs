using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Saas.Business.Abstract;
using Saas.Business.Concrete;
using Saas.Core.Security.Security.Jwt;
using Saas.Core.Utilities.Interceptors;
using Saas.DataAccess.EntityFrameWorkCore.EfDal;
using Saas.DataAccess.EntityFrameWorkCore.IDal;

namespace Saas.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region firma-sube-lisans 

            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            //      builder.RegisterType<CompanyBranchManager>().As<ICompanyBranchService>();
            builder.RegisterType<EfCompanyBranchDal>().As<ICompanyBranchDal>();

            #endregion

            #region Kullanici

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfCompanyOperationClaimDal>().As<ICompanyOperationClaimDal>();

            builder.RegisterType<CompanyOperationUserClaimManager>().As<ICompanyOperationUserClaimService>();
            builder.RegisterType<EfCompanyOperationUserClaimDal>().As<ICompanyOperationUserClaimDal>();

            builder.RegisterType<CompanyUsersManager>().As<ICompanyUserService>();
            builder.RegisterType<EfCompanyUserDal>().As<ICompanyUserDal>();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();



            #endregion




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()

            }).SingleInstance();


        }
    }
}
