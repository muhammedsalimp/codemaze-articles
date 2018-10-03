using System.Linq;

namespace EFCoreDatabaseFirstSample.Models.DTO
{
    public static class BookDTOMapper
    {
        public static BookDTO MapToBookDTO(Book book)
        {
            return new BookDTO()
            {
                Id = book.Id,
                Title = book.Title,

                Publisher = new PublisherDTO()
                {
                    Id = book.Publisher.Id,
                    Name = book.Publisher.Name
                },

                Authors = AuthorDTOMapper.MapToDTOs(book.BookAuthors.Select(b => b.Author).ToList())
            };
        }
    }
}
