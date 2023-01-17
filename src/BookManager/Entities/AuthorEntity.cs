namespace BookManager.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public String CountryCode { get; set;}

        // Navigation properties
        public List<BookEntity> Books { get; set; } = new();
    }
}
