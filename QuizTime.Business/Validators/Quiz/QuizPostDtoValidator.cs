using FluentValidation;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.DTOs.Result;

namespace QuizTime.Business.Validators.Quiz
{
    public class QuizPostDtoValidator : AbstractValidator<QuizPostForOwnerDto>
    {
        public QuizPostDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(30);

            // 1 minute between 24 hour
            RuleFor(x => x.Timer)
                .InclusiveBetween(1, 1440);

            RuleFor(x => x.CategoryId)
                 .NotNull()
                 .NotEmpty();

            RuleFor(quiz => quiz.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(100);
        }
    }
}
