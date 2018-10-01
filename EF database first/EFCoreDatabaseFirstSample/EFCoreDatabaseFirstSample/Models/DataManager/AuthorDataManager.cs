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
                authors = context.Authors
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
                author = context.Authors
                    .Single(b => b.Id == id);
            }

            return author;
        }

        public void Add(Author entity)
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

                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        public void Update(Author entityToUpdate, Author entity)
        {
            using (var context = new BooksContext())
            {
                var authorToUpdate = context.Authors.Single(author => author.Name.Equals("William Shakespeare"));

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

        public void Delete(Author entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
