using ChessLogic;

namespace Chess_Api.Dto;

public class BoardDto
{
    public PieceDto[] Pieces { get; set; }
    public Player Player { get; set; }
}