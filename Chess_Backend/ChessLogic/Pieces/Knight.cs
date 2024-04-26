namespace ChessLogic.Pieces;

public class Knight : IPiece
{
    public Player Color { get; }

    public Knight(Player color)
    {
        Color = color;
    }
}