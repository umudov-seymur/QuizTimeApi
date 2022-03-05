using FluentValidation;
using QuizTime.Business.DTOs.Question;

namespace QuizTime.Business.Validators.Question
{
    public class QuestionPostDtoValidator : AbstractValidator<QuestionPostDto>
    {
        public QuestionPostDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(200);

            RuleFor(x => x.QuestionType).IsInEnum();

            RuleFor(x => x.Content)
                .MaximumLength(1000);

            RuleFor(x => x.Weight)
               .NotNull()
               .NotEmpty()
               .InclusiveBetween(0, 100);

            //RuleForEach(x => x.Answers).SetValidator(new AnswerPostDtoValidator());
        }
    }
}
