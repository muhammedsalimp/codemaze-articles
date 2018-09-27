using System;
using System.Collections.Generic;

namespace EFCoreDatabaseFirstSample.Models
{
    public partial class BookAuthors
    {
        public long BookId { get; set; }
        public long AuthorId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
