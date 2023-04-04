
using BookManager.Domain;
using System.ComponentModel.DataAnnotations;

namespace BookManager.Application.Models
{
    public class Book
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public DateTime PublishedOn { get; }

        public string Text { get; init; } = string.Empty;

        public string FormattedText => 
            $"[{PublishedOn.ToString("yyy MM dd")}]";
        
        public Book(int id, string title, string description, DateTime publishedOn) 
        {
            Id = id;
            Title = title;
            Description = description;
            PublishedOn = publishedOn;

        }

    }
}
