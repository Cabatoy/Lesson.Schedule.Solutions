﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Saas.Entities.Models;
using Saas.Entities.Models.UserClaims;

namespace Saas.Business.Abstract
{
    public interface ICompanyUserService
    {
        List<CompanyOperationClaim> GetClaims(CompanyUser user);
        IDataResult<List<CompanyUser>> GetUserList();
        IDataResult<CompanyUser> GetUserById(int userId);
        CompanyUser GetByMail(string mail);
        IResult Add(CompanyUser user);
        IResult Delete(CompanyUser user);
        IResult Update(CompanyUser user);

    }
}
