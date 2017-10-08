using Empower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Empower.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {

        private Users users;
        private string username;

        public UsersController()
        {
            users = new Users();
        }

        //
        // GET: /Users/
        [Route("")]
        public IHttpActionResult Get()
        {
            List<MyUser> allusers = new List<MyUser>();
            allusers = users.getUsers();
            return Ok(allusers);
        }

        // POST: /Users/Delete/5
        [HttpGet, ActionName("Delete")]
        public async Task<IHttpActionResult> delete(string id)
        {
            bool x = await users.deleteUser(id);

            return Ok();
        }
	}
}