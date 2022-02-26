using Microsoft.AspNetCore.Mvc;
using QuizTime.Business.DTOs.Quiz;
using QuizTime.Business.Services.Implementations;
using QuizTime.Business.Services.Interfaces;
using QuizTime.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public QuizzesController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/Quizzes
        [HttpGet]
        public async Task<List<QuizGetDto>> Get()
        {
            return await _unitOfWorkService.QuizService.GetAllQuizzesync();
        }

        // GET api/Quizzes/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Quizzes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Quizzes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Quizzes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
