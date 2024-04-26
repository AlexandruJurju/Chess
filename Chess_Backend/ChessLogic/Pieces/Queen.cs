namespace ChessLogic.Pieces;

public class Queen : IPiece
{
    public Player Color { get; }

    public Queen(Player color)
    {
        Color = color;
    }
}