using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TheRedChamber.Data;
using TheRedChamber.Migrations;
using TheRedChamber.Model;

namespace TheRedChamber.Controllers
{
    [Route("api/MenuItems")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        //DI
        private readonly ApplicationDbContext _context;
        private readonly ApiResponse _response;

        //initiating constructor
        public MenuItemsController(ApplicationDbContext context)
        {
            _context = context;
            _response = new ApiResponse(); //creating instance of ApiResponse
                                           //to use all it's fnuctionalities
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            if (_context.MenuItems == null)
            {
                return NotFound();
            }

            var allMenuItems = await _context.MenuItems.ToListAsync();
            _response.Result = allMenuItems;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

    }
}
