using BooksManagementSystem.Application.Features.Books.Commands.Models;
using BooksManagementSystem.Application.ServiceInterfaces;
using FluentValidation;

public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    private readonly IAuthorService _authorService;
    private readonly IBookService _bookService;

    public UpdateBookValidator(IAuthorService authorService, IBookService bookService)
    {
        _authorService = authorService;
        _bookService = bookService;
        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.BookId)
            .GreaterThan(0).WithMessage("Book ID must be a valid positive number!")
            .WithErrorCode("400")
            .DependentRules(() =>
            {
                RuleFor(x => x.BookId)
                    .MustAsync(async (bookId, cancellationToken) => await _bookService.IsExistAsync(bookId))
                    .WithMessage(x => $"The Book ID: {x.BookId} doesn't exist!")
                    .WithErrorCode("404");
            });


        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required!")
            .WithErrorCode("400")
            .MaximumLength(30).WithMessage("Title must not be longer than 30 characters!")
            .WithErrorCode("400")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long!")
            .WithErrorCode("400");

        RuleFor(x => x.PublishedDate)
            .NotEmpty().WithMessage("Publish date is required!")
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Publish date cannot be in the future!")
            .WithErrorCode("400");

        RuleFor(x => x.AuthorId)
            .GreaterThan(0).WithMessage("Author ID must be a valid positive number!")
            .WithErrorCode("400")
            .DependentRules(() =>
            {
                RuleFor(x => x.AuthorId)
                    .MustAsync(async (authorId, cancellationToken) => await _authorService.IsExistAsync(authorId))
                    .WithMessage(x => $"The Author ID: {x.AuthorId} doesn't exist!")
                    .WithErrorCode("404");
            });
    }
}
