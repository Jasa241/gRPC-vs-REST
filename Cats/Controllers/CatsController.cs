using Cats.Models;
using Cats.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        // GET: api/<CatsController>
        [HttpGet]
        public IEnumerable<Cat> Get()
        {
            return CatsUseCase.GetCats();
        }

        // GET api/<CatsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CatsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
