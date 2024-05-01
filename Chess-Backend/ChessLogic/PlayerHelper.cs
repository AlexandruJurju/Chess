namespace ChessLogic;

public static class PlayerHelper
{
    public static Player Opponent(Player player)
    {
        return player == Player.Black ? Player.White : Player.Black;
    }
}