using ChessLogic;

namespace Chess_Api.Dto;

public class GameDto
{
    public BoardDto BoardDto { get; set; }
    public Player Player { get; set; }
}