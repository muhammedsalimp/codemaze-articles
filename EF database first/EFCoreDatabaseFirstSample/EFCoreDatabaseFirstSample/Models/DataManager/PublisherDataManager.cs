using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class PublisherDataManager : IDataRepository<Publisher, PublisherDTO>
    {
        public IEnumerable<PublisherDTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public PublisherDTO Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public Publisher GetEntity(long id)
        {
            Publisher publisher;
            using (var context = new BooksContext())
            {
                publisher = context.Publisher
                    .Include(a => a.Books)
                    .Single(b => b.Id == id);
            }

            return publisher;
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
            using (var context = new BooksContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
