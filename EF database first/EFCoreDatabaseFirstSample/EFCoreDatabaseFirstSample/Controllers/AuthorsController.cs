using System.Collections.Generic;
using EFCoreDatabaseFirstSample.Models;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDatabaseFirstSample.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IDataRepository<Author, AuthorDTO> _dataRepository;

        public AuthorsController(IDataRepository<Author, AuthorDTO> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<AuthorDTO> authors = _dataRepository.GetAll();
            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            AuthorDTO author = _dataRepository.Get(id);
            return Ok(author);
        }

        // POST: api/Authors
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            if (author is null)
            {
                return BadRequest("Author is null.");
            }

            _dataRepository.Add(author);
            return CreatedAtRoute("GetAuthor", new { Id = author.Id }, null);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest("Author is null.");
            }

            Author authorToUpdate = _dataRepository.GetEntity(id);
            if (authorToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Update(authorToUpdate, author);
            return NoContent();
        }
    }
}
