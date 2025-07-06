using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application;

namespace EndpointApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(AddUserDto dto)
        {
            _service.AddUser(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, EditUserDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID in route does not match ID in body");

            _service.EditUser(dto);
            return Ok();
        }
    }
}
