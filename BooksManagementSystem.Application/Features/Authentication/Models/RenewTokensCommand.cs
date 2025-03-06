using BooksManagementSystem.Application.Features.Authentication.Responses;
using BooksManagementSystem.Application.ResponseBase;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authentication.Models
{
    public class RenewTokensCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string RefreshToken { get; set; }
    }
}
