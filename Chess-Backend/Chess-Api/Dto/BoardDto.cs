using ChessLogic;
using ChessLogic.Pieces;

namespace Chess_Api.Dto;

public class BoardDto
{
    public PieceDto[] Pieces { get; set; }

    public static BoardDto ConvertToDto(Board board)
    {
        PieceDto[] piecesDto = new PieceDto[8 * 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Piece piece = board[i, j];
                if (piece != null)
                {
                    piecesDto[i * 8 + j] = new PieceDto
                    {
                        Color = piece.Color,
                        Type = piece.Type,
                        Position = new Position(i, j)
                    };
                }
            }
        }

        return new BoardDto { Pieces = piecesDto };
    }
}