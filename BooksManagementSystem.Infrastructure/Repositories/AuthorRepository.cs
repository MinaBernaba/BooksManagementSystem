using BooksManagementSystem.Data.Entities;
using BooksManagementSystem.Infrastructure.Context;
using BooksManagementSystem.Infrastructure.Interfaces;

namespace BooksManagementSystem.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context) { }
    }
}
