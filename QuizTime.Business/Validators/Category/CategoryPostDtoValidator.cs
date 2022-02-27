using FluentValidation;
using QuizTime.Business.DTOs.Category;

namespace QuizTime.Business.Validators.Quiz
{
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50);
        }
    }
}
