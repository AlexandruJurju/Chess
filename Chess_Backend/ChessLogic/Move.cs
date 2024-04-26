using ChessLogic.Pieces;

namespace ChessLogic;

public class Move
{
    public Position StartPosition { get; }
    public Position EndPosition { get; }

    public Move(Position startPosition, Position endPosition)
    {
        StartPosition = startPosition;
        EndPosition = endPosition;
    }

    public void ExecuteMove(Board board)
    {
        Piece piece = board[StartPosition];
        board[EndPosition] = piece;
        board[StartPosition] = null;
    }
}