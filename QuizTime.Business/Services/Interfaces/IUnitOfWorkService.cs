namespace QuizTime.Business.Services.Interfaces
{
    public interface IUnitOfWorkService
    {
        IQuizService QuizService { get; }
        ICategoryService CategoryService { get; }
        IQuestionService QuestionService { get; }
        IAnswerService AnswerService { get; }
        IQuizSettingService QuizSettingService { get; }
        IResultService ResultService { get; }
        IResultAnswerService ResultAnswerService { get; }
    }
}
