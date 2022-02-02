﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Saas.Core.Security.Security.Jwt
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims,string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email,value: email));
        }
        public static void AddName(this ICollection<Claim> claims,string name)
        {
            claims.Add(new Claim(ClaimTypes.Name,value: name));
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims,string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier,value: nameIdentifier));
        }

        public static void AddUserOperationClaim(this ICollection<Claim> claims,string[] userOperationClaim)
        {
            userOperationClaim.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role,value: role)));
        }
    }
}
