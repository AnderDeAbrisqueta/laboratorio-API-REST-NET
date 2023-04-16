

namespace BookManager.Domain
{
    
    public class Fluent_AuthorEntity
    {
        
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birth { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public List<Fluent_BookEntity> Fluent_Books { get; set; } = null!;

    }
}
