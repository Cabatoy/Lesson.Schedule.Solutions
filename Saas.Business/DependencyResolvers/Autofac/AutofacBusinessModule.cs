using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Distributed;
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
            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<CompanyBranchesManager>().As<ICompanyBranchesService>();
            builder.RegisterType<EfCompanyBranchDal>().As<ICompanyBranchDal>();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfCompanyOperationClaimDal>().As<ICompanyOperationClaimDal>();

            builder.RegisterType<CompanyOperationUserClaimManager>().As<ICompanyOperationUserClaimService>();
            builder.RegisterType<EfCompanyOperationUserClaimDal>().As<ICompanyOperationUserClaimDal>();

            builder.RegisterType<CompanyUsersManager>().As<ICompanyUserService>();
            builder.RegisterType<EfCompanyUserDal>().As<ICompanyUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<CompanyUserBranchesManager>().As<ICompanyUserBranchesService>();
            builder.RegisterType<EfCompanyUserBranchesDal>().As<ICompanyUserBranchesDal>();





            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()

            }).SingleInstance();


        }
    }
}
