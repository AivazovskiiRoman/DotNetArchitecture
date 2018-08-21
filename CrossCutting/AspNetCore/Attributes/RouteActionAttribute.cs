using System;
using Microsoft.AspNetCore.Mvc;

namespace Solution.CrossCutting.AspNetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class RouteActionAttribute : RouteAttribute
    {
        public RouteActionAttribute() : base("[action]")
        {
        }
    }
}
