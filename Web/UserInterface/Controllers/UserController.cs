using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.AspNetCore.Attributes;
using Solution.Model.Models;

namespace Solution.Web.UserInterface.Controllers
{
    [ApiController]
    [RouteController]
    public class UserController : ControllerBase
    {
        public UserController(IUserApplication userApplication)
        {
            UserApplication = userApplication;
        }

        private IUserApplication UserApplication { get; }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return UserApplication.List();
        }
    }
}
