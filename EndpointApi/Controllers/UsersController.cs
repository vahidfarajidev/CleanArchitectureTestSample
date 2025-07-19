using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application;

namespace EndpointApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Add(AddUserDto dto)
        {
            _userService.AddUser(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, EditUserDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID in route does not match ID in body");

            _userService.EditUser(dto);
            return Ok();
        }
    }
}
