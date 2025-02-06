

namespace SurveyBasket.Api.Contracts.Validations
{
    public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatePollRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                // .WithMessage("please add  A {PropertyName}")
                .Length(3, 100);
            // .WithMessage("Title is shoud be at least {MinLength} and maximum {MaxLength} ,you entered[{TotalLength}] ");

            RuleFor(x => x.Description)
               .NotEmpty()
               //.WithMessage("please add  A {PropertyName}")
               .Length(3, 100);
               //.WithMessage("Title is shoud be at least {MinLength} and maximum {MaxLength} ,you entered[{TotalLength}] ");
        }
    }
}
