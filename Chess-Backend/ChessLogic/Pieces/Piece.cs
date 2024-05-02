namespace ChessLogic.Pieces;

public abstract class Piece
{
    public abstract Player Color { get; }
    public abstract PieceType Type { get; }
    public abstract List<Move> GetMoves(Position startPosition, Board board);
    public bool HasBeenMoved { get; set; }

    protected List<Position> FindValidPositions(Position startPosition, Board board, Direction[] directions)
    {
        List<Position> validPositions = new List<Position>();
        foreach (Direction direction in directions)
        {
            for (Position currentPosition = startPosition + direction; board.IsInside(currentPosition); currentPosition += direction)
            {
                // if empty square then its a valid move
                if (board.IsEmpty(currentPosition))
                {
                    validPositions.Add(currentPosition);
                }
                else
                {
                    // if piece is an enemy then valid because it can be captures
                    Piece piece = board[currentPosition];
                    if (piece.Color != Color)
                    {
                        validPositions.Add(currentPosition);
                    }

                    // stop looking in that direction after finding a piece, either an enemy or a friend piece
                    break;
                }
            }
        }

        return validPositions;
    }

    public abstract override string ToString();


    public Piece DeepCopy()
    {
        return (Piece)MemberwiseClone();
    }
}