namespace ChessLogic.Pieces;

public class Pawn : Piece
{
    public override Player Color { get; }
    public override PieceType Type => PieceType.Pawn;

    private readonly Direction _forward;

    public Pawn(Player color)
    {
        Color = color;
        _forward = color == Player.White ? Directions.North : Directions.South;
    }

    public override List<Move> GetMoves(Position startPosition, Board board)
    {
        List<Move> moves = new List<Move>();

        moves.AddRange(GenerateForwardMoves(startPosition, board));
        moves.AddRange(GenerateDiagonalMoves(startPosition, board));

        return moves;
    }

    private List<Move> GenerateDiagonalMoves(Position startPosition, Board board)
    {
        List<Move> validMoves = new List<Move>();

        Direction[] diagonalDirections = { Directions.East, Directions.West };

        foreach (var direction in diagonalDirections)
        {
            Position endPosition = startPosition + _forward + direction;
            if (CanCapture(board, endPosition))
            {
                validMoves.Add(new Move(startPosition, endPosition));
            }
        }

        return validMoves;
    }

    private List<Move> GenerateForwardMoves(Position startPosition, Board board)
    {
        List<Move> validMoves = new List<Move>();

        Position oneForward = startPosition + _forward;

        if (IsEmpty(board, oneForward))
        {
            validMoves.Add(new Move(startPosition, oneForward));

            if (!HasBeenMoved && IsEmpty(board, oneForward + _forward))
            {
                validMoves.Add(new Move(startPosition, oneForward + _forward));
            }
        }

        return validMoves;
    }

    private bool IsEmpty(Board board, Position position)
    {
        return board.IsInside(position) && (board.IsEmpty(position));
    }

    private bool CanCapture(Board board, Position position)
    {
        return board.IsInside(position) && (!board.IsEmpty(position) && board[position].Color != Color);
    }

    public override string ToString()
    {
        return Color == Player.White ? "P" : "p";
    }
}