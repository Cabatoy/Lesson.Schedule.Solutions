
using System.Collections.Generic;

using Saas.Core.Utilities.Results;
using Saas.Entities.Models;

namespace Saas.Business.Abstract
{
    public interface ICompanyBranchesService
    {
        
        IDataResult<List<CompanyBranch>> CompanyBranchesList();
        IDataResult<CompanyBranch> CompanyBranchById(int userId);
        
        IResult Add(CompanyBranch companyBranch);
        IResult Delete(CompanyBranch companyBranch);
        IResult Update(CompanyBranch companyBranch);
    }
}
