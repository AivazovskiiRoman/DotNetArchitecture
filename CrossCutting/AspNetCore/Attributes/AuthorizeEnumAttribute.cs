using System;
using Microsoft.AspNetCore.Authorization;
using Solution.Model.Enums;

namespace Solution.CrossCutting.AspNetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class AuthorizeEnumAttribute : AuthorizeAttribute
    {
        public AuthorizeEnumAttribute(Roles roles)
        {
            Roles = roles.ToString();
        }
    }
}
