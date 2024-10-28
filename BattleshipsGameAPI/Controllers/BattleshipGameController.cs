using Microsoft.AspNetCore.Mvc;

namespace BattleshipsGameAPI.Controllers
{
    public class BattleshipGameController : ControllerBase
    {
        private static Game game;

        [HttpPost("start")]
        public IActionResult StartGame()
        {
            game = new Game();
            game.PlaceShips();
            return Ok("Game started!");
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(game.GetBoardStatus());
        }

        [HttpPost("shot")]
        public IActionResult Shoot([FromBody] string shot)
        {
            var result = game.ProcessShot(shot);
            if (!result.IsValid)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

      
    }
}
