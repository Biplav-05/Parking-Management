using Application.UserService.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace ParkingApi.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _userService.GetAllUser();
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid Id)
        {
            var responses = await _userService.GetUserById(Id);
            return Ok(responses);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel model)
        {
            var response = await _userService.UpdateUser(model);
            return Ok(response);
        }
        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel model)
        {
            var response = await _userService.CreateUser(model);
            return Ok(response);
        }
    }
}
