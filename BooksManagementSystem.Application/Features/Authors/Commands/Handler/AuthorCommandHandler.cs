using AutoMapper;
using BooksManagementSystem.Application.Features.Authors.Commands.Models;
using BooksManagementSystem.Application.ResponseBase;
using BooksManagementSystem.Application.ServiceInterfaces;
using BooksManagementSystem.Data.Entities;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authors.Commands.Handler
{
    public class AuthorCommandHandler(IAuthorService _authorService, IMapper _mapper) : ResponseHandler,
        IRequestHandler<AddAuthorCommand, Response<string>>,
        IRequestHandler<UpdateAuthorCommand, Response<string>>,
        IRequestHandler<DeleteAuthorCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request);

            if (!await _authorService.AddAuthorAsync(author))
                return BadRequest<string>("Failed to add author.");

            else
                return Created<string>($"Author added successfully with ID: {author.AuthorId}.");

        }

        public async Task<Response<string>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request);

            if (!await _authorService.UpdateAuthorAsync(author))
                return BadRequest<string>("Failed to update author.");

            else
                return Updated<string>($"Author with ID: {author.AuthorId} updated successfully.");


        }

        public async Task<Response<string>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {

            if (!await _authorService.IsExistAsync(request.AuthorId))
                return NotFound<string>($"Author with ID: {request.AuthorId} not found");

            if (!await _authorService.DeleteAuthorAsync(request.AuthorId))
                return BadRequest<string>("Failed to delete author.");

            else
                return Deleted<string>($"Author with ID: {request.AuthorId} deleted successfully.");

        }
    }
}
