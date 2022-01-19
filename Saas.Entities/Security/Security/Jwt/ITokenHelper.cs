

using Saas.Entities.Models;
using Saas.Entities.Models.UserClaims;
using System;
using System.Collections.Generic;


namespace Saas.Entities.Security.Security.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(CompanyUser user, List<CompanyOperationClaim> roles);
    }
}
