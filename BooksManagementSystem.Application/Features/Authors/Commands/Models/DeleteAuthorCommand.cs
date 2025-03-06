using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authors.Commands.Models
{
    public class DeleteAuthorCommand : IRequest<Response<string>>
    {
        public int AuthorId { get; set; }
    }
}
