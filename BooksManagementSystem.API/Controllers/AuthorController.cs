using BooksManagementSystem.Application.Features.Authors.Commands.Models;
using BooksManagementSystem.Application.Features.Authors.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;

namespace BooksManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : AppControllerBase
    {
        [HttpGet("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthor(int id)
            => NewResult(await Mediator.Send(new GetAuthorByIdQuery() { AuthorId = id }));

        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
           => NewResult(await Mediator.Send(new GetAllAuthorsQuery()));


        [HttpPost("AddNewAuthor")]
        public async Task<IActionResult> AddNewAuthor(AddAuthorCommand addAuthor)
            => NewResult(await Mediator.Send(addAuthor));

        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand updateAuthor)
            => NewResult(await Mediator.Send(updateAuthor));


        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
            => NewResult(await Mediator.Send(new DeleteAuthorCommand() { AuthorId = id }));
    }
}
