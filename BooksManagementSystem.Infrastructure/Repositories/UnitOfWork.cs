using BooksManagementSystem.Infrastructure.Context;
using BooksManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace BooksManagementSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly ApplicationDbContext _context;

        private Lazy<IBookRepository> _books;
        private Lazy<IAuthorRepository> _authors;


        public IBookRepository Books => _books.Value;
        public IAuthorRepository Authors => _authors.Value;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _books = new Lazy<IBookRepository>(() => new BookRepository(_context));
            _authors = new Lazy<IAuthorRepository>(() => new AuthorRepository(_context));
        }
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        public async Task CommitTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CommitTransactionAsync();
                await SaveChangesAsync();
            }
        }
        public async Task RollBackAsync()
        {
            if (_context.Database.CurrentTransaction != null)
                await _context.Database.RollbackTransactionAsync();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}
