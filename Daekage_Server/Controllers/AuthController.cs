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

        [HttpGet("{email}", Name = "GetTeacher")]
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
        public ActionResult<Teacher> Create([FromBody] Teacher teacher)
        {
            if(Get(teacher.Email).Value is null)
                _authService.Create(teacher);

            return CreatedAtRoute("GetTeacher", new { email = teacher.Email }, teacher);
        }

        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            if (Get(email).Value is null)
                return NotFound();

            _authService.Remove(email);

            return NoContent();
        }
    }
}
