namespace BooksManagementSystem.Data.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    }
}