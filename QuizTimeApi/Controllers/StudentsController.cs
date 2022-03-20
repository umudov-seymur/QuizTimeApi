using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.DTOs.StatusCode;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Services.Interfaces;
using System.Threading.Tasks;
using System;
using QuizTime.Business.DTOs.ResultAnswers;

namespace QuizTimeApi.Controllers
{
    [Route("api/[controller]/quizzes")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public StudentsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET api/students/quizzes/<Password>
        [HttpGet("{password}")]
        public async Task<ActionResult<QuizGetOfJoinedStudentDto>> GetQuizByPasswordAsync([FromRoute] string password)
        {
            try
            {
                return await _unitOfWorkService.QuizService.GetQuizForJoinedStudentAsync(password);
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

        // POST api/students/quizzes/<Password>/start
        [HttpPost("{password}/start")]
        public async Task<ActionResult> StartQuizByPasswordAsync([FromRoute] string password)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _unitOfWorkService.ResultService.AddResultByQuizPasswordAsync(password));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // POST api/students/quizzes/<Password>/answers
        [HttpPost("{password}/answers")]
        public async Task<ActionResult> SaveAnswersByQuizPassword(string password, [FromBody] ResultAnswersPostForStudentDto resultAnswersPostDto)
        {
            try
            {
                await _unitOfWorkService.ResultAnswerService.SaveAnswersByQuizPasswordAsync(password, resultAnswersPostDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }
    }
}
