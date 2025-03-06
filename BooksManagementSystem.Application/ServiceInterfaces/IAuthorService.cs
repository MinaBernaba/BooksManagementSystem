using BooksManagementSystem.Application.Features.Authors.Queries.Responses;
using BooksManagementSystem.Data.Entities;

namespace BooksManagementSystem.Application.ServiceInterfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorsMainInfoResponse>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<bool> IsAuthorExistByNameAsync(string authorName);
        Task<bool> IsExistAsync(int authorId);
        Task<bool> AddAuthorAsync(Author author);
        Task<bool> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int authorId);
        Task<GetAuthorByIdResponse> GetAuthorWithHisBooks(int authorId);
    }
}
