using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Saas.Entities.Models.UserClaims;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<List<CompanyOperationClaim>> GetList();
        IDataResult<CompanyOperationClaim> GetById(int rolesId);
        IResult Add(CompanyOperationClaim roles);
        IResult Delete(CompanyOperationClaim roles);
        IResult Update(CompanyOperationClaim roles);
    }
}
