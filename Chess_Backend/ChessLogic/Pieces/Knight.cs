namespace ChessLogic.Pieces;

public class Knight : Piece
{
    public override Player Color { get; }

    public Knight(Player color)
    {
        Color = color;
    }

    public override List<Move> GetValidMoves(Position startPosition, Board board)
    {
        List<Position> validJumpPositions = FindValidJumpPositions(startPosition, board);
        return validJumpPositions.Select(
                endPosition => new Move(startPosition, endPosition))
            .ToList();
    }

    private List<Position> FindValidJumpPositions(Position startPosition, Board board)
    {
        List<Position> endPositions = new List<Position>
        {
            startPosition + Directions.North + Directions.North + Directions.East,
            startPosition + Directions.North + Directions.North + Directions.West,
            startPosition + Directions.South + Directions.South + Directions.East,
            startPosition + Directions.South + Directions.South + Directions.West,
            startPosition + Directions.East + Directions.East + Directions.North,
            startPosition + Directions.East + Directions.East + Directions.South,
            startPosition + Directions.West + Directions.West + Directions.North,
            startPosition + Directions.West + Directions.West + Directions.South,
        };

        return endPositions
            .Where(position => board.IsInside(position) && (board.IsEmpty(position) || board[position].Color != Color))
            .ToList();
    }
}