using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_pk.DTOs;
using kolokwium_pk.Models;
using kolokwium_pk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace kolokwium_pk.Controllers
{
    [ApiController]
    public class ActionsController : ControllerBase
    {

        MainDbContext _context;

        public ActionsController(MainDbContext context)
        {
            this._context = context;
        }

        [HttpPost("api/actions/{id}/fire-trucks")]
        public IActionResult GetFirefighters(int id, FiretruckActionRequestDTO request)
        {

            if (id != request.idAction)
            {
                return BadRequest("Action ID doesn't match");
            }

            try
            {
                var result = _context.GetService<IFiretruckActionsService>().AssignFiretruck(id, request.idFiretruck);

                if (result == null)
                {
                    return NotFound("Action or firetruck not found.");
                }

                return Ok(result);
            }
            catch (FirefightersException e)
            {
                return BadRequest(e.Message);
            };
        }
    }
}