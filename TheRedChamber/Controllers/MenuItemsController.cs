using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TheRedChamber.Data;
using TheRedChamber.Data.Dto;
using TheRedChamber.Interfaces;
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
        private readonly IPhotoService _photoService;

        //initiating constructor
        public MenuItemsController(ApplicationDbContext context, IPhotoService photoService)
        {
            _context = context;
            _response = new ApiResponse(); //creating instance of ApiResponse
                                           //to use all it's fnuctionalities

            _photoService = photoService; //instance of photoservice
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

        [HttpGet("{id:int}", Name = "GetMenuItem")]
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

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateMenuItem([FromForm] MenuItemCreateDTO menuItemCreateDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imageResult = await _photoService.AddPhotoAsync(menuItemCreateDto.File);

                    if (menuItemCreateDto.File == null)
                    {
                        return BadRequest();
                    }

                    var menuItemToCreate = new MenuItem()
                    {
                        Name = menuItemCreateDto.Name,
                        Description = menuItemCreateDto.Description,
                        SpecialTag = menuItemCreateDto.SpecialTag,
                        Category = menuItemCreateDto.Category,
                        Price = menuItemCreateDto.Price,
                        Image = imageResult.Url.ToString(),
                    };

                    _context.MenuItems.Add(menuItemToCreate);
                    _context.SaveChanges();
                    _response.Result = menuItemToCreate;
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetMenuItem", new { id = menuItemToCreate.Id }, _response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>
                {
                    ex.Message
                };
            }

            return _response;
        }

    }
}
