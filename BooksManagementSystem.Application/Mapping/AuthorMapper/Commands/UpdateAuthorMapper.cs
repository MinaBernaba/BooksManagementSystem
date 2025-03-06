using BooksManagementSystem.Application.Features.Authors.Commands.Models;
using BooksManagementSystem.Data.Entities;

namespace BooksManagementSystem.Application.Mapping.AuthorMapper
{
    public partial class AuthorProfile
    {
        public void UpdateAuthorMapper() => CreateMap<UpdateAuthorCommand, Author>();
    }
}
