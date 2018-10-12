using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class AuthorDataManager : IDataRepository<Author, AuthorDTO>
    {
        readonly BooksContext _booksContext;

        public AuthorDataManager(BooksContext context)
        {
            _booksContext = context;
        }

        public IEnumerable<Author> GetAll()
        {
            _booksContext.ChangeTracker.LazyLoadingEnabled = false;

            return _booksContext.Author
                .Include(author => author.AuthorContact)
                .ToList();
        }

        public AuthorDTO GetWithContact(long id)
        {
            Author author = Get(id);
            if (author == null)
            {
                return null;
            }

            return AuthorDTOMapper.MapToDTO(author);
        }

        public Author Get(long id)
        {
            Author author = _booksContext.Author
                .SingleOrDefault(b => b.Id == id);

            return author;
        }

        public AuthorDTO GetDTO(long id)
        {
            using (var context = new BooksContext())
            {
                Author author = context.Author
                    .SingleOrDefault(b => b.Id == id);

                return AuthorDTOMapper.MapToDTO(author);
            }
        }


        public void Add(Author entity)
        {
            _booksContext.Author.Add(entity);
            _booksContext.SaveChanges();
        }

        public void Update(Author entityToUpdate, Author entity)
        {
            entityToUpdate = _booksContext.Author
                .Include(a => a.BookAuthors)
                .Include(a=> a.AuthorContact)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            entityToUpdate.AuthorContact.Address = entity.AuthorContact.Address;
            entityToUpdate.AuthorContact.ContactNumber = entity.AuthorContact.ContactNumber;

            List<BookAuthors> deletedBooks = entityToUpdate.BookAuthors.Except(entity.BookAuthors).ToList();
            List<BookAuthors> addedBooks = entity.BookAuthors.Except(entityToUpdate.BookAuthors).ToList();

            deletedBooks.ForEach(bookToDelete =>
                entityToUpdate.BookAuthors.Remove(
                    entityToUpdate.BookAuthors
                        .First(b => b.BookId == bookToDelete.BookId)));

            foreach (BookAuthors addedBook in addedBooks)
            {
                _booksContext.Entry(addedBook).State = EntityState.Added;
            }

            _booksContext.SaveChanges();
        }

        public void Delete(Author entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
