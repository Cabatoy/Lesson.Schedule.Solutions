using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Generic;
using Saas.Entities.Models;
using Saas.Entities.Models.UserClaims;

namespace Saas.DataAccess.EntityFrameWorkCore.EfDal
{
    public class EfCompanyUserDal :EfEntityRepositoryBase<CompanyUser,GordionDbContext>, ICompanyUserDal
    {
        public List<CompanyOperationClaim> GetClaims(CompanyUser user)
        {
            using var context = new GordionDbContext();
            var result = from operationClaim in context.CompanyOperationClaim
                         join companyOperationUserClaim in context.CompanyOperationUserClaim
                         on operationClaim.Id equals companyOperationUserClaim.CompanyOperationClaimId
                         where companyOperationUserClaim.CompanyUserId == user.Id
                         select new CompanyOperationClaim { Id = operationClaim.Id,Name = operationClaim.Name };
            return result.ToList();
            // return new List<CompanyOperationClaim>();
        }
    }
}
