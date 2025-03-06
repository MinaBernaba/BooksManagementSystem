using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authentication.Models
{
    public class RevokeRefreshTokenCommand : IRequest<Response<string>>
    {
        public string RefreshToken { get; set; }
    }
}
