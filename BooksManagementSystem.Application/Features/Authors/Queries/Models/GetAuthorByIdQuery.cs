using BooksManagementSystem.Application.Features.Authors.Queries.Responses;
using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authors.Queries.Models
{
    public class GetAuthorByIdQuery : IRequest<Response<GetAuthorByIdResponse>>
    {
        public int AuthorId { get; set; }
    }
}
