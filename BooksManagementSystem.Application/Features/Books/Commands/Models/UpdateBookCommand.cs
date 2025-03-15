using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Books.Commands.Models
{
    public class UpdateBookCommand : IRequest<Response<string>>
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
