using BooksManagementSystem.Application.Features.Authentication.Models;
using BooksManagementSystem.Data.Identity;

namespace BooksManagementSystem.Application.Mapping.UserMapper
{
    public partial class UserProfile
    {
        public void RegisterUser() => CreateMap<RegisterUserCommand, User>();
    }
}
