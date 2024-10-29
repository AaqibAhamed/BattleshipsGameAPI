using BattleshipsGameAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipsGameAPI.Controllers
{
    [ApiController]
    [Route("api/battleshipgame")]
    public class BattleshipGameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IBoardRepository _boardRepository;

        public BattleshipGameController(IGameRepository gameRepository, IBoardRepository boardRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            _boardRepository = boardRepository ?? throw new ArgumentNullException(nameof(boardRepository));
        }

        [HttpGet]
        public IActionResult StartGame()
        {
            _gameRepository.Start();
            return Ok("Game Started!");
        }


        [HttpPost("shot")]
        public IActionResult Shoot([FromBody] string shot)
        {
            var (result, message) = _boardRepository.ProcessShot(shot);
            if (!result)
            {
                return BadRequest(message);
            }
            return Ok(message);
        }

        //[HttpGet("status")]
        //public IActionResult GetStatus()
        //{
        //    return Ok(_boardRepository.Display());
        //}



    }
}
