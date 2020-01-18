using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestCleverbit.ApiModels;
using TestCleverbit.Domain.Services.Contracts;

namespace TestCleverbit.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserApiModel user)
        {
            return Ok(await _userService.Login(user.Email, user.Password));
        }
    }
}