using System.Collections.Generic;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDatabaseFirstSample.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IDataRepository<BookDTO> _dataRepository;

        public BooksController(IDataRepository<BookDTO> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BookDTO book = _dataRepository.Get(id);
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Books/5
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
