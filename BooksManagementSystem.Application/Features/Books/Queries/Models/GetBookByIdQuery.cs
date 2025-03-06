using BooksManagementSystem.Application.Features.Books.Queries.Responses;
using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Books.Queries.Models
{
    public class GetBookByIdQuery : IRequest<Response<BookMainInfoResponse>>
    {
        public int BookId { get; set; }
    }
}