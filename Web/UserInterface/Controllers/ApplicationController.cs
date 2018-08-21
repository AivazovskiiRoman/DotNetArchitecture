using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.CrossCutting.AspNetCore.Attributes;
using Solution.Model.Models;

namespace Solution.Web.UserInterface.Controllers
{
    [ApiController]
    [RouteController]
    public class ApplicationController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public ApplicationModel Get()
        {
            return new ApplicationModel();
        }
    }
}
