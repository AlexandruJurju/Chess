namespace ChessLogic.Pieces;

public class Pawn : IPiece
{
    public Player Color { get; }

    public Pawn(Player color)
    {
        Color = color;
    }
    
    
}