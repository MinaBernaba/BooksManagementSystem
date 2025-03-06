using System.Text.Json.Serialization;

namespace BooksManagementSystem.Application.Features.Authentication.Responses
{
    public class JwtAuthResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string>? Roles { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
