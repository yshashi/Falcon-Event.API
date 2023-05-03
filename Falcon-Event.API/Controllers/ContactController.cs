using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Falcon_Event.API.Data;
using Falcon_Event.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Falcon_Event.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            if (contact is null)
            {
                return BadRequest();
            }

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Status = 200,
                Message = "Contact Added!"
            });
            
        }
    }
}
