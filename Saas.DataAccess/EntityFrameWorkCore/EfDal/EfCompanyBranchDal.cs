﻿using Saas.DataAccess.EntityFrameWorkCore.DbContexts;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.DataAccess.EntityFrameWorkCore.EfDal
{
    public class EfCompanyBranchDal :EfEntityRepositoryBase<CompanyBranch,GordionDbContext>, ICompanyBranchDal
    {
    }
}
