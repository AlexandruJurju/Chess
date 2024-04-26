namespace ChessLogic.Pieces;

public class Queen : Piece
{
    public override Player Color { get; }

    private readonly Direction[] _directions =
    {
        Directions.North,
        Directions.East,
        Directions.South,
        Directions.West,
        Directions.NE,
        Directions.NW,
        Directions.SE,
        Directions.SW,
    };

    public Queen(Player color)
    {
        Color = color;
    }

    public override List<Move> GetValidMoves(Position startPosition, Board board)
    {
        List<Position> validEndPositions = FindValidPositions(startPosition, board, _directions);
        return validEndPositions.Select(
                endPosition => new Move(startPosition, endPosition))
            .ToList();
    }
}