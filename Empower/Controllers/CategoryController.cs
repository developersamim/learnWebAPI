using Empower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Empower.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Category> Get()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            return categoryRepository.getAll();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}