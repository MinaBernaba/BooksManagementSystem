using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Books.Commands.Models
{
    public class DeleteBookCommand : IRequest<Response<string>>
    {
        public int BookId { get; set; }
    }
}
