using System.Threading.Tasks;
using Core.Utilities.Results;
using Saas.Core.Security.Security.Security.Jwt;

using Saas.Entities.Dto;
using Saas.Entities.Models;




namespace Saas.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<CompanyUser> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<CompanyUser> Login(UserForLoginDto userForLoginDto);

        IResult RegisterForCompany(UserForRegisterDto userForRegisterDto);
        IResult UserExist(string Email);
        IDataResult<AccessToken> CreateAccessToken(CompanyUser user);

    }
}
