using AutoMapper;
using Quiztime.Core;
using QuizTime.Business.Services.Interfaces;

namespace QuizTime.Business.Services.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private IQuizService _quizService;

        public UnitOfWorkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IQuizService QuizService => _quizService ??= new QuizService(_unitOfWork, _mapper);
    }
}
