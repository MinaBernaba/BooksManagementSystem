namespace BooksManagementSystem.Application.Features.Books.Queries.Responses
{
    public class BookMainInfoResponse
    {
        public string AuthorName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateOnly PublishedDate { get; set; }
    }
}
