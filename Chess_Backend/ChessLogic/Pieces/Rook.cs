namespace ChessLogic.Pieces;

public class Rook : IPiece
{
    public Player Color { get; }

    public Rook(Player color)
    {
        Color = color;
    }
}