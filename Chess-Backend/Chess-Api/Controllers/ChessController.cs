using Chess_Api.Dto;
using ChessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Chess_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessController : ControllerBase
    {
        private readonly Game _game;

        public ChessController(Game game)
        {
            _game = game;
        }

        // GET api/chess
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(BoardDto))]
        public IActionResult GetBoard()
        {
            BoardDto boardDto = BoardDto.ConvertToDto(_game.Board);

            return Ok(boardDto);
        }

        // POST api/chess/move
        [HttpPost("move")]
        public IActionResult MakeMove([FromBody] Move move)
        {
            _game.MakeMove(move);
            return Ok();
        }
    }
}