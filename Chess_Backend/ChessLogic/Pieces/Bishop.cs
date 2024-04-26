namespace ChessLogic.Pieces;

public class Bishop : IPiece
{
    public Player Color { get; }

    public Bishop(Player color)
    {
        Color = color;
    }
}