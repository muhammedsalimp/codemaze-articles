using System.Collections.Generic;
using EFCoreDatabaseFirstSample.Models;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDatabaseFirstSample.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IDataRepository<Book, BookDTO> _dataRepository;

        public BooksController(IDataRepository<Book, BookDTO> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BookDTO book = _dataRepository.Get(id);
            return Ok(book);
        }

    }
}
