using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.DTOs.StatusCode;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Queries;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
    public class QuizzesController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public QuizzesController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/Quizzes
        [HttpGet]
        public async Task<List<QuizGetForOwnerDto>> Get([FromQuery] QuizQuery query)
        {
            return await _unitOfWorkService.QuizService.GetAllQuizzesAsync(query);
        }

        // GET api/Quizzes/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<QuizGetForOwnerDto>> GetAsync(Guid id)
        {
            try
            {
                return await _unitOfWorkService.QuizService.GetQuizByIdAsync(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // POST api/Quizzes
        [HttpPost]
        public async Task<ActionResult<QuizGetForOwnerDto>> Post([FromBody] QuizPostForOwnerDto quizPostDto)
        {
            try
            {
                var quiz = await _unitOfWorkService.QuizService.AddAsync(quizPostDto);
                return StatusCode(StatusCodes.Status201Created, quiz);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // PUT api/Quizzes/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<QuizGetForOwnerDto>> Put(Guid id, [FromBody] QuizPutForOwnerDto quizPutDto)
        {
            try
            {
                quizPutDto.Id = id;
                return Ok(await _unitOfWorkService.QuizService.UpdateAsync(id, quizPutDto));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // DELETE api/Quizzes/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _unitOfWorkService.QuizService.DeleteAsync(id);
                return Ok(new Response { Status = "Success", Message = "Quiz deleted successfull" });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }
    }
}
