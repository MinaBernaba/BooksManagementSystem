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
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty().WithMessage("Name is required!")
                .WithErrorCode("400")
                .DependentRules(() =>
                {
                    RuleFor(x => x.AuthorName)
                    .MaximumLength(30).WithMessage("Name is too long")
                    .WithErrorCode("400")
                    .MinimumLength(3).WithMessage("Name is too short")
                    .WithErrorCode("400")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.AuthorName)
                       .MustAsync(async (authorName, cancellationToken) => !await _authorService.IsAuthorExistByNameAsync(authorName))
                       .WithMessage(x => $"The Author Name: {x.AuthorName} already exists!")
                       .WithErrorCode("404");
                    });
                });

            RuleFor(x => x.DateOfBirth)
               .NotEmpty().WithMessage("Date Of Birth is required!")
               .WithErrorCode("400")
               .LessThan(new DateOnly(2000, 1, 1)).WithMessage(@"Date Of Birth can't be greater than 2000-01-01.")
               .WithErrorCode("400")
               .GreaterThan(new DateOnly(1800, 1, 1)).WithMessage(@"Date Of Birth can't be less than 1800-01-01.")
               .WithErrorCode("400");
        }
    }
}