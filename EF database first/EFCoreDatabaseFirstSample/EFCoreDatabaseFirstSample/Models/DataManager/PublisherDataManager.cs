using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class PublisherDataManager : IDataRepository<Publisher, PublisherDTO>
    {
        readonly BooksContext _booksContext;

        public PublisherDataManager(BooksContext context)
        {
            _booksContext = context;
        }

        public IEnumerable<Publisher> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Publisher Get(long id)
        {
            return _booksContext.Publisher
                .Include(a => a.Books)
                .Single(b => b.Id == id);
        }

        public PublisherDTO GetDTO(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Publisher entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Publisher entityToUpdate, Publisher entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Publisher entity)
        {
            _booksContext.Remove(entity);
            _booksContext.SaveChanges();
        }
    }
}
