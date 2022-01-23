using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Business.Abstract;
using Saas.Business.Constants;
using Saas.Core.Aspect.Autofac.Caching;
using Saas.Core.Aspect.Autofac.Logging;
using Saas.Core.Aspect.Autofac.Performance;
using Saas.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Saas.Core.Utilities.Results;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Models.UserClaims;

namespace Saas.Business.Concrete
{
    public class CompanyOperationUserClaimManager :ICompanyOperationUserClaimService
    {
        private readonly ICompanyOperationUserClaimDal _UserOperationClaim;

        public CompanyOperationUserClaimManager(ICompanyOperationUserClaimDal userOperationClaim)
        {
            _UserOperationClaim = userOperationClaim;
        }

        public IResult Add(CompanyOperationUserClaim roles)
        {
            _UserOperationClaim.Add(roles);
            return new DataResult<CompanyOperationUserClaim>(Messages.rolesAdded);
        }

        public IResult Delete(CompanyOperationUserClaim roles)
        {
            _UserOperationClaim.Delete(roles);
            return new DataResult<CompanyOperationUserClaim>(Messages.rolesDeleted);
        }

        public IDataResult<List<CompanyOperationUserClaim>> GetByRoleId(int operationClaimId)
        {
            return new DataResult<List<CompanyOperationUserClaim>>(_UserOperationClaim.GetList(p => p.CompanyOperationClaimId == operationClaimId),true);
        }
        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(DatabaseLogger))]
      
        public IDataResult<List<CompanyOperationUserClaim>> GetList()
        {
            return new DataResult<List<CompanyOperationUserClaim>>(_UserOperationClaim.GetList(),true);
        }
        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(DatabaseLogger))]
      
        public IResult Update(CompanyOperationUserClaim roles)
        {
            _UserOperationClaim.Update(roles);
            return new DataResult<CompanyOperationUserClaim>(Messages.rolesUpdated);
        }
    }
}
