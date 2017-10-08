using Empower.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Empower.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/roles")]
    public class RolesController : ApiController
    {
        private RolesRepository _roles;

        
        public RolesController()
        {
            _roles = new RolesRepository();
        }

        public IEnumerable<IdentityRole> Get()
        {
            return _roles.getListRole();
        }

        // POST: /Roles/Create
        [Route("create")]
        [HttpGet]
        public async Task<IHttpActionResult> Create(string name)
        {
            IdentityResult result = await _roles.Create(name);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}