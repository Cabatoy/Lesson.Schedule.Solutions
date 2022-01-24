using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.DataAccess.EntityFrameWorkCore.IDal
{
    public interface ICompanyUserBranchesDal :IEntityRepository<CompanyUserBranches>, IEntityRepositoryAsync<CompanyUserBranches>
    {
    }
}
