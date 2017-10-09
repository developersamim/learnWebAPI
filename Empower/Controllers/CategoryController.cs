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
            return Ok(result);
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
        public IHttpActionResult Put(int id, [FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.id)
            {
                return BadRequest();
            }
            CategoryRepository categoryRepository = new CategoryRepository();
            if (!categoryRepository.keyExists(id))
            {
                return NotFound();
            }
            if(categoryRepository.update(id, category))
                return Ok();
            else
                return Content(HttpStatusCode.BadRequest, "Unexpected Error!");
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            if (!categoryRepository.keyExists(id))
            {
                return NotFound();
            }
            if (categoryRepository.delete(id))
                return Ok();
            else
                return Content(HttpStatusCode.BadRequest, "Unexpected Error!");
        }
    }
}