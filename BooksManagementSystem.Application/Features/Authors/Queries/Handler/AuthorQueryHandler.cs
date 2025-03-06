using BooksManagementSystem.Application.Features.Authors.Queries.Models;
using BooksManagementSystem.Application.Features.Authors.Queries.Responses;
using BooksManagementSystem.Application.ResponseBase;
using BooksManagementSystem.Application.ServiceInterfaces;
using MediatR;

namespace BooksManagementSystem.Application.Features.Authors.Queries.Handler
{
    public class AuthorQueryHandler(IAuthorService _authorService) : ResponseHandler,
        IRequestHandler<GetAuthorByIdQuery, Response<GetAuthorByIdResponse>>,
        IRequestHandler<GetAllAuthorsQuery, Response<List<AuthorsMainInfoResponse>>>
    {
        public async Task<Response<GetAuthorByIdResponse>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _authorService.IsExistAsync(request.AuthorId))
                return NotFound<GetAuthorByIdResponse>($"Author with ID: {request.AuthorId} not found");


            var response = await _authorService.GetAuthorWithHisBooks(request.AuthorId);
            return Success(response);
        }

        public async Task<Response<List<AuthorsMainInfoResponse>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Success(authors);
        }
    }
}
