using BooksManagementSystem.Application.Features.Authentication.Responses;
using BooksManagementSystem.Data.Identity;

namespace BooksManagementSystem.Application.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<JwtAuthResponse> LoginUser(User user);
        Task<JwtAuthResponse?> RenewTokensAsync(string refreshToken);
        Task<bool> RevokeRefreshTokenAsync(string refreshToken);
    }
}
