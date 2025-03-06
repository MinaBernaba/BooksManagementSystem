using BooksManagementSystem.Data.Entities;
using BooksManagementSystem.Infrastructure.Context;
using BooksManagementSystem.Infrastructure.Interfaces;

namespace BooksManagementSystem.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
    }
}