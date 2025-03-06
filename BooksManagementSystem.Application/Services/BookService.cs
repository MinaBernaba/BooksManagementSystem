using BooksManagementSystem.Application.Features.Books.Queries.Responses;
using BooksManagementSystem.Application.ServiceInterfaces;
using BooksManagementSystem.Data.Entities;
using BooksManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BooksManagementSystem.Application.Services
{
    public class BookService(IUnitOfWork _unitOfWork, IMemoryCache _cache) : IBookService
    {
        public async Task<List<BookMainInfoResponse>> GetAllBooks()
        {
            const string cacheKey = "GetAllBooks";

            if (!_cache.TryGetValue(cacheKey, out List<BookMainInfoResponse> books))
            {
                books = await _unitOfWork.Books.GetAllNoTracking().Select(x => new BookMainInfoResponse()
                {
                    AuthorName = x.Author.AuthorName,
                    PublishedDate = x.PublishedDate,
                    Title = x.Title
                }).ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                _cache.Set(cacheKey, books, cacheEntryOptions);
            }
            return books;
        }
        public async Task<BookMainInfoResponse> GetBookByIdAsync(int bookId)
            => await _unitOfWork.Books.GetAllNoTracking()
            .Where(x => x.BookId == bookId)
            .Select(x => new BookMainInfoResponse()
            {
                AuthorName = x.Author.AuthorName,
                PublishedDate = x.PublishedDate,
                Title = x.Title
            }).FirstAsync();
        public async Task<bool> IsBookExistByTitleAsync(string title) => await _unitOfWork.Books.IsExistAsync(x => x.Title.ToLower() == title);
        public async Task<bool> IsExistAsync(int bookId) => await _unitOfWork.Books.IsExistAsync(x => x.BookId == bookId);

        public async Task<bool> AddBookAsync(Book book)
        {
            await _unitOfWork.Books.AddAsync(book);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateBookAsync(Book book)
        {
            _unitOfWork.Books.Update(book);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(bookId);
            _unitOfWork.Books.Delete(book);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }


    }
}
