using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Core.Utilities.Results;
using Saas.Entities.Models;

namespace Saas.Business.Abstract
{
    public interface ICompanyUserBranchesService
    {
        Task<IDataResult<List<CompanyUserBranches>>> GetCompanyUserBranchesList();
        Task<IDataResult<CompanyUserBranches>> GetCompanyUserBranchesById(int companyId);
        Task<IResult> Add(CompanyUserBranches company);
        Task<IResult> Delete(CompanyUserBranches company);
        Task<IResult> Update(CompanyUserBranches company);
    }
}
