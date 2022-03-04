using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizTime.Business.DTOs.Question.Answers;
using QuizTime.Business.DTOs.StatusCode;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/questions/<questionId>/answers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/questions/<questionId>/answers/<answerId>
        [HttpGet("{answerId:guid}")]
        public string Get(Guid questionId, [FromRoute] Guid answerId)
        {

            return questionId.ToString();
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

        // PUT api/questions/<questionId>/5
        [HttpPut("{answerId:guid}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/questions/<questionId>/5
        [HttpDelete("{answerId:guid}")]
        public void Delete(int id)
        {
        }
    }
}
