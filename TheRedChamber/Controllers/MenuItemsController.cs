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
        public async Task<IActionResult> GetMenuItem()
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

        [HttpGet("{id:int}")] 
        public async Task<IActionResult> GetMenuItem(int id)
        {
            //finding if the menuItems exist by Id
            var menuItemsById = await _context.MenuItems.FindAsync(id);

            //if notfound by id
            if (menuItemsById == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            //result
            _response.Result = menuItemsById;
            //status code
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

    }
}
