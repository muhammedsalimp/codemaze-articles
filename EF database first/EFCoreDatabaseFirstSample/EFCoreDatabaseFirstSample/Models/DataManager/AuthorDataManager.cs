using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class AuthorDataManager : IDataRepository<Author, AuthorDTO>
    {
        public IEnumerable<AuthorDTO> GetAll()
        {
            using (var context = new BooksContext())
            {
                List<Author> authors = context.Author
                    .Include(author => author.AuthorContact)
                    .ToList();

                List<AuthorDTO> authorDTOs = AuthorDTOMapper.MapToDTOs(authors);
                return authorDTOs;
            }
        }

        public AuthorDTO Get(long id)
        {
            AuthorDTO authorDTO;

            using (var context = new BooksContext())
            {
                Author author = context.Author
                    .SingleOrDefault(b => b.Id == id);

                if (author == null)
                {
                    return null;
                }

                authorDTO = AuthorDTOMapper.MapToDTO(author);
            }

            return authorDTO;
        }

        public Author GetEntity(long id)
        {
            using (var context = new BooksContext())
            {
                Author author = context.Author
                    .Include(a => a.AuthorContact)
                    .Single(b => b.Id == id);

                return author;
            }
        }

        public void Add(Author author)
        {
            using (var context = new BooksContext())
            {
                context.Author.Add(author);
                context.SaveChanges();
            }
        }

        public void Update(Author entityToUpdate, Author entity)
        {
            using (var context = new BooksContext())
            {
                entityToUpdate = context.Author.Include(a => a.BookAuthors).Single(b => b.Id == entityToUpdate.Id);

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
                    context.Entry(addedBook).State = EntityState.Added;
                }

                context.SaveChanges();
            }
        }

        public void Delete(Author entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
