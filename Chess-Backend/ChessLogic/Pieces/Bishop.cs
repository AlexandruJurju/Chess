namespace ChessLogic.Pieces;

public class Bishop : Piece
{
    public override Player Color { get; }
    public override PieceType Type => PieceType.Bishop;


    private readonly Direction[] _moveDirections =
    {
        Directions.NorthWest,
        Directions.NorthEast,
        Directions.SouthEast,
        Directions.SouthWest,
    };

    public Bishop(Player color)
    {
        Color = color;
    }

    public override List<Move> GetMoves(Position startPosition, Board board)
    {
        List<Position> validEndPositions = FindValidPositions(startPosition, board, _moveDirections);
        return validEndPositions
            .Select(
                endPosition => new Move(startPosition, endPosition))
            .ToList();
    }

    public override string ToString()
    {
        return Color == Player.White ? "B" : "b";
    }
}