using BooksManagementSystem.Application.Features.Authors.Commands.Models;
using BooksManagementSystem.Application.ServiceInterfaces;
using FluentValidation;

namespace BooksManagementSystem.Application.Features.Authors.Commands.Validators
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        private readonly IAuthorService _authorService;

        public UpdateAuthorValidator(IAuthorService authorService)
        {
            _authorService = authorService;
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("Author ID must be greater than 0.")
                .WithErrorCode("400")
                .DependentRules(() =>
                {
                    RuleFor(x => x.AuthorId)
                       .MustAsync(async (authorId, cancellationToken) => await _authorService.IsExistAsync(authorId))
                       .WithMessage(x => $"The Author ID: {x.AuthorId} doesn't exist.")
                       .WithErrorCode("404");
                });

            RuleFor(x => x.AuthorName)
                .NotEmpty().WithMessage("Name is required.")
                .WithErrorCode("400")
                .MaximumLength(30).WithMessage("Name is too long.")
                .WithErrorCode("400")
                .MinimumLength(3).WithMessage("Name is too short.")
                .WithErrorCode("400")
                .DependentRules(() =>
                {
                    RuleFor(x => x.AuthorName)
                       .MustAsync(async (authorName, cancellationToken) => !await _authorService.IsAuthorExistByNameAsync(authorName))
                       .WithMessage(x => $"The Author Name: {x.AuthorName} already exists.")
                       .WithErrorCode("404");
                });


            RuleFor(x => x.DateOfBirth)
               .NotEmpty().WithMessage("Date Of Birth is required.")
               .WithErrorCode("400")
               .LessThan(new DateOnly(2000, 1, 1)).WithMessage(@"Date Of Birth can't be greater than 2000-1-1.")
               .WithErrorCode("400")
               .GreaterThan(new DateOnly(1800, 1, 1)).WithMessage(@"Date Of Birth can't be less than 1800-1-1.")
               .WithErrorCode("400");

        }
    }
}