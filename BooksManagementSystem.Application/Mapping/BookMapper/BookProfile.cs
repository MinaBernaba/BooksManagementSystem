using AutoMapper;

namespace BooksManagementSystem.Application.Mapping.BookMapper
{
    public partial class BookProfile : Profile
    {
        public BookProfile()
        {
            AddBookMapper();
            UpdateBookMapper();
        }
    }
}
