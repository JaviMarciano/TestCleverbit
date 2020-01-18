using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestCleverbit.ApiModels;
using TestCleverbit.Domain.Services;
using TestCleverbit.Domain.Services.Contracts;

namespace TestCleverbit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
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
        public void Play([FromBody] int number)
        {
            var a= 10;
        }
    }
}