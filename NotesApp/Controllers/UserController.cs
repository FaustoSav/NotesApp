using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Data.Entities;
using NotesApp.Services.Interfaces;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("email")]
        public IActionResult GetUserByEmail([FromQuery] string email)
        {

           

                User? user = _userService.GetUserByEmail(email);

                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            
           

        }
    }
}
