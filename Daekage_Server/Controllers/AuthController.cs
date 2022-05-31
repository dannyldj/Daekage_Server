using Microsoft.AspNetCore.Mvc;
using Daekage_Server.Models;
using Daekage_Server.Services;

namespace Daekage_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet(Name = "GetTeacher")]
        public ActionResult<Teacher> Get(string email)
        {
            var notice = _authService.Get(email);

            if (notice == null)
            {
                return NotFound();
            }

            return notice;
        }

        [HttpPost]
        public ActionResult<Teacher> Create(Teacher teacher)
        {
            _authService.Create(teacher);

            return CreatedAtRoute("GetTeacher", teacher);
        }
    }
}
