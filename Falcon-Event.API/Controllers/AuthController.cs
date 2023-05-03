using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Falcon_Event.API.Data;
using Falcon_Event.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Falcon_Event.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginObj)
        {
            if (loginObj == null)
                return BadRequest(new { Message = "Form is empty" });

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == loginObj.Username && x.Password == loginObj.Password);

            if (user == null)
                return NotFound(new { message = "User Not Found!" });



            return Ok(new
            {
                Message="Login Success"
            });
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User registerDto)
        {
                if (registerDto is null)
                {
                    return BadRequest();
                }

                await _context.Users.AddAsync(registerDto);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    Status = 200,
                    Message = "User Added!"
                });
            
        }
    }
}
