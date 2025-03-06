using BooksManagementSystem.Application.Features.Books.Queries.Responses;
using BooksManagementSystem.Data.Entities;

namespace BooksManagementSystem.Application.ServiceInterfaces
{
    public interface IBookService
    {
        Task<List<BookMainInfoResponse>> GetAllBooks();
        Task<BookMainInfoResponse> GetBookByIdAsync(int BookId);
        Task<bool> IsBookExistByTitleAsync(string BookName);
        Task<bool> IsExistAsync(int BookId);
        Task<bool> AddBookAsync(Book Book);
        Task<bool> UpdateBookAsync(Book Book);
        Task<bool> DeleteBookAsync(int BookId);
    }
}
