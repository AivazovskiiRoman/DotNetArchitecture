using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Solution.CrossCutting.AspNetCore.Attributes;
using Solution.CrossCutting.AspNetCore.Extensions;
using Solution.Model.Models;

namespace Solution.Web.UserInterface.Controllers
{
    [ApiController]
    [RouteController]
    public class UploadController : ControllerBase
    {
        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        private IHostingEnvironment HostingEnvironment { get; }

        [DisableRequestSizeLimit]
        [HttpPost]
        public IEnumerable<FileModel> Upload()
        {
            return Request.Upload(Path.Combine(HostingEnvironment.ContentRootPath, nameof(Upload)));
        }
    }
}
