namespace ChessLogic.Pieces;

public class King : IPiece
{
    public Player Color { get; }

    public King(Player color)
    {
        Color = color;
    }
}