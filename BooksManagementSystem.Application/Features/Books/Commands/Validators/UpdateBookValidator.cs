﻿using BooksManagementSystem.Application.Features.Books.Commands.Models;
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
        ApplyCustomValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.BookId)
            .NotEmpty().WithMessage("Book ID is required!")
            .GreaterThan(0).WithMessage("Book ID must be a valid positive number!");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required!")
            .NotNull().WithMessage("Title is required!")
            .MaximumLength(30).WithMessage("Title must not be longer than 30 characters!")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long!");

        RuleFor(x => x.PublishedDate)
            .NotEmpty().WithMessage("Publish date is required!")
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Publish date cannot be in the future!");

        RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("Author ID is required!")
            .GreaterThan(0).WithMessage("Author ID must be a valid positive number!");
    }

    private void ApplyCustomValidationRules()
    {
        RuleFor(x => x.BookId)
            .MustAsync(async (bookId, cancellationToken) => await _bookService.IsExistAsync(bookId))
            .WithMessage(x => $"The Book ID: {x.BookId} doesn't exist!");

        RuleFor(x => x.AuthorId)
            .MustAsync(async (authorId, cancellationToken) => await _authorService.IsExistAsync(authorId))
            .WithMessage(x => $"The Author ID: {x.AuthorId} doesn't exist!");
    }
}
