﻿using AutoMapper;
using Quiztime.Core;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Question;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<QuestionGetOfTeacherDto>> GetAllQuestionsByQuizIdAsync(Guid quizId)
        {
            return _mapper.Map<List<QuestionGetOfTeacherDto>>(
                await _unitOfWork.QuestionRepository.GetAllAsync(n => n.QuizId == quizId, "Answers")
            );
        }

        public async Task<QuestionGetOfTeacherDto> GetQuestionByQuizIdAsync(Guid quizId, Guid questionId)
        {
            var question = await _unitOfWork.QuestionRepository
                    .GetAsync(n => n.Id == questionId && n.QuizId == quizId);

            if (question is null) throw new NotFoundException("Question could not found");
            
            return _mapper.Map<QuestionGetOfTeacherDto>(question);
        }

        public async Task<QuestionGetOfTeacherDto> GetQuestionByIdAsync(Guid questionId)
        {
            var question = await GetQuestionAsync(questionId);
            
            if (question is null) 
                throw new NotFoundException("Question could not found");

            return _mapper.Map<QuestionGetOfTeacherDto>(question);
        }

        public async Task AddAsync(QuestionPostDto questionPostDto)
        {
            var question = _mapper.Map<Question>(questionPostDto);

            await _unitOfWork.QuestionRepository.AddAsync(question);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var question = await GetQuestionAsync(id);

            await _unitOfWork.QuestionRepository.DeleteAsync(question);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<Question> GetQuestionAsync(Guid id)
        {
            var question = await _unitOfWork.QuestionRepository.GetAsync(n => n.Id == id);
            if (question is null) throw new NotFoundException("Question could not found");
            return question;
        }
    }
}
