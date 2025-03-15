using Microsoft.AspNetCore.Identity;

namespace BooksManagementSystem.Data.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Country { get; set; }
        public virtual List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
