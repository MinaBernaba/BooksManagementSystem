using BooksManagementSystem.Application.Features.Authors.Commands.Models;
using BooksManagementSystem.Application.ServiceInterfaces;
using FluentValidation;

namespace BooksManagementSystem.Application.Features.Authors.Commands.Validators
{
    public class AddAuthorValidator : AbstractValidator<AddAuthorCommand>
    {
        private readonly IAuthorService _authorService;

        public AddAuthorValidator(IAuthorService authorService)
        {
            _authorService = authorService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty().WithMessage("Name is required!")
                .NotNull().WithMessage("Name is required!")
                .MaximumLength(30).WithMessage("Name is too long")
                .MinimumLength(3).WithMessage("Name is too short");




            RuleFor(x => x.DateOfBirth)
               .NotEmpty().WithMessage("Date Of Birth is required!")
               .NotNull().WithMessage("Date Of Birth is required!")
               .LessThan(new DateOnly(2000, 1, 1)).WithMessage("Date Of Birth is invalid!")
               .GreaterThan(new DateOnly(1800, 1, 1)).WithMessage("Date Of Birth is invalid!");

        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.AuthorName)
               .MustAsync(async (authorName, cancellationToken) => !await _authorService.IsAuthorExistByNameAsync(authorName))
               .WithMessage(x => $"The Author Name: {x.AuthorName} already exists!");
        }
    }
}