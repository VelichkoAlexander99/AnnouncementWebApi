using Domain.Models.QueryParameters;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Incoming;
using WebApi.DTOs.Outgoing;
using WebApi.Services.UserService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users/
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] QueryUserParameters query)
        {
            return Ok(await _userService.GetAll(query));
        }

        // GET api/users/5
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var response = await _userService.GetById(id);

            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationOrUpdateDto userDto)
        {
            var response = await _userService.Create(userDto);

            if (response.Succeeded)
                return Ok(response);
            else 
                return BadRequest(response);
        }

        // PUT api/users/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForCreationOrUpdateDto userDto)
        {
            var response = await _userService.Update(id, userDto);

            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }

        // DELETE api/users/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var response = await _userService.Delete(id);

            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
