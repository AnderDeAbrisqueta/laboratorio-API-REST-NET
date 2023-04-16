using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManager.Domain
{
    public class Fluent_BookEntity
    {
        
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PublishedOn { get; set; }
        public int AuthorId { get; set; }
        public Fluent_AuthorEntity Fluent_Author { get; set; } = null!;

    }
}
