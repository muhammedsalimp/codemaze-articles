using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class PublisherDataManager : IDataRepository<Publisher>
    {
        public IEnumerable<Publisher> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Publisher Get(long id)
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
            using (var context = new BooksContext())
            {
                var publisher = context.Publishers
                    .Include(b => b.Books)
                    .Single(publisher1 => publisher1.Name.Equals("Simon & Schuster"));

                context.Remove(publisher);
            }
        }
    }
}
