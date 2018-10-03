﻿using System.Collections.Generic;

namespace EFCoreDatabaseFirstSample.Models.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        
        public PublisherDTO Publisher { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
    }
}
