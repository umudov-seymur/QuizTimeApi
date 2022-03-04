using FluentValidation;
using QuizTime.Business.DTOs.Question.Answers;

namespace QuizTime.Business.Validators.Answer
{
    public class AnswerPostDtoValidator : AbstractValidator<AnswerPostDto>
    {
        public AnswerPostDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(30);
        }
    }
}
