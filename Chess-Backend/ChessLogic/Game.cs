using ChessLogic.Pieces;

namespace ChessLogic;

public class Game
{
    public Board Board { get; }
    public Player CurrentPlayer { get; private set; }

    public Game(Board board, Player currentPlayer)
    {
        Board = board;
        CurrentPlayer = currentPlayer;
        CurrentPlayer = Player.Black;
    }

    public List<Move> FindAllPossibleMovesFor(Position position)
    {
        if (Board.IsEmpty(position) || Board[position].Color != CurrentPlayer)
        {
            return new List<Move>();
        }

        Piece piece = Board[position];
        return piece.GetMoves(position, Board);
    }

    public List<Move> FindAllLegalMovesFor(Position position)
    {
        if (Board.IsEmpty(position) || Board[position].Color != CurrentPlayer)
        {
            return new List<Move>();
        }

        Piece piece = Board[position];
        List<Move> possibleMovies = piece.GetMoves(position, Board);
        return possibleMovies.Where(move => move.IsLegal(Board)).ToList();
    }

    public bool IsPlayerInCheck(Player player)
    {
        return Board.IsInCheck(player);
    }

    public bool IsPlayerInCheckMate(Player player)
    {
        return FindAllLegalMovesFor(player).Count == 0;
    }

    private List<Move> FindAllLegalMovesFor(Player player)
    {
        List<Move> possibleMoves = new List<Move>();

        foreach (var position in Board.GetPositionsWithPiecesOf(player))
        {
            Piece piece = Board[position];
            possibleMoves.AddRange(piece.GetMoves(position, Board));
        }

        List<Move> legalMoves = new List<Move>();

        foreach (var move in possibleMoves)
        {
            if (move.IsLegal(Board))
            {
                legalMoves.Add(move);
            }
        }

        return legalMoves;
    }


    public void MakeMove(Move move)
    {
        move.Execute(Board);
        CurrentPlayer = CurrentPlayer == Player.White ? Player.Black : Player.White;
    }
}