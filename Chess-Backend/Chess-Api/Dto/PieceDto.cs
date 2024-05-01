using ChessLogic;
using ChessLogic.Pieces;

namespace Chess_Api.Dto;

public class PieceDto
{
    public Player Color { get; set; }
    public PieceType Type { get; set; }
    public Position Position { get; set; }
}