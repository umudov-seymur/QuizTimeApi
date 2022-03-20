using AutoMapper;
using Microsoft.AspNetCore.Http;
using Quiztime.Core;
using QuizTime.Business.Services.Interfaces;

namespace QuizTime.Business.Services.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private IQuizService _quizService;
        private ICategoryService _categoryService;
        private IQuestionService _questionService;
        private IAnswerService _answerService;
        private IQuizSettingService _quizSettingService;
        private IResultService _resultService;
        private IResultAnswerService _resultAnswerService;


        public UnitOfWorkService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQuizService QuizService => _quizService ??= new QuizService(_unitOfWork, _mapper, _httpContextAccessor);
        public ICategoryService CategoryService => _categoryService ??= new CategoryService(_unitOfWork, _mapper, _httpContextAccessor);
        public IQuestionService QuestionService => _questionService ??= new QuestionService(_unitOfWork, _mapper);
        public IAnswerService AnswerService => _answerService ??= new AnswerService(_unitOfWork, _mapper);
        public IQuizSettingService QuizSettingService => _quizSettingService ??= new QuizSettingService(_unitOfWork, _mapper, _httpContextAccessor);
        public IResultService ResultService => _resultService ??= new ResultService(_unitOfWork, _mapper, _httpContextAccessor);
        public IResultAnswerService ResultAnswerService => _resultAnswerService ??= new ResultAnswerService(_unitOfWork, _mapper, _httpContextAccessor);
    }
}
