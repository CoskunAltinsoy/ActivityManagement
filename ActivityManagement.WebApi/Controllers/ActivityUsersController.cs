using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Application.Security.Authorization;
using ActivityManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivityManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityUsersController : ControllerBase
    {
        private readonly IActivityUserService _activityUserService;
        public ActivityUsersController(IActivityUserService activityUserService)
        {
            _activityUserService = activityUserService;
        }

       // [AuthorizeRoles(Role.User)]
        [HttpPost]
        public IActionResult Add(ActivityUser activityUser)
        {
            var activityUserAdded = _activityUserService.Add(activityUser);
            if (activityUserAdded.Success)
            {
                return Ok(activityUserAdded.Message);
            }
            return BadRequest(activityUserAdded);
        }
    }
}
