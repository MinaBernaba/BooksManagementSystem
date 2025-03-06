using AutoMapper;

namespace BooksManagementSystem.Application.Mapping.AuthorMapper
{
    public partial class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            AddAuthorMapper();
            UpdateAuthorMapper();
            GetAllAuthorsMapper();
        }
    }
}
