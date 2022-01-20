﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Saas.Entities.Models;

namespace Saas.Business.Abstract
{
    public interface ICompanyService
    {
        Task<IDataResult<List<Company>>> GetCompanyList();
        Task<IDataResult<Company>> GetCompanyById(int CompanyId);
        Task<IResult> Add(Company company);
        Task<IResult> Delete(Company company);
        Task<IResult> Update(Company company);

       
    }
}