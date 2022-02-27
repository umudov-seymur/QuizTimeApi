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

        public UnitOfWorkService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQuizService QuizService => _quizService ??= new QuizService(_unitOfWork, _mapper, _httpContextAccessor);
    }
}
