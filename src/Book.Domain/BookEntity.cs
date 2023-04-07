using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManager.Domain
{
    [Table("tb_Book")]
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Column("Published_On")]
        public DateTime PublishedOn { get; set; }

        [ForeignKey("AuthorEntity")]
        public int AuthorId { get; set; }

        // Navigation properties
        public AuthorEntity Author { get; set; } = null!;
        
    }
}
