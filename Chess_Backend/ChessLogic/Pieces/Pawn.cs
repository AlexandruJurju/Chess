namespace ChessLogic.Pieces;

public class Pawn : Piece
{
    public override Player Color { get; }
    private readonly Direction _forward;

    public Pawn(Player color)
    {
        Color = color;
        if (color == Player.White)
        {
            _forward = Directions.North;
        }
        else
        {
            _forward = Directions.South;
        }
    }

    public override List<Move> GetMoves(Position startPosition, Board board)
    {
        return GenerateForwardMoves(startPosition, board);
    }

    // TODO: add diagonal movies
    private List<Move> GenerateForwardMoves(Position startPosition, Board board)
    {
        List<Position> validEndPositions = new List<Position>();

        Position oneForward = startPosition + _forward;
        if (board.IsInside(oneForward) && (board.IsEmpty(oneForward) || board[oneForward].Color != Color))
        {
            validEndPositions.Add(oneForward);
        }

        // TODO: check if moved
        Position twoForward = oneForward + _forward;
        if (board.IsInside(twoForward) && (board.IsEmpty(twoForward) || board[twoForward].Color != Color))
        {
            validEndPositions.Add(twoForward);
        }

        return validEndPositions.Select(
                endPosition => new Move(startPosition, endPosition))
            .ToList();
    }
    
    public override string ToString()
    {
        return Color == Player.White ? "P" : "p";
    }
}