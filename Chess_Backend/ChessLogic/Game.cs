using ChessLogic.Pieces;

namespace ChessLogic;

public class Game
{
    public Board Board { get; }
    public Player CurrentPlayer { get; private set; }
    public bool IsGameOver => false;

    public Game(Board board, Player currentPlayer)
    {
        Board = board;
        CurrentPlayer = currentPlayer;
    }

    public List<Move> FindMovesForPiece(Position position)
    {
        if (Board.IsEmpty(position) || Board[position].Color != CurrentPlayer)
        {
            return new List<Move>();
        }

        Piece piece = Board[position];
        return piece.GetValidMoves(position, Board);
    }

    public void MakeMove(Move move)
    {
        move.Execute(Board);
        CurrentPlayer = CurrentPlayer == Player.White ? Player.Black : Player.White;
    }
}