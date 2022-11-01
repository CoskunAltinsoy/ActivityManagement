using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Application.Security.Authorization;
using ActivityManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivityManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AuthorizeRoles(Role.Admin)]
        [HttpPost]
        public IActionResult Add(Category category)
        {
            var categoryAdded = _categoryService.Add(category);
            if (categoryAdded.Success)
            {
                return Ok(categoryAdded.Message);
            }
            return BadRequest(categoryAdded);
        }

        [AuthorizeRoles(Role.Admin)]
        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            var categoryDeleted = _categoryService.Delete(category);
            if (categoryDeleted.Success)
            {
                return Ok(categoryDeleted.Message);
            }
            return BadRequest(categoryDeleted);
        }

        [AuthorizeRoles(Role.Admin)]
        [HttpPut]
        public IActionResult Update(Category category)
        {
            var categoryUpdated = _categoryService.Update(category);
            if (categoryUpdated.Success) 
            {
                return Ok(categoryUpdated.Message);
            }
            return BadRequest(categoryUpdated);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryGetAll = _categoryService.GetAll();
            if (categoryGetAll.Success)
            {
                return Ok(categoryGetAll.Data);
            }
            return BadRequest(categoryGetAll);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var categoryGetAll = _categoryService.Get(id);
            if (categoryGetAll.Success)
            {
                return Ok(categoryGetAll);
            }
            return BadRequest(categoryGetAll.Message);
        }

    }
}
