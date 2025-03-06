using BooksManagementSystem.Application.Features.Books.Queries.Responses;
using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Books.Queries.Models
{
    public class GetAllBooksQuery : IRequest<Response<List<BookMainInfoResponse>>>
    {
    }
}
