using BooksManagementSystem.Application.Features.Books.Commands.Models;
using BooksManagementSystem.Application.Features.Books.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;

namespace BooksManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController(IMediator _mediator) : AppControllerBase
    {
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks() => Ok(await _mediator.Send(new GetAllBooksQuery()));

        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById(int id) => Ok(await _mediator.Send(new GetBookByIdQuery() { BookId = id }));

        [HttpPost("AddNewBook/")]
        public async Task<IActionResult> AddNewBook(AddBookCommand addBook) => Ok(await _mediator.Send(addBook));

        [HttpPut("UpdateBook/")]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand updateBook) => Ok(await _mediator.Send(updateBook));

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id) => Ok(await _mediator.Send(new DeleteBookCommand() { BookId = id }));

    }
}
