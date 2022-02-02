﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Saas.Core.Utilities.Results;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetCompanyList();
        IDataResult<Company> GetCompanyById(int companyId);
        IResult Add(Company company);
        IResult Delete(Company company);
        IResult Update(Company company);

        Task<IDataResult<List<Company>>> GetCompanyListAsync();
        Task<IDataResult<Company>> GetCompanyByIdAsync(int companyId);
        Task<IResult> AddAsync(Company company);
        Task<IResult> DeleteAsync(Company company);
        Task<IResult> UpdateAsync(Company company);

        IDataResult<IDto> SqlHelper(string query);

    }
}
