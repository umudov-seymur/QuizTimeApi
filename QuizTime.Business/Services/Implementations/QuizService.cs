﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Quiztime.Core;
using Quiztime.Core.Entities;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Extensions;
using QuizTime.Business.Queries;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizTime.Business.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QuizService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<QuizGetForOwnerDto>> GetAllQuizzesAsync(QuizQuery query)
        {
            var filters = GetQuizFilters(query);
            return _mapper.Map<List<QuizGetForOwnerDto>>(await _unitOfWork.QuizRepository.GetAllQuizzesAsync(filters));
        }

        public async Task<QuizGetForOwnerDto> GetQuizByIdAsync(Guid id)
        {
            return _mapper.Map<QuizGetForOwnerDto>(await GetQuizOfOwner(id));
        }

        public async Task<QuizGetForOwnerDto> AddAsync(QuizPostForOwnerDto quizPostDto)
        {
            var quiz = _mapper.Map<Quiz>(quizPostDto);
            var quizPassword = quizPostDto.Password;

            quiz.OwnerId = _httpContextAccessor.HttpContext.User.GetUserId();

            await CheckQuizUniquePasswordAsync(quizPassword);

            await _unitOfWork.QuizRepository.AddAsync(quiz);

            var quizPasswordEntity = new Password() { Content = quizPassword, QuizId = quiz.Id };
            await _unitOfWork.PasswordRepository.AddAsync(quizPasswordEntity);
            quiz.Password = quizPasswordEntity;

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuizGetForOwnerDto>(quiz);
        }

        public async Task<QuizGetForOwnerDto> UpdateAsync(Guid id, QuizPutForOwnerDto quizPutDto)
        {
            var oldQuiz = await GetQuizOfOwner(id);
            var quizPassword = quizPutDto.Password.ToUpper();
            var quiz = _mapper.Map<QuizPutForOwnerDto, Quiz>(quizPutDto, oldQuiz);

            if (oldQuiz.Password.Content.ToUpper() != quizPutDto.Password.ToUpper())
            {
                await CheckQuizUniquePasswordAsync(quizPassword);
                quiz.Password.Content = quizPassword;
            }

            await _unitOfWork.QuizRepository.UpdateAsync(quiz);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuizGetForOwnerDto>(quiz);
        }

        public async Task DeleteAsync(Guid id)
        {
            var quiz = await GetQuizOfOwner(id);

            await _unitOfWork.QuizRepository.DeleteAsync(quiz);
            await _unitOfWork.PasswordRepository.DeleteAsync(quiz.Password);

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task CheckQuizUniquePasswordAsync(string password)
        {
            var quizPassword = await _unitOfWork.PasswordRepository
                    .GetAsync(pwd => pwd.Content.Contains(password));

            if (!(quizPassword is null))
                throw new QuizPasswordExistException("This password is already used. Please, use different password.");
        }

        private Expression<Func<Quiz, bool>> GetQuizFilters(QuizQuery query)
        {
            var ownerId = _httpContextAccessor.HttpContext.User.GetUserId();

            Expression<Func<Quiz, bool>> filter = q => (
                q.OwnerId == ownerId &&
                (query.CategoryId != null ? q.CategoryId == query.CategoryId : true)
            );

            return filter;
        }

        private async Task<Quiz> GetQuizOfOwner(Guid id)
        {
            var ownerId = _httpContextAccessor.HttpContext.User.GetUserId();

            var quiz = await _unitOfWork.QuizRepository
                    .GetAsync(quiz => quiz.Id == id && quiz.OwnerId == ownerId, "Password");

            if (quiz is null) throw new NotFoundException("Quiz could not found");

            return quiz;
        }
    }
}
