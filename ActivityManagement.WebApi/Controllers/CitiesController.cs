using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Application.Security.Authorization;
using ActivityManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ActivityManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController:ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [AuthorizeRoles(Role.Admin)]
        [HttpPost]
        public IActionResult Add(City city)
        {
            var cityAdded = _cityService.Add(city);
            if (cityAdded.Success)
            {
                return Ok(cityAdded.Message);
            }
            return BadRequest(cityAdded);
        }

        [AuthorizeRoles(Role.Admin)]
        [HttpDelete]
        public IActionResult Delete(City city)
        {
            var cityDeleted = _cityService.Delete(city);
            if (cityDeleted.Success)
            {
                return Ok(cityDeleted.Message);
            }
            return BadRequest(cityDeleted);
        }

        [AuthorizeRoles(Role.Admin)]
        [HttpPut]
        public IActionResult Update(City city)
        {
            var cityUpdated = _cityService.Update(city);
            if (cityUpdated.Success)
            {
                return Ok(cityUpdated.Message);
            }
            return BadRequest(cityUpdated);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cityGetAll = _cityService.GetAll();
            if (cityGetAll.Success)
            {
                return Ok(cityGetAll.Data);
            }
            return BadRequest(cityGetAll);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cityGetAll = _cityService.Get(id);
            if (cityGetAll.Success)
            {
                return Ok(cityGetAll);
            }
            return BadRequest(cityGetAll.Message);
        }
    }
}
