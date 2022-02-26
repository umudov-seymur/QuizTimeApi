using AutoMapper;
using Quiztime.Core;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuizService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<QuizGetDto>> GetAllQuizzesync()
        {
            return _mapper.Map<List<QuizGetDto>>(await _unitOfWork.QuizRepository.GetAllAsync());
        }
    }
}
