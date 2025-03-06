namespace BooksManagementSystem.Data.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateOnly PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
