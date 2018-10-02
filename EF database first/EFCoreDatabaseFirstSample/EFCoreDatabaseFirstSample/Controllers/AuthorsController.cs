using System.Collections.Generic;
using EFCoreDatabaseFirstSample.Models;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDatabaseFirstSample.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IDataRepository<Author> _dataRepository;

        public AuthorsController(IDataRepository<Author> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult Get()

        {
            IEnumerable<Author> authors = _dataRepository.GetAll();
            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Authors
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
