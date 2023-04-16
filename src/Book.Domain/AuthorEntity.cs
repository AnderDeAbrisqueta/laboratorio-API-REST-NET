using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookManager.Domain
{
    [Table("tb_Author")]
    public class AuthorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime Birth { get; set; }
        [Column("Country_Code")]
        public string CountryCode { get; set; } = string.Empty;

        // Navigation properties
        public List<BookEntity>? Books { get; set; }
    }
}
