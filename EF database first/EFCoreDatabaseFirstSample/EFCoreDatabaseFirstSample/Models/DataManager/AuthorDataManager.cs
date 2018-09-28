using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class AuthorDataManager : IDataRepository<Author>
    {
        public IEnumerable<Author> GetAll()
        {
            List<Author> authors;

            using (var context = new BooksContext())
            {
                authors = context.Author
                   .Include(author => author.AuthorContact)
                   .ToList();
            }

            return authors;
        }

        public Author Get(long id)
        {
            Author author;

            using (var context = new BooksContext())
            {
                author = context.Author
                    .Single(b => b.Id == id);
            }

            return author;
        }

        public void Add(Author entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Author entityToUpdate, Author entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Author entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
