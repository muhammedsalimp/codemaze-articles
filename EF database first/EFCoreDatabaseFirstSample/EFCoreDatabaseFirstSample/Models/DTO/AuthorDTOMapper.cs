using System.Collections.Generic;

namespace EFCoreDatabaseFirstSample.Models.DTO
{
    public static class AuthorDTOMapper
    {
        public static List<AuthorDTO> MapToDTOs(List<Author> authors)
        {
            List<AuthorDTO> authorDTOs = new List<AuthorDTO>();

            foreach (Author author in authors)
            {
                AuthorDTO authorDTO = MapToDTO(author);
                authorDTOs.Add(authorDTO);
            }

            return authorDTOs;
        }

        public static AuthorDTO MapToDTO(Author author)
        {
            return new AuthorDTO()
            {
                Id = author.Id,
                Name = author.Name,
                AuthorContact = new AuthorContactDTO()
                {
                    AuthorId = author.Id,
                    Address = author.AuthorContact.Address,
                    ContactNumber = author.AuthorContact.ContactNumber
                }
            };
        }
    }
}
