namespace ChessLogic.Pieces;

public class Rook : Piece
{
    public override Player Color { get; }

    private readonly Direction[] _directions =
    {
        Directions.North,
        Directions.South,
        Directions.East,
        Directions.West,
    };

    public override List<Move> GetValidMoves(Position startPosition, Board board)
    {
        List<Position> validEndPositions = FindValidPositions(startPosition, board, _directions);
        return validEndPositions.Select(
                endPosition => new Move(startPosition, endPosition))
            .ToList();
    }

    public Rook(Player color)
    {
        Color = color;
    }
}