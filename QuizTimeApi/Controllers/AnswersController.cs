using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizTime.Business.DTOs.Question.Answers;
using QuizTime.Business.DTOs.StatusCode;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTimeApi.Controllers
{
    [Route("api/questions/{questionId:guid}/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public AnswersController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // POST api/questions/<questionId>/answers
        [HttpPost]
        public async Task<ActionResult> PostAsync(Guid questionId, [FromBody] List<AnswerPostDto> answersPostDto)
        {
            try
            {
                var question = await _unitOfWorkService.QuestionService.GetQuestionByIdAsync(questionId);
                await _unitOfWorkService.AnswerService.AddAnswerByQuestionIdAsync(questionId, answersPostDto);

                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Answers created successfull" });
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
    }
}
