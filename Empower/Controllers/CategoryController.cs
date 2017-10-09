using Empower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Empower.DTO;
using Newtonsoft.Json;

namespace Empower.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var result = categoryRepository.getAll();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var result = categoryRepository.get(id);
            return Ok(result);
        }

        // POST api/<controller>
        public IHttpActionResult Post(CategoryDTO dto)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            return Ok(categoryRepository.add(dto));
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