using FluentValidation;
using GuestReview.Model;

namespace GuestReview.Validator
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.Body)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Score)
                .NotEmpty()
                .InclusiveBetween(1, 5);                
        }
    }
}
