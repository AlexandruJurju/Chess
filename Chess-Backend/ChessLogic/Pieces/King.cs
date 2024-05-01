namespace ChessLogic.Pieces;

public class King : Piece
{
    public override Player Color { get; }
    public override PieceType Type => PieceType.King;


    private readonly Direction[] _directions =
    {
        Directions.North,
        Directions.East,
        Directions.South,
        Directions.West,
        Directions.NorthEast,
        Directions.NorthWest,
        Directions.SouthEast,
        Directions.SouthWest,
    };

    public King(Player color)
    {
        Color = color;
    }

    public override List<Move> GetMoves(Position startPosition, Board board)
    {
        return FindEndPositions(startPosition, board)
            .Select(endPosition => new Move(startPosition, endPosition))
            .ToList();
    }

    private List<Position> FindEndPositions(Position startPosition, Board board)
    {
        List<Position> endPositions = new List<Position>();

        foreach (Direction direction in _directions)
        {
            Position endPosition = startPosition + direction;
            if (board.IsInside(endPosition) && (board.IsEmpty(endPosition) || board[endPosition].Color != Color))
            {
                endPositions.Add(endPosition);
            }
        }

        return endPositions;
    }

    public override string ToString()
    {
        return Color == Player.White ? "K" : "k";
    }
}