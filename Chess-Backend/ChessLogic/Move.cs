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

    public void Execute(Board board)
    {
        Piece piece = board[StartPosition];
        board[EndPosition] = piece;
        board[StartPosition] = null!;
        piece.HasBeenMoved = true;
    }

    // Move is legal if after the player movies, the king of the player that executed the move is not in check
    // TODO: use a faster method 
    public bool IsLegal(Board board)
    {
        Player player = board[StartPosition].Color;
        Board boardCopy = board.DeepCopy();
        Execute(boardCopy);
        return !boardCopy.IsInCheck(player);
    }
}