using FluentValidation;
using QuizTime.Business.DTOs.Authentication;

namespace QuizTime.Business.Validators.Authenticate
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                 .NotEmpty()
                 .NotNull()
                 .MinimumLength(3)
                 .MaximumLength(30);

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(100);

            RuleFor(x => x.Role)
             .NotNull()
             .InclusiveBetween(1, 2);
        }
    }
}
