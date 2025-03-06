using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authors.Commands.Models
{
    public class AddAuthorCommand : IRequest<Response<string>>
    {
        public string AuthorName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
