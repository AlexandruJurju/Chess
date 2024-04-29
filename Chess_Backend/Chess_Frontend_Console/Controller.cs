using ChessLogic;

namespace Chess_Frontend_Test;

public class Controller
{
    private Game Model { get; set; } = new(new Board().Initialize(), Player.White);
    private View View { get; set; } = new();

    public void Run()
    {
        while (!Model.IsGameOver)
        {
            View.PrintBoardWithIndexes(Model);

            var startPosition = GetStartPosition(out var possibleMoves);

            var endPosition = GetEndPosition(possibleMoves);

            Move move = new Move(startPosition, endPosition);
            Model.MakeMove(move);
        }
    }

    private Position GetStartPosition(out List<Move> possibleMoves)
    {
        Position startPosition = View.ReadStartPosition();
        possibleMoves = Model.FindMovesForPiece(startPosition);

        while (possibleMoves.Count == 0)
        {
            View.DisplayMessage("No possible moves for this piece. Please choose another piece.");
            startPosition = View.ReadStartPosition();
            possibleMoves = Model.FindMovesForPiece(startPosition);
        }

        View.PrintBoardWithPossibleMoves(Model, possibleMoves);
        return startPosition;
    }

    private Position GetEndPosition(List<Move> possibleMoves)
    {
        // View.PrintPossibleEndPositions(possibleMoves);
        Position endPosition = View.ReadEndPosition();
        while (!IsEndPositionValid(endPosition, possibleMoves))
        {
            View.DisplayMessage("Invalid end position. Please choose a valid end position");
            endPosition = View.ReadEndPosition();
        }

        return endPosition;
    }

    private bool IsEndPositionValid(Position endPosition, List<Move> possibleMoves)
    {
        return possibleMoves.Any(move => move.EndPosition.Equals(endPosition));
    }
}