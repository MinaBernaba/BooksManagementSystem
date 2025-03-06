using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authors.Commands.Models
{
    public class UpdateAuthorCommand : IRequest<Response<string>>
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
