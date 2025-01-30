using CMSPlus.Domain.Models.CommentModels;
using FluentValidation;

namespace CMSPlus.Presentation.Validations
{
    public class CommentCreateModelValidator : AbstractValidator<CommentCreateModel>
    {
        public CommentCreateModelValidator()
        {
            RuleFor(comment => comment.FullName)
                .NotEmpty()
                .Length(2, 100).WithMessage("Full Name must be between 2 and 100 characters.");

            RuleFor(comment => comment.Body)
                .NotEmpty().WithMessage("Body must not be empty.");
        }
    }
}
