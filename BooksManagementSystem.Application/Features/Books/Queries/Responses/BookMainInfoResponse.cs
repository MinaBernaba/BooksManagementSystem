namespace BooksManagementSystem.Application.Features.Books.Queries.Responses
{
    public class BookMainInfoResponse
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public DateOnly PublishedDate { get; set; }
    }
}
