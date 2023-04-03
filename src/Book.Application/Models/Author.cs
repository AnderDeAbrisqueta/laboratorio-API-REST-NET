namespace BookManager.Application.Models
{
    public class Author
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public DateTime Birth { get; set; }
        public string CountryCode { get; set; } = string.Empty;

        public Author (int id, string name, string lastName, DateTime birth, string countryCode)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Birth= birth;
            CountryCode = countryCode;
        }
    }
}
