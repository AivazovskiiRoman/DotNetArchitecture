using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Solution.CrossCutting.Security
{
    public class JsonWebToken : IJsonWebToken
    {
        public TokenValidationParameters TokenValidationParameters => new TokenValidationParameters
        {
            IssuerSigningKey = JsonWebTokenSettings.SecurityKey,
            ValidateActor = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidAudience = JsonWebTokenSettings.Audience,
            ValidIssuer = JsonWebTokenSettings.Issuer
        };

        public Dictionary<string, object> Decode(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token).Payload;
        }

        public string Encode(string sub, string[] roles)
        {
            var claims = new List<Claim>();
            claims.AddJti();
            claims.AddRoles(roles);
            claims.AddSub(sub);

            return new JwtSecurityTokenHandler().WriteToken(GetJwtSecurityToken(claims));
        }

        private static JwtSecurityToken GetJwtSecurityToken(IEnumerable<Claim> claims)
        {
            return new JwtSecurityToken
            (
                JsonWebTokenSettings.Issuer,
                JsonWebTokenSettings.Audience,
                claims,
                DateTime.UtcNow,
                JsonWebTokenSettings.Expires,
                JsonWebTokenSettings.SigningCredentials
            );
        }
    }
}
