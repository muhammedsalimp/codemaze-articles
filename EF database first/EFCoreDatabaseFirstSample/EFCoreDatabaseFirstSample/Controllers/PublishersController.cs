using System.Collections.Generic;
using EFCoreDatabaseFirstSample.Models;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDatabaseFirstSample.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IDataRepository<Publisher, PublisherDTO> _dataRepository;

        public PublishersController(IDataRepository<Publisher, PublisherDTO> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Publisher publisher = _dataRepository.GetEntity(id);
            if (publisher == null)
            {
                return NotFound("The Publisher record couldn't be found.");
            }

            _dataRepository.Delete(publisher);
            return NoContent();
        }
    }
}
