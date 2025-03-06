using AutoMapper;
using BooksManagementSystem.Application.Features.Books.Queries.Models;
using BooksManagementSystem.Application.Features.Books.Queries.Responses;
using BooksManagementSystem.Application.ResponseBase;
using BooksManagementSystem.Application.ServiceInterfaces;
using MediatR;

namespace BooksManagementSystem.Application.Features.Books.Queries.Handler
{
    public class BookQueryHandler(IBookService _bookService, IMapper _mapper) : ResponseHandler,
        IRequestHandler<GetAllBooksQuery, Response<List<BookMainInfoResponse>>>,
        IRequestHandler<GetBookByIdQuery, Response<BookMainInfoResponse>>
    {

        public async Task<Response<List<BookMainInfoResponse>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllBooks();
            return Success(books);
        }

        public async Task<Response<BookMainInfoResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _bookService.IsExistAsync(request.BookId))
                return NotFound<BookMainInfoResponse>($"Book with ID: {request.BookId} not found");

            var book = await _bookService.GetBookByIdAsync(request.BookId);
            return Success(book);
        }
    }
}
