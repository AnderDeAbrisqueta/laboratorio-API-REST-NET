namespace BookManager.Application.Models
{
    public class Author
    {
        public int Id { get; }
        public string Name { get; } 
        public string LastName { get; }

        public Author(int id, string name, string lastName) 
        { 
            Id = id;
            Name = name;
            LastName = lastName;
        }
    }
}
