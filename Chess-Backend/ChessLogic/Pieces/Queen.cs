namespace ChessLogic.Pieces;

public class Queen : Piece
{
    public override Player Color { get; }
    public override PieceType Type => PieceType.Queen;


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

    public Queen(Player color)
    {
        Color = color;
    }

    public override List<Move> GetMoves(Position startPosition, Board board)
    {
        List<Position> validEndPositions = FindValidPositions(startPosition, board, _directions);
        return validEndPositions.Select(
                endPosition => new Move(startPosition, endPosition))
            .ToList();
    }
    
}