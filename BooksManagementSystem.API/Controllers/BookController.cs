using BooksManagementSystem.Application.Features.Books.Commands.Models;
using BooksManagementSystem.Application.Features.Books.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;

namespace BooksManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : AppControllerBase
    {
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks() => Ok(await Mediator.Send(new GetAllBooksQuery()));

        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById(int id) => Ok(await Mediator.Send(new GetBookByIdQuery() { BookId = id }));

        [HttpPost("AddNewBook/")]
        public async Task<IActionResult> AddNewBook(AddBookCommand addBook) => Ok(await Mediator.Send(addBook));

        [HttpPut("UpdateBook/")]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand updateBook) => Ok(await Mediator.Send(updateBook));

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id) => Ok(await Mediator.Send(new DeleteBookCommand() { BookId = id }));

    }
}
