using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class BookDataManager : IDataRepository<Book, BookDTO>
    {
        readonly BooksContext _booksContext;

        public BookDataManager(BooksContext context)
        {
            _booksContext = context;
        }

        public IEnumerable<Book> GetAll()
        {
            throw new System.NotImplementedException();
        }
        
        public Book Get(long id)
        {
            _booksContext.ChangeTracker.LazyLoadingEnabled = false;

            Book book = _booksContext.Book
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            _booksContext.Entry(book)
                .Collection(b => b.BookAuthors)
                .Load();

            _booksContext.Entry(book)
                .Reference(b => b.Publisher)
                .Load();
            
            return book;
        }

        public BookDTO GetDTO(long id)
        {
            throw new System.NotImplementedException();
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
