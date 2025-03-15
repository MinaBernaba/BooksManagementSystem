namespace BooksManagementSystem.Application.Features.Authors.Queries.Responses
{
    public class BooksOfAuthor
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly PublishedDate { get; set; }
    }
}
