namespace ChessLogic.Pieces;

public class Rook : Piece
{
    public override Player Color { get; }
    public override PieceType Type => PieceType.Rook;

    private readonly Direction[] _directions =
    {
        Directions.North,
        Directions.South,
        Directions.East,
        Directions.West,
    };

    public Rook(Player color)
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

    public override string ToString()
    {
        return Color == Player.White ? "R" : "r";
    }
}