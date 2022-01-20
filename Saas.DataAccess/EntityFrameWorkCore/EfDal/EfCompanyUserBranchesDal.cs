﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.DataAccess.EntityFrameWorkCore.EfDal
{
    public class EfCompanyUserBranchesDal :EfEntityRepositoryBase<CompanyUserBranches,GordionDbContext>, ICompanyUserBranchesDal
    {
    }
}