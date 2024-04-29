using ChessLogic;

namespace Chess_Frontend_Test;

public class Controller
{
    private Game Model { get; set; } = new(new Board().Initialize(), Player.White);
    private View View { get; set; } = new();

    public void Start()
    {
        while (!Model.IsGameOver)
        {
            View.PrintBoardWithIndexes(Model);

            Position startPosition = View.ReadStartPosition();
            List<Move> possibleMoves = Model.FindMovesForPiece(startPosition);
            View.PrintPossibleMoves(possibleMoves);

            Position endPosition = View.ReadEndPosition();

            Move move = new Move(startPosition, endPosition);
            Model.MakeMove(move);
        }
    }
}