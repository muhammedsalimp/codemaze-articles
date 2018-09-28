using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.Repository;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class BookDataManager : IDataRepository<Book>

    {
        public IEnumerable<Book> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Book Get(long id)
        {
            Book book;

            using (var context = new BooksContext())
            {
                book = context.Books
                   .Single(b => b.Id == id);

                context.Entry(book)
                    .Collection(b => b.BookAuthors)
                    .Load();

                context.Entry(book)
                    .Reference(b => b.Publisher)
                    .Load();
            }

            return book;
        }

        public void Add(Book entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Book entityToUpdate, Book entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Book entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
