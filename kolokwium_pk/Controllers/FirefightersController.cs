using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_pk.Models;
using kolokwium_pk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace kolokwium_pk.Controllers
{
    [ApiController]
    public class FirefightersController : ControllerBase
    {

        MainDbContext _context;

        public FirefightersController(MainDbContext context) {
            this._context = context;
        }

        [HttpGet("api/firefighter/{id}/actions")]
        public IActionResult GetFirefighters(int id)
        {
            try
            {
                var result = _context.GetService<IFirefighterActionsService>().GetActions(id);

                if (result == null)
                {
                    return NotFound("Firefighter not found.");
                }

                return Ok(result);
            }
            catch (FirefightersException e) { 
                return BadRequest(e.Message); 
            };
        }
    }
}