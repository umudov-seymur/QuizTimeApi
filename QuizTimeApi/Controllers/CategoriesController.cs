using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizTime.Business.DTOs.Category;
using QuizTime.Business.DTOs.StatusCode;
using QuizTime.Business.Exceptions;
using QuizTime.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        // GET api/Categories/e11ea9bc-c3e8-4f7f-3e68-08d9fa39218e
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryGetDto>> GetAsync(Guid id)
        {
            try
            {
                return await _unitOfWorkService.CategoryService.GetCategoryByIdAsync(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // POST api/Categories
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CategoryPostDto categoryPostDto)
        {
            try
            {
                await _unitOfWorkService.CategoryService.AddAsync(categoryPostDto);
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Category created successfull" });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // PUT api/Categories/e11ea9bc-c3e8-4f7f-3e68-08d9fa39218e
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryGetDto>> PutAsync(Guid id, [FromBody] CategoryPutDto categoryPutDto)
        {
            try
            {
                categoryPutDto.Id = id;
                return Ok(await _unitOfWorkService.CategoryService.UpdateAsync(id, categoryPutDto));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // DELETE api/Categories/e11ea9bc-c3e8-4f7f-3e68-08d9fa39218e
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _unitOfWorkService.CategoryService.DeleteAsync(id);
                return Ok(new Response { Status = "Success", Message = "Category deleted successfull" });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message.ToString() });
            }
        }
    }
}
