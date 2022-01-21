using System;
using System.Collections.Generic;
using Saas.Core.Utilities.Results;
using Saas.Entities.Models.UserClaims;

namespace Saas.Business.Abstract
{
    public interface ICompanyOperationUserClaimService
    {
        IDataResult<List<CompanyOperationUserClaim>> GetList();
        IDataResult<List<CompanyOperationUserClaim>> GetByRoleId(int rolesId);
        IResult Add(CompanyOperationUserClaim roles);
        IResult Delete(CompanyOperationUserClaim roles);
        IResult Update(CompanyOperationUserClaim roles);
    }
}
