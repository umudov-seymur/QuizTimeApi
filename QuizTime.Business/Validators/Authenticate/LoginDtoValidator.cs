using FluentValidation;
using QuizTime.Business.DTOs.Authentication;

namespace QuizTime.Business.Validators.Authenticate
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
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
        }
    }
}
