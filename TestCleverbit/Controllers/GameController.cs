using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TestCleverbit.ApiModels;
using TestCleverbit.Domain.Services;
using TestCleverbit.Domain.Services.Contracts;

namespace TestCleverbit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("all-matches")]
        public async Task<IActionResult> GetAllMatchees()
        {
            var matches = await _gameService.GetAllMatches();
            return Ok(matches);
        }

        [HttpPost]
        [Authorize]
        [Route("play")]
        public async Task<IActionResult> Play([FromBody] int number)
        {
            var currentUser = GetCurrentUser();
            await _gameService.Play(number, currentUser);
            return Ok();
        }
    }
}