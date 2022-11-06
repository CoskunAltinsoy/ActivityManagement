using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Application.Security.Authorization;
using ActivityManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivityManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [AuthorizeRoles(Role.Organizer)]
        [HttpPost]
        public IActionResult Add(Activity activity)
        {
            var activityAdded = _activityService.Add(activity);
            if (activityAdded.Success)
            {
                return Ok(activityAdded.Message);
            }
            return BadRequest(activityAdded);
        }

        [AuthorizeRoles(Role.Organizer)]
        [HttpDelete]
        public IActionResult Delete(Activity activity)
        {
            var activityDeleted = _activityService.Delete(activity);
            if (activityDeleted.Success)
            {
                return Ok(activityDeleted.Message);
            }
            return BadRequest(activityDeleted);
        }

        [AuthorizeRoles(Role.Organizer)]
        [HttpPut]
        public IActionResult Update(Activity activity)
        {
            var activityUpdated = _activityService.Update(activity);
            if (activityUpdated.Success)
            {
                return Ok(activityUpdated.Message);
            }
            return BadRequest(activityUpdated);
        }

        [AuthorizeRoles(Role.User)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var activityGetAll = _activityService.GetAll();
            if (activityGetAll.Success)
            {
                return Ok(activityGetAll.Data);
            }
            return BadRequest(activityGetAll);
        }

        [AuthorizeRoles(Role.User)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var activityGetAll = _activityService.Get(id);
            if (activityGetAll.Success)
            {
                return Ok(activityGetAll);
            }
            return BadRequest(activityGetAll.Message);
        }
    }
}
