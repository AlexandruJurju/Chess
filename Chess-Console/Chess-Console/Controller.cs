using ChessLogic;

namespace Chess_Console;

public class Controller
{
    private Game Model { get; set; } = new(new Board().PlaceStartingPieces(), Player.White);
    private View View { get; set; } = new();

    public void Run()
    {
        while (!Model.IsPlayerInCheckMate(Model.CurrentPlayer))
        {
            View.PrintCurrentPlayer(Model);
            if (Model.Board.IsInCheck(Model.CurrentPlayer))
            {
                Console.WriteLine("CHECK");
            }

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
        possibleMoves = Model.FindAllLegalMovesFor(startPosition);

        while (possibleMoves.Count == 0)
        {
            View.DisplayMessage("No possible moves for this piece. Please choose another piece.");
            startPosition = View.ReadStartPosition();
            possibleMoves = Model.FindAllLegalMovesFor(startPosition);
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