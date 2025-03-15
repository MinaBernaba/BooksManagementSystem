using BooksManagementSystem.Application.Features.Authentication.Responses;
using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authentication.Models
{
    public class LoginUserCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
