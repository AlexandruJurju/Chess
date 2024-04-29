namespace ChessLogic.Pieces;

public abstract class Piece
{
    public abstract Player Color { get; }
    public abstract List<Move> GetValidMoves(Position startPosition, Board board);

    protected List<Position> FindValidPositions(Position startPosition, Board board, Direction[] directions)
    {
        List<Position> validPositions = new List<Position>();
        foreach (Direction direction in directions)
        {
            for (Position currentPosition = startPosition + direction; board.IsInside(currentPosition); currentPosition += direction)
            {
                if (board.IsEmpty(currentPosition))
                {
                    validPositions.Add(currentPosition);
                }
                else
                {
                    Piece piece = board[currentPosition];
                    if (piece.Color != Color)
                    {
                        validPositions.Add(currentPosition);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        return validPositions;
    }

    public abstract override string ToString();
}