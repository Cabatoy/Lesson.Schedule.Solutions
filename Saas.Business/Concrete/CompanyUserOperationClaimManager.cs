using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Business.Abstract;
using Saas.Business.Constants;
using Saas.Core.Utilities.Results;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Models.UserClaims;

namespace Saas.Business.Concrete
{
    public class CompanyOperationUserClaimManager :ICompanyOperationUserClaimService
    {
        private ICompanyOperationUserClaimDal _UserOperationClaim;

        public CompanyOperationUserClaimManager(ICompanyOperationUserClaimDal UserOperationClaim)
        {
            _UserOperationClaim = UserOperationClaim;
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

        public IDataResult<List<CompanyOperationUserClaim>> GetList()
        {
            return new DataResult<List<CompanyOperationUserClaim>>(_UserOperationClaim.GetList(),true);
        }

        public IResult Update(CompanyOperationUserClaim roles)
        {
            _UserOperationClaim.Update(roles);
            return new DataResult<CompanyOperationUserClaim>(Messages.rolesUpdated);
        }
    }
}
