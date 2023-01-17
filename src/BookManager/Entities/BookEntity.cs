using System.Data;

namespace BookManager.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public int AuthorId { get; set; }

       // Navigation properties
        public AuthorEntity Author  { get; set; }
        
    }
}
