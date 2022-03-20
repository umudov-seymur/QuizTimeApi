using FluentValidation;
using QuizTime.Business.DTOs.Quiz.Setting;

namespace QuizTime.Business.Validators.Quiz
{
    public class QuizSettingPutDtoValidator : AbstractValidator<QuizSettingPutDto>
    {
        public QuizSettingPutDtoValidator()
        {
            RuleFor(x => x.IsShuffleAnswers)
                .Must(x => x == false || x == true);

            RuleFor(x => x.IsShuffleAnswers)
               .Must(x => x == false || x == true);

            RuleFor(x => x.IsActive)
               .Must(x => x == false || x == true);
        }
    }
}
