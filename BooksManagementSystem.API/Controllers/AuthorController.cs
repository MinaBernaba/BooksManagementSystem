using BooksManagementSystem.Application.Features.Authors.Commands.Models;
using BooksManagementSystem.Application.Features.Authors.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;

namespace BooksManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController(IMediator _mediator) : AppControllerBase
    {
        [HttpGet("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthor(int id)
            => NewResult(await _mediator.Send(new GetAuthorByIdQuery() { AuthorId = id }));

        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
               => NewResult(await _mediator.Send(new GetAllAuthorsQuery()));


        [HttpPost("AddNewAuthor")]
        public async Task<IActionResult> AddNewAuthor(AddAuthorCommand addAuthor)
            => NewResult(await _mediator.Send(addAuthor));

        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand updateAuthor)
            => NewResult(await _mediator.Send(updateAuthor));


        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
            => NewResult(await _mediator.Send(new DeleteAuthorCommand() { AuthorId = id }));
    }
}
