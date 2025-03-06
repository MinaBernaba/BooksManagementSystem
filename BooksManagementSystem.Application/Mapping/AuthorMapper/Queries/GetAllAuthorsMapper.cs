using BooksManagementSystem.Application.Features.Authors.Queries.Responses;
using BooksManagementSystem.Data.Entities;

namespace BooksManagementSystem.Application.Mapping.AuthorMapper
{
    public partial class AuthorProfile
    {
        public void GetAllAuthorsMapper() => CreateMap<Author, AuthorsMainInfoResponse>();
    }
}
