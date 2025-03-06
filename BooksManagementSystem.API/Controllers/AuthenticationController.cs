using BooksManagementSystem.Application.Features.Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;

namespace BooksManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {

        #region Set Refresh Token In Cookie
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expiresOn)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = expiresOn.ToLocalTime()
            };
            Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
        }
        #endregion

        #region  Delete Refresh Token In Cookie
        private void DeleteRefreshTokenFromCookie()
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(-1)
            };
            Response.Cookies.Append("RefreshToken", "", cookieOptions);
        }
        #endregion

        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand loginUser)
        {
            var response = await Mediator.Send(loginUser);
            if (response.Data == null)
            {
                DeleteRefreshTokenFromCookie();
                return NewResult(response);
            }

            SetRefreshTokenInCookie(response.Data.RefreshToken, response.Data.RefreshTokenExpiration);
            return NewResult(response);
        }
        #endregion

        #region Resigter User
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand registerUser)
        {
            var response = await Mediator.Send(registerUser);
            if (response.Data != null)
            {
                var cookieOptions = new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = response.Data.RefreshTokenExpiration.ToLocalTime()
                };

                Response.Cookies.Append("RefreshToken", response.Data.RefreshToken, cookieOptions);
            }
            return Ok(response);
        }
        #endregion

        #region Renew Tokens
        [HttpPost("RenewTokens")]
        public async Task<IActionResult> RenewTokens()
        {
            var refreshToken = Request.Cookies["RefreshToken"];

            if (string.IsNullOrWhiteSpace(refreshToken))
                return BadRequest("No refresh token provided!");

            var response = await Mediator.Send(new RenewTokensCommand() { RefreshToken = refreshToken });

            if (response.Data != null)
                SetRefreshTokenInCookie(response.Data.RefreshToken, response.Data.RefreshTokenExpiration);
            else
                DeleteRefreshTokenFromCookie();

            return NewResult(response);
        }
        #endregion

        #region Revoke Refresh Token
        [HttpPost("RevokeRefreshToken")]
        public async Task<IActionResult> RevokeRefreshToken([FromBody] RevokeRefreshTokenCommand? revokeToken)
        {
            var refreshToken = revokeToken?.RefreshToken ?? Request.Cookies["RefreshToken"];
            if (string.IsNullOrWhiteSpace(refreshToken))
                return BadRequest("Refresh Token is required!");

            return NewResult(await Mediator.Send(new RevokeRefreshTokenCommand() { RefreshToken = refreshToken }));
        }
        #endregion
    }
}