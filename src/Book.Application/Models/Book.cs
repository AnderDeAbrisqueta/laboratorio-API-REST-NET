
using BookManager.Domain;

namespace BookManager.Application.Models
{
    public class Book
    {
        public int Id { get; }
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
