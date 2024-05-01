using Chess_Api.Dto;
using Chess_Api.Helper;
using ChessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Chess_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessController : ControllerBase
    {
        private readonly Game _game;
        private readonly BoardMapper _mapper;

        public ChessController(Game game, BoardMapper mapper)
        {
            _game = game;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GameDto))]
        public IActionResult GetBoard()
        {
            BoardDto boardDto = _mapper.ToDto(_game.Board);
            GameDto gameDto = new()
            {
                BoardDto = boardDto,
                Player = _game.CurrentPlayer
            };

            return Ok(gameDto);
        }

        [HttpPost("valid")]
        [ProducesResponseType(200, Type = typeof(List<Move>))]
        public IActionResult GetValidMoves([FromBody] Position position)
        {
            return Ok(_game.FindLegalMovesForPiece(position));
        }

        [HttpPost("move")]
        [ProducesResponseType(200, Type = typeof(GameDto))]
        public IActionResult MakeMove([FromBody] Move move)
        {
            _game.MakeMove(move);
            BoardDto boardDto = _mapper.ToDto(_game.Board);
            GameDto gameDto = new()
            {
                BoardDto = boardDto,
                // calculate check after the move, if CURRENT PLAYER is in check
                IsInCheck = _game.IsPlayerInCheck(_game.CurrentPlayer),
                Player = _game.CurrentPlayer
            };

            return Ok(gameDto);
        }
    }
}