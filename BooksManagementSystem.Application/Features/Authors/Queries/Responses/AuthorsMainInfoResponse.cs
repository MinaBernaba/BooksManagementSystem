namespace BooksManagementSystem.Application.Features.Authors.Queries.Responses
{
    public class AuthorsMainInfoResponse
    {
        public string AuthorName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
    }
}
