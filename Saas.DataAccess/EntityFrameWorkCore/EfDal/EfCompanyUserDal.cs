using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.DataAccess.EntityFrameWorkCore.EfDal
{
    public class EfCompanyUserDal :EfEntityRepositoryBase<CompanyUser,GordionDbContext>, ICompanyUserDal
    {
        //public List<CompanyOperationClaim> GetClaims(CompanyUser user)
        //{
        //    using var context = new FirstStepContext();
        //    var result = from operationClaim in context.CompanyOperationClaim
        //        join userOperationClaim in context.CompanyUserOperationClaim
        //            on operationClaim.Id equals userOperationClaim.OperationClaimId
        //        where userOperationClaim.UserId == user.Id
        //        select new CompanyOperationClaim { Id = operationClaim.Id,Name = operationClaim.Name };
        //    return result.ToList();
        //}
    }
}
