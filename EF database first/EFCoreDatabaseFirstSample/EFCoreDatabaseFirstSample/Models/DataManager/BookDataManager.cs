using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class BookDataManager : IDataRepository<Book, BookDTO>

    {
        public IEnumerable<BookDTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public BookDTO Get(long id)
        {
            BookDTO bookDTO;

            using (var context = new BooksContext())
            {
                Book book = context.Book
                   .Single(b => b.Id == id);

                context.Entry(book)
                    .Collection(b => b.BookAuthors)
                    .Load();

                context.Entry(book)
                    .Reference(b => b.Publisher)
                    .Load();

                bookDTO = BookDTOMapper.MapToBookDTO(book);
            }

            return bookDTO;
        }

        public Book GetEntity(long id)
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
