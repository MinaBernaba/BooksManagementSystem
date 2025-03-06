using BooksManagementSystem.Application.Features.Books.Commands.Models;
using BooksManagementSystem.Data.Entities;

namespace BooksManagementSystem.Application.Mapping.BookMapper
{
    public partial class BookProfile
    {
        public void AddBookMapper() => CreateMap<AddBookCommand, Book>();
    }
}
