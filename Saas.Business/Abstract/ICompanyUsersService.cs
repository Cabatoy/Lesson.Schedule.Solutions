using System.Collections.Generic;
using Saas.Core.Utilities.Results;
using Saas.Entities.Generic;
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

        IDataResult<IDto> SqlHelper(string query);

    }
}
