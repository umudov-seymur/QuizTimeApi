using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizTime.Business.DTOs.Question;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.DTOs.StatusCode;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTimeApi.Controllers
{
    [Route("api/quizzes/{quizId:guid}/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
    public class QuestionsController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public QuestionsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/quizzes/{quizId:guid}/questions
        [HttpGet]
        public async Task<ActionResult<List<QuestionGetOfTeacherDto>>> Get(Guid quizId)
        {
            try
            {
                await CheckQuizIsExist(quizId);
                return await _unitOfWorkService.QuestionService.GetAllQuestionsByQuizIdAsync(quizId);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // GET api/quizzes/{quizId:guid}/questions/{questionId:guid}
        [HttpGet("{questionId:guid}")]
        public async Task<ActionResult<QuestionGetOfTeacherDto>> Get(Guid quizId, [FromRoute] Guid questionId)
        {
            try
            {
                await CheckQuizIsExist(quizId);
                return await _unitOfWorkService.QuestionService.GetQuestionByQuizIdAsync(quizId, questionId);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // POST api/quizzes/{quizId:guid}/questions
        [HttpPost]
        public async Task<ActionResult> PostAsync(Guid quizId, [FromBody] QuestionPostDto questionPostDto)
        {
            try
            {
                var quiz = await CheckQuizIsExist(quizId);
                questionPostDto.QuizId = quiz.Id.ToString();

                return StatusCode(StatusCodes.Status201Created, await _unitOfWorkService.QuestionService.AddAsync(questionPostDto));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }
        // GET api/quizzes/{quizId:guid}/questions/{questionId:guid}
        [HttpPut("{questionId:guid}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // PATCH: api/quizzes/{quizId:guid}/questions/UpdateOrder
        [HttpPatch("UpdateOrder")]
        public async Task<ActionResult> UpdateOrder(Guid quizId, [FromBody] List<QuestionOrderPatchDto> sortedQuestionsDto)
        {
            try
            {
                await _unitOfWorkService.QuestionService.UpdateOrderByQuizIdAsync(quizId, sortedQuestionsDto);
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Questions sorted successfull." });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // GET api/quizzes/{quizId:guid}/questions/{questionId:guid}
        [HttpDelete("{questionId:guid}")]
        public async Task<ActionResult> Delete(Guid quizId, Guid questionId)
        {
            try
            {
                await CheckQuizIsExist(quizId);
                await _unitOfWorkService.QuestionService.DeleteAsync(questionId);
                return Ok(new Response { Status = "Success", Message = "Question deleted successfull" });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        private async Task<QuizGetForOwnerDto> CheckQuizIsExist(Guid quizId)
        {
            return await _unitOfWorkService.QuizService.GetQuizByIdAsync(quizId);
        }
    }
}
