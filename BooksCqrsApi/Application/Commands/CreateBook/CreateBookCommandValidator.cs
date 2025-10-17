using FluentValidation;

namespace BooksCqrsApi.Application.Commands.CreateBook;


public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200);
        
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author is required")
            .MaximumLength(100);
        
        RuleFor(x => x.Year)
            .GreaterThan(0).WithMessage("Year must be positive")
            .LessThanOrEqualTo(DateTime.Now.Year);
    }
}