using System.Collections.Generic;
using System.Linq;
using EFCoreDatabaseFirstSample.Models.DTO;
using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstSample.Models.DataManager
{
    public class AuthorDataManager : IDataRepository<AuthorDTO>
    {
        public IEnumerable<AuthorDTO> GetAll()
        {
            List<AuthorDTO> authorDTOs;

            using (var context = new BooksContext())
            {
                var authors = context.Author
                    .Include(author => author.AuthorContact)
                    .ToList();

                authorDTOs = AuthorDTOMapper.MapToDTOs(authors);
            }

            return authorDTOs;
        }

        public AuthorDTO Get(long id)
        {
            AuthorDTO authorDTO;

            using (var context = new BooksContext())
            {
                var author = context.Author
                    .Single(b => b.Id == id);

                authorDTO = AuthorDTOMapper.MapToDTO(author);
            }

            return authorDTO;
        }

        public void Add(AuthorDTO entity)
        {
            using (var context = new BooksContext())
            {
                Author author = new Author
                {
                    Name = "William Shakespeare",
                    AuthorContact = new AuthorContact()
                    {
                        Address = "Henley St, Stratford-upon-Avon CV37 6QW, UK",
                        ContactNumber = "666-777-8888"
                    }
                };

                context.Author.Add(author);
                context.SaveChanges();
            }
        }

        public void Update(AuthorDTO entityToUpdate, AuthorDTO entity)
        {
            using (var context = new BooksContext())
            {
                var authorToUpdate = context.Author.Single(author => author.Name.Equals("William Shakespeare"));

                authorToUpdate.BookAuthors = new List<BookAuthors>()
                {
                    new BookAuthors()
                    {
                        Book = new Book()
                        {
                            Title = "Hamlet",
                            Category = new BookCategory()
                            {
                                Name = "Tragedy"
                            },
                            Publisher = new Publisher()
                            {
                                Name = "Simon & Schuster"
                            }
                        }
                    },
                    new BookAuthors()
                    {
                        Book = new Book()
                        {
                            Title = "Romeo and Juliet",
                            Category = new BookCategory()
                            {
                                Name = "Romance"
                            },
                            Publisher = new Publisher()
                            {
                                Name = "Oxford University Press"
                            }
                        }
                    }
                };
                context.SaveChanges();
            }
        }

        public void Delete(AuthorDTO entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
