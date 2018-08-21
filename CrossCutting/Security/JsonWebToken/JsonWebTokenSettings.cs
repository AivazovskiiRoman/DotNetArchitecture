using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Solution.CrossCutting.Security
{
    public static class JsonWebTokenSettings
    {
        public static string Audience => nameof(Audience);

        public static DateTime Expires => DateTime.UtcNow.AddDays(1);

        public static string Issuer => nameof(Issuer);

        public static string Key => PrivateKey ?? (PrivateKey = Guid.NewGuid().ToString());

        public static SecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

        public static SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha512);

        private static string PrivateKey { get; set; }
    }
}
