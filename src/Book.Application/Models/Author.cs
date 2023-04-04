using System.ComponentModel.DataAnnotations;

namespace BookManager.Application.Models
{
    public class Author
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public string Name { get; } = string.Empty;
        [Required]
        public string LastName { get; } = string.Empty;
        public DateTime Birth { get; set; }
        [Required]
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
