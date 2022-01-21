using System.Threading.Tasks;
using Saas.Core.Security.Security.Jwt;
using Saas.Core.Utilities.Results;
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
