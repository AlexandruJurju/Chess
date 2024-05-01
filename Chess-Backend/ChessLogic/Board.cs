using System.Text;
using ChessLogic.Pieces;

namespace ChessLogic;

public class Board
{
    private Piece[,] Pieces { get; set; }

    public Board()
    {
        PlaceStartingPieces();
    }

    // setup indexer to access board like a 2d matrix
    public Piece this[int row, int col]
    {
        get => Pieces[row, col];
        set => Pieces[row, col] = value;
    }

    // indexer to use position object as an index to the matrix
    public Piece this[Position position]
    {
        get => this[position.Row, position.Column];
        set => Pieces[position.Row, position.Column] = value;
    }

    private void PlaceStartingPieces()
    {
        Pieces = new Piece[8, 8];
        this[0, 0] = new Rook(Player.Black);
        this[0, 1] = new Knight(Player.Black);
        this[0, 2] = new Bishop(Player.Black);
        this[0, 3] = new Queen(Player.Black);
        this[0, 4] = new King(Player.Black);
        this[0, 5] = new Bishop(Player.Black);
        this[0, 6] = new Knight(Player.Black);
        this[0, 7] = new Rook(Player.Black);

        // for (int i = 0; i < 8; i++)
        // {
        //     this[1, i] = new Pawn(Player.Black);
        // }

        this[7, 0] = new Rook(Player.White);
        this[7, 1] = new Knight(Player.White);
        this[7, 2] = new Bishop(Player.White);
        this[7, 3] = new Queen(Player.White);
        this[7, 4] = new King(Player.White);
        this[7, 5] = new Bishop(Player.White);
        this[7, 6] = new Knight(Player.White);
        this[7, 7] = new Rook(Player.White);

        // for (int i = 0; i < 8; i++)
        // {
        //     this[6, i] = new Pawn(Player.White);
        // }
    }

    private List<Position> FindAllPositionsWithPieces()
    {
        List<Position> positions = new List<Position>();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Position currentPosition = new Position(i, j);
                if (!IsEmpty(currentPosition))
                {
                    positions.Add(currentPosition);
                }
            }
        }

        return positions;
    }

    public List<Position> GetPositionsWithPiecesOf(Player player)
    {
        return FindAllPositionsWithPieces().Where(p => this[p].Color == player).ToList();
    }

    // TODO: check easier, find opponent king position and check if any piece can attack it
    public bool IsInCheck(Player player)
    {
        List<Position> positions = GetPositionsWithPiecesOf(PlayerHelper.Opponent(player));

        foreach (var position in positions)
        {
            Piece piece = this[position];
            if (CanPieceAttackKing(piece, position))
            {
                return true;
            }
        }

        return false;
    }

    private bool CanPieceAttackKing(Piece piece, Position position)
    {
        List<Move> validMoves = piece.GetMoves(position, this);

        foreach (var move in validMoves)
        {
            Piece targetPiece = this[move.EndPosition];
            // TODO Use a better way to check if piece is king
            if (targetPiece != null && targetPiece.ToString().ToLower().Equals("k"))
            {
                return true;
            }
        }

        return false;
    }

    public Board DeepCopy()
    {
        Board boardCopy = new Board();
        foreach (Position position in FindAllPositionsWithPieces())
        {
            boardCopy[position] = this[position].DeepCopy();
        }

        return boardCopy;
    }

    public bool IsInside(Position position)
    {
        return position.Row >= 0 && position.Row < 8 && position.Column >= 0 && position.Column < 8;
    }

    public bool IsEmpty(Position position)
    {
        return this[position] == null;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Piece piece = Pieces[i, j];
                sb.Append(piece != null ? piece.ToString() : " ");
                sb.Append(" ");
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}