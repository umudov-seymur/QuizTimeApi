using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizTime.Business.DTOs.Category;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public CategoriesController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<List<CategoryGetDto>> Get()
        {
            return await _unitOfWorkService.CategoryService.GetAllCategoryAsync();
        }

        // GET api/Categories/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Categories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
