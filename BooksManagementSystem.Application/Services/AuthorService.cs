using BooksManagementSystem.Application.Features.Authors.Queries.Responses;
using BooksManagementSystem.Application.ServiceInterfaces;
using BooksManagementSystem.Data.Entities;
using BooksManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BooksManagementSystem.Application.Services
{
    public class AuthorService(IUnitOfWork unitOfWork, IMemoryCache _cache) : IAuthorService
    {
        public async Task<Author> GetAuthorByIdAsync(int authorId) => await unitOfWork.Authors.GetByIdAsync(authorId);
        public async Task<bool> IsAuthorExistByNameAsync(string authorName) => await unitOfWork.Authors.IsExistAsync(x => x.AuthorName.ToLower() == authorName.ToLower());
        public async Task<bool> IsExistAsync(int authorId) => await unitOfWork.Authors.IsExistAsync(x => x.AuthorId == authorId);
        public async Task<List<AuthorsMainInfoResponse>> GetAllAuthorsAsync()
        {
            const string cacheKey = "GetAllAuthors";

            if (!_cache.TryGetValue(cacheKey, out List<AuthorsMainInfoResponse> authors))
            {
                authors = await unitOfWork.Authors.GetAllNoTracking().Select(x => new AuthorsMainInfoResponse()
                {
                    AuthorName = x.AuthorName,
                    DateOfBirth = x.DateOfBirth
                }).ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                _cache.Set(cacheKey, authors, cacheEntryOptions);
            }
            return authors;
        }
        public async Task<bool> AddAuthorAsync(Author author)
        {
            await unitOfWork.Authors.AddAsync(author);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAuthorAsync(Author author)
        {
            unitOfWork.Authors.Update(author);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAuthorAsync(int authorId)
        {
            var author = await unitOfWork.Authors.GetByIdAsync(authorId);
            unitOfWork.Authors.Delete(author);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<GetAuthorByIdResponse> GetAuthorWithHisBooks(int authorId) =>
            await unitOfWork.Authors.GetAllNoTracking()
            .Where(x => x.AuthorId == authorId)
            .Select(x => new GetAuthorByIdResponse()
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                DateOfBirth = x.DateOfBirth,
                Books = x.Books.Select(b => new BooksOfAuthor()
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    PublishedDate = b.PublishedDate,

                }).ToList()
            }).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Author with ID {authorId} not found.");
    }
}
