namespace ChessLogic.Pieces;

public class Bishop : Piece
{
    public override Player Color { get; }

    private readonly Direction[] _moveDirections =
    {
        Directions.NW,
        Directions.NE,
        Directions.SE,
        Directions.SW,
    };

    public Bishop(Player color)
    {
        Color = color;
    }

    public override List<Move> GetValidMoves(Position startPosition, Board board)
    {
        List<Position> validEndPositions = FindValidPositions(startPosition, board, _moveDirections);
        return validEndPositions
            .Select(
                endPosition => new Move(startPosition, endPosition))
            .ToList();
    }
}